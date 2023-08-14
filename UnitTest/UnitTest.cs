using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using SchemeServe;
using SchemeServe.Controllers;


namespace UnitTest;


[TestClass]
public class OrganizationsControllerTests
{
     private Mock<HttpMessageHandler> _mockHttpMessageHandler;
     private OrganizationsController _controller;
     private HttpClient _httpClient;
     private Mock<OrganizationDbContext> _dbContextMock;
 

[TestInitialize]
public void Setup()
{
    _dbContextMock = new Mock<OrganizationDbContext>();
    _httpClient = new HttpClient();
    _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
    _controller = new OrganizationsController(_httpClient, _dbContextMock.Object);
}

    [TestMethod]
    public async Task GetRemoteData_ValidProviderId_ReturnsOrganization()
    {
        // Arrange
        var providerId = "1-1000388746";
        var targetOrg = new Organization
            { ProviderId = providerId, DateModified = DateTime.Now.ToString("yyyy-MM-dd") };

        var json = JsonConvert.SerializeObject(targetOrg);
        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };

        _mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(response);

        // Act
        var result = await _controller.GetRemoteData(providerId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(targetOrg.ProviderId, result.ProviderId);
        Assert.AreEqual(targetOrg.DateModified, result.DateModified);
    }


    [TestMethod]
    public async Task GetRemoteData_WrongProviderId_ThrowsException()
    {
        // Arrange
        var providerId = "wrongid";
        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.BadRequest,
            Content = new StringContent("Bad request", Encoding.UTF8, "application/json")
        };

        _mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(response);

        // Act & Assert
        await Assert.ThrowsExceptionAsync<Exception>(() => _controller.GetRemoteData(providerId));
    }
    

    [TestMethod]
    public async Task GetOrganization_ExistingOrganization_ReturnsContentResult()
    {
        // Arrange
        var providerId = "416";
        var existingOrg = new Organization
            { ProviderId = providerId, DateModified = DateTime.Now.ToString("yyyy-MM-dd") };
        _dbContextMock.Setup(mock => mock.Organizations.Find(providerId)).Returns(existingOrg);

        // Act
        var result = await _controller.GetOrganization(providerId);

        // Assert
        Assert.IsInstanceOfType(result, typeof(ContentResult));

        var contentResult = (ContentResult)result;
        Assert.AreEqual("application/json", contentResult.ContentType);
    }
}

using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SchemeServe.Controllers;


[ApiController]
[Microsoft.AspNetCore.Mvc.Route("Organizations")]
public class OrganizationsController : ControllerBase
{
    private readonly OrganizationDbContext dbContext;
    private readonly HttpClient httpClient;

    public OrganizationsController(HttpClient _httpClient, OrganizationDbContext _dbContext)
    {
        httpClient = _httpClient;
        dbContext = _dbContext;
    }
     
    [HttpGet]
    public string Get()
    {
        return "Use the following: Organizations/providerId to get information about a specific organization.";
    }

    [HttpGet("{providerId}")]
    public async Task<ActionResult> GetOrganization(string providerId)
    {
         
        Organization? org = dbContext.Organizations.Find(providerId);

        if (org == null)
        {
            try
            {
                org = await GetRemoteData(providerId);
                await AddOrganization(org);
                return await ShowOrganization(org);
            }

            catch
            {
                return Content("Wrong provider id.");
            }
        }

        else
        {
            DateTime dateModified = Utilities.StringToDate(org.DateModified);

            if (DateTime.Now.Subtract(dateModified).TotalDays <= 30)
            {
                // Get the current organization from the database
                return await ShowOrganization(org);
            }
            
            else {
                // Get a remote organization
                Organization remoteOrg = await GetRemoteData(providerId);
                await EditOrganization(org, remoteOrg);
                return await ShowOrganization(remoteOrg);
            }
        }
        
    }


    [NonAction]
    public async Task<ActionResult> ShowOrganization(Organization org)
    {
        var jsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            ContractResolver = new DefaultContractResolver { }
        };

        return Content(JsonConvert.SerializeObject(org, jsonSettings), "application/json");
    }

    
    [NonAction]
    public async Task<Organization> GetRemoteData(string providerId)
    {
        var url = $"https://api.cqc.org.uk/public/v1/providers/{providerId}";

        HttpResponseMessage response;
        
       // Singleton instead of using
       response = await httpClient.GetAsync(url);
       
       if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(json) || json.Contains("Bad request") || json.Contains("No Provider found") )
            {
                throw new Exception("Wrong provider ID.");
            }

            var org = JsonConvert.DeserializeObject<Organization>(json);
            org.DateModified = DateTime.Now.ToString("yyyy-MM-dd");
            
            return org;
        }
        
        throw new Exception("Failed to retrieve the remote data.");
    }
    
    
    [NonAction]
    public async Task AddOrganization(Organization org)
    {
        dbContext.Organizations.Add(org);
        await dbContext.SaveChangesAsync();
    }
    
    
    [NonAction]
    public async Task EditOrganization(Organization org, Organization remoteOrg)
    {
        dbContext.Entry(org).CurrentValues.SetValues(remoteOrg);
        await dbContext.SaveChangesAsync();
    }
    
}



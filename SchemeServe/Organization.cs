using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using SchemeServe.Controllers;


namespace SchemeServe;

[Table("Organizations")]
public class Organization
{
    public string ProviderId { get; set; }
    
    public string[] LocationIds
    {
        get
        {
            return LocationIdsString?.Split(',');
        }
        set
        {
            LocationIdsString = string.Join(",", value);
        }
    }
    
    [JsonIgnore]
    public string LocationIdsString { get; set; } = "Not given";

    public string OrganisationType { get; set; } = "Not given";

    public string OwnershipType { get; set; } = "Not given";

    public string Type { get; set; } = "Not given";

    public string Name { get; set; } = "Not given";

    public string BrandId { get; set; } = "Not given";

    public string BrandName { get; set; } = "Not given";

    public string RegistrationStatus { get; set; } = "Not given";

    public string RegistrationDate { get; set; } = "Not given";

    public string CompaniesHouseNumber { get; set; } = "Not given";

    public string CharityNumber { get; set; } = "Not given";

    public string Website { get; set; } = "Not given";

    public string PostalAddressLine1 { get; set; } = "Not given";

    public string PostalAddressLine2 { get; set; } = "Not given";

    public string PostalAddressTownCity { get; set; } = "Not given";

    public string PostalAddressCounty { get; set; } = "Not given";

    public string Region { get; set; } = "Not given";

    public string PostalCode { get; set; } = "Not given";
    
    public string Uprn { get; set; } = "Not given";
    
    public double OnspdLatitude { get; set; } = 0;
    
    public double OnspdLongitude { get; set; } = 0;
    
    public string MainPhoneNumber { get; set; } = "Not given";
    
    public string InspectionDirectorate { get; set; } = "Not given";
    
    public string Constituency { get; set; } = "Not given";
    
    public string LocalAuthority { get; set; } = "Not given";
    
    public string DateModified { get; set; }   = "Not given";
    
}





   


using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchemeServe;

using Microsoft.EntityFrameworkCore;

public class OrganizationDbContext : DbContext
{
    
    public OrganizationDbContext() { }
    
    public OrganizationDbContext(DbContextOptions<OrganizationDbContext> options) : base(options)
    {
      
    }
    
    public virtual DbSet<Organization> Organizations { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Organization>().Ignore(og => og.LocationIds);

        string defaultValue = "Not given";
        
        modelBuilder.Entity<Organization>(entity =>
    {
        entity.ToTable("Organizations");
        entity.HasKey(og => og.ProviderId);

        entity.Property(og => og.LocationIdsString)
            .HasColumnName("LocationIds");
        
        entity.Property(og => og.OrganisationType)
            .HasColumnName("OrganisationType")
            .HasDefaultValue(defaultValue);

        entity.Property(og => og.OwnershipType)
            .HasColumnName("OwnershipType")
            .HasDefaultValue(defaultValue);

        entity.Property(og => og.Type)
            .HasColumnName("Type")
            .HasDefaultValue(defaultValue);

        entity.Property(og => og.Name)
            .HasColumnName("Name")
            .HasDefaultValue(defaultValue);

        entity.Property(og => og.BrandId)
            .HasColumnName("BrandId")
            .HasDefaultValue(defaultValue);

        entity.Property(og => og.BrandName)
            .HasColumnName("BrandName")
            .HasDefaultValue(defaultValue);

        entity.Property(og => og.RegistrationStatus)
            .HasColumnName("RegistrationStatus")
            .HasDefaultValue(defaultValue);

        entity.Property(og => og.RegistrationDate)
            .HasColumnName("RegistrationDate")
            .HasDefaultValue(defaultValue);

        entity.Property(og => og.CompaniesHouseNumber)
            .HasColumnName("CompaniesHouseNumber")
            .HasDefaultValue(defaultValue);

        entity.Property(og => og.CharityNumber)
            .HasColumnName("CharityNumber")
            .HasDefaultValue(defaultValue);

        entity.Property(og => og.Website)
            .HasColumnName("Website")
            .HasDefaultValue(defaultValue);

        entity.Property(og => og.PostalAddressLine1)
            .HasColumnName("PostalAddressLine1")
            .HasDefaultValue(defaultValue);

        entity.Property(og => og.PostalAddressLine2)
            .HasColumnName("PostalAddressLine2")
            .HasDefaultValue(defaultValue);

        entity.Property(og => og.PostalAddressTownCity)
            .HasColumnName("PostalAddressTownCity")
            .HasDefaultValue(defaultValue);

        entity.Property(og => og.PostalAddressCounty)
            .HasColumnName("PostalAddressCounty")
            .HasDefaultValue(defaultValue);

        entity.Property(og => og.Region)
            .HasColumnName("Region")
            .HasDefaultValue(defaultValue);

        entity.Property(og => og.PostalCode)
            .HasColumnName("PostalCode")
            .HasDefaultValue(defaultValue);

        entity.Property(og => og.Uprn)
            .HasColumnName("Uprn")
            .HasDefaultValue(defaultValue);

        entity.Property(og => og.OnspdLatitude)
            .HasColumnName("OnspdLatitude")
            .HasDefaultValue(0);

        entity.Property(og => og.OnspdLongitude)
            .HasColumnName("OnspdLongitude")
            .HasDefaultValue(0);

        entity.Property(og => og.MainPhoneNumber)
            .HasColumnName("MainPhoneNumber")
            .HasDefaultValue(defaultValue);

        entity.Property(og => og.InspectionDirectorate)
            .HasColumnName("InspectionDirectorate")
            .HasDefaultValue(defaultValue);

        entity.Property(og => og.Constituency)
            .HasColumnName("Constituency")
            .HasDefaultValue(defaultValue);

        entity.Property(og => og.LocalAuthority)
            .HasColumnName("LocalAuthority")
            .HasDefaultValue(defaultValue);

        entity.Property(og => og.DateModified)
            .HasColumnName("DateModified")
            .HasDefaultValue(defaultValue);
    });
        
    }
    
}
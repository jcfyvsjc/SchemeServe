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
        entity.HasKey(e => e.ProviderId);

        entity.Property(e => e.LocationIdsString)
            .HasColumnName("LocationIds");
        
        entity.Property(e => e.OrganisationType)
            .HasColumnName("OrganisationType")
            .HasDefaultValue(defaultValue);

        entity.Property(e => e.OwnershipType)
            .HasColumnName("OwnershipType")
            .HasDefaultValue(defaultValue);

        entity.Property(e => e.Type)
            .HasColumnName("Type")
            .HasDefaultValue(defaultValue);

        entity.Property(e => e.Name)
            .HasColumnName("Name")
            .HasDefaultValue(defaultValue);

        entity.Property(e => e.BrandId)
            .HasColumnName("BrandId")
            .HasDefaultValue(defaultValue);

        entity.Property(e => e.BrandName)
            .HasColumnName("BrandName")
            .HasDefaultValue(defaultValue);

        entity.Property(e => e.RegistrationStatus)
            .HasColumnName("RegistrationStatus")
            .HasDefaultValue(defaultValue);

        entity.Property(e => e.RegistrationDate)
            .HasColumnName("RegistrationDate")
            .HasDefaultValue(defaultValue);

        entity.Property(e => e.CompaniesHouseNumber)
            .HasColumnName("CompaniesHouseNumber")
            .HasDefaultValue(defaultValue);

        entity.Property(e => e.CharityNumber)
            .HasColumnName("CharityNumber")
            .HasDefaultValue(defaultValue);

        entity.Property(e => e.Website)
            .HasColumnName("Website")
            .HasDefaultValue(defaultValue);

        entity.Property(e => e.PostalAddressLine1)
            .HasColumnName("PostalAddressLine1")
            .HasDefaultValue(defaultValue);

        entity.Property(e => e.PostalAddressLine2)
            .HasColumnName("PostalAddressLine2")
            .HasDefaultValue(defaultValue);

        entity.Property(e => e.PostalAddressTownCity)
            .HasColumnName("PostalAddressTownCity")
            .HasDefaultValue(defaultValue);

        entity.Property(e => e.PostalAddressCounty)
            .HasColumnName("PostalAddressCounty")
            .HasDefaultValue(defaultValue);

        entity.Property(e => e.Region)
            .HasColumnName("Region")
            .HasDefaultValue(defaultValue);

        entity.Property(e => e.PostalCode)
            .HasColumnName("PostalCode")
            .HasDefaultValue(defaultValue);

        entity.Property(e => e.Uprn)
            .HasColumnName("Uprn")
            .HasDefaultValue(defaultValue);

        entity.Property(e => e.OnspdLatitude)
            .HasColumnName("OnspdLatitude")
            .HasDefaultValue(0);

        entity.Property(e => e.OnspdLongitude)
            .HasColumnName("OnspdLongitude")
            .HasDefaultValue(0);

        entity.Property(e => e.MainPhoneNumber)
            .HasColumnName("MainPhoneNumber")
            .HasDefaultValue(defaultValue);

        entity.Property(e => e.InspectionDirectorate)
            .HasColumnName("InspectionDirectorate")
            .HasDefaultValue(defaultValue);

        entity.Property(e => e.Constituency)
            .HasColumnName("Constituency")
            .HasDefaultValue(defaultValue);

        entity.Property(e => e.LocalAuthority)
            .HasColumnName("LocalAuthority")
            .HasDefaultValue(defaultValue);

        entity.Property(e => e.DateModified)
            .HasColumnName("DateModified")
            .HasDefaultValue(defaultValue);
    });
        
    }
    
}
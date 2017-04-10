using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Repository.Entities.ConstantConnect.Map
{
    public class OrganizationConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Organization>
    {
        public OrganizationConfiguration()
            : this("dbo")
        {
        }

        public OrganizationConfiguration(string schema)
        {
            ToTable("Organization", schema);
            HasKey(x => x.OrganizationId);

            Property(x => x.OrganizationId).HasColumnName(@"OrganizationID").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.ParentId).HasColumnName(@"ParentID").HasColumnType("uniqueidentifier").IsOptional();
            Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar").IsRequired().HasMaxLength(255);
            Property(x => x.AddressLine1).HasColumnName(@"AddressLine1").HasColumnType("nvarchar").IsOptional().HasMaxLength(100);
            Property(x => x.AddressLine2).HasColumnName(@"AddressLine2").HasColumnType("nvarchar").IsOptional().HasMaxLength(100);
            Property(x => x.AddressLine3).HasColumnName(@"AddressLine3").HasColumnType("nvarchar").IsOptional().HasMaxLength(100);
            Property(x => x.City).HasColumnName(@"City").HasColumnType("nvarchar").IsOptional().HasMaxLength(100);
            Property(x => x.State).HasColumnName(@"State").HasColumnType("nvarchar").IsOptional().HasMaxLength(2);
            Property(x => x.Zip).HasColumnName(@"Zip").HasColumnType("nvarchar").IsOptional().HasMaxLength(12);
            Property(x => x.Country).HasColumnName(@"Country").HasColumnType("nvarchar").IsOptional().HasMaxLength(100);
            Property(x => x.TimeZone).HasColumnName(@"TimeZone").HasColumnType("nvarchar").IsOptional().HasMaxLength(100);
            Property(x => x.Status).HasColumnName(@"Status").HasColumnType("int").IsRequired();
            Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").HasColumnType("datetime").IsRequired();
            Property(x => x.ModifiedOn).HasColumnName(@"ModifiedOn").HasColumnType("datetime").IsOptional();
            Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("uniqueidentifier").IsRequired();
            Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("uniqueidentifier").IsOptional();
            Property(x => x.PartnerId).HasColumnName(@"PartnerID").HasColumnType("uniqueidentifier").IsOptional();

            // Foreign keys
            HasOptional(a => a.Organization_PartnerId).WithMany(b => b.Organizations_PartnerId).HasForeignKey(c => c.PartnerId).WillCascadeOnDelete(false); // FK_Organization_OrgPartner
            HasOptional(a => a.Parent).WithMany(b => b.Organizations_ParentId).HasForeignKey(c => c.ParentId).WillCascadeOnDelete(false); // FK_Organization_Organization
        }
    }
}

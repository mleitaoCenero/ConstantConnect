namespace ConstantConnect.Repository.Entities.ConstantConnect
{
    using System;
    using System.Collections.Generic;

    public class Organization
    {
        public System.Guid OrganizationId { get; set; } // OrganizationID (Primary key)
        public System.Guid? ParentId { get; set; } // ParentID
        public string Name { get; set; } // Name (length: 255)
        public string AddressLine1 { get; set; } // AddressLine1 (length: 100)
        public string AddressLine2 { get; set; } // AddressLine2 (length: 100)
        public string AddressLine3 { get; set; } // AddressLine3 (length: 100)
        public string City { get; set; } // City (length: 100)
        public string State { get; set; } // State (length: 2)
        public string Zip { get; set; } // Zip (length: 12)
        public string Country { get; set; } // Country (length: 100)
        public string TimeZone { get; set; } // TimeZone (length: 100)
        public int Status { get; set; } // Status
        public System.DateTime CreatedOn { get; set; } // CreatedOn
        public System.DateTime? ModifiedOn { get; set; } // ModifiedOn
        public System.Guid CreatedBy { get; set; } // CreatedBy
        public System.Guid? ModifiedBy { get; set; } // ModifiedBy
        public System.Guid? PartnerId { get; set; } // PartnerID

        // Reverse navigation
        //public virtual System.Collections.Generic.ICollection<AssociatedOrganization> AssociatedOrganizations { get; set; } // AssociatedOrganization.FK_AssociatedOrganization_Organization
        //public virtual System.Collections.Generic.ICollection<Brand> Brands { get; set; } // Brand.FK_Brand_Organization
        //public virtual System.Collections.Generic.ICollection<Contact> Contacts { get; set; } // Contact.FK_Contact_Organization
        public virtual System.Collections.Generic.ICollection<Organization> Organizations_ParentId { get; set; } // Organization.FK_Organization_Organization
        public virtual System.Collections.Generic.ICollection<Organization> Organizations_PartnerId { get; set; } // Organization.FK_Organization_OrgPartner
        //public virtual System.Collections.Generic.ICollection<Tenant> Tenants { get; set; } // Tenant.FK_Tenant_Organization

        // Foreign keys
        public virtual Organization Organization_PartnerId { get; set; } // FK_Organization_OrgPartner
        public virtual Organization Parent { get; set; } // FK_Organization_Organization

        public Organization()
        {
            //AssociatedOrganizations = new System.Collections.Generic.List<AssociatedOrganization>();
            //Brands = new System.Collections.Generic.List<Brand>();
            //Contacts = new System.Collections.Generic.List<Contact>();
            Organizations_ParentId = new System.Collections.Generic.List<Organization>();
            Organizations_PartnerId = new System.Collections.Generic.List<Organization>();
            //Tenants = new System.Collections.Generic.List<Tenant>();
        }
    }
}

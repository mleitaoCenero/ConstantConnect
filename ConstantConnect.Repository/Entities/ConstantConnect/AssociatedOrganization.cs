namespace ConstantConnect.Repository.Entities.ConstantConnect
{
    public class AssociatedOrganization
    {
        public long LineId { get; set; } // LineID (Primary key)
        public System.Guid UserId { get; set; } // UserID
        public System.Guid OrganizationId { get; set; } // OrganizationID
        public System.DateTime CreatedOn { get; set; } // CreatedOn

        // Foreign keys
        //public virtual Organization Organization { get; set; } // FK_AssociatedOrganization_Organization
        //public virtual UserAccount UserAccount { get; set; } // FK_AssociatedOrganization_User
    }
}
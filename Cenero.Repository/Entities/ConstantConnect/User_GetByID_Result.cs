namespace Cenero.Repository.Entities.ConstantConnect
{
    using System;
    
    public partial class User_GetByID_Result
    {
        public System.Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool PasswordMustChange { get; set; }
        public bool FirstLogIn { get; set; }
        public int AuralinkAccess { get; set; }
        public bool DashboardAccess { get; set; }
        public bool Dashboard_Admin { get; set; }
        public bool Dashboard_Financial { get; set; }
        public bool Dashboard_Super { get; set; }
        public bool RoomCheckAccess { get; set; }
        public bool RoomCheck_Technician { get; set; }
        public bool RoomCheck_Manager { get; set; }
        public bool RoomCheck_Admin { get; set; }
        public bool RoomCheck_Commissioning { get; set; }
        public int EventSchedulerAccess { get; set; }
        public int Status { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public System.Guid CreatedBy { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public System.Guid OrganizationID { get; set; }
        public Nullable<System.Guid> TenantID { get; set; }
        public string Tenant { get; set; }
        public string TenantPrefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Salutation { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
    }
}

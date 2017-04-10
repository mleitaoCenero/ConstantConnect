using Cenero.Repository.Entities.ConstantConnect;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenero.Repository.Entities.Contexts
{
    public partial class ConstantConnectContext : DbContext
    {
        public ConstantConnectContext()
            : base("name=ConstantConnectEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }


        public virtual ObjectResult<Nullable<System.Guid>> User_AddContact(Nullable<System.Guid> userID, Nullable<System.Guid> contactID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(System.Guid));

            var contactIDParameter = contactID.HasValue ?
                new ObjectParameter("ContactID", contactID) :
                new ObjectParameter("ContactID", typeof(System.Guid));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<System.Guid>>("User_AddContact", userIDParameter, contactIDParameter);
        }

        public virtual ObjectResult<User_Create_Result> User_Create(Nullable<System.Guid> editorID, string userName, string password, Nullable<System.Guid> organizationID, Nullable<System.Guid> tenantID, string firstName, string middleName, string lastName, string displayName, string salutation, string email, string email2)
        {
            var editorIDParameter = editorID.HasValue ?
                new ObjectParameter("EditorID", editorID) :
                new ObjectParameter("EditorID", typeof(System.Guid));

            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));

            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));

            var organizationIDParameter = organizationID.HasValue ?
                new ObjectParameter("OrganizationID", organizationID) :
                new ObjectParameter("OrganizationID", typeof(System.Guid));

            var tenantIDParameter = tenantID.HasValue ?
                new ObjectParameter("TenantID", tenantID) :
                new ObjectParameter("TenantID", typeof(System.Guid));

            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));

            var middleNameParameter = middleName != null ?
                new ObjectParameter("MiddleName", middleName) :
                new ObjectParameter("MiddleName", typeof(string));

            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));

            var displayNameParameter = displayName != null ?
                new ObjectParameter("DisplayName", displayName) :
                new ObjectParameter("DisplayName", typeof(string));

            var salutationParameter = salutation != null ?
                new ObjectParameter("Salutation", salutation) :
                new ObjectParameter("Salutation", typeof(string));

            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));

            var email2Parameter = email2 != null ?
                new ObjectParameter("Email2", email2) :
                new ObjectParameter("Email2", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User_Create_Result>("User_Create", editorIDParameter, userNameParameter, passwordParameter, organizationIDParameter, tenantIDParameter, firstNameParameter, middleNameParameter, lastNameParameter, displayNameParameter, salutationParameter, emailParameter, email2Parameter);
        }

        public virtual ObjectResult<User_Disable_Result> User_Disable(Nullable<System.Guid> userID, Nullable<System.Guid> editorID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(System.Guid));

            var editorIDParameter = editorID.HasValue ?
                new ObjectParameter("EditorID", editorID) :
                new ObjectParameter("EditorID", typeof(System.Guid));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User_Disable_Result>("User_Disable", userIDParameter, editorIDParameter);
        }

        public virtual ObjectResult<User_Get_Result> User_Get(string userName)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User_Get_Result>("User_Get", userNameParameter);
        }

        //public virtual ObjectResult<User_GetByID_Result> User_GetByID(Nullable<System.Guid> userID)
        public virtual User_GetByID_Result User_GetByID(Nullable<System.Guid> userID)
        {
            //var userIDParameter = userID.HasValue ?
            //    new ObjectParameter("UserID", userID) :
            //    new ObjectParameter("UserID", typeof(System.Guid));

            //return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User_GetByID_Result>("User_GetByID", userIDParameter);


            var userIDParameter = userID.HasValue ?
                new SqlParameter { ParameterName = "@UserID", Value = userID } :
                new SqlParameter { ParameterName = "@UserID", Value = typeof(System.Guid) };

            var result = this.Database.SqlQuery<User_GetByID_Result>("User_GetByID @UserID", userIDParameter).SingleOrDefault();
            return result;
        }

        public virtual ObjectResult<Nullable<System.Guid>> User_GetViewableOrganizations(Nullable<System.Guid> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(System.Guid));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<System.Guid>>("User_GetViewableOrganizations", userIDParameter);
        }

        public virtual int User_RemoveContact(Nullable<System.Guid> userID, Nullable<System.Guid> contactID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(System.Guid));

            var contactIDParameter = contactID.HasValue ?
                new ObjectParameter("ContactID", contactID) :
                new ObjectParameter("ContactID", typeof(System.Guid));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("User_RemoveContact", userIDParameter, contactIDParameter);
        }

        public virtual ObjectResult<User_SetEmail_Result> User_SetEmail(string userName, string password, string email, string email2)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));

            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));

            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));

            var email2Parameter = email2 != null ?
                new ObjectParameter("Email2", email2) :
                new ObjectParameter("Email2", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User_SetEmail_Result>("User_SetEmail", userNameParameter, passwordParameter, emailParameter, email2Parameter);
        }

        public virtual ObjectResult<User_SetPassword_Result> User_SetPassword(Nullable<System.Guid> userID, string userName, string oldPassword, string newPassword)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(System.Guid));

            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));

            var oldPasswordParameter = oldPassword != null ?
                new ObjectParameter("OldPassword", oldPassword) :
                new ObjectParameter("OldPassword", typeof(string));

            var newPasswordParameter = newPassword != null ?
                new ObjectParameter("NewPassword", newPassword) :
                new ObjectParameter("NewPassword", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User_SetPassword_Result>("User_SetPassword", userIDParameter, userNameParameter, oldPasswordParameter, newPasswordParameter);
        }

        public virtual ObjectResult<User_SetPermissions_Result> User_SetPermissions(Nullable<System.Guid> userID, Nullable<System.Guid> editorID, Nullable<int> auralinkAccess, Nullable<bool> dashboardAccess, Nullable<bool> dashboard_Admin, Nullable<bool> dashboard_Financial, Nullable<bool> dashboard_Super, Nullable<bool> roomCheckAccess, Nullable<bool> roomCheck_Technician, Nullable<bool> roomCheck_Manager, Nullable<bool> roomCheck_Admin, Nullable<bool> roomCheck_Commissioning, Nullable<int> eventSchedulerAccess)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(System.Guid));

            var editorIDParameter = editorID.HasValue ?
                new ObjectParameter("EditorID", editorID) :
                new ObjectParameter("EditorID", typeof(System.Guid));

            var auralinkAccessParameter = auralinkAccess.HasValue ?
                new ObjectParameter("AuralinkAccess", auralinkAccess) :
                new ObjectParameter("AuralinkAccess", typeof(int));

            var dashboardAccessParameter = dashboardAccess.HasValue ?
                new ObjectParameter("DashboardAccess", dashboardAccess) :
                new ObjectParameter("DashboardAccess", typeof(bool));

            var dashboard_AdminParameter = dashboard_Admin.HasValue ?
                new ObjectParameter("Dashboard_Admin", dashboard_Admin) :
                new ObjectParameter("Dashboard_Admin", typeof(bool));

            var dashboard_FinancialParameter = dashboard_Financial.HasValue ?
                new ObjectParameter("Dashboard_Financial", dashboard_Financial) :
                new ObjectParameter("Dashboard_Financial", typeof(bool));

            var dashboard_SuperParameter = dashboard_Super.HasValue ?
                new ObjectParameter("Dashboard_Super", dashboard_Super) :
                new ObjectParameter("Dashboard_Super", typeof(bool));

            var roomCheckAccessParameter = roomCheckAccess.HasValue ?
                new ObjectParameter("RoomCheckAccess", roomCheckAccess) :
                new ObjectParameter("RoomCheckAccess", typeof(bool));

            var roomCheck_TechnicianParameter = roomCheck_Technician.HasValue ?
                new ObjectParameter("RoomCheck_Technician", roomCheck_Technician) :
                new ObjectParameter("RoomCheck_Technician", typeof(bool));

            var roomCheck_ManagerParameter = roomCheck_Manager.HasValue ?
                new ObjectParameter("RoomCheck_Manager", roomCheck_Manager) :
                new ObjectParameter("RoomCheck_Manager", typeof(bool));

            var roomCheck_AdminParameter = roomCheck_Admin.HasValue ?
                new ObjectParameter("RoomCheck_Admin", roomCheck_Admin) :
                new ObjectParameter("RoomCheck_Admin", typeof(bool));

            var roomCheck_CommissioningParameter = roomCheck_Commissioning.HasValue ?
                new ObjectParameter("RoomCheck_Commissioning", roomCheck_Commissioning) :
                new ObjectParameter("RoomCheck_Commissioning", typeof(bool));

            var eventSchedulerAccessParameter = eventSchedulerAccess.HasValue ?
                new ObjectParameter("EventSchedulerAccess", eventSchedulerAccess) :
                new ObjectParameter("EventSchedulerAccess", typeof(int));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User_SetPermissions_Result>("User_SetPermissions", userIDParameter, editorIDParameter, auralinkAccessParameter, dashboardAccessParameter, dashboard_AdminParameter, dashboard_FinancialParameter, dashboard_SuperParameter, roomCheckAccessParameter, roomCheck_TechnicianParameter, roomCheck_ManagerParameter, roomCheck_AdminParameter, roomCheck_CommissioningParameter, eventSchedulerAccessParameter);
        }

        public virtual ObjectResult<User_Update_Result> User_Update(Nullable<System.Guid> userID, Nullable<System.Guid> editorID, string userName, Nullable<System.Guid> organizationID, Nullable<System.Guid> tenantID, string firstName, string middleName, string lastName, string displayName, string salutation, string email, string email2)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(System.Guid));

            var editorIDParameter = editorID.HasValue ?
                new ObjectParameter("EditorID", editorID) :
                new ObjectParameter("EditorID", typeof(System.Guid));

            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));

            var organizationIDParameter = organizationID.HasValue ?
                new ObjectParameter("OrganizationID", organizationID) :
                new ObjectParameter("OrganizationID", typeof(System.Guid));

            var tenantIDParameter = tenantID.HasValue ?
                new ObjectParameter("TenantID", tenantID) :
                new ObjectParameter("TenantID", typeof(System.Guid));

            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));

            var middleNameParameter = middleName != null ?
                new ObjectParameter("MiddleName", middleName) :
                new ObjectParameter("MiddleName", typeof(string));

            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));

            var displayNameParameter = displayName != null ?
                new ObjectParameter("DisplayName", displayName) :
                new ObjectParameter("DisplayName", typeof(string));

            var salutationParameter = salutation != null ?
                new ObjectParameter("Salutation", salutation) :
                new ObjectParameter("Salutation", typeof(string));

            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));

            var email2Parameter = email2 != null ?
                new ObjectParameter("Email2", email2) :
                new ObjectParameter("Email2", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User_Update_Result>("User_Update", userIDParameter, editorIDParameter, userNameParameter, organizationIDParameter, tenantIDParameter, firstNameParameter, middleNameParameter, lastNameParameter, displayNameParameter, salutationParameter, emailParameter, email2Parameter);
        }

        //public virtual ObjectResult<User_Validate_Result> User_Validate(string userName, string password)
        //{
        public virtual User_Validate_Result User_Validate(string userName, string password)
        { 
            //var userNameParameter = userName != null ?
            //    new ObjectParameter("UserName", userName) :
            //    new ObjectParameter("UserName", typeof(string));

        //var passwordParameter = password != null ?
        //    new ObjectParameter("Password", password) :
        //    new ObjectParameter("Password", typeof(string));

        //return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User_Validate_Result>("User_Validate", userNameParameter, passwordParameter);

            var userNameParameter = userName != null ?
                new SqlParameter { ParameterName = "@UserName", Value = userName } :
                new SqlParameter { ParameterName = "@UserName", Value = typeof(string) };

            var passwordParameter = userName != null ?
                new SqlParameter { ParameterName = "@Password", Value = password } :
                new SqlParameter { ParameterName = "@Password", Value = typeof(string) };

            var result = this.Database.SqlQuery<User_Validate_Result>("User_Validate @UserName, @Password", userNameParameter, passwordParameter).SingleOrDefault();
            return result;
        }


    }
}


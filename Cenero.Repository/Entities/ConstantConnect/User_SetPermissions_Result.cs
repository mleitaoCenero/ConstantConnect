namespace Cenero.Repository.Entities.ConstantConnect
{
    using System;
    
    public partial class User_SetPermissions_Result
    {
        public Nullable<System.Guid> UserID { get; set; }
        public Nullable<bool> HasError { get; set; }
        public Nullable<int> ErrorCode { get; set; }
        public string ErrorMsg { get; set; }
        public Nullable<int> ErrorLine { get; set; }
        public Nullable<bool> Updated { get; set; }
        public Nullable<bool> AuralinkUpdated { get; set; }
        public Nullable<bool> DashboardUpdated { get; set; }
        public Nullable<bool> RoomCheckUpdated { get; set; }
    }
}

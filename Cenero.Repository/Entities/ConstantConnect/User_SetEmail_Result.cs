namespace Cenero.Repository.Entities.ConstantConnect
{
    using System;
    
    public partial class User_SetEmail_Result
    {
        public System.Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public Nullable<bool> Updated { get; set; }
    }
}

namespace ConstantConnect.Repository.Entities.CRM
{
    using System;
    
    public partial class Document_Write_Result
    {
        public Nullable<System.Guid> DocumentID { get; set; }
        public Nullable<bool> HasError { get; set; }
        public Nullable<int> ErrorCode { get; set; }
        public string ErrorMsg { get; set; }
        public Nullable<int> ErrorLine { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    
    public partial class Equipment_ClientUpdate_Result
    {
        public Nullable<System.Guid> EquipmentID { get; set; }
        public string DeviceID { get; set; }
        public Nullable<bool> HasError { get; set; }
        public Nullable<int> ErrorCode { get; set; }
        public string ErrorMsg { get; set; }
        public Nullable<int> ErrorLine { get; set; }
        public Nullable<bool> Updated { get; set; }
    }
}

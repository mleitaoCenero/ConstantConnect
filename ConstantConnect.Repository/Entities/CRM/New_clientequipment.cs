namespace ConstantConnect.Repository.Entities.CRM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class New_clientequipment
    {
        public string createdbyyominame { get; set; }
        public string modifiedbyyominame { get; set; }
        public string createdonbehalfbyyominame { get; set; }
        public string modifiedonbehalfbyyominame { get; set; }
        public string CreatedOnBehalfByName { get; set; }
        public string New_EquipmentIdName { get; set; }
        public string New_LoanedByIdName { get; set; }
        public string ModifiedByName { get; set; }
        public string New_ClientRoomEquipmentIdName { get; set; }
        public string New_LoanedByIdYomiName { get; set; }
        public string OrganizationIdName { get; set; }
        public string new_ServiceEquipmentIdName { get; set; }
        public string New_EquipmentStatusIdName { get; set; }
        public string New_ValidatedByIdName { get; set; }
        public string New_ManufacturerIdName { get; set; }
        public string CreatedByName { get; set; }
        public string New_EquipmentOwnerIdName { get; set; }
        public string ModifiedOnBehalfByName { get; set; }
        public string New_EquipmentOwnerIdYomiName { get; set; }
        public string New_EquipmentFunctionIdName { get; set; }
        public string New_ValidatedByIdYomiName { get; set; }
        public System.Guid New_clientequipmentId { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public Nullable<System.Guid> OrganizationId { get; set; }
        public int statecode { get; set; }
        public Nullable<int> statuscode { get; set; }
        public byte[] VersionNumber { get; set; }
        public Nullable<int> ImportSequenceNumber { get; set; }
        public Nullable<System.DateTime> OverriddenCreatedOn { get; set; }
        public Nullable<int> TimeZoneRuleVersionNumber { get; set; }
        public Nullable<int> UTCConversionTimeZoneCode { get; set; }
        public string New_name { get; set; }
        public string New_Model { get; set; }
        public string New_ModelNumber { get; set; }
        public string New_SerialNumber { get; set; }
        public string New_EquipmentNotes { get; set; }
        public Nullable<System.Guid> New_ClientRoomEquipmentId { get; set; }
        public Nullable<System.Guid> New_ManufacturerId { get; set; }
        public Nullable<System.Guid> New_EquipmentStatusId { get; set; }
        public string New_LocationDescription { get; set; }
        public string New_ComponentDescription { get; set; }
        public string New_AssetTag { get; set; }
        public Nullable<System.DateTime> New_ValidationDate { get; set; }
        public Nullable<System.DateTime> New_AuditDate { get; set; }
        public string New_ComponentFunction { get; set; }
        public string New_ComponentDetails { get; set; }
        public string New_ComponentLocation { get; set; }
        public string New_MiscTag { get; set; }
        public string New_IPAddress { get; set; }
        public string New_NetworkInfo { get; set; }
        public string New_Barcode { get; set; }
        public string New_AssetID { get; set; }
        public string New_WCITTag { get; set; }
        public string New_EquipmentType { get; set; }
        public string New_PartNumber { get; set; }
        public string New_Firmware { get; set; }
        public Nullable<bool> New_Loanable { get; set; }
        public string New_ContactName { get; set; }
        public string New_ContactInfo { get; set; }
        public Nullable<System.Guid> New_ValidatedById { get; set; }
        public Nullable<System.Guid> New_LoanedById { get; set; }
        public string New_RMANumber { get; set; }
        public string New_HostName { get; set; }
        public string New_LoanContactName { get; set; }
        public string New_LoanContactInfo { get; set; }
        public string New_BENAssetNumber { get; set; }
        public Nullable<System.Guid> New_EquipmentId { get; set; }
        public Nullable<System.Guid> New_EquipmentFunctionId { get; set; }
        public string New_Subnet { get; set; }
        public string New_Gateway { get; set; }
        public string New_ServiceLocation { get; set; }
        public string New_DeviceAssigned { get; set; }
        public string New_PlateID { get; set; }
        public string New_PlateLocation { get; set; }
        public string New_PortType { get; set; }
        public string New_PortStatus { get; set; }
        public string New_PortSpeed { get; set; }
        public string New_ATCNumber { get; set; }
        public string New_ScreenResolution { get; set; }
        public Nullable<System.Guid> New_EquipmentOwnerId { get; set; }
        public Nullable<int> New_Quantity { get; set; }
        public Nullable<bool> New_CCCMonitored { get; set; }
        public string New_CCCDeviceID { get; set; }
        public Nullable<System.Guid> CreatedOnBehalfBy { get; set; }
        public Nullable<System.Guid> ModifiedOnBehalfBy { get; set; }
        public string new_CodeFileName { get; set; }
        public Nullable<System.DateTime> new_CodeCompileDate { get; set; }
        public string new_ConstantConnectVersion { get; set; }
        public Nullable<System.Guid> new_ServiceEquipmentId { get; set; }
        public Nullable<int> new_Lamp1HoursUsed { get; set; }
        public Nullable<int> new_Lamp1LifeEstimate { get; set; }
        public Nullable<int> new_Lamp1HoursRemaining { get; set; }
        public Nullable<int> new_Lamp2HoursUsed { get; set; }
        public Nullable<int> new_Lamp2LifeEstimate { get; set; }
        public Nullable<int> new_Lamp2HoursRemaining { get; set; }

        [ForeignKey("New_ClientRoomEquipmentId")]
        public virtual New_clientroom New_clientroom { get; set; }
    }
}

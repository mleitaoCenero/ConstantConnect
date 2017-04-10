namespace ConstantConnect.Repository.Entities.CRM
{
    using System;
    using System.Collections.Generic;

    public partial class New_clientequipmemtipdata
    {
        public string createdbyyominame { get; set; }
        public string modifiedbyyominame { get; set; }
        public string createdonbehalfbyyominame { get; set; }
        public string modifiedonbehalfbyyominame { get; set; }
        public string ModifiedByName { get; set; }
        public string New_ClientRoomIdName { get; set; }
        public string OrganizationIdName { get; set; }
        public string CreatedOnBehalfByName { get; set; }
        public string new_ClientEquipmentIdName { get; set; }
        public string New_ProjectIdName { get; set; }
        public string New_ProjectRoomIdName { get; set; }
        public string ModifiedOnBehalfByName { get; set; }
        public string CreatedByName { get; set; }
        public System.Guid New_clientequipmemtipdataId { get; set; }
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
        public string New_Hostname { get; set; }
        public string New_IPAddress { get; set; }
        public string New_Subnet { get; set; }
        public string New_Gateway { get; set; }
        public Nullable<System.Guid> New_ClientRoomId { get; set; }
        public string New_Band { get; set; }
        public string New_Frequency { get; set; }
        public string New_FQN { get; set; }
        public Nullable<System.Guid> New_ProjectId { get; set; }
        public Nullable<System.Guid> New_ProjectRoomId { get; set; }
        public Nullable<System.Guid> CreatedOnBehalfBy { get; set; }
        public Nullable<System.Guid> ModifiedOnBehalfBy { get; set; }
        public string new_FirmwareVersion { get; set; }
        public string new_Manufacturer { get; set; }
        public string new_ModelNumber { get; set; }
        public string new_Notes { get; set; }
        public Nullable<int> new_NetworkType { get; set; }
        public Nullable<bool> new_ConnectionType { get; set; }
        public Nullable<System.Guid> new_ClientEquipmentId { get; set; }
        public string new_SSID { get; set; }
        public string new_PSK { get; set; }
        public string new_Mask { get; set; }
        public string new_WirelessGateway { get; set; }
        public string new_IPID { get; set; }
        public string new_Username { get; set; }
        public string new_Password { get; set; }
        public string new_Gatekeeper { get; set; }
        public string new_OpenBatchFile { get; set; }
        public string new_WANAccessIPAddress { get; set; }
        public string new_LANAccessPort { get; set; }
        public string new_WANAccessPort { get; set; }
        public string new_DPS { get; set; }
        public string new_Encryption { get; set; }
        public string new_BusType { get; set; }
        public string new_BusID { get; set; }
        public string new_CresnetID { get; set; }
        public string new_MACAddress { get; set; }
        public string new_InternalIP { get; set; }
        public string new_Subnet_txt { get; set; }
        public string new_Gateway_txt { get; set; }
        public string new_ExternalIP { get; set; }
        public string new_Gatekeeper_txt { get; set; }
        public string new_WirelessGateway_txt { get; set; }

        public virtual New_clientroom New_clientroom { get; set; }
    }
}

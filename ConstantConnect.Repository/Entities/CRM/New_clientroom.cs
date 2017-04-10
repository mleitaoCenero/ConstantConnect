﻿namespace ConstantConnect.Repository.Entities.CRM
{
    using System;
    using System.Collections.Generic;

    public partial class New_clientroom
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public New_clientroom()
        {
            this.Incident = new List<Incident>();
            this.New_clientequipment = new List<New_clientequipment>();
            this.New_clientequipmemtipdata = new List<New_clientequipmemtipdata>();
        }

        public string createdbyyominame { get; set; }
        public string modifiedbyyominame { get; set; }
        public string createdonbehalfbyyominame { get; set; }
        public string modifiedonbehalfbyyominame { get; set; }
        public string new_CCCImplementorIdYomiName { get; set; }
        public string New_RoomOwnerIdName { get; set; }
        public string new_NotificationIdYomiName { get; set; }
        public string New_RoomOwnerIdYomiName { get; set; }
        public string new_RoomContactIdYomiName { get; set; }
        public string new_CCCImplementorIdName { get; set; }
        public string new_NotificationIdName { get; set; }
        public string new_RoomContactIdName { get; set; }
        public string new_ServiceSubcontractorIdYomiName { get; set; }
        public string new_ServiceLocationIdName { get; set; }
        public string ModifiedByName { get; set; }
        public string OrganizationIdName { get; set; }
        public string CreatedOnBehalfByName { get; set; }
        public string new_RoomAdminName { get; set; }
        public string new_CSRIdYomiName { get; set; }
        public string new_ISPIdName { get; set; }
        public string new_CCCPMIdName { get; set; }
        public string CreatedByName { get; set; }
        public string new_ServiceSubContactIdYomiName { get; set; }
        public string new_CCCPMIdYomiName { get; set; }
        public string new_ServiceSubcontractorIdName { get; set; }
        public string new_ServiceSubContactIdName { get; set; }
        public string new_RoomAdminYomiName { get; set; }
        public string new_CSRIdName { get; set; }
        public string ModifiedOnBehalfByName { get; set; }
        public System.Guid New_clientroomId { get; set; }
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
        public string New_RoomDescription { get; set; }
        public string New_RoomNotes { get; set; }
        public string New_MouseFrequency { get; set; }
        public string New_MicrophoneFrequency { get; set; }
        public string New_ComputerIP { get; set; }
        public string New_DVPHDIP { get; set; }
        public string New_ControllerIP { get; set; }
        public string New_ProjectorIP { get; set; }
        public string New_Subnet { get; set; }
        public string New_Gateway { get; set; }
        public string New_Projector2IP { get; set; }
        public string New_Projector3IP { get; set; }
        public Nullable<int> New_LocationType { get; set; }
        public Nullable<int> New_LocationSubType { get; set; }
        public string New_LocationCapacity { get; set; }
        public string New_LocationDescription { get; set; }
        public string New_LocationTypeT { get; set; }
        public string New_LocationSubTypeT { get; set; }
        public string New_Mic_Band { get; set; }
        public string New_Mic_1_Freq { get; set; }
        public string New_Mic_2_Freq { get; set; }
        public string New_Mic_3_Freq { get; set; }
        public string New_Mic_4_Freq { get; set; }
        public string New_Mic_5_Freq { get; set; }
        public string New_Mic_6_Freq { get; set; }
        public string New_RoomPhone { get; set; }
        public string New_RoomPhonePortID { get; set; }
        public Nullable<System.Guid> New_RoomOwnerId { get; set; }
        public Nullable<bool> New_Dashboard30 { get; set; }
        public Nullable<bool> New_RoomCheck { get; set; }
        public string New_SupportNumber { get; set; }
        public string New_RoomNumber { get; set; }
        public string New_RoomFloorNumber { get; set; }
        public Nullable<System.DateTime> New_TestedOn { get; set; }
        public Nullable<int> New_ServicePlan { get; set; }
        public Nullable<int> New_ServiceRoomType { get; set; }
        public string New_RoomViewName { get; set; }
        public Nullable<bool> New_ConstantConnect { get; set; }
        public Nullable<bool> New_ActiveinDashboard { get; set; }
        public Nullable<System.Guid> CreatedOnBehalfBy { get; set; }
        public Nullable<System.Guid> ModifiedOnBehalfBy { get; set; }
        public Nullable<System.Guid> new_RoomContactId { get; set; }
        public Nullable<int> new_RoomCombine { get; set; }
        public string new_WebPagesVPN { get; set; }
        public string new_SupportTabletIP { get; set; }
        public string new_TouchPanelIP { get; set; }
        public Nullable<System.DateTime> new_TabletPulse { get; set; }
        public string new_ProcessorType { get; set; }
        public Nullable<System.DateTime> new_CompileDate { get; set; }
        public string new_ProgramFileName { get; set; }
        public string new_VTCIP { get; set; }
        public string new_ATCNumber { get; set; }
        public string new_SwitcherIP { get; set; }
        public string new_RoomSwitchIP { get; set; }
        public string new_OpenBatchFile { get; set; }
        public string new_DialOutsideLine { get; set; }
        public string new_SystemNotes { get; set; }
        public string new_RouterIP { get; set; }
        public string new_SiteModemIP { get; set; }
        public string new_RouterUserName { get; set; }
        public string new_RouterPassword { get; set; }
        public string new_ISP { get; set; }
        public string new_ISPPlan_SpeedName { get; set; }
        public string new_ISPAccountNumber { get; set; }
        public string new_SiteCircuitID { get; set; }
        public string new_SiteGateway { get; set; }
        public string new_SiteSubnet { get; set; }
        public Nullable<System.Guid> new_CCCPMId { get; set; }
        public Nullable<System.Guid> new_CCCImplementorId { get; set; }
        public Nullable<int> new_Status { get; set; }
        public Nullable<int> new_CCCTabletRequired { get; set; }
        public string new_StatusNotes { get; set; }
        public Nullable<System.DateTime> new_GoLiveActualDate { get; set; }
        public Nullable<System.DateTime> new_OffLineStartDate { get; set; }
        public Nullable<System.DateTime> new_OffLineEndDate { get; set; }
        public Nullable<int> new_DataConnectionType { get; set; }
        public string new_DataConnectionTypeOther { get; set; }
        public Nullable<int> new_Carrier { get; set; }
        public string new_CarrierOther { get; set; }
        public string new_TabletName { get; set; }
        public string new_TabletPassword { get; set; }
        public string new_LogMeInUser { get; set; }
        public string new_LogMeInPassword { get; set; }
        public string new_TetherCode { get; set; }
        public string new_ControlCodeRevision { get; set; }
        public string new_AudioCODECFirmware { get; set; }
        public string new_ControlFirmwareVersion { get; set; }
        public string new_VTCFirmwareVersion { get; set; }
        public string new_SwitcherFirmwareVersion { get; set; }
        public Nullable<double> new_LampHoursUsed { get; set; }
        public Nullable<double> new_LampLifeEstimate { get; set; }
        public Nullable<double> new_LampHoursEstimate { get; set; }
        public Nullable<double> new_Lamp2HoursUsed { get; set; }
        public Nullable<double> new_Lamp2LifeEstimate { get; set; }
        public Nullable<double> new_Lamp2HoursEstimate { get; set; }
        public Nullable<bool> new_CeneroChangesOnly { get; set; }
        public string new_CCVersion { get; set; }
        public Nullable<System.Guid> new_NotificationId { get; set; }
        public Nullable<System.Guid> new_ServiceSubcontractorId { get; set; }
        public Nullable<System.Guid> new_ServiceSubContactId { get; set; }
        public string new_TouchpanelWebPage { get; set; }
        public Nullable<System.DateTime> new_GoLiveTargetDate { get; set; }
        public string new_GPProjectNo { get; set; }
        public Nullable<System.Guid> new_ServiceLocationId { get; set; }
        public Nullable<System.Guid> new_ISPId { get; set; }
        public Nullable<bool> new_ReviewComplete { get; set; }
        public string new_TouchPanelExternalWebPage { get; set; }
        public Nullable<System.Guid> new_CSRId { get; set; }
        public string new_EventSchedulerRoomEmail { get; set; }
        public string new_CCModules { get; set; }
        public string new_EventSchedulerRoomName { get; set; }
        public Nullable<System.Guid> new_RoomAdmin { get; set; }
        public string new_ServiceBillingNotes { get; set; }
        public Nullable<bool> new_TouchPanelSurvey { get; set; }
        public string new_DisplayName { get; set; }
        public string new_City { get; set; }
        public string new_State { get; set; }
        public Nullable<System.DateTime> new_VPNConnectionRequestDate { get; set; }

        public virtual List<Incident> Incident { get; set; }
        public virtual List<New_clientequipment> New_clientequipment { get; set; }
        public virtual List<New_clientequipmemtipdata> New_clientequipmemtipdata { get; set; }
    }
}

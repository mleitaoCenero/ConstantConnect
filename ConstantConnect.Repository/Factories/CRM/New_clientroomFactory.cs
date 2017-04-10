using ConstantConnect.Repository.Entities.CRM;
using ConstantConnect.Repository.Helpers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Repository.Factories.CRM
{
    public class New_clientroomFactory
    {
        IncidentFactory incidentFactory = new IncidentFactory();
        New_clientequipmemtipdataFactory new_clientequipmemtipdataFactory = new New_clientequipmemtipdataFactory();
        New_clientequipmentFactory new_clientequipmentFactory = new New_clientequipmentFactory();
        public New_clientroomFactory()
        {

        }

        public DTO.CRM.New_clientroom CreateNew_clientroom(New_clientroom entity)
        {
            return new DTO.CRM.New_clientroom()
            {
                createdbyyominame = entity.createdbyyominame,
                modifiedbyyominame = entity.modifiedbyyominame,
                createdonbehalfbyyominame = entity.createdonbehalfbyyominame,
                modifiedonbehalfbyyominame = entity.modifiedonbehalfbyyominame,
                new_CCCImplementorIdYomiName = entity.new_CCCImplementorIdYomiName,
                New_RoomOwnerIdName = entity.New_RoomOwnerIdName,
                new_NotificationIdYomiName = entity.new_NotificationIdYomiName,
                New_RoomOwnerIdYomiName = entity.New_RoomOwnerIdYomiName,
                new_RoomContactIdYomiName = entity.new_RoomContactIdYomiName,
                new_CCCImplementorIdName = entity.new_CCCImplementorIdName,
                new_NotificationIdName = entity.new_NotificationIdName,
                new_RoomContactIdName = entity.new_RoomContactIdName,
                new_ServiceSubcontractorIdYomiName = entity.new_ServiceSubcontractorIdYomiName,
                new_ServiceLocationIdName = entity.new_ServiceLocationIdName,
                ModifiedByName = entity.ModifiedByName,
                OrganizationIdName = entity.OrganizationIdName,
                CreatedOnBehalfByName = entity.CreatedOnBehalfByName,
                new_RoomAdminName = entity.new_RoomAdminName,
                new_CSRIdYomiName = entity.new_CSRIdYomiName,
                new_ISPIdName = entity.new_ISPIdName,
                new_CCCPMIdName = entity.new_CCCPMIdName,
                CreatedByName = entity.CreatedByName,
                new_ServiceSubContactIdYomiName = entity.new_ServiceSubContactIdYomiName,
                new_CCCPMIdYomiName = entity.new_CCCPMIdYomiName,
                new_ServiceSubcontractorIdName = entity.new_ServiceSubcontractorIdName,
                new_ServiceSubContactIdName = entity.new_ServiceSubContactIdName,
                new_RoomAdminYomiName = entity.new_RoomAdminYomiName,
                new_CSRIdName = entity.new_CSRIdName,
                ModifiedOnBehalfByName = entity.ModifiedOnBehalfByName,
                New_clientroomId = entity.New_clientroomId,
                CreatedOn = entity.CreatedOn,
                CreatedBy = entity.CreatedBy,
                ModifiedOn = entity.ModifiedOn,
                ModifiedBy = entity.ModifiedBy,
                OrganizationId = entity.OrganizationId,
                statecode = entity.statecode,
                statuscode = entity.statuscode,
                VersionNumber = entity.VersionNumber,
                ImportSequenceNumber = entity.ImportSequenceNumber,
                OverriddenCreatedOn = entity.OverriddenCreatedOn,
                TimeZoneRuleVersionNumber = entity.TimeZoneRuleVersionNumber,
                UTCConversionTimeZoneCode = entity.UTCConversionTimeZoneCode,
                New_name = entity.New_name,
                New_RoomDescription = entity.New_RoomDescription,
                New_RoomNotes = entity.New_RoomNotes,
                New_MouseFrequency = entity.New_MouseFrequency,
                New_MicrophoneFrequency = entity.New_MicrophoneFrequency,
                New_ComputerIP = entity.New_ComputerIP,
                New_DVPHDIP = entity.New_DVPHDIP,
                New_ControllerIP = entity.New_ControllerIP,
                New_ProjectorIP = entity.New_ProjectorIP,
                New_Subnet = entity.New_Subnet,
                New_Gateway = entity.New_Gateway,
                New_Projector2IP = entity.New_Projector2IP,
                New_Projector3IP = entity.New_Projector3IP,
                New_LocationType = entity.New_LocationType,
                New_LocationSubType = entity.New_LocationSubType,
                New_LocationCapacity = entity.New_LocationCapacity,
                New_LocationDescription = entity.New_LocationDescription,
                New_LocationTypeT = entity.New_LocationTypeT,
                New_LocationSubTypeT = entity.New_LocationSubTypeT,
                New_Mic_Band = entity.New_Mic_Band,
                New_Mic_1_Freq = entity.New_Mic_1_Freq,
                New_Mic_2_Freq = entity.New_Mic_2_Freq,
                New_Mic_3_Freq = entity.New_Mic_3_Freq,
                New_Mic_4_Freq = entity.New_Mic_4_Freq,
                New_Mic_5_Freq = entity.New_Mic_5_Freq,
                New_Mic_6_Freq = entity.New_Mic_6_Freq,
                New_RoomPhone = entity.New_RoomPhone,
                New_RoomPhonePortID = entity.New_RoomPhonePortID,
                New_RoomOwnerId = entity.New_RoomOwnerId,
                New_Dashboard30 = entity.New_Dashboard30,
                New_RoomCheck = entity.New_RoomCheck,
                New_SupportNumber = entity.New_SupportNumber,
                New_RoomNumber = entity.New_RoomNumber,
                New_RoomFloorNumber = entity.New_RoomFloorNumber,
                New_TestedOn = entity.New_TestedOn,
                New_ServicePlan = entity.New_ServicePlan,
                New_ServiceRoomType = entity.New_ServiceRoomType,
                New_RoomViewName = entity.New_RoomViewName,
                New_ConstantConnect = entity.New_ConstantConnect,
                New_ActiveinDashboard = entity.New_ActiveinDashboard,
                CreatedOnBehalfBy = entity.CreatedOnBehalfBy,
                ModifiedOnBehalfBy = entity.ModifiedOnBehalfBy,
                new_RoomContactId = entity.new_RoomContactId,
                new_RoomCombine = entity.new_RoomCombine,
                new_WebPagesVPN = entity.new_WebPagesVPN,
                new_SupportTabletIP = entity.new_SupportTabletIP,
                new_TouchPanelIP = entity.new_TouchPanelIP,
                new_TabletPulse = entity.new_TabletPulse,
                new_ProcessorType = entity.new_ProcessorType,
                new_CompileDate = entity.new_CompileDate,
                new_ProgramFileName = entity.new_ProgramFileName,
                new_VTCIP = entity.new_VTCIP,
                new_ATCNumber = entity.new_ATCNumber,
                new_SwitcherIP = entity.new_SwitcherIP,
                new_RoomSwitchIP = entity.new_RoomSwitchIP,
                new_OpenBatchFile = entity.new_OpenBatchFile,
                new_DialOutsideLine = entity.new_DialOutsideLine,
                new_SystemNotes = entity.new_SystemNotes,
                new_RouterIP = entity.new_RouterIP,
                new_SiteModemIP = entity.new_SiteModemIP,
                new_RouterUserName = entity.new_RouterUserName,
                new_RouterPassword = entity.new_RouterPassword,
                new_ISP = entity.new_ISP,
                new_ISPPlan_SpeedName = entity.new_ISPPlan_SpeedName,
                new_ISPAccountNumber = entity.new_ISPAccountNumber,
                new_SiteCircuitID = entity.new_SiteCircuitID,
                new_SiteGateway = entity.new_SiteGateway,
                new_SiteSubnet = entity.new_SiteSubnet,
                new_CCCPMId = entity.new_CCCPMId,
                new_CCCImplementorId = entity.new_CCCImplementorId,
                new_Status = entity.new_Status,
                new_CCCTabletRequired = entity.new_CCCTabletRequired,
                new_StatusNotes = entity.new_StatusNotes,
                new_GoLiveActualDate = entity.new_GoLiveActualDate,
                new_OffLineStartDate = entity.new_OffLineStartDate,
                new_OffLineEndDate = entity.new_OffLineEndDate,
                new_DataConnectionType = entity.new_DataConnectionType,
                new_DataConnectionTypeOther = entity.new_DataConnectionTypeOther,
                new_Carrier = entity.new_Carrier,
                new_CarrierOther = entity.new_CarrierOther,
                new_TabletName = entity.new_TabletName,
                new_TabletPassword = entity.new_TabletPassword,
                new_LogMeInUser = entity.new_LogMeInUser,
                new_LogMeInPassword = entity.new_LogMeInPassword,
                new_TetherCode = entity.new_TetherCode,
                new_ControlCodeRevision = entity.new_ControlCodeRevision,
                new_AudioCODECFirmware = entity.new_AudioCODECFirmware,
                new_ControlFirmwareVersion = entity.new_ControlFirmwareVersion,
                new_VTCFirmwareVersion = entity.new_VTCFirmwareVersion,
                new_SwitcherFirmwareVersion = entity.new_SwitcherFirmwareVersion,
                new_LampHoursUsed = entity.new_LampHoursUsed,
                new_LampLifeEstimate = entity.new_LampLifeEstimate,
                new_LampHoursEstimate = entity.new_LampHoursEstimate,
                new_Lamp2HoursUsed = entity.new_Lamp2HoursUsed,
                new_Lamp2LifeEstimate = entity.new_Lamp2LifeEstimate,
                new_Lamp2HoursEstimate = entity.new_Lamp2HoursEstimate,
                new_CeneroChangesOnly = entity.new_CeneroChangesOnly,
                new_CCVersion = entity.new_CCVersion,
                new_NotificationId = entity.new_NotificationId,
                new_ServiceSubcontractorId = entity.new_ServiceSubcontractorId,
                new_ServiceSubContactId = entity.new_ServiceSubContactId,
                new_TouchpanelWebPage = entity.new_TouchpanelWebPage,
                new_GoLiveTargetDate = entity.new_GoLiveTargetDate,
                new_GPProjectNo = entity.new_GPProjectNo,
                new_ServiceLocationId = entity.new_ServiceLocationId,
                new_ISPId = entity.new_ISPId,
                new_ReviewComplete = entity.new_ReviewComplete,
                new_TouchPanelExternalWebPage = entity.new_TouchPanelExternalWebPage,
                new_CSRId = entity.new_CSRId,
                new_EventSchedulerRoomEmail = entity.new_EventSchedulerRoomEmail,
                new_CCModules = entity.new_CCModules,
                new_EventSchedulerRoomName = entity.new_EventSchedulerRoomName,
                new_RoomAdmin = entity.new_RoomAdmin,
                new_ServiceBillingNotes = entity.new_ServiceBillingNotes,
                new_TouchPanelSurvey = entity.new_TouchPanelSurvey,
                new_DisplayName = entity.new_DisplayName,
                new_City = entity.new_City,
                new_State = entity.new_State,
                new_VPNConnectionRequestDate = entity.new_VPNConnectionRequestDate,

                Incident = entity.Incident.Select(e => incidentFactory.CreateIncident(e)).ToList(),
                New_clientequipment = entity.New_clientequipment.Select(e => new_clientequipmentFactory.CreateNew_clientequipment(e)).ToList(),
                New_clientequipmemtipdata = entity.New_clientequipmemtipdata.Select(e=> new_clientequipmemtipdataFactory.CreateNew_clientequipmemtipdata(e)).ToList()
                
            };
        }

        public New_clientroom CreateNew_clientroom(DTO.CRM.New_clientroom entity)
        {
            return new New_clientroom()
            {
                createdbyyominame = entity.createdbyyominame,
                modifiedbyyominame = entity.modifiedbyyominame,
                createdonbehalfbyyominame = entity.createdonbehalfbyyominame,
                modifiedonbehalfbyyominame = entity.modifiedonbehalfbyyominame,
                new_CCCImplementorIdYomiName = entity.new_CCCImplementorIdYomiName,
                New_RoomOwnerIdName = entity.New_RoomOwnerIdName,
                new_NotificationIdYomiName = entity.new_NotificationIdYomiName,
                New_RoomOwnerIdYomiName = entity.New_RoomOwnerIdYomiName,
                new_RoomContactIdYomiName = entity.new_RoomContactIdYomiName,
                new_CCCImplementorIdName = entity.new_CCCImplementorIdName,
                new_NotificationIdName = entity.new_NotificationIdName,
                new_RoomContactIdName = entity.new_RoomContactIdName,
                new_ServiceSubcontractorIdYomiName = entity.new_ServiceSubcontractorIdYomiName,
                new_ServiceLocationIdName = entity.new_ServiceLocationIdName,
                ModifiedByName = entity.ModifiedByName,
                OrganizationIdName = entity.OrganizationIdName,
                CreatedOnBehalfByName = entity.CreatedOnBehalfByName,
                new_RoomAdminName = entity.new_RoomAdminName,
                new_CSRIdYomiName = entity.new_CSRIdYomiName,
                new_ISPIdName = entity.new_ISPIdName,
                new_CCCPMIdName = entity.new_CCCPMIdName,
                CreatedByName = entity.CreatedByName,
                new_ServiceSubContactIdYomiName = entity.new_ServiceSubContactIdYomiName,
                new_CCCPMIdYomiName = entity.new_CCCPMIdYomiName,
                new_ServiceSubcontractorIdName = entity.new_ServiceSubcontractorIdName,
                new_ServiceSubContactIdName = entity.new_ServiceSubContactIdName,
                new_RoomAdminYomiName = entity.new_RoomAdminYomiName,
                new_CSRIdName = entity.new_CSRIdName,
                ModifiedOnBehalfByName = entity.ModifiedOnBehalfByName,
                New_clientroomId = entity.New_clientroomId,
                CreatedOn = entity.CreatedOn,
                CreatedBy = entity.CreatedBy,
                ModifiedOn = entity.ModifiedOn,
                ModifiedBy = entity.ModifiedBy,
                OrganizationId = entity.OrganizationId,
                statecode = entity.statecode,
                statuscode = entity.statuscode,
                VersionNumber = entity.VersionNumber,
                ImportSequenceNumber = entity.ImportSequenceNumber,
                OverriddenCreatedOn = entity.OverriddenCreatedOn,
                TimeZoneRuleVersionNumber = entity.TimeZoneRuleVersionNumber,
                UTCConversionTimeZoneCode = entity.UTCConversionTimeZoneCode,
                New_name = entity.New_name,
                New_RoomDescription = entity.New_RoomDescription,
                New_RoomNotes = entity.New_RoomNotes,
                New_MouseFrequency = entity.New_MouseFrequency,
                New_MicrophoneFrequency = entity.New_MicrophoneFrequency,
                New_ComputerIP = entity.New_ComputerIP,
                New_DVPHDIP = entity.New_DVPHDIP,
                New_ControllerIP = entity.New_ControllerIP,
                New_ProjectorIP = entity.New_ProjectorIP,
                New_Subnet = entity.New_Subnet,
                New_Gateway = entity.New_Gateway,
                New_Projector2IP = entity.New_Projector2IP,
                New_Projector3IP = entity.New_Projector3IP,
                New_LocationType = entity.New_LocationType,
                New_LocationSubType = entity.New_LocationSubType,
                New_LocationCapacity = entity.New_LocationCapacity,
                New_LocationDescription = entity.New_LocationDescription,
                New_LocationTypeT = entity.New_LocationTypeT,
                New_LocationSubTypeT = entity.New_LocationSubTypeT,
                New_Mic_Band = entity.New_Mic_Band,
                New_Mic_1_Freq = entity.New_Mic_1_Freq,
                New_Mic_2_Freq = entity.New_Mic_2_Freq,
                New_Mic_3_Freq = entity.New_Mic_3_Freq,
                New_Mic_4_Freq = entity.New_Mic_4_Freq,
                New_Mic_5_Freq = entity.New_Mic_5_Freq,
                New_Mic_6_Freq = entity.New_Mic_6_Freq,
                New_RoomPhone = entity.New_RoomPhone,
                New_RoomPhonePortID = entity.New_RoomPhonePortID,
                New_RoomOwnerId = entity.New_RoomOwnerId,
                New_Dashboard30 = entity.New_Dashboard30,
                New_RoomCheck = entity.New_RoomCheck,
                New_SupportNumber = entity.New_SupportNumber,
                New_RoomNumber = entity.New_RoomNumber,
                New_RoomFloorNumber = entity.New_RoomFloorNumber,
                New_TestedOn = entity.New_TestedOn,
                New_ServicePlan = entity.New_ServicePlan,
                New_ServiceRoomType = entity.New_ServiceRoomType,
                New_RoomViewName = entity.New_RoomViewName,
                New_ConstantConnect = entity.New_ConstantConnect,
                New_ActiveinDashboard = entity.New_ActiveinDashboard,
                CreatedOnBehalfBy = entity.CreatedOnBehalfBy,
                ModifiedOnBehalfBy = entity.ModifiedOnBehalfBy,
                new_RoomContactId = entity.new_RoomContactId,
                new_RoomCombine = entity.new_RoomCombine,
                new_WebPagesVPN = entity.new_WebPagesVPN,
                new_SupportTabletIP = entity.new_SupportTabletIP,
                new_TouchPanelIP = entity.new_TouchPanelIP,
                new_TabletPulse = entity.new_TabletPulse,
                new_ProcessorType = entity.new_ProcessorType,
                new_CompileDate = entity.new_CompileDate,
                new_ProgramFileName = entity.new_ProgramFileName,
                new_VTCIP = entity.new_VTCIP,
                new_ATCNumber = entity.new_ATCNumber,
                new_SwitcherIP = entity.new_SwitcherIP,
                new_RoomSwitchIP = entity.new_RoomSwitchIP,
                new_OpenBatchFile = entity.new_OpenBatchFile,
                new_DialOutsideLine = entity.new_DialOutsideLine,
                new_SystemNotes = entity.new_SystemNotes,
                new_RouterIP = entity.new_RouterIP,
                new_SiteModemIP = entity.new_SiteModemIP,
                new_RouterUserName = entity.new_RouterUserName,
                new_RouterPassword = entity.new_RouterPassword,
                new_ISP = entity.new_ISP,
                new_ISPPlan_SpeedName = entity.new_ISPPlan_SpeedName,
                new_ISPAccountNumber = entity.new_ISPAccountNumber,
                new_SiteCircuitID = entity.new_SiteCircuitID,
                new_SiteGateway = entity.new_SiteGateway,
                new_SiteSubnet = entity.new_SiteSubnet,
                new_CCCPMId = entity.new_CCCPMId,
                new_CCCImplementorId = entity.new_CCCImplementorId,
                new_Status = entity.new_Status,
                new_CCCTabletRequired = entity.new_CCCTabletRequired,
                new_StatusNotes = entity.new_StatusNotes,
                new_GoLiveActualDate = entity.new_GoLiveActualDate,
                new_OffLineStartDate = entity.new_OffLineStartDate,
                new_OffLineEndDate = entity.new_OffLineEndDate,
                new_DataConnectionType = entity.new_DataConnectionType,
                new_DataConnectionTypeOther = entity.new_DataConnectionTypeOther,
                new_Carrier = entity.new_Carrier,
                new_CarrierOther = entity.new_CarrierOther,
                new_TabletName = entity.new_TabletName,
                new_TabletPassword = entity.new_TabletPassword,
                new_LogMeInUser = entity.new_LogMeInUser,
                new_LogMeInPassword = entity.new_LogMeInPassword,
                new_TetherCode = entity.new_TetherCode,
                new_ControlCodeRevision = entity.new_ControlCodeRevision,
                new_AudioCODECFirmware = entity.new_AudioCODECFirmware,
                new_ControlFirmwareVersion = entity.new_ControlFirmwareVersion,
                new_VTCFirmwareVersion = entity.new_VTCFirmwareVersion,
                new_SwitcherFirmwareVersion = entity.new_SwitcherFirmwareVersion,
                new_LampHoursUsed = entity.new_LampHoursUsed,
                new_LampLifeEstimate = entity.new_LampLifeEstimate,
                new_LampHoursEstimate = entity.new_LampHoursEstimate,
                new_Lamp2HoursUsed = entity.new_Lamp2HoursUsed,
                new_Lamp2LifeEstimate = entity.new_Lamp2LifeEstimate,
                new_Lamp2HoursEstimate = entity.new_Lamp2HoursEstimate,
                new_CeneroChangesOnly = entity.new_CeneroChangesOnly,
                new_CCVersion = entity.new_CCVersion,
                new_NotificationId = entity.new_NotificationId,
                new_ServiceSubcontractorId = entity.new_ServiceSubcontractorId,
                new_ServiceSubContactId = entity.new_ServiceSubContactId,
                new_TouchpanelWebPage = entity.new_TouchpanelWebPage,
                new_GoLiveTargetDate = entity.new_GoLiveTargetDate,
                new_GPProjectNo = entity.new_GPProjectNo,
                new_ServiceLocationId = entity.new_ServiceLocationId,
                new_ISPId = entity.new_ISPId,
                new_ReviewComplete = entity.new_ReviewComplete,
                new_TouchPanelExternalWebPage = entity.new_TouchPanelExternalWebPage,
                new_CSRId = entity.new_CSRId,
                new_EventSchedulerRoomEmail = entity.new_EventSchedulerRoomEmail,
                new_CCModules = entity.new_CCModules,
                new_EventSchedulerRoomName = entity.new_EventSchedulerRoomName,
                new_RoomAdmin = entity.new_RoomAdmin,
                new_ServiceBillingNotes = entity.new_ServiceBillingNotes,
                new_TouchPanelSurvey = entity.new_TouchPanelSurvey,
                new_DisplayName = entity.new_DisplayName,
                new_City = entity.new_City,
                new_State = entity.new_State,
                new_VPNConnectionRequestDate = entity.new_VPNConnectionRequestDate,

                Incident = entity.Incident == null ? new List<Incident>() : entity.Incident.Select(e => incidentFactory.CreateIncident(e)).ToList(),
                New_clientequipment = entity.New_clientequipment == null ? new List<New_clientequipment>() : entity.New_clientequipment.Select(e => new_clientequipmentFactory.CreateNew_clientequipment(e)).ToList(),
                New_clientequipmemtipdata = entity.New_clientequipmemtipdata == null ? new List<New_clientequipmemtipdata>() : entity.New_clientequipmemtipdata.Select(e => new_clientequipmemtipdataFactory.CreateNew_clientequipmemtipdata(e)).ToList()
            };
        }

        public object CreateDataShapedObject(New_clientroom x, List<string> listOfFields)
        {
            return CreateDataShapedObject(CreateNew_clientroom(x), listOfFields);
        }

        public object CreateDataShapedObject(DTO.CRM.New_clientroom x, List<string> listOfFields)
        {
            var listOfFieldsToWorkWith = new List<string>(listOfFields);

            if (!listOfFieldsToWorkWith.Any())
                return x;

            var listOfIncidentFields = listOfFieldsToWorkWith.Where(f => f.Contains("incident")).ToList();
            var listOfNew_clientequipmemtipdataFields = listOfFieldsToWorkWith.Where(f => f.Contains("new_clientequipmemtipdata")).ToList();
            var listOfNew_clientequipmemtFields = listOfFieldsToWorkWith.Where(f => f.Contains("new_clientequipmemt")).ToList();

            bool returnPartialIncident = listOfIncidentFields.Any() && !listOfIncidentFields.Contains("incident");
            bool returnPartialNew_clientequipmemtipdata = listOfNew_clientequipmemtipdataFields.Any() && !listOfNew_clientequipmemtipdataFields.Contains("new_clientequipmemtipdata");
            bool returnPartialNew_clientequipmemt = listOfNew_clientequipmemtFields.Any() && !listOfNew_clientequipmemtFields.Contains("new_clientequipmemt");

            if (returnPartialIncident)
            {
                listOfFieldsToWorkWith.RemoveRange(listOfIncidentFields);
                listOfIncidentFields = listOfIncidentFields.Select(f => f.Substring(f.IndexOf(".") + 1)).ToList();
            }
            else
            {
                listOfIncidentFields.Remove("incident");
                listOfFieldsToWorkWith.RemoveRange(listOfIncidentFields);
            }

            if (returnPartialNew_clientequipmemtipdata)
            {
                listOfFieldsToWorkWith.RemoveRange(listOfNew_clientequipmemtipdataFields);
                listOfNew_clientequipmemtipdataFields = listOfNew_clientequipmemtipdataFields.Select(f => f.Substring(f.IndexOf(".") + 1)).ToList();
            }
            else
            {
                listOfNew_clientequipmemtipdataFields.Remove("new_clientequipmemtipdata");
                listOfFieldsToWorkWith.RemoveRange(listOfNew_clientequipmemtipdataFields);
            }

            if (returnPartialNew_clientequipmemt)
            {
                listOfFieldsToWorkWith.RemoveRange(listOfNew_clientequipmemtFields);
                listOfNew_clientequipmemtFields = listOfNew_clientequipmemtFields.Select(f => f.Substring(f.IndexOf(".") + 1)).ToList();
            }
            else
            {
                listOfNew_clientequipmemtipdataFields.Remove("new_clientequipmemt");
                listOfFieldsToWorkWith.RemoveRange(listOfNew_clientequipmemtFields);
            }

            ExpandoObject result = new ExpandoObject();
            foreach (var field in listOfFieldsToWorkWith)
            {
                var fieldValue = x.GetType()
                    .GetProperty(field, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                    .GetValue(x, null);

                ((IDictionary<String, Object>)result).Add(field, fieldValue);
            }

            if (returnPartialIncident)
            {
                var incidents = new List<object>();
                foreach (var incident in x.Incident)
                {
                    incidents.Add(incidentFactory.CreateDataShapedObject(incident, listOfIncidentFields));
                }
                ((IDictionary<String, Object>)result).Add("incident", incidents);
            }

            if (returnPartialNew_clientequipmemtipdata)
            {
                var data = new List<object>();
                foreach (var n in x.New_clientequipmemtipdata)
                {
                    data.Add(new_clientequipmemtipdataFactory.CreateDataShapedObject(n, listOfNew_clientequipmemtipdataFields));
                }
                ((IDictionary<String, Object>)result).Add("new_clientequipmemtipdata", data);
            }

            if (returnPartialNew_clientequipmemt)
            {
                var data = new List<object>();
                foreach (var n in x.New_clientequipment)
                {
                    data.Add(new_clientequipmentFactory.CreateDataShapedObject(n, listOfNew_clientequipmemtFields));
                }
                ((IDictionary<String, Object>)result).Add("new_clientequipmemt", data);
            }

            return result;
        }
    }
}

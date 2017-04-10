using ConstantConnect.Repository.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Repository.Factories.CRM
{
    public class New_clientequipmentFactory
    {
        #region Constructor
        public New_clientequipmentFactory()
        {

        }
        #endregion

        #region Mapping

        public DTO.CRM.New_clientequipment CreateNew_clientequipment(New_clientequipment entity)
        {
            return new DTO.CRM.New_clientequipment()
            {
                createdbyyominame = entity.createdbyyominame,
                modifiedbyyominame = entity.modifiedbyyominame,
                createdonbehalfbyyominame = entity.createdonbehalfbyyominame,
                modifiedonbehalfbyyominame = entity.modifiedonbehalfbyyominame,
                CreatedOnBehalfByName = entity.CreatedOnBehalfByName,
                New_EquipmentIdName = entity.New_EquipmentIdName,
                New_LoanedByIdName = entity.New_LoanedByIdName,
                ModifiedByName = entity.ModifiedByName,
                New_ClientRoomEquipmentIdName = entity.New_ClientRoomEquipmentIdName,
                New_LoanedByIdYomiName = entity.New_LoanedByIdYomiName,
                OrganizationIdName = entity.OrganizationIdName,
                new_ServiceEquipmentIdName = entity.new_ServiceEquipmentIdName,
                New_EquipmentStatusIdName = entity.New_EquipmentStatusIdName,
                New_ValidatedByIdName = entity.New_ValidatedByIdName,
                New_ManufacturerIdName = entity.New_ManufacturerIdName,
                CreatedByName = entity.CreatedByName,
                New_EquipmentOwnerIdName = entity.New_EquipmentOwnerIdName,
                ModifiedOnBehalfByName = entity.ModifiedOnBehalfByName,
                New_EquipmentOwnerIdYomiName = entity.New_EquipmentOwnerIdYomiName,
                New_EquipmentFunctionIdName = entity.New_EquipmentFunctionIdName,
                New_ValidatedByIdYomiName = entity.New_ValidatedByIdYomiName,
                New_clientequipmentId = entity.New_clientequipmentId,
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
                New_Model = entity.New_Model,
                New_ModelNumber = entity.New_ModelNumber,
                New_SerialNumber = entity.New_SerialNumber,
                New_EquipmentNotes = entity.New_EquipmentNotes,
                New_ClientRoomEquipmentId = entity.New_ClientRoomEquipmentId,
                New_ManufacturerId = entity.New_ManufacturerId,
                New_EquipmentStatusId = entity.New_EquipmentStatusId,
                New_LocationDescription = entity.New_LocationDescription,
                New_ComponentDescription = entity.New_ComponentDescription,
                New_AssetTag = entity.New_AssetTag,
                New_ValidationDate = entity.New_ValidationDate,
                New_AuditDate = entity.New_AuditDate,
                New_ComponentFunction = entity.New_ComponentFunction,
                New_ComponentDetails = entity.New_ComponentDetails,
                New_ComponentLocation = entity.New_ComponentLocation,
                New_MiscTag = entity.New_MiscTag,
                New_IPAddress = entity.New_IPAddress,
                New_NetworkInfo = entity.New_NetworkInfo,
                New_Barcode = entity.New_Barcode,
                New_AssetID = entity.New_AssetID,
                New_WCITTag = entity.New_WCITTag,
                New_EquipmentType = entity.New_EquipmentType,
                New_PartNumber = entity.New_PartNumber,
                New_Firmware = entity.New_Firmware,
                New_Loanable = entity.New_Loanable,
                New_ContactName = entity.New_ContactName,
                New_ContactInfo = entity.New_ContactInfo,
                New_ValidatedById = entity.New_ValidatedById,
                New_LoanedById = entity.New_LoanedById,
                New_RMANumber = entity.New_RMANumber,
                New_HostName = entity.New_HostName,
                New_LoanContactName = entity.New_LoanContactName,
                New_LoanContactInfo = entity.New_LoanContactInfo,
                New_BENAssetNumber = entity.New_BENAssetNumber,
                New_EquipmentId = entity.New_EquipmentId,
                New_EquipmentFunctionId = entity.New_EquipmentFunctionId,
                New_Subnet = entity.New_Subnet,
                New_Gateway = entity.New_Gateway,
                New_ServiceLocation = entity.New_ServiceLocation,
                New_DeviceAssigned = entity.New_DeviceAssigned,
                New_PlateID = entity.New_PlateID,
                New_PlateLocation = entity.New_PlateLocation,
                New_PortType = entity.New_PortType,
                New_PortStatus = entity.New_PortStatus,
                New_PortSpeed = entity.New_PortSpeed,
                New_ATCNumber = entity.New_ATCNumber,
                New_ScreenResolution = entity.New_ScreenResolution,
                New_EquipmentOwnerId = entity.New_EquipmentOwnerId,
                New_Quantity = entity.New_Quantity,
                New_CCCMonitored = entity.New_CCCMonitored,
                New_CCCDeviceID = entity.New_CCCDeviceID,
                CreatedOnBehalfBy = entity.CreatedOnBehalfBy,
                ModifiedOnBehalfBy = entity.ModifiedOnBehalfBy,
                new_CodeFileName = entity.new_CodeFileName,
                new_CodeCompileDate = entity.new_CodeCompileDate,
                new_ConstantConnectVersion = entity.new_ConstantConnectVersion,
                new_ServiceEquipmentId = entity.new_ServiceEquipmentId,
                new_Lamp1HoursUsed = entity.new_Lamp1HoursUsed,
                new_Lamp1LifeEstimate = entity.new_Lamp1LifeEstimate,
                new_Lamp1HoursRemaining = entity.new_Lamp1HoursRemaining,
                new_Lamp2HoursUsed = entity.new_Lamp2HoursUsed,
                new_Lamp2LifeEstimate = entity.new_Lamp2LifeEstimate,
                new_Lamp2HoursRemaining = entity.new_Lamp2HoursRemaining

                //New_clientroom New_clientroom { get; set; }
            };
        }

        public New_clientequipment CreateNew_clientequipment(DTO.CRM.New_clientequipment entity)
        {
            return new New_clientequipment()
            {
                createdbyyominame = entity.createdbyyominame,
                modifiedbyyominame = entity.modifiedbyyominame,
                createdonbehalfbyyominame = entity.createdonbehalfbyyominame,
                modifiedonbehalfbyyominame = entity.modifiedonbehalfbyyominame,
                CreatedOnBehalfByName = entity.CreatedOnBehalfByName,
                New_EquipmentIdName = entity.New_EquipmentIdName,
                New_LoanedByIdName = entity.New_LoanedByIdName,
                ModifiedByName = entity.ModifiedByName,
                New_ClientRoomEquipmentIdName = entity.New_ClientRoomEquipmentIdName,
                New_LoanedByIdYomiName = entity.New_LoanedByIdYomiName,
                OrganizationIdName = entity.OrganizationIdName,
                new_ServiceEquipmentIdName = entity.new_ServiceEquipmentIdName,
                New_EquipmentStatusIdName = entity.New_EquipmentStatusIdName,
                New_ValidatedByIdName = entity.New_ValidatedByIdName,
                New_ManufacturerIdName = entity.New_ManufacturerIdName,
                CreatedByName = entity.CreatedByName,
                New_EquipmentOwnerIdName = entity.New_EquipmentOwnerIdName,
                ModifiedOnBehalfByName = entity.ModifiedOnBehalfByName,
                New_EquipmentOwnerIdYomiName = entity.New_EquipmentOwnerIdYomiName,
                New_EquipmentFunctionIdName = entity.New_EquipmentFunctionIdName,
                New_ValidatedByIdYomiName = entity.New_ValidatedByIdYomiName,
                New_clientequipmentId = entity.New_clientequipmentId,
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
                New_Model = entity.New_Model,
                New_ModelNumber = entity.New_ModelNumber,
                New_SerialNumber = entity.New_SerialNumber,
                New_EquipmentNotes = entity.New_EquipmentNotes,
                New_ClientRoomEquipmentId = entity.New_ClientRoomEquipmentId,
                New_ManufacturerId = entity.New_ManufacturerId,
                New_EquipmentStatusId = entity.New_EquipmentStatusId,
                New_LocationDescription = entity.New_LocationDescription,
                New_ComponentDescription = entity.New_ComponentDescription,
                New_AssetTag = entity.New_AssetTag,
                New_ValidationDate = entity.New_ValidationDate,
                New_AuditDate = entity.New_AuditDate,
                New_ComponentFunction = entity.New_ComponentFunction,
                New_ComponentDetails = entity.New_ComponentDetails,
                New_ComponentLocation = entity.New_ComponentLocation,
                New_MiscTag = entity.New_MiscTag,
                New_IPAddress = entity.New_IPAddress,
                New_NetworkInfo = entity.New_NetworkInfo,
                New_Barcode = entity.New_Barcode,
                New_AssetID = entity.New_AssetID,
                New_WCITTag = entity.New_WCITTag,
                New_EquipmentType = entity.New_EquipmentType,
                New_PartNumber = entity.New_PartNumber,
                New_Firmware = entity.New_Firmware,
                New_Loanable = entity.New_Loanable,
                New_ContactName = entity.New_ContactName,
                New_ContactInfo = entity.New_ContactInfo,
                New_ValidatedById = entity.New_ValidatedById,
                New_LoanedById = entity.New_LoanedById,
                New_RMANumber = entity.New_RMANumber,
                New_HostName = entity.New_HostName,
                New_LoanContactName = entity.New_LoanContactName,
                New_LoanContactInfo = entity.New_LoanContactInfo,
                New_BENAssetNumber = entity.New_BENAssetNumber,
                New_EquipmentId = entity.New_EquipmentId,
                New_EquipmentFunctionId = entity.New_EquipmentFunctionId,
                New_Subnet = entity.New_Subnet,
                New_Gateway = entity.New_Gateway,
                New_ServiceLocation = entity.New_ServiceLocation,
                New_DeviceAssigned = entity.New_DeviceAssigned,
                New_PlateID = entity.New_PlateID,
                New_PlateLocation = entity.New_PlateLocation,
                New_PortType = entity.New_PortType,
                New_PortStatus = entity.New_PortStatus,
                New_PortSpeed = entity.New_PortSpeed,
                New_ATCNumber = entity.New_ATCNumber,
                New_ScreenResolution = entity.New_ScreenResolution,
                New_EquipmentOwnerId = entity.New_EquipmentOwnerId,
                New_Quantity = entity.New_Quantity,
                New_CCCMonitored = entity.New_CCCMonitored,
                New_CCCDeviceID = entity.New_CCCDeviceID,
                CreatedOnBehalfBy = entity.CreatedOnBehalfBy,
                ModifiedOnBehalfBy = entity.ModifiedOnBehalfBy,
                new_CodeFileName = entity.new_CodeFileName,
                new_CodeCompileDate = entity.new_CodeCompileDate,
                new_ConstantConnectVersion = entity.new_ConstantConnectVersion,
                new_ServiceEquipmentId = entity.new_ServiceEquipmentId,
                new_Lamp1HoursUsed = entity.new_Lamp1HoursUsed,
                new_Lamp1LifeEstimate = entity.new_Lamp1LifeEstimate,
                new_Lamp1HoursRemaining = entity.new_Lamp1HoursRemaining,
                new_Lamp2HoursUsed = entity.new_Lamp2HoursUsed,
                new_Lamp2LifeEstimate = entity.new_Lamp2LifeEstimate,
                new_Lamp2HoursRemaining = entity.new_Lamp2HoursRemaining

                //New_clientroom New_clientroom { get; set; }
            };
        }

        #endregion

        #region DataShaping
        public object CreateDataShapedObject(New_clientequipment x, List<string> listOfFields)
        {
            return CreateDataShapedObject(CreateNew_clientequipment(x), listOfFields);
        }
        public object CreateDataShapedObject(DTO.CRM.New_clientequipment x, List<string> listOfFields)
        {
            if (!listOfFields.Any())
                return x;

            ExpandoObject result = new ExpandoObject();
            foreach (var field in listOfFields)
            {
                var fieldValue = x.GetType()
                    .GetProperty(field, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                    .GetValue(x, null);

                ((IDictionary<string, object>)result).Add(field, fieldValue);
            }

            return result;
        }

        #endregion

    }
}

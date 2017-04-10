using ConstantConnect.Repository.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Repository.Factories.CRM
{
    public class New_documentationFactory
    {
        public New_documentationFactory()
        {

        }

        public DTO.CRM.New_documentation CreateNew_documentation(New_documentation entity)
        {
            return new DTO.CRM.New_documentation()
            {
                createdbyyominame = entity.createdbyyominame,
                modifiedbyyominame = entity.modifiedbyyominame,
                createdonbehalfbyyominame = entity.createdonbehalfbyyominame,
                modifiedonbehalfbyyominame = entity.modifiedonbehalfbyyominame,
                CreatedOnBehalfByName = entity.CreatedOnBehalfByName,
                CreatedByName = entity.CreatedByName,
                New_ProjectRoomIdName = entity.New_ProjectRoomIdName,
                New_ProjectIdName = entity.New_ProjectIdName,
                ModifiedByName = entity.ModifiedByName,
                New_DocumentOwnerIdYomiName = entity.New_DocumentOwnerIdYomiName,
                New_DocumentOwnerIdName = entity.New_DocumentOwnerIdName,
                ModifiedOnBehalfByName = entity.ModifiedOnBehalfByName,
                New_ClientRoomIdName = entity.New_ClientRoomIdName,
                OwnerId = entity.OwnerId,
                OwnerIdName = entity.OwnerIdName,
                OwnerIdYomiName = entity.OwnerIdYomiName,
                OwnerIdDsc = entity.OwnerIdDsc,
                OwnerIdType = entity.OwnerIdType,
                OwningUser = entity.OwningUser,
                OwningTeam = entity.OwningTeam,
                New_documentationId = entity.New_documentationId,
                CreatedOn = entity.CreatedOn,
                CreatedBy = entity.CreatedBy,
                ModifiedOn = entity.ModifiedOn,
                ModifiedBy = entity.ModifiedBy,
                OwningBusinessUnit = entity.OwningBusinessUnit,
                statecode = entity.statecode,
                statuscode = entity.statuscode,
                VersionNumber = entity.VersionNumber,
                ImportSequenceNumber = entity.ImportSequenceNumber,
                OverriddenCreatedOn = entity.OverriddenCreatedOn,
                TimeZoneRuleVersionNumber = entity.TimeZoneRuleVersionNumber,
                UTCConversionTimeZoneCode = entity.UTCConversionTimeZoneCode,
                New_name = entity.New_name,
                New_ProjectId = entity.New_ProjectId,
                New_ProjectRoomId = entity.New_ProjectRoomId,
                New_DocumentType = entity.New_DocumentType,
                New_Notes = entity.New_Notes,
                New_DocumentOwnerId = entity.New_DocumentOwnerId,
                New_ShareDocument = entity.New_ShareDocument,
                New_ClientRoomId = entity.New_ClientRoomId,
                CreatedOnBehalfBy = entity.CreatedOnBehalfBy,
                ModifiedOnBehalfBy = entity.ModifiedOnBehalfBy
            };
        }

        public New_documentation CreateNew_documentation(DTO.CRM.New_documentation entity)
        {
            return new New_documentation()
            {
                createdbyyominame = entity.createdbyyominame,
                modifiedbyyominame = entity.modifiedbyyominame,
                createdonbehalfbyyominame = entity.createdonbehalfbyyominame,
                modifiedonbehalfbyyominame = entity.modifiedonbehalfbyyominame,
                CreatedOnBehalfByName = entity.CreatedOnBehalfByName,
                CreatedByName = entity.CreatedByName,
                New_ProjectRoomIdName = entity.New_ProjectRoomIdName,
                New_ProjectIdName = entity.New_ProjectIdName,
                ModifiedByName = entity.ModifiedByName,
                New_DocumentOwnerIdYomiName = entity.New_DocumentOwnerIdYomiName,
                New_DocumentOwnerIdName = entity.New_DocumentOwnerIdName,
                ModifiedOnBehalfByName = entity.ModifiedOnBehalfByName,
                New_ClientRoomIdName = entity.New_ClientRoomIdName,
                OwnerId = entity.OwnerId,
                OwnerIdName = entity.OwnerIdName,
                OwnerIdYomiName = entity.OwnerIdYomiName,
                OwnerIdDsc = entity.OwnerIdDsc,
                OwnerIdType = entity.OwnerIdType,
                OwningUser = entity.OwningUser,
                OwningTeam = entity.OwningTeam,
                New_documentationId = entity.New_documentationId,
                CreatedOn = entity.CreatedOn,
                CreatedBy = entity.CreatedBy,
                ModifiedOn = entity.ModifiedOn,
                ModifiedBy = entity.ModifiedBy,
                OwningBusinessUnit = entity.OwningBusinessUnit,
                statecode = entity.statecode,
                statuscode = entity.statuscode,
                VersionNumber = entity.VersionNumber,
                ImportSequenceNumber = entity.ImportSequenceNumber,
                OverriddenCreatedOn = entity.OverriddenCreatedOn,
                TimeZoneRuleVersionNumber = entity.TimeZoneRuleVersionNumber,
                UTCConversionTimeZoneCode = entity.UTCConversionTimeZoneCode,
                New_name = entity.New_name,
                New_ProjectId = entity.New_ProjectId,
                New_ProjectRoomId = entity.New_ProjectRoomId,
                New_DocumentType = entity.New_DocumentType,
                New_Notes = entity.New_Notes,
                New_DocumentOwnerId = entity.New_DocumentOwnerId,
                New_ShareDocument = entity.New_ShareDocument,
                New_ClientRoomId = entity.New_ClientRoomId,
                CreatedOnBehalfBy = entity.CreatedOnBehalfBy,
                ModifiedOnBehalfBy = entity.ModifiedOnBehalfBy
            };
        }

        public object CreateDataShapedObject(New_documentation x, List<string> listOfFields)
        {
            return CreateDataShapedObject(CreateNew_documentation(x), listOfFields);
        }

        public object CreateDataShapedObject(DTO.CRM.New_documentation x, List<string> listOfFields)
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

    }
}

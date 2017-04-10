namespace ConstantConnect.Repository.Entities.CRM
{
    using System;
    using System.Collections.Generic;

    public partial class New_documentation
    {
        public string createdbyyominame { get; set; }
        public string modifiedbyyominame { get; set; }
        public string createdonbehalfbyyominame { get; set; }
        public string modifiedonbehalfbyyominame { get; set; }
        public string CreatedOnBehalfByName { get; set; }
        public string CreatedByName { get; set; }
        public string New_ProjectRoomIdName { get; set; }
        public string New_ProjectIdName { get; set; }
        public string ModifiedByName { get; set; }
        public string New_DocumentOwnerIdYomiName { get; set; }
        public string New_DocumentOwnerIdName { get; set; }
        public string ModifiedOnBehalfByName { get; set; }
        public string New_ClientRoomIdName { get; set; }
        public System.Guid OwnerId { get; set; }
        public string OwnerIdName { get; set; }
        public string OwnerIdYomiName { get; set; }
        public int OwnerIdDsc { get; set; }
        public Nullable<int> OwnerIdType { get; set; }
        public Nullable<System.Guid> OwningUser { get; set; }
        public Nullable<System.Guid> OwningTeam { get; set; }
        public System.Guid New_documentationId { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public Nullable<System.Guid> OwningBusinessUnit { get; set; }
        public int statecode { get; set; }
        public Nullable<int> statuscode { get; set; }
        public byte[] VersionNumber { get; set; }
        public Nullable<int> ImportSequenceNumber { get; set; }
        public Nullable<System.DateTime> OverriddenCreatedOn { get; set; }
        public Nullable<int> TimeZoneRuleVersionNumber { get; set; }
        public Nullable<int> UTCConversionTimeZoneCode { get; set; }
        public string New_name { get; set; }
        public Nullable<System.Guid> New_ProjectId { get; set; }
        public Nullable<System.Guid> New_ProjectRoomId { get; set; }
        public Nullable<int> New_DocumentType { get; set; }
        public string New_Notes { get; set; }
        public Nullable<System.Guid> New_DocumentOwnerId { get; set; }
        public Nullable<bool> New_ShareDocument { get; set; }
        public Nullable<System.Guid> New_ClientRoomId { get; set; }
        public Nullable<System.Guid> CreatedOnBehalfBy { get; set; }
        public Nullable<System.Guid> ModifiedOnBehalfBy { get; set; }
    }
}

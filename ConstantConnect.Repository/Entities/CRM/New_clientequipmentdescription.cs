namespace ConstantConnect.Repository.Entities.CRM
{
    using System;
    using System.Collections.Generic;

    public partial class New_clientequipmentdescription
    {
        public string createdbyyominame { get; set; }
        public string modifiedbyyominame { get; set; }
        public string createdonbehalfbyyominame { get; set; }
        public string modifiedonbehalfbyyominame { get; set; }
        public string CreatedByName { get; set; }
        public string ModifiedByName { get; set; }
        public string CreatedOnBehalfByName { get; set; }
        public string OrganizationIdName { get; set; }
        public string ModifiedOnBehalfByName { get; set; }
        public System.Guid New_clientequipmentdescriptionId { get; set; }
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
        public Nullable<System.Guid> CreatedOnBehalfBy { get; set; }
        public Nullable<System.Guid> ModifiedOnBehalfBy { get; set; }
    }
}

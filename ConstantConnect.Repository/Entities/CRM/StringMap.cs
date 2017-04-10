namespace ConstantConnect.Repository.Entities.CRM
{
    using System;
    using System.Collections.Generic;

    public partial class StringMap
    {
        public int ObjectTypeCode { get; set; }
        public string AttributeName { get; set; }
        public int AttributeValue { get; set; }
        public int LangId { get; set; }
        public System.Guid OrganizationId { get; set; }
        public string Value { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public byte[] VersionNumber { get; set; }
        public System.Guid StringMapId { get; set; }
    }
}

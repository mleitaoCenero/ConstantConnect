namespace ConstantConnect.Repository.Entities.CRM
{
    using System;
    using System.Collections.Generic;

    public partial class new_clientroom_projectfile
    {
        public System.Guid new_clientroom_projectfileId { get; set; }
        public byte[] VersionNumber { get; set; }
        public System.Guid new_clientroomid { get; set; }
        public System.Guid new_projectfileid { get; set; }
    }
}

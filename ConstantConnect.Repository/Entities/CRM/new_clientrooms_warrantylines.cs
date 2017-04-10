namespace ConstantConnect.Repository.Entities.CRM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class new_clientrooms_warrantylines
    {
        public System.Guid new_clientrooms_warrantylinesId { get; set; }
        public byte[] VersionNumber { get; set; }
        public System.Guid new_clientroomid { get; set; }
        public System.Guid new_warrantyid { get; set; }
    }
}

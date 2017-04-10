using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.DTO.Shared
{
    public class Document
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public Guid OrganizationId { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string Name { get; set; }
        public string FolderName { get; set; }
        public string Type { get; set; }
        public bool isProtected { get; set; }
    }
}

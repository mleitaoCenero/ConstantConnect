using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstantConnect.MVCClient.Models
{
    public class AttachmentsModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Size { get; set; }
        public string CreatedOn { get; set; }
        public string FileType { get; set; }
        public bool ReadOnly { get; set; }
    }
}
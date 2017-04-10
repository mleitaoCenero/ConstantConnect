using ConstantConnect.DTO.CRM;
using ConstantConnect.DTO.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstantConnect.MVCClient.Models
{
    public class DocumentModel
    {
        public Guid RoomId { get; set; }
        public List<AttachmentsModel> Attachments { get; set; }
        public Guid? ParentId { get; set; }
        //public List<Document> Documents { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstantConnect.MVCClient.Models
{
    public class Modal
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public string Name { get; set; }
    }
}
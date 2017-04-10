using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstantConnect.MVCClient.Models
{
    public class TableDiscriptor
    {
        public int  Position { get; set; }
        public string TextColor { get; set; }
        public string Data { get; set; }
        public string DescriptionHeader { get; set; }
        public string DescriptionText { get; set; }

    }
}
using ConstantConnect.DTO.CRM;
using ConstantConnect.DTO.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstantConnect.MVCClient.Models
{
    public class InventoryDetailsModel
    {
        public New_clientequipment Equipment { get; set; }
        public IEnumerable<Room> ClientRooms { get; set; }
        public IEnumerable<New_manufacturer> Manufacturers { get; set; }
        public IEnumerable<New_clientequipmentfunction> FunctionTypes { get; set; }
    }
}
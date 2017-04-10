using ConstantConnect.DTO.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstantConnect.MVCClient.Models
{
    public class InventoryModel
    {
        public IEnumerable<Room> ClientRooms { get; set; }

    }
}
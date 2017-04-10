using ConstantConnect.DTO.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstantConnect.MVCClient.Models
{
    public class DataTableTile<T> where T : class
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public int Position { get; set; }
        public string Width { get; set; }
        public bool AllowSearch { get; set; }
        public bool AllowFilter { get; set; }
        public string FilterOptions { get; set; }
        public List<TableColumn> Columns { get; set; }
        public IEnumerable<T> Data { get; set; }
        public List<TableDiscriptor> Discriptors { get; set; }
    }
}
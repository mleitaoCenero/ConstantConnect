using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConstantConnect.MVCClient.Models
{
    public class TableColumn
    {
        [Required(ErrorMessage = "Column Title is required.")]
        [StringLength(20, ErrorMessage = "Title cannot be longer then 20 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Column Position is required.")]
        public int Position { get; set; }
        public bool SearchOn { get; set; } = true;
        public string AllowSort { get; set; } = "";
        public int RowSpan { get; set; } = 1;
        public int ColSpan { get; set; } = 1;
        public string DisplayStyle { get; set; } = "";

    }
}
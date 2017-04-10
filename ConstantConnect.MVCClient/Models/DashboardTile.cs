using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConstantConnect.MVCClient.Models
{
    public class DashboardTile//<T> where T : class
    {
        [Required(ErrorMessage ="Tile ID is required.")]
        [StringLength(20, ErrorMessage = "ID cannot be longer then 20 characters.")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Tile Title is required.")]
        [StringLength(20, ErrorMessage ="Title cannot be longer then 20 characters.")]
        public string Title { get; set; }

        
        [Required(ErrorMessage ="Tile Description is required.")]
        [StringLength(250, ErrorMessage ="Description cannot be longer than 250 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage ="Tile Icon is required.")]
        [StringLength(20, ErrorMessage = "Icon cannot be longer than 20 characters")]
        public string Icon { get; set; }

        //public IEnumerable<T> Data { get; set; }
        public string Data { get; set; }

        [Required(ErrorMessage ="Tile Position is required.")]
        [Range(1,4,ErrorMessage ="Tile Position can only be between 1 - 4.")]
        public int Position { get; set; }

        [Required]
        //[RegularExpression("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", 
        //    ErrorMessage = "Specified Color has Invalid Format, must be hexadecimal. (ie:#f00 = Red")]
        public string Color { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Tile Details Link cannot be longer than 25 characters")]
        public string LinkToTable { get; set; }

    }
}
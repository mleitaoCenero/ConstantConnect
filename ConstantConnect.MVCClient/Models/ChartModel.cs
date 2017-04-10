using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstantConnect.MVCClient.Models
{
    public class ChartModel<T> where T : class
    {
        public IEnumerable<T> Data { get; set; }
        public int Year { get; set; }
        
    }
}
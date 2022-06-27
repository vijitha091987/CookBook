using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.Models
{
    public class CookBookRequest
    {
        public int ItemID { get; set; }
        public int ItemTypeID { get; set; }
        public string ItemName { get; set; }
        public string Recipe   { get; set; }
     
    }
}
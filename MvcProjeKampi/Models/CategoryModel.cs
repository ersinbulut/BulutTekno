using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.Models
{
    public class CategoryModel
    {
        public int CategoryID { get; set; }
  
        public string CategoryName { get; set; }

        public int Count { get; set; }

        public int ParentID { get; set; }
    }
}
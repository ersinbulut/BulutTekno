using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        [AllowHtml]
        public string BlogDescription { get; set; }
        public DateTime BlogDate { get; set; }

        public int? WriterID { get; set; }
        public virtual WriterUser Writer { get; set; }

        public bool BlogStatus { get; set; }
        public string ImageUrl { get; set; }

        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }
}

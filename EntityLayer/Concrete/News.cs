using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.Concrete
{
    public class News
    {
        [Key]
        public int NewsID { get; set; }
        public string NewsTitle { get; set; }
        [AllowHtml]
        public string NewsDescription { get; set; }
        public DateTime NewsDate { get; set; }

        public int? WriterID { get; set; }
        public virtual WriterUser Writer { get; set; }

        public bool NewsStatus { get; set; }
        public string ImageUrl { get; set; }

        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}

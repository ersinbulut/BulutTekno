using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.Concrete
{
    public class Video
    {
        [Key]
        public int VideoID { get; set; }
        public string VideoTitle { get; set; }
        [AllowHtml]
        public string VideoDescription { get; set; }
        public DateTime VideoDate { get; set; }

        public int? WriterID { get; set; }
        public virtual WriterUser Writer { get; set; }

        public bool VideoStatus { get; set; }
        public string ImageUrl { get; set; }

        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}

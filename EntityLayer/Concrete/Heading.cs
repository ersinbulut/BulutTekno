using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingID { get; set; }
        [StringLength(200)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }
        [StringLength(200)]
        public string ImageUrl { get; set; }
        public bool HeadingStatus { get; set; }
        public bool Slider { get; set; }

        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public int? WriterID { get; set; }
        public virtual WriterUser Writer { get; set; }

        public ICollection<Content> Contents { get; set; }

        public int? CommentID { get; set; }
        public virtual Comment Comment { get; set; }
        //
        //public ICollection<Comment> Comments { get; set; }
    }
}

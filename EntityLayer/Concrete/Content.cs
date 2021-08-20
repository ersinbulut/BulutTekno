using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }
        [StringLength(1000)]
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }

        [StringLength(200)]
        public string ImageUrl1 { get; set; }
        [StringLength(200)]
        public string ImageUrl2 { get; set; }
        [StringLength(200)]
        public string ImageUrl3 { get; set; }

        //content yazar : bu yazı kim tarafından yazıldı
        //content başlık: bu yazı hangi başlığa yazıldı

        public bool ContentStatus { get; set; }


        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }

        public int? WriterID { get; set; }
        public virtual WriterUser Writer { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}

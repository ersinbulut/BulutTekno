using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(250)]
        public string ImageUrl { get; set; }

        public DateTime CommentDate { get; set; }

        public string CommentValue { get; set; }

        public int ParentID { get; set; }

        public int? WriterID { get; set; }
        public virtual WriterUser Writer { get; set; }

        public int? ContentID { get; set; }
        public virtual Content Content { get; set; }

        public int? BlogID { get; set; }
        public virtual Blog Blog { get; set; }

        public int? VideoID { get; set; }
        public virtual Video Video { get; set; }


        public int? NewsID { get; set; }
        public virtual News News { get; set; }

    }
}

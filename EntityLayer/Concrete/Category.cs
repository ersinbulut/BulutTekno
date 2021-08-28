using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; }
        [StringLength(200)]
        public string CategoryDesctription { get; set; }
        public bool CategoryStatus { get; set; }//
        public int ParentID { get; set; }

        public int Count { get; set; }

        public ICollection<Heading> Headings { get; set; }
        public ICollection<Blog> Blogs { get; set; }
        public ICollection<Video> Videos { get; set; }
        public ICollection<News> News { get; set; }
    }
}

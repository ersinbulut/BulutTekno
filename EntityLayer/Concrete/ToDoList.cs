using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ToDoList
    {
        [Key]
        public int ToDoID { get; set; }
        public string Content { get; set; }
        [StringLength(100)]
        public string Priority { get; set; }//öncelik
        public DateTime ToDoDate { get; set; }
        [StringLength(250)]
        public string ImageUrl { get; set; }
        public bool ToDoStatus { get; set; }//durum
    }
}

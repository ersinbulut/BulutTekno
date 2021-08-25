using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Talent
    {
        public int TalentID { get; set; }
        public string Description { get; set; }
        public string TalentDescription { get; set; } //yüzde
        public int Percent { get; set; } //yetenek
        public int PercentValue { get; set; } //yetenek

        public int? WriterID { get; set; }
        public virtual WriterUser WriterUser { get; set; }
    }
}

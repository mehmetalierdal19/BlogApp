using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        public string FirstDetails { get; set; }
        public string SecondDetails { get; set; }
        public string FirstImage { get; set; }
        public string SecondImage { get; set; }
        public string MapLocation { get; set; }
        public bool Status { get; set; }
    }
}

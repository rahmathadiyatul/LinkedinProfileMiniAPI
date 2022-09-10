using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string University { get; set; }
        public int Lulus { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; } 
        public List<string> Skills { get; set; }
    }
}

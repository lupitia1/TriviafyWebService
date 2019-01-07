using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Album
    {
        public string href { get; set; }
        public List<Image> images { get; set; }
        public string name { get; set; }
    }
}

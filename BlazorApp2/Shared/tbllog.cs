using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Shared
{
    public class tbllog
    {
        public string Name { get; set; }
        public string Website { get; set; }
        public string Checked { get; set; }
        public DateTime LogDate { get; set; } = DateTime.Now;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava7
{
    public class Station
    {
        public string StationName { get; set; }
        public string StationShortCode { get; set; }

        public override string ToString()
        {
            return StationName;
        }
    }
}

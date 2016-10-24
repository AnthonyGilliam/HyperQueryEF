using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperQueryEF.Model
{
    public class Car : Vehicle
    {
        public int Doors { get; set; }
        public bool PowerStearing { get; set; }
        public bool PowerWindowsAndLocks { get; set; }
        public bool CruiseControl { get; set; }
    }
}

using System;

namespace HyperQueryEF.Tests.Model
{
    public class Car : Vehicle
    {
        public int Doors { get; set; }
        public bool PowerStearing { get; set; }
        public bool PowerWindowsAndLocks { get; set; }
        public bool? CruiseControl { get; set; }
    }
}

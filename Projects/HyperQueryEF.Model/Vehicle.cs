using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperQueryEF.Model
{
    public abstract class Vehicle : Entity
    {
        public Make Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Wheels { get; set; }
        public string Engine { get; set; }
        public decimal MilesPerGallon { get; set; }
        public decimal ListPrice { get; set; }
    }
}

using System;

namespace HyperQueryEF.Tests.Model
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

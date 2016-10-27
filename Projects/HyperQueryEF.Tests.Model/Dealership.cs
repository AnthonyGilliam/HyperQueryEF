using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HyperQueryEF.Tests.Model
{
    public class Dealership : Entity
    {
        public Dealership()
        {
            Vehicles = new Collection<Vehicle>();
            SalesPeople = new List<SalesPerson>();
        }

        public string Name { get; set; }
        public ICollection<Vehicle> Vehicles { get; private set; }
        public IList<SalesPerson> SalesPeople { get; }
        public int VehichlesSold => SalesPeople.Sum(salesPerson => salesPerson.Sales.Count);
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperQueryEF.Model
{
    public class Dealership : Entity
    {
        public Dealership()
        {
            Vehicles = new Collection<Vehicle>();
            SalesPeople = new Collection<SalesPerson>();   
        }

        public string Name { get; set; }
        public ICollection<Vehicle> Vehicles { get; private set; }
        public IList<SalesPerson> SalesPeople { get; }
        public int VehichlesSold => SalesPeople.Sum(salesPerson => salesPerson.VehiclesSold);
    }
}

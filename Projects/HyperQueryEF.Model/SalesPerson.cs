using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperQueryEF.Model
{
    public class SalesPerson : Person
    {
        public SalesPerson()
        {
            Sales = new List<Sale>();
        }

        public string SalesID { get; private set; }
        public IList<Sale> Sales { get; private set; }
        public int VehiclesSold { get; private set; }

        public Sale MakeSale(Vehicle vehicle, Customer customer, decimal salePrice)
        {
            var sale = new Sale
            {
                SalesPerson = this,
                Vehicle = vehicle,
                Customer = customer,
                Date = DateTime.Now,
                SalePrice = salePrice
            };

            Sales.Add(sale);

            return sale;
        }
    }
}

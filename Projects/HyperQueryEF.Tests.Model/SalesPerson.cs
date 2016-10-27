using System;
using System.Collections.Generic;

namespace HyperQueryEF.Tests.Model
{
    public class SalesPerson : Person
    {
        public SalesPerson(string salesId)
        {
            Sales = new List<Sale>();
        }

        public string SalesID { get; private set; }
        public IList<Sale> Sales { get; }
        public decimal Commission { get; private set; }

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

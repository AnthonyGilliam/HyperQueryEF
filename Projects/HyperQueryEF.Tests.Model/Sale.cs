using System;

namespace HyperQueryEF.Tests.Model
{
    public class Sale : Entity
    {
        public Vehicle Vehicle { get; set; }
        public Customer Customer { get; set; }
        public SalesPerson SalesPerson { get; set; }
        public DateTime Date { get; set; }
        public decimal SalePrice { get; set; }
    }
}

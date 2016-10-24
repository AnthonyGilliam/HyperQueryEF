using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperQueryEF.Model
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

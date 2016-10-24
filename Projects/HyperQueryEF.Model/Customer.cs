using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperQueryEF.Model
{
    public class Customer : Person
    {
        public Customer()
        {
            Purchases = new Collection<Sale>();
        }
        public ICollection<Sale> Purchases { get; private set; }
    }
}

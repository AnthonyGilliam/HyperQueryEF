using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HyperQueryEF.Tests.Model
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

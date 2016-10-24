using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperQueryEF.Model
{
    public abstract class Person : Entity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {MiddleName?[0]}. {LastName}";
    }
}

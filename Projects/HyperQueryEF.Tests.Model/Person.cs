using System;

namespace HyperQueryEF.Tests.Model
{
    public abstract class Person : Entity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {MiddleName?[0]}. {LastName}";
    }
}

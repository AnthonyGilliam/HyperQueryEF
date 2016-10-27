using System;

namespace HyperQueryEF.Tests.Model
{
    public abstract class Entity
    {
        protected Entity()
        {
            DateCreated = DateTime.Now;    
        }

        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

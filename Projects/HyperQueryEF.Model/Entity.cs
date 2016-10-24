using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperQueryEF.Model
{
    public abstract class Entity
    {
        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

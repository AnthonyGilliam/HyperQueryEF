using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HyperQueryEF.Model
{
    public class Motorcycle : Vehicle
    {
        public string BoreAndStroke { get; set; }
        public string CompressionRatio { get; set; }
        public int CurbWeight { get; set; }
    }
}

using System;

namespace HyperQueryEF.Tests.Model
{
    public class Motorcycle : Vehicle
    {
        public string BoreAndStroke { get; set; }
        public string CompressionRatio { get; set; }
        public int CurbWeight { get; set; }
    }
}

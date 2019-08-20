using System;

namespace OptionsPricer.Models
{
    public class BlacksCholes
    {
        public double S { get; set; }
        public double K { get; set; }
        public double t { get; set; }
        public double sigma { get; set; }
        public double r { get; set; }
        public double d1 { get; set; }
        public double d2 { get; set; }
        public double Put { get; set; }
        public double Call { get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    struct KeplerElements
    {
        public double a;//semimajor axis
        public double ecc;
        public double оmega;
        public double v;
        public double i;
        public double lgNode;

        public KeplerElements(double a, double ecc, double оmega, double v, double i, double lgNode)
        {
            this.a = a;
            this.ecc = ecc;
            this.оmega = оmega;
            this.v = v;
            this.i = i;
            this.lgNode = lgNode;
        }
    }
}

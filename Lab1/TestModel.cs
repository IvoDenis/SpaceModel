using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab1
{
    class TestModel : Model
    {
        public TestModel(double t0, double t1, double dt)
        {
            this.t0 = t0;
            this.t1 = t1;
            SamplingIncrement = dt;
            gsX0 = new TVector(new double[] { 0});
           

        }

        public override void AddResult(TVector X, double t)
        {
            if (!FileCreated())
            {
                sw = new StreamWriter("result.txt");
            }
            sw.WriteLine(X[0].ToString() + ' ' + t.ToString());
            sw.Flush();
            
        }

        public override TVector RightParts(TVector X, double t)
        {
            return new TVector(new double[] { Math.Cos(t) });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab1
{
    class SATModel : Model
    {
        private const double mu = 398600.44158;

        public SATModel(double t0, double t1, double h, KeplerElements elements)
        {
            this.t0 = t0;
            this.t1 = t1;
            SamplingIncrement = h;
            gsX0 = Converter.OscToVec(elements);
           

        }

        public override void AddResult(TVector x, double t)
        {
            if (!FileCreated())
            {
                sw = new StreamWriter("result.txt");
            }
            string str = String.Empty;
            foreach (var e in x.Vector)
            {
                str = String.Concat(str + e.ToString()) + " ";

            }
            str = String.Concat(str + t.ToString());
            sw.WriteLine(str);
            sw.Flush();
        }

        public override TVector RightParts(TVector X, double t)
        {
            var result = new double[X.Length()];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = i < 3 ? X[i + 3] : -mu * X[i - 3] / Math.Pow(Math.Sqrt(X[0] * X[0] + X[1] * X[1] + X[2] * X[2]), 3);
            }
            return new TVector(result);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class MoonModel : Model
    {
        const double mu = 398600.44158;
        public MoonModel(double t0, double t1, double h)
        {
            this.t0 = t0;
            this.t1 = t1;
            this.SamplingIncrement = h;
            var X0 = new double[6];
            X0[0] = -0.00080817732791148419*Converter.aeToKm;
            X0[1] = -0.00199463000162039941 * Converter.aeToKm;
            X0[2] = -0.00108726266083810178 * Converter.aeToKm;
            X0[3] = 0.00060108481665912983*Converter.aedayToKmSec;
            X0[4] = -0.00016744546061515148 * Converter.aedayToKmSec;
            X0[5] = -0.00008556214497398616 * Converter.aedayToKmSec;
            gsX0 = new TVector(X0);
        }

        public override void AddResult(TVector x, double t)
        {
            if (!FileCreated())
            {
                sw = new System.IO.StreamWriter("result.txt");
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

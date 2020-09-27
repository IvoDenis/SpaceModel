using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class EarthModel : Model
    {
        const double mu = 132712440018;
        public EarthModel(double  t0, double t1,double h )
        {
            this.t0 = t0;
            this.t1 = t1;
            this.SamplingIncrement = h;
            var X0 = new double[6]; 
            X0[0] = -2.566123740124270e7;
            X0[1] = 1.339350231544666e8;
            X0[2] = 5.805149372446711e7;
            X0[3] = -2.983549561177192 * 10;
            X0[4] = -4.846747552523134;
            X0[5] = -2.100585886567924;
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

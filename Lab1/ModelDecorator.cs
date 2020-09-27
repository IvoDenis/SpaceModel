using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    abstract class ModelDecorator : Model
    {
        protected Model decorated;

        protected ModelDecorator(Model decorated, double t0, double t1, double dt)
        {
            this.decorated = decorated;
            this.t0 = t0;
            this.t1 = t1;
            this.SamplingIncrement = dt;

        }
    }
    class LunarDecorator : ModelDecorator
    {
        MoonModel moon;
        public LunarDecorator(Model decorated, double t0, double t1, double dt) : base(decorated, t0, t1, dt)
        {
            moon = new MoonModel(t0, t1, dt);
            gsX0 = (TVector)decorated.gsX0.Concat(moon.gsX0);
        }

        public override void AddResult(TVector x, double t)
        {
            if (!FileCreated())
            {
                sw = new System.IO.StreamWriter("resultMoonDec.txt");
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
            double muMoon = 4902.8000;

            TVector objectVector = new TVector(X.Vector.Take(X.Length() - 6)
                                                       .ToArray());
            TVector moonVector = new TVector(X.Vector.Skip(X.Length() - 6)
                                                     .Take(6)
                                                     .ToArray());
            TVector bufDecoratedRP = decorated.RightParts(objectVector, t);
            TVector bufMoonRP = moon.RightParts(moonVector, t);
            TVector delta = moonVector.Take(3) - objectVector.Take(3);
            double R = moonVector.Take(3).Norm();
            double distance = delta.Norm();
         
            for (int i = 3; i < 6; i++)
            {
                bufDecoratedRP[i] += muMoon * (delta[i - 3] / Math.Pow(distance, 3) - moonVector[i - 3] / Math.Pow(R, 3));
            }
            return bufDecoratedRP.Concat(bufMoonRP);

        }
    }
    class SolarDecorator : ModelDecorator
    {
        EarthModel earth;

        public SolarDecorator(Model decorated, double t0, double t1, double dt) : base(decorated, t0, t1, dt)
        {
            earth = new EarthModel(t0, t1, dt);
            gsX0 = decorated.gsX0.Concat(earth.gsX0);
        }

        public override void AddResult(TVector x, double t)
        {
            if (!FileCreated())
            {
                sw = new System.IO.StreamWriter("resultSunDec.txt");
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
            double mus = 132712440018; 
            TVector objectVector = new TVector(X.Vector.Take(X.Length() - 6).ToArray());
            TVector earthVector = new TVector(X.Vector.Skip(X.Length() - 6).ToArray());
            TVector bufDecoratedRP = decorated.RightParts(objectVector, t);
            TVector bufEarthRP = earth.RightParts(earthVector, t);
            TVector HelioVector = Converter.GeoToHelio(objectVector.Take(3), earthVector.Take(3));
            double distance = HelioVector.Norm();
            double R = Math.Pow(earthVector.Take(3).Norm(), 3);
            for (int i = 3; i < 6; i++)
            {
                bufDecoratedRP[i] += mus * (HelioVector[i - 3] / Math.Pow(distance, 3) - (earthVector[i - 3] / R));
            }
            return bufDecoratedRP.Concat(bufEarthRP);

        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    static class Converter
    {
        public static Double  mu =398600.44158;
         public static  double aeToKm =1.496e+8;
        public static Double aedayToKmSec = 1.731e+3;
        public static TVector GeoToHelio(TVector X,TVector EarthX )
        {
            return EarthX + X;
        }
        public static TMatrix TransformMatrix(KeplerElements elements)
        {
            var A = new double[3, 3];
            var u = elements.оmega + elements.v;
            A[0, 0] = Math.Cos(u) * Math.Cos(elements.lgNode) - Math.Sin(u) * Math.Sin(elements.lgNode) * Math.Cos(elements.i);
            A[0, 1] = -Math.Sin(u) * Math.Cos(elements.lgNode) - Math.Cos(u) * Math.Sin(elements.lgNode) * Math.Cos(elements.i);
            A[0, 2] = Math.Sin(elements.lgNode) * Math.Sin(elements.i);
            A[1, 0] = Math.Cos(u) * Math.Sin(elements.lgNode) + Math.Sin(u) * Math.Cos(elements.lgNode) * Math.Cos(elements.i);
            A[1, 1] = -Math.Sin(u) * Math.Sin(elements.lgNode) + Math.Cos(u) * Math.Cos(elements.lgNode) * Math.Cos(elements.i);
            A[1, 2] = -Math.Cos(elements.lgNode) * Math.Sin(elements.i);
            A[2, 0] = Math.Sin(u) * Math.Sin(elements.i);
            A[2, 1] = Math.Cos(u) * Math.Sin(elements.i);
            A[2, 2] = Math.Cos(elements.i);
            return new TMatrix(A);
        }
        public static TVector OscToVec(KeplerElements elements)
        {
            var A = TransformMatrix(elements);
            var p = elements.a * (1 - Math.Pow(elements.ecc, 2));
            TVector bufR = new TVector(new double[] {
                                                p/(1+elements.ecc*Math.Cos(elements.v))
                                                ,0
                                                ,0});
            TVector bufV = new TVector(new double[] {
                                              Math.Sqrt(mu/p)*elements.ecc*Math.Sin(elements.v)
                                              , Math.Sqrt(mu/p)*(1+elements.ecc*Math.Cos(elements.v))
                                                ,0});
            var r = A * bufR;
            var v = A * bufV;
            return new TVector(r.Vector.Concat(v.Vector).ToArray() );
        }
        public static KeplerElements VecToOsc(TVector vector)
        {
            throw new Exception();//
        }
    }
}

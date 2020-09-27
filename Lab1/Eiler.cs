namespace Lab1
{
    class Eiler: TIntegrator
    {
        public Eiler()
        {
        }

        public override void Run(Model model)
        {
            var X = model.gsX0;
            var t0 = model.t0;
            var t = t0;
            var tk = model.t1;
            var dt = model.SamplingIncrement;
             while (t<tk)
            {
                X += model.RightParts(X, t) * dt;
                model.AddResult(X, t);
                t += dt; 
           }
        }
    }
}

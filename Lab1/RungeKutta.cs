namespace Lab1
{
    class RungeKutta : TIntegrator
    {
        public RungeKutta()
        {
        }

        public override void Run(Model model)
        {
            var X = model.gsX0;
            var t0 = model.t0;
            var t = t0;
            var tk = model.t1;
            var dt = model.SamplingIncrement;
            while (t < tk)
            {
                var K1 = model.RightParts(X, t);
                var K2 = model.RightParts(X + dt / 2 * K1, t + 0.5 * dt);
                var K3 = model.RightParts(X + dt / 2 * K2, t + 0.5 * dt);
                var K4 = model.RightParts(X + dt / 2 * K3, t + dt);
                X += dt / 6.0 * (K1 + 2 * K2 + 2 * K3 + K4);
                model.AddResult(X, t);
                t += dt;
            }
        }
    }

}

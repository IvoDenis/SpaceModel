using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Lab1
{
    abstract class TIntegrator
    {
        protected double eps;
        public TIntegrator()
        {
            eps = 1e-4;
        }
        public abstract void Run(Model model);
    }

}

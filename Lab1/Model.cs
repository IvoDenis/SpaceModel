using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab1
{
    abstract class Model
    {

        // Начальные условия
        private TVector x0;
        protected StreamWriter sw;
        // Требуемый от интегратора интервал выдачи результатов
        public double SamplingIncrement;
        // Начало и окончание времени интегрирования
        public double t0, t1;



        public TVector gsX0 { get => x0; set => x0 = value; }

        public Model()
        {
            SamplingIncrement = 1e-1;
            t0 = 0;
            t1 = 20;
   
            

        }
        public bool FileCreated()
        {
            return sw != null;
        }
        public void CloseFile()
        {
            sw.Close();
        }
        public abstract void AddResult(TVector x, double t);

        public abstract TVector RightParts(TVector X, double t);
    }
}

using System;
using System.Linq;


namespace Lab1
{
    class TDormanPrince : TIntegrator
    {

        private double[][] a;
        private double[] c;
        private double[] b1;
        private double[] b2;
        TVector[] K = new TVector[7];
        double u;

        public TDormanPrince()
        {


            c = new double[] { 0, 1.0 / 5, 3.0 / 10, 4.0 / 5, 8.0 / 9, 1, 1 };
            a = new double[][] {
                                  new double []   { 0.0 },
                                  new double []  { 1.0/5 },
                                  new double []   { 3.0/40, 9.0/40 },
                                  new double [] { 44.0/45, -56.0/15, 32.0/9 },
                                  new double [4] { 19372.0/6561, -25360.0/2187, 64448.0/6561, -212.0/729 },
                                  new double [5] { 9017.0/3168, -355.0/33, 46732.0/5247, 49.0/176, -5103.0/18656 },
                                  new double [6] { 35.0/384, 0, 500.0/1113, 125.0/192, -2187.0/6784, 11.0/84 }
                                  };



            b1 = new double[7]
                { 35.0 / 384, 0, 500.0/ 1113, 125.0/ 192, -2187.0/ 6784, 11.0/ 84, 0 };
            b2 = new double[7]
                { 5179.0/57600, 0, 7571.0/16695, 393.0/640, -92097.0/339200, 187.0/2100, 1.0/40 };

            // Определение машинного нуля
            double v = 1;
            while (1 + v > 1)
            {
                u = v;
                v = v / 2;
            }

        }
        public override void Run(Model model)
        {
            double // Это время для интегрирования (увеличивается на величину шага интегрирования)
                           t = model.t0,
                           // Это время для выдачи (увеличивается дискретно на величину плотности)
                           t_out = t,
                           // Это конечное время
                           t1 = model.t1,
                           // Это шаг интегрирования
                           h,
                           // Это шаг после коррекции (инициализируются плотностью выдачи результатов)
                           h_new = model.SamplingIncrement,
                           // Это ошибка на шаге интегрирования
                           e = 0;

            TVector // это вектор состояния на конец шага интегрирования
                    X = model.gsX0,
            // это вектор состояния на конец шага интегрирования (решение 4-го порядка)
            X1,
            // Это вектор состояния на конец шага для коррекции величины шага (решение 5-го порядка)
            X2,
            // Это вектор для выдачи рез-тов
            Xout;



            // Счётчик количества сделанных шагов
            int N = 0;

            // Главный цикл
            while (t < t1)
            {

                // Устанавливаем шаг на итерацию
                h = h_new;

                // Вычисляем коэф-ты К
                K[0] = model.RightParts(X, t);
                K[1] = model.RightParts(X + (K[0] * h * a[1][0]), t + c[1] * h);
                K[2] = model.RightParts(X + (K[0] * a[2][0] + K[1] * a[2][1]) * h, t + c[2] * h);
                K[3] = model.RightParts(X + (K[0] * a[3][0] + K[1] * a[3][1] + K[2] * a[3][2]) * h, t + c[3] * h);
                K[4] = model.RightParts(X + (K[0] * a[4][0] + K[1] * a[4][1] + K[2] * a[4][2] + K[3] * a[4][3]) * h, t + c[4] * h);
                K[5] = model.RightParts(X + (K[0] * a[5][0] + K[1] * a[5][1] + K[2] * a[5][2] + K[3] * a[5][3] + K[4] * a[5][4]) * h, t + c[5] * h);
                K[6] = model.RightParts(X + (K[0] * a[6][0] + K[1] * a[6][1] + K[2] * a[6][2] + K[3] * a[6][3] + K[4] * a[6][4] + K[5] * a[6][5]) * h, t + c[6] * h);
                // Вычисляем решения 4-го и 5-го порядков
                X1 = X;
                X2 = X;
                for (int i = 0; i < 7; i++)
                {
                    X1 = X1 + K[i] * h * b1[i];
                    X2 = X2 + K[i] * h * b2[i];
                }

                // Вычисляем значение локальной ошибки

                e = 0;

                for (int i = 0; i < X.Vector.Length; i++)
                {
                    double[] buf1 = new double[2]
                    {
                        Math.Abs(X.Vector[i]), Math.Abs(X1.Vector[i])
                    };
                    double[] buf2 = new double[2]
                    {
                        1e-5 , 0.25*u/eps
                    };
                    double[] buf = new double[2]
                    {
                         buf1.Max(), buf2.Max()
                    };


                    e += Math.Pow(h * (X1.Vector[i] - X2.Vector[i]) / buf.Max(), 2);
                }
                e = Math.Sqrt(e / X.Vector.Length);

                // вычисляем новое значение шага
                double[] buf3 = new double[2]
                {
                    5.0, Math.Pow(e / eps, 0.1) / 0.5
                };

                double den_h = buf3.Min();
                double[] buf4 = new double[2]
                {
                    0.1, den_h
                };
                double den = buf4.Max();
                h_new = h / den;


                // Если локальная ошибка превышает установленную величину, пытаемся сделать шаг заново
                if (e > eps)


                    continue;

                // Формирование рез-тов при помощи механизмов плотной выдачи
                while ((t_out < t + h) && (t_out <= t1))
                {
                    double theta = (t_out - t) / h;
                    double[] b = new double[6];
                    // Расчитываем коэф-ты плотной выдачи
                    b[0] = theta * (1 + theta * (-1337.0 / 480 + theta * (1039.0 / 360.0) + theta * (-1163.0 / 1152.0)));
                    b[1] = 0.0;
                    b[2] = 100.0 * theta * theta * (1054.0 / 9275.0 + theta * (-4682.0 / 27825.0 + theta * (379.0 / 5565.0))) / 3.0;
                    b[3] = -5.0 * theta * theta * (27.0 / 40.0 + theta * (-9.0 / 5.0 + theta * (83.0 / 96.0))) / 2.0;
                    b[4] = 18225.0 * theta * theta * (-3.0 / 250.0 + theta * (22.0 / 375.0 + theta * (-37.0 / 600.0))) / 848.0;
                    b[5] = -22.0 * theta * theta * (-3.0 / 10.0 + theta * (29.0 / 30.0 + theta * (-17.0 / 24.0))) / 7.0;

                    // Получаем рез-тат для выдачи
                    
                    TVector mult = new TVector((K[0] * b[0]).Vector);
                    for (int i = 1; i < 6; i++)
                    {
                        mult = mult + (K[i] * b[i]);
                    }
                    Xout = X + mult * h;

                    // Передача рез-тов в модель
                    //  

                    model.AddResult(Xout, t_out);
                    // Наращиваем время выдачи

                    t_out = t_out + model.SamplingIncrement;


                }

                // Обновлем Х решением 5-го порядка и наращиваем время на величину сделанного шага
                X = X1;
                t += h;


                // Считаем количество итераций для вычисления глобальной погрешности
                N++;
            }
            model.CloseFile();
        }
    }
}

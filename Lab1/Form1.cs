using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Reflection;
namespace Lab1
{
    public partial class Form1 : Form
    {
        Model model;
        List<Series> hiddenSeries = new List<Series>();
        public Form1()
        {
            InitializeComponent();
            SetupControls();


        }
        private void SetupControls()
        {
            buttonRun.Text = "Моделировать";
            buttonGraphics.Text = "Построить график";
            Type integratorType = typeof(TIntegrator);
            IEnumerable<Type> listIntegrator = Assembly.GetAssembly(integratorType).GetTypes()
                                                                                   .Where(type => type.IsSubclassOf(integratorType));
            foreach (var type in listIntegrator)
            {
                integratorBox.Items.Add(type.Name);
            }
            Type modelType = typeof(Model);
            IEnumerable<Type> listModel = Assembly.GetAssembly(modelType).GetTypes()
                                                                         .Where(type => type.BaseType == modelType && !type.IsAbstract);
            foreach (var type in listModel)
            {
                modelBox.Items.Add(type.Name);
            }
            modelBox.Items.Add("deltaOrbit");
            modelBox.SelectedIndex = 3;
            textSemiMajorAxis.Text = "15000";
            textBoxArgPer.Text = "65";
            textBoxAscNode.Text = "256";
            textBoxEcc.Text = "0,2";
            textBoxInclination.Text = "15";
            textBoxTrueAnomaly.Text = "31";
            chartResult.MouseWheel += chart1_MouseWheel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double time = Double.Parse(textBoxTime.Text);
            double dt = Double.Parse(textBoxDt.Text);
            Func<double, double> gradtorad = grad => grad * Math.PI / 180;
            KeplerElements InitElement;
            switch (modelBox.SelectedIndex)
            {
                case 0:
                    model = new EarthModel(0, time, dt);
                    break;
                case 1:
                    model = new MoonModel(0, time, dt);
                    break;
                case 2:
                    InitElement = new KeplerElements(Double.Parse(textSemiMajorAxis.Text),
                                               Double.Parse(textBoxEcc.Text),
                                                gradtorad(Double.Parse(textBoxArgPer.Text)),
                                                gradtorad(Double.Parse(textBoxTrueAnomaly.Text)),
                                                gradtorad(Double.Parse(textBoxInclination.Text)),
                                                gradtorad(Double.Parse(textBoxAscNode.Text)));
                    model = new SATModel(0, time, dt, InitElement);
                    break;
                case 3:
                    model = new TestModel(0, time, dt);
                    break;
                case 4:
                    InitElement = new KeplerElements(Double.Parse(textSemiMajorAxis.Text),
                                              Double.Parse(textBoxEcc.Text),
                                               gradtorad(Double.Parse(textBoxArgPer.Text)),
                                               gradtorad(Double.Parse(textBoxTrueAnomaly.Text)),
                                               gradtorad(Double.Parse(textBoxInclination.Text)),
                                               gradtorad(Double.Parse(textBoxAscNode.Text)));
                    model = new SATModel(0, time, dt, InitElement);

                    break;
            }


            TIntegrator integrator = null;
            switch (integratorBox.SelectedIndex)
            {
                case 0:
                    integrator = new Eiler();
                    break;
                case 1:
                    integrator = new RungeKutta();
                    break;
                case 2:
                    integrator = new TDormanPrince();
                    break;
                default:
                    integrator = new TDormanPrince();
                    break;
            }
            if (modelBox.SelectedIndex == 4)
            {
                Model modelWithDec = null;
                if (checkBoxSolar.Checked)
                    modelWithDec = new SolarDecorator(model, 0, time, dt);
                if (checkBoxLunar.Checked)
                    modelWithDec = new LunarDecorator(model, 0, time, dt);
                integrator.Run(modelWithDec);
                modelWithDec.CloseFile();
                boxAxisY.Items.AddRange(new string[] { "dx", "dy", "dz" });
            }
            else
            {

                if (checkBoxSolar.Checked)
                    model = new SolarDecorator(model, 0, time, dt);
                if (checkBoxLunar.Checked)
                    model = new LunarDecorator(model, 0, time, dt);
            }
            integrator.Run(model);
            model.CloseFile();
            UpdateComboBox();


        }

        void UpdateComboBox()
        {
            boxAxisX.Items.Clear();
            boxAxisY.Items.Clear();
            switch (modelBox.SelectedIndex)
            {
                case 3:
                    boxAxisX.Items.Add("x");
                    boxAxisX.Items.Add("t");
                    boxAxisY.Items.Add("x");
                    boxAxisY.Items.Add("t");
                    boxAxisY.SelectedIndex = 0;
                    boxAxisX.SelectedIndex = 1;
                    break;

                default:
                    boxAxisX.Items.Add("x");
                    boxAxisX.Items.Add("y");
                    boxAxisX.Items.Add("z");
                    boxAxisX.Items.Add("t");
                    boxAxisY.Items.Add("x");
                    boxAxisY.Items.Add("y");
                    boxAxisY.Items.Add("z");
                    boxAxisY.Items.Add("t");
                    boxAxisY.SelectedIndex = 1;
                    boxAxisX.SelectedIndex = 0;
                    if (modelBox.SelectedIndex == 4)
                    {
                        boxAxisY.Items.AddRange(new string[] { "dx", "dy", "dz" });
                    }
                    break;
            }
        }
        private string[] readFile(StreamReader reader)
        {
            var text = reader.ReadToEnd();
            string[] stringSeparators = new string[] { "\r\n" };
            return text.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
        }
        Series CreateSeries(string[] arraystring, string name)
        {
            Series mySeriesOfPoint = new Series($"{name}");
            mySeriesOfPoint.ChartType = SeriesChartType.Line;
            var AxisX = boxAxisX.SelectedIndex;
            var AxisY = boxAxisY.SelectedIndex;
            foreach (var str in arraystring)
            {
                var splitstr = Array.ConvertAll(str.Split(' '), p => Double.Parse(p));
                if ((boxAxisY.SelectedIndex <= 3))
                {
                    AxisX = (splitstr.Length > 2) && (boxAxisX.SelectedIndex == 3) ? splitstr.Length - 1 : AxisX;
                    AxisY = (splitstr.Length > 2) && (boxAxisY.SelectedIndex == 3) ? splitstr.Length - 1 : AxisY;
                    mySeriesOfPoint.Points.AddXY(splitstr[AxisX], splitstr[AxisY]);
                }
            }
            return mySeriesOfPoint;
        }
        Series DeltaSeries(string[] arraystring, string[] arraystring1)
        {
            List<double[]> centralVec = new List<double[]>();
            foreach (var str in arraystring)
            {
                var splitstr = Array.ConvertAll(str.Split(' '), p => Double.Parse(p));
                centralVec.Add(splitstr);
            }
            List<double[]> decoratorVec = new List<double[]>();
            foreach (var str in arraystring1)
            {
                var splitstr = Array.ConvertAll(str.Split(' '), p => Double.Parse(p));
                decoratorVec.Add(splitstr);
            }
            var AxisX = 6;
            var AxisY = boxAxisY.SelectedIndex - 4;
            Series mySeriesOfPoint = new Series($"");
            for (int i = 0; i < centralVec.Count(); i++)
            {
                var varX = centralVec[i][AxisX];
                var varY = Math.Abs(centralVec[i][AxisY] - decoratorVec[i][AxisY]);
                mySeriesOfPoint.ChartType = SeriesChartType.Line;
                mySeriesOfPoint.Points.AddXY(varX, varY);
            }
            return mySeriesOfPoint;

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (modelBox.SelectedItem == "deltaOrbit")
            {
                StreamReader reader = new StreamReader("result.txt");
                chartResult.Series.Clear();
                var arraystring = readFile(reader);
                string[] arraystring1 = null;
                reader.Close();
                if (checkBoxSolar.Checked)
                {
                    reader = new StreamReader("resultSunDec.txt");
                    arraystring1 = readFile(reader);
                }
                if (checkBoxLunar.Checked)
                {
                    reader = new StreamReader("resultMoonDec.txt");
                    arraystring1 = readFile(reader);

                }
                reader.Close();
                if (boxAxisY.SelectedIndex <= 3)
                {
                    Series series = CreateSeries(arraystring, "Main");
                    Series series1 = CreateSeries(arraystring1, "Dec");

                    chartResult.Series.Add(series);
                    chartResult.Series.Add(series1);
                }
                else
                {

                    var deltaSeries = DeltaSeries(arraystring, arraystring1);
                    chartResult.Series.Add(deltaSeries);
                }
                reader.Close();

            }
            else
            {

                StreamReader reader = new StreamReader("result.txt");
                chartResult.Series.Clear();

                if (checkBoxSolar.Checked)
                {
                    reader.Close();
                    reader = new StreamReader("resultSunDec.txt");
                }
                if (checkBoxLunar.Checked)
                {
                    reader.Close();
                    reader = new StreamReader("resultMoonDec.txt");

                }
                var arraystring = readFile(reader);
                reader.Close();
                var series = CreateSeries(arraystring, "");
                chartResult.Series.Add(series);
            }
            chartResult.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chartResult.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

        }
        private void chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            var chart = (Chart)sender;
            var xAxis = chart.ChartAreas[0].AxisX;
            var yAxis = chart.ChartAreas[0].AxisY;

            try
            {
                if (e.Delta < 0)
                {
                    xAxis.ScaleView.ZoomReset();
                    yAxis.ScaleView.ZoomReset();
                }
                else if (e.Delta > 0)
                {
                    var xMin = xAxis.ScaleView.ViewMinimum;
                    var xMax = xAxis.ScaleView.ViewMaximum;
                    var yMin = yAxis.ScaleView.ViewMinimum;
                    var yMax = yAxis.ScaleView.ViewMaximum;

                    var posXStart = xAxis.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 2;
                    var posXFinish = xAxis.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 2;
                    var posYStart = yAxis.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 2;
                    var posYFinish = yAxis.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 2;

                    xAxis.ScaleView.Zoom(posXStart, posXFinish);
                    yAxis.ScaleView.Zoom(posYStart, posYFinish);
                }
            }
            catch { }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            chartResult.Height = control.Height - 100;
        }

        private void modelBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBoxSolar.Checked = false;
            checkBoxLunar.Checked = false;
            switch (modelBox.SelectedIndex)
            {

                case 2:
                    checkBoxSolar.Enabled = true;
                    checkBoxLunar.Enabled = true;
                    break;
                case 1:
                    checkBoxSolar.Enabled = true;
                    checkBoxLunar.Enabled = false;
                    break;
                case 4:
                    checkBoxSolar.Enabled = true;
                    checkBoxLunar.Enabled = true;
                    break;
                default:
                    checkBoxSolar.Enabled = false;
                    checkBoxLunar.Enabled = false;

                    break;

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chartResult_Click(object sender, EventArgs e)
        {
 
        }
    }
}

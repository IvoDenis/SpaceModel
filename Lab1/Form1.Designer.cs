namespace Lab1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.label10 = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.textBoxDt = new System.Windows.Forms.TextBox();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.checkBoxLunar = new System.Windows.Forms.CheckBox();
            this.checkBoxSolar = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.integratorBox = new System.Windows.Forms.ComboBox();
            this.modelBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTrueAnomaly = new System.Windows.Forms.TextBox();
            this.textBoxInclination = new System.Windows.Forms.TextBox();
            this.textBoxAscNode = new System.Windows.Forms.TextBox();
            this.textBoxArgPer = new System.Windows.Forms.TextBox();
            this.textBoxEcc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textSemiMajorAxis = new System.Windows.Forms.TextBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.boxAxisX = new System.Windows.Forms.ComboBox();
            this.buttonGraphics = new System.Windows.Forms.Button();
            this.boxAxisY = new System.Windows.Forms.ComboBox();
            this.chartResult = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartResult)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.label10);
            this.splitContainer.Panel1.Controls.Add(this.labelTime);
            this.splitContainer.Panel1.Controls.Add(this.textBoxDt);
            this.splitContainer.Panel1.Controls.Add(this.textBoxTime);
            this.splitContainer.Panel1.Controls.Add(this.checkBoxLunar);
            this.splitContainer.Panel1.Controls.Add(this.checkBoxSolar);
            this.splitContainer.Panel1.Controls.Add(this.label8);
            this.splitContainer.Panel1.Controls.Add(this.label7);
            this.splitContainer.Panel1.Controls.Add(this.integratorBox);
            this.splitContainer.Panel1.Controls.Add(this.modelBox);
            this.splitContainer.Panel1.Controls.Add(this.label1);
            this.splitContainer.Panel1.Controls.Add(this.label2);
            this.splitContainer.Panel1.Controls.Add(this.label3);
            this.splitContainer.Panel1.Controls.Add(this.label4);
            this.splitContainer.Panel1.Controls.Add(this.label6);
            this.splitContainer.Panel1.Controls.Add(this.textBoxTrueAnomaly);
            this.splitContainer.Panel1.Controls.Add(this.textBoxInclination);
            this.splitContainer.Panel1.Controls.Add(this.textBoxAscNode);
            this.splitContainer.Panel1.Controls.Add(this.textBoxArgPer);
            this.splitContainer.Panel1.Controls.Add(this.textBoxEcc);
            this.splitContainer.Panel1.Controls.Add(this.label5);
            this.splitContainer.Panel1.Controls.Add(this.textSemiMajorAxis);
            this.splitContainer.Panel1.Controls.Add(this.buttonRun);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panel1);
            this.splitContainer.Panel2.Controls.Add(this.chartResult);
            this.splitContainer.Size = new System.Drawing.Size(800, 599);
            this.splitContainer.SplitterDistance = 266;
            this.splitContainer.SplitterWidth = 6;
            this.splitContainer.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 352);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(179, 17);
            this.label10.TabIndex = 27;
            this.label10.Text = "Шаг интегрирования (сек)";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(16, 305);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(190, 17);
            this.labelTime.TabIndex = 26;
            this.labelTime.Text = "Время моделирования(сек)";
            // 
            // textBoxDt
            // 
            this.textBoxDt.Location = new System.Drawing.Point(17, 372);
            this.textBoxDt.Name = "textBoxDt";
            this.textBoxDt.Size = new System.Drawing.Size(101, 22);
            this.textBoxDt.TabIndex = 25;
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(17, 327);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(101, 22);
            this.textBoxTime.TabIndex = 24;
            // 
            // checkBoxLunar
            // 
            this.checkBoxLunar.AutoSize = true;
            this.checkBoxLunar.Location = new System.Drawing.Point(12, 456);
            this.checkBoxLunar.Name = "checkBoxLunar";
            this.checkBoxLunar.Size = new System.Drawing.Size(217, 21);
            this.checkBoxLunar.TabIndex = 23;
            this.checkBoxLunar.Text = "добавить воздействие Луны";
            this.checkBoxLunar.UseVisualStyleBackColor = true;
            // 
            // checkBoxSolar
            // 
            this.checkBoxSolar.AutoSize = true;
            this.checkBoxSolar.Location = new System.Drawing.Point(12, 429);
            this.checkBoxSolar.Name = "checkBoxSolar";
            this.checkBoxSolar.Size = new System.Drawing.Size(231, 21);
            this.checkBoxSolar.TabIndex = 22;
            this.checkBoxSolar.Text = "добавить воздействие Солнца";
            this.checkBoxSolar.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 552);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Модель";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 520);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Интегратор";
            // 
            // integratorBox
            // 
            this.integratorBox.FormattingEnabled = true;
            this.integratorBox.Location = new System.Drawing.Point(129, 517);
            this.integratorBox.Name = "integratorBox";
            this.integratorBox.Size = new System.Drawing.Size(121, 24);
            this.integratorBox.TabIndex = 19;
            // 
            // modelBox
            // 
            this.modelBox.FormattingEnabled = true;
            this.modelBox.IntegralHeight = false;
            this.modelBox.Location = new System.Drawing.Point(129, 546);
            this.modelBox.Name = "modelBox";
            this.modelBox.Size = new System.Drawing.Size(121, 24);
            this.modelBox.TabIndex = 18;
            this.modelBox.TabStop = false;
            this.modelBox.SelectedIndexChanged += new System.EventHandler(this.modelBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Большая полуось (км)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Эксцентриситет";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Аргумент перицентра(градусы)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(252, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Долгота восходящего узла (градусы)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(208, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Истинная аномалия (градусы)";
            // 
            // textBoxTrueAnomaly
            // 
            this.textBoxTrueAnomaly.Location = new System.Drawing.Point(19, 271);
            this.textBoxTrueAnomaly.Name = "textBoxTrueAnomaly";
            this.textBoxTrueAnomaly.Size = new System.Drawing.Size(101, 22);
            this.textBoxTrueAnomaly.TabIndex = 6;
            // 
            // textBoxInclination
            // 
            this.textBoxInclination.Location = new System.Drawing.Point(19, 226);
            this.textBoxInclination.Name = "textBoxInclination";
            this.textBoxInclination.Size = new System.Drawing.Size(101, 22);
            this.textBoxInclination.TabIndex = 5;
            // 
            // textBoxAscNode
            // 
            this.textBoxAscNode.Location = new System.Drawing.Point(17, 179);
            this.textBoxAscNode.Name = "textBoxAscNode";
            this.textBoxAscNode.Size = new System.Drawing.Size(101, 22);
            this.textBoxAscNode.TabIndex = 4;
            // 
            // textBoxArgPer
            // 
            this.textBoxArgPer.Location = new System.Drawing.Point(19, 134);
            this.textBoxArgPer.Name = "textBoxArgPer";
            this.textBoxArgPer.Size = new System.Drawing.Size(101, 22);
            this.textBoxArgPer.TabIndex = 3;
            // 
            // textBoxEcc
            // 
            this.textBoxEcc.Location = new System.Drawing.Point(17, 89);
            this.textBoxEcc.Name = "textBoxEcc";
            this.textBoxEcc.Size = new System.Drawing.Size(101, 22);
            this.textBoxEcc.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Наклонение (градусы)";
            // 
            // textSemiMajorAxis
            // 
            this.textSemiMajorAxis.Location = new System.Drawing.Point(19, 37);
            this.textSemiMajorAxis.Name = "textSemiMajorAxis";
            this.textSemiMajorAxis.Size = new System.Drawing.Size(101, 22);
            this.textSemiMajorAxis.TabIndex = 1;
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(18, 400);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(100, 23);
            this.buttonRun.TabIndex = 0;
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.boxAxisX);
            this.panel1.Controls.Add(this.buttonGraphics);
            this.panel1.Controls.Add(this.boxAxisY);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 532);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 67);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // boxAxisX
            // 
            this.boxAxisX.FormattingEnabled = true;
            this.boxAxisX.Location = new System.Drawing.Point(3, 22);
            this.boxAxisX.Name = "boxAxisX";
            this.boxAxisX.Size = new System.Drawing.Size(121, 24);
            this.boxAxisX.TabIndex = 1;
            // 
            // buttonGraphics
            // 
            this.buttonGraphics.Location = new System.Drawing.Point(269, 21);
            this.buttonGraphics.Name = "buttonGraphics";
            this.buttonGraphics.Size = new System.Drawing.Size(247, 23);
            this.buttonGraphics.TabIndex = 7;
            this.buttonGraphics.Text = "button2";
            this.buttonGraphics.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonGraphics.UseVisualStyleBackColor = true;
            this.buttonGraphics.Click += new System.EventHandler(this.button2_Click);
            // 
            // boxAxisY
            // 
            this.boxAxisY.FormattingEnabled = true;
            this.boxAxisY.Location = new System.Drawing.Point(142, 21);
            this.boxAxisY.Name = "boxAxisY";
            this.boxAxisY.Size = new System.Drawing.Size(121, 24);
            this.boxAxisY.TabIndex = 2;
            // 
            // chartResult
            // 
            chartArea1.Name = "ChartArea1";
            this.chartResult.ChartAreas.Add(chartArea1);
            this.chartResult.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.chartResult.Legends.Add(legend1);
            this.chartResult.Location = new System.Drawing.Point(0, 0);
            this.chartResult.Name = "chartResult";
            this.chartResult.Size = new System.Drawing.Size(528, 537);
            this.chartResult.TabIndex = 8;
            this.chartResult.Text = "chart1";
            this.chartResult.Click += new System.EventHandler(this.chartResult_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 599);
            this.Controls.Add(this.splitContainer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TextBox textBoxTrueAnomaly;
        private System.Windows.Forms.TextBox textBoxInclination;
        private System.Windows.Forms.TextBox textBoxAscNode;
        private System.Windows.Forms.TextBox textBoxArgPer;
        private System.Windows.Forms.TextBox textBoxEcc;
        private System.Windows.Forms.TextBox textSemiMajorAxis;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonGraphics;
        private System.Windows.Forms.ComboBox boxAxisY;
        private System.Windows.Forms.ComboBox boxAxisX;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartResult;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox modelBox;
        private System.Windows.Forms.ComboBox integratorBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxLunar;
        private System.Windows.Forms.CheckBox checkBoxSolar;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.TextBox textBoxDt;
    }
}


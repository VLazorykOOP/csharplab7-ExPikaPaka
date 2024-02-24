using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graph {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            // Colors
            colorDialog1.Color = Color.DarkMagenta;
            button1.BackColor = Color.DarkMagenta;
            button4.BackColor = Color.Black;
            button5.BackColor = Color.FromArgb(255, 150, 150, 150);

            // Slider
            trackBar1.Value = 50;

            // Timer
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;

            plot();
        }

        // Colors
        Color lineColor = Color.DarkMagenta;
        Color textAndGridColor = Color.Black;
        Color backgroundColor = Color.FromArgb(255, 180, 180, 180);

        // Color buttons
        private void button1_Click(object sender, EventArgs e) {
            colorDialog1.ShowDialog();
            button1.BackColor = colorDialog1.Color;
            lineColor = colorDialog1.Color; 
        }
        private void button4_Click(object sender, EventArgs e) {
            colorDialog1.ShowDialog();
            button4.BackColor = colorDialog1.Color;
            textAndGridColor = colorDialog1.Color;
        }
        private void button5_Click(object sender, EventArgs e) {
            colorDialog1.ShowDialog();
            button5.BackColor = colorDialog1.Color;
            backgroundColor = colorDialog1.Color;
        }


        // Graphic
        private double xS = -2;
        private double xE = 0;
        private double step = 0.01;
        
        void plot() {
            // Create new series
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;

            series.Color = lineColor;
            series.BorderWidth = 3;

            // Add points to the series
            double x = xS; // Reset x
            while (x <= xE) {
                double y = (1 - x * x) * (x - 2);
                series.Points.AddXY(x, y);
                x += 0.01; // Step size for x
            }
            //xS += 0.01;
            xE += step;

            // Clear previous series
            chart1.Series.Clear();

            // Grid colors
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = textAndGridColor;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = textAndGridColor;
            chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = textAndGridColor;
            chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = textAndGridColor;
            chart1.ChartAreas[0].AxisX.LineColor = textAndGridColor;
            chart1.ChartAreas[0].AxisY.LineColor = textAndGridColor;

            chart1.ChartAreas[0].BackColor = backgroundColor;



            // Add series to the chart
            chart1.Series.Add(series);
        }
        private void timer1_Tick(object sender, EventArgs e) {
            plot();
        }

        private void button2_Click(object sender, EventArgs e) {
            xS = -2;
            xE = 0;

            plot();
        }

        private void button3_Click(object sender, EventArgs e) {
            if(timer1.Enabled) {
                timer1.Stop();
            } else { 
                timer1.Start(); 
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e) {
            float value = (float)trackBar1.Value / 100.0f;

            step = 0.02 * value;

        }
    }
}

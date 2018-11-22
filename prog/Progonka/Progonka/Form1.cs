using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Progonka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].HeaderText = "x";
            dataGridView1.Columns[1].HeaderText = "Y";
            radioButton1.Checked = true;
        }

        const int N = 51;
        double[] a = new double[N];
        double[] b = new double[N];
        double[] c = new double[N];
        double[] d = new double[N];
        double[] V = new double[N];
        double[] U = new double[N];
        double[] Y = new double[N];

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private double func(double x, int N)
        {
            if (radioButton1.Checked)
                return (Math.Sinh(x) / Math.Sinh(1)) - 2 * x;
            if (radioButton2.Checked)
                return x + Math.Pow(Math.E, -x) - Math.Pow(Math.E, -1);
            if (radioButton3.Checked)
                return Math.Pow(Math.E, x) - 2;
            if (radioButton4.Checked)
                return 1 - Math.Sin(x) - Math.Cos(x);
            else return 0;            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            double A1 = 0;
            double b1 = 1;
            double h = (b1 - A1) / (N - 1);
            a[0] = a[a.Length - 1] = 1;
            b[0] = b[b.Length - 1] = c[c.Length - 1] = d[0] = 0;

            if (radioButton1.Checked)
            {
                d[0] = 0;
                d[N-1] = -1;
                for (int i = 1; i < N - 1; i++)
                {
                    a[i] = -2 - h * h;
                    b[i] = 1;
                    c[i] = 1;
                }
                d[d.Length - 1] = -1;
                for (int i = 1; i < d.Length - 1; i++)
                {
                    d[i] = 2 * Math.Pow(h, 3) * (i - 1);
                }
            }

            if (radioButton2.Checked)
            {
                A1 = 0;
                b1 = 1;
                h = (b1 - A1) / (N - 1);
                b[0] = -1;
                d[0] = 2 * Math.Pow(h, 2);             
                d[N - 1] = 1;
                for (int i = 1; i < N - 1; i++)
                {
                    a[i] = -4;
                    b[i] = 2 + h;
                    c[i] = 2 - h;
                    d[i] = 2 * Math.Pow(h, 2);
                }
            }

            if (radioButton3.Checked)
            {
                A1 = 0;
                b1 = 1;
                h = (b1 - A1) / (N - 1);
                a[0] = 1;
                b[0] = c[0] = 0;
                for (int i = 1; i < N - 1; i++)
                {
                    a[i] = -4;
                    b[i] = 2 - h;
                    c[i] = 2 + h;
                    d[i] = 0;
                }
                d[0] = -1;
                d[N - 1] = 0;
                a[N - 1] = 1 - h;
                c[N - 1] = -1;
                b[N - 1] = 2 * h;
            }

            if (radioButton4.Checked)
            {
                A1 = 0;
                b1 = 1;
                h = Math.PI / 100;
                a[0] = a[N - 1] = 1;
                b[0] = c[0] = b[N - 1] =  0;
                d[0] = 0;
                for (int i = 1; i < N - 1; i++)
                {
                    a[i] = (Math.Pow(h, 2) - 2);
                    b[i] = 1;
                    c[i] = 1;
                }

                for (int i = 0; i < N; i++)
                {
                    d[i] = Math.Pow(h, 2);
                }

            }

            chart1.Series.Clear();
            var ser1 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Running",
                Color = Color.Blue,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
            };

            var ser2 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Func",
                Color = Color.Red,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
            };
            chart1.Series.Add(ser1);
            chart1.Series.Add(ser2);

            dataGridView1.RowCount = N;
            for (int i = 0; i < N; i++)
            {
                ser1.Points.AddXY(h * (i - 1) + h, Running.Run(a, b, c, d, h, N)[i]);
                ser2.Points.AddXY(h * (i - 1) + h, func(h * (i - 1), N));
                dataGridView1[0, i].Value = h * (i - 1) + h;
                dataGridView1[1, i].Value = Running.Run(a, b, c, d, h, N)[i];
            }
        }
    }
}

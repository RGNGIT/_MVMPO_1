using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _MVMPO_1
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
            chartMain.Series.Clear();
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            var calc = new Mathf();
            chartMain.Series.Clear();
            chartMain.Series.Add("Расчет");
            chartMain.Series["Расчет"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chartMain.Series["Расчет"].BorderWidth = 5;
            if (!int.TryParse(textBox1.Text, out int l))
            {
                MessageBox.Show("Невалидный X");
                return;
            }
            if (!double.TryParse(textBox2.Text, out double k))
            {
                MessageBox.Show("Невалидный epsilon");
                return;
            }
            var x = Convert.ToInt32(textBox1.Text);
            var epsilon = Convert.ToDouble(textBox2.Text);
            if (x <= -7 || x >= 7)
            {
                    MessageBox.Show("Выход за ОДЗ!");
                    return;
            }

            var calcResult = calc.FuncResultRange(x, epsilon);
            double sum = 0;
            foreach (var item in calcResult)
            {
                listBox.Items.Add($"N: {item.Item1}. Result: {item.Item2}. Sum: {sum}");
                chartMain.Series["Расчет"].Points.AddXY(item.Item1, sum);
                sum += item.Item2;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraTemperaturas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (Centigrados.Text == "")
            {
                Fahrenheit.Clear();
                return;
            }

            if (double.TryParse(Centigrados.Text, out double celsius))
            {
                double fahrenheit = (celsius * 9 / 5) + 32;
               Fahrenheit.Text = fahrenheit.ToString("0.##");
            }
            else
            {
                Fahrenheit.Clear();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (Fahrenheit.Text == "")
            {
                Centigrados.Clear();
                return;
            }

            if (double.TryParse(Fahrenheit.Text, out double fahrenheit))
            {
                double celsius = (fahrenheit - 32) * 5 / 9;
                Centigrados.Text = celsius.ToString("0.##");
            }
            else
            {
                Centigrados.Clear();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double num1 = double.Parse(this.textBox1.Text);
            double num2 = double.Parse(this.textBox2.Text);

            double result = num1 + num2;
            this.textBox3.Text = result.ToString();
        }
    }
}

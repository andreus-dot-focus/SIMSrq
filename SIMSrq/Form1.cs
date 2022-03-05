using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMSrq
{
    public partial class Form1 : Form
    {
        Model model;

        public Form1()
        {
            InitializeComponent();
            model = new Model();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double startMu1 = Convert.ToDouble(mu1TB.Text);
            double endMu1 = Convert.ToDouble(mu1TB2.Text);
            for (double i = startMu1; i <= endMu1; i += 0.5)
            {
                model.ResetModel(Convert.ToDouble(lambdaTB.Text), i, Convert.ToDouble(mu2TB.Text), Convert.ToInt32(NTB.Text), Convert.ToDouble(sigmaTB.Text));
                model.simulationTime = Convert.ToDouble(timeTB.Text);
                model.StartSimulation();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           model.OpenTab();
        }
    }
}

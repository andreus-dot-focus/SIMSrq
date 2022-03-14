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
            model.ResetModel(Convert.ToDouble(lambdaTB.Text), Convert.ToDouble(mu1TB.Text), Convert.ToDouble(mu2TB.Text), Convert.ToInt32(NTB.Text), Convert.ToDouble(sigmaTB.Text));
            model.maxCalls = Convert.ToDouble(callsTB.Text);
            button1.Enabled = false;
            button2.Enabled = false;
            model.StartSimulation();
            MessageBox.Show("Симуляция завершена!");
            button1.Enabled = true;
            button2.Enabled = true;
            kvar1Label.Text = model.kvar1.ToString();
            kvar2Label.Text = model.kvar2.ToString();
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            add_product obj = new add_product();
            obj.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            add_supplier obj = new add_supplier();
            obj.Show();
            obj.TopMost = true;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            view_supplier obj = new view_supplier();
            obj.Show();
            this.Hide();
            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            add_customer obj = new add_customer();
            obj.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            view_products obj = new view_products();
            obj.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            view_bill obj = new view_bill();
            obj.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

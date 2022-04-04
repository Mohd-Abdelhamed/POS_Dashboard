using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pos_system
{
    public partial class add_supplier : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=3B7AMEED\SQLEXPRESS;Initial Catalog=pos_sql;Integrated Security=True");

        public add_supplier()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }


        void reset()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";

        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void bunifuThinButton22_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmmd = new SqlCommand("insert into supplier values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", conn);
            cmmd.ExecuteNonQuery();
            conn.Close();
            reset();
            Mbox.mShow("Supplier Saved");

        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            reset();
        }

        private void add_supplier_Load(object sender, EventArgs e)
        {

        }
    }
}

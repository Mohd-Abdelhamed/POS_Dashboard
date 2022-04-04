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
    public partial class add_customer : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=3B7AMEED\SQLEXPRESS;Initial Catalog=pos_sql;Integrated Security=True");

        public add_customer()
        {
            InitializeComponent();
        }

        private void add_customer_Load(object sender, EventArgs e)
        {

        }

        void reset()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = "";

        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                Mbox.mShow("Missing Infromation");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmmd = new SqlCommand("insert into customer values('" + textBox1.Text + "','" + textBox3.Text + "','" + textBox2.Text + "')", conn);
                    cmmd.ExecuteNonQuery();
                    Mbox.mShow("Customer Saved");
                    reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            reset();
        }
    }
}

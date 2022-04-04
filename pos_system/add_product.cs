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
    public partial class add_product : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=3B7AMEED\SQLEXPRESS;Initial Catalog=pos_sql;Integrated Security=True");

        public add_product()
        {
            InitializeComponent();
            domainDown();
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }
        private void domainDown()
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from category",conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr.ItemArray[1]);
                
            }
            conn.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        void reset()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = comboBox1.Text = "";
        }

        private void label6_Click(object sender, EventArgs e)
        {
            


        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select id from category where name='" + comboBox1.SelectedItem.ToString() + "'", conn);
            Int32 num = (Int32)cmd.ExecuteScalar();
            SqlCommand cmmd = new SqlCommand("insert into product values('" + textBox1.Text + "','" + num + "','" + textBox2.Text + "','" + textBox3.Text + "')", conn);
            cmmd.ExecuteNonQuery();
            Mbox.mShow("Product Saved");
            reset();
            conn.Close();

            //MessageBox.Show("name: "+comboBox1.SelectedItem.ToString()+"\n value: "+num);

        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            reset();
        }
    }
}

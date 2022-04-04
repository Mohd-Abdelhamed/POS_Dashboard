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
    public partial class view_products : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=3B7AMEED\SQLEXPRESS;Initial Catalog=pos_sql;Integrated Security=True");

        public view_products()
        {
            InitializeComponent();
            fetch_products();
            show_category();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void fetch_products()
        {
            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from product", conn);
            adapter.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];
            guna2DataGridView1.DataSource = ds.Tables[0];
        }


        private void label12_Click(object sender, EventArgs e)
        {
            add_product obj = new add_product();
            obj.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            view_products obj = new view_products();
            obj.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int category_key = 0;
        int product_key = 0;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                show_category();
                product_key =Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                textBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                category_key = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                textBox2.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox3.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();

           
                SqlCommand cmd = new SqlCommand("Select name from category where id= '" +category_key + "'", conn);
                string cat_name = Convert.ToString(cmd.ExecuteScalar());
            comboBox1.Text = cat_name;

            }

            void show_category()
            {
                comboBox1.Items.Clear();
                 SqlDataAdapter sda = new SqlDataAdapter("Select name from category", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox1.Items.Add(dr.ItemArray[0]);
                }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
            {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
           
        }

        private void label10_Click(object sender, EventArgs e)
        {
            add_supplier obj = new add_supplier();
            obj.Show();
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

        private void label9_Click(object sender, EventArgs e)
        {
            view_bill obj = new view_bill();
            obj.Show();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click_1(object sender, EventArgs e)
        {
            if (product_key == 0)
            {
                Mbox.mShow("Select the Product");
            }
            else
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("select id from category where name='" + comboBox1.SelectedItem.ToString() + "'", conn);
                    Int32 num = (Int32)cmd.ExecuteScalar();
                    SqlCommand cmmd = new SqlCommand("update product set name= '" + textBox1.Text + "', category= '" + num + "', price= '" + textBox2.Text + "',quantity='" + textBox3.Text + "' where id ='" + product_key + "'", conn);
                    cmmd.ExecuteNonQuery();
                    Mbox.mShow("Product Updated");

                }
                catch (Exception ex)
                {
                    Mbox.mShow(ex.Message);
                }


            }
            conn.Close();
            fetch_products();
        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            if (product_key == 0)
            {
                Mbox.mShow("Select the Product");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select id from category where name='" + comboBox1.SelectedItem.ToString() + "'", conn);
                    Int32 num = (Int32)cmd.ExecuteScalar();
                    SqlCommand cmmd = new SqlCommand("delete from product where id='" + product_key + "'", conn);
                    cmmd.ExecuteNonQuery();
                    Mbox.mShow("Product Deleted");

                }
                catch (Exception ex)
                {
                    Mbox.mShow(ex.Message);
                }

            }
            conn.Close();
            fetch_products();
        }

        private void bunifuThinButton23_Click_1(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }
    }
}

        
        


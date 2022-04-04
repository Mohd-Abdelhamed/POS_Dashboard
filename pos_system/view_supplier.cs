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
    public partial class view_supplier : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=3B7AMEED\SQLEXPRESS;Initial Catalog=pos_sql;Integrated Security=True");

        public view_supplier()
        {
            InitializeComponent();
            fetch_supplier();
        }
        void fetch_supplier()
        {
            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Supplier",conn);
            sda.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
        int supplier_key = 0;
        
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            supplier_key = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            textBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();


        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (supplier_key == 0)
            {
                Mbox.mShow("Select a Supplier");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update Supplier set name= '" + textBox1.Text + "', address= '" + textBox2.Text + "', phone= '" + textBox3.Text + "', remarks='" + textBox4.Text + "' where id ='"+supplier_key+"'", conn);
                    cmd.ExecuteNonQuery();
                    Mbox.mShow("Supplier Updated Sucessfully");
                }
                catch(Exception ex)
                {
                    Mbox.mShow(ex.Message);
                }

            }  
                conn.Close();
                fetch_supplier();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (supplier_key == 0)
            {
                Mbox.mShow("Select a Supplier");
            }
            else
            {
                try
                {
                    SqlCommand cmmd = new SqlCommand("delete from Supplier where id='" + supplier_key + "'", conn);
                    cmmd.ExecuteNonQuery();
                    Mbox.mShow("Supplier Deleted");

                }
                catch (Exception ex)
                {
                    Mbox.mShow(ex.Message);
                }

            }
            conn.Close();
            fetch_supplier();
        }

        private void view_supplier_Load(object sender, EventArgs e)
        {

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
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

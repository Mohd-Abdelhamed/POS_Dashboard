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
    public partial class bill : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=3B7AMEED\SQLEXPRESS;Initial Catalog=pos_sql;Integrated Security=True");
        public bill()
        {
            InitializeComponent();
            display_product();
            get_customer();
        }
        void search_product()
        {
            if (searchText.Text == "")
            {
                Mbox.mShow("Enter a Product");
            }
            else
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from product where name= '" + searchText.Text + "'", conn);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                guna2DataGridView2.DataSource = ds.Tables[0];
                conn.Close();
            }
        }
        void display_product()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from product", conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            guna2DataGridView2.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            search_product();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            display_product();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            add_to_bill();
        } 
        private void update_quantity()
        {
            
            int new_qty = p_stock - Convert.ToInt32(quan.Text);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update product set quantity= @qt where id= @idd", conn);
                cmd.Parameters.AddWithValue("@qt",new_qty);
                cmd.Parameters.AddWithValue("@idd", key);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                Mbox.mShow(ex.Message);
            }
            
        }
        string name;
        double price;
        int p_stock, key = 0;
        int product_id = 1;
        double tPrice_product = 0;

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(guna2DataGridView2.SelectedRows[0].Cells[0].Value.ToString());
            name = guna2DataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            price = Convert.ToDouble(guna2DataGridView2.SelectedRows[0].Cells[3].Value.ToString());
            p_stock= Convert.ToInt32(guna2DataGridView2.SelectedRows[0].Cells[4].Value.ToString());
        }
        private void reset()
        {
            name = "";
            key = 0;
            
            quan.Text = "";

        }
        private void add_to_bill()
        {
            if (key == 0)
            {
                Mbox.mShow("Select a Product");
            }
            else if (quan.Text == "")
            {
                Mbox.mShow("Enter The Quantity");
            }
            else if (Convert.ToInt32(quan.Text) > p_stock)
            {
                Mbox.mShow("No Enough Stock");
            }
            else
            {
                double total_price = Convert.ToInt32(quan.Text) * price;
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(guna2DataGridView1);
                newRow.Cells[0].Value = product_id;
                newRow.Cells[1].Value = name;
                newRow.Cells[2].Value = quan.Text;
                newRow.Cells[3].Value = price;
                newRow.Cells[4].Value = total_price;
                guna2DataGridView1.Rows.Add(newRow);
                product_id++;
                tPrice_product += total_price;
                subTotalText.Text =""+ tPrice_product;
                update_quantity();
                reset();
                display_product();
            }
        }
        private void get_customer()
        {
            cust_id.Text = login.customer_id.ToString();
            cust_name.Text = login.customer_name;
            
        }

        private void bill_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox2.Text == "")
            {

            }
            else if (subTotalText.Text == "")
            {
                Mbox.mShow("Add Product To The Cart First");
                textBox2.Text = "";
            }
            else
            {

                try
                {
                    double vat = (Convert.ToDouble(textBox2.Text) / 100) * Convert.ToDouble(tPrice_product);
                    textBox3.Text = ""+ (vat + tPrice_product);
                    textBox1.Text = "" + (vat + tPrice_product);
                }
                catch (Exception ex)
                {
                    Mbox.mShow(ex.Message);
                }
            }
        }
        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {

            if (discountBox.Text == "")
            {

            }
            else if (subTotalText.Text == "")
            {
                Mbox.mShow("Add Product To The Cart First");
                discountBox.Text = "";

            }
            else
            {

                try
                {
                    double disc = (Convert.ToDouble(discountBox.Text) / 100) * Convert.ToDouble(tPrice_product);
                    DiscountValue.Text = "" + disc;
                    textBox1.Text = "" + (Convert.ToDouble(DiscountValue.Text)+(Convert.ToDouble(textBox3.Text)));
                }
                catch (Exception ex)
                {
                    Mbox.mShow(ex.Message);
                }
            }
        }
        int flag = 0;
        private void insert_Bill()
        {
            if(comboBox1.SelectedIndex==-1 || textBox1.Text=="")
            {
                Mbox.mShow("Missing Infromation");
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into bill(BDate,CustId,CustName,PayMethod,amount) values(@b_date,@cust_id,@cust_name,@pay_method,@amount)", conn);
                cmd.Parameters.AddWithValue("@b_date", guna2DateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@cust_id",Convert.ToInt32(cust_id.Text));
                cmd.Parameters.AddWithValue("@cust_name",cust_name.Text);
                cmd.Parameters.AddWithValue("@pay_method",comboBox1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@amount", Convert.ToDouble(textBox1.Text));
                cmd.ExecuteNonQuery();
                //Mbox.mShow("Bill Saved");
                conn.Close();
                flag = 1;

            }
        }
        
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            insert_Bill();

            if (flag == 1)
            {
             printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 500, 600);
                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
               
            
        }
        int prod_id, prod_qty, total, pos = 110;

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            view_bill obj = new view_bill();
            obj.Show();
        }

        double prod_price;
        string prod_name;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("3b7ameed POS", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(100,50));
            e.Graphics.DrawString("ID     PRODUCT     QUANTITY    PRICE    TOTAL", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(26, 90));
            foreach(DataGridViewRow rw in guna2DataGridView1.Rows)
            {
                prod_id = Convert.ToInt32(rw.Cells["Column1"].Value);
                prod_name ="" + rw.Cells["Column2"].Value;
                prod_qty = Convert.ToInt32(rw.Cells["Column3"].Value);
                prod_price = Convert.ToDouble(rw.Cells["Column4"].Value);
                total = Convert.ToInt32(rw.Cells["Column5"].Value);
                e.Graphics.DrawString("" + prod_id, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(31, pos));
                e.Graphics.DrawString("" + prod_name, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(80, pos));
                e.Graphics.DrawString("" + prod_qty, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(165, pos));
                e.Graphics.DrawString("" + prod_price, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(225, pos));
                e.Graphics.DrawString("" + total, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(285, pos));
                pos += 20;
            }
            e.Graphics.DrawString("Grand Total: BD. " + textBox1.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(80, pos + 50));
            e.Graphics.DrawString("*******************************************", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(80, pos + 80));
            guna2DataGridView1.Rows.Clear();
            guna2DataGridView1.Refresh();
            pos = 100;
            subTotalText.Text = textBox2.Text = textBox3.Text = discountBox.Text = DiscountValue.Text = textBox1.Text = "";


        }





        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}

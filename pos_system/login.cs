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
    public partial class login : Form
    {
        public static int customer_id;
        public static string customer_name;

        SqlConnection conn = new SqlConnection(@"Data Source=3B7AMEED\SQLEXPRESS;Initial Catalog=pos_sql;Integrated Security=True");

        public login()
        {
            InitializeComponent();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from users where username= '" + textBox1.Text + "' and password= '" + textBox2.Text + "'", conn);
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    if (sdr[1].ToString() == "admin")
                    {
                        Form1 frm = new Form1();
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        customer_id =Convert.ToInt32(sdr[0].ToString());
                        customer_name = sdr[1].ToString();
                        bill frm = new bill();
                        frm.Show();
                        this.Hide();
                    }
                    
                }
            }
            else
            {
                Mbox.mShow("Error..");
            }
            conn.Close();

        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}

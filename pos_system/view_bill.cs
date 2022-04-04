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
    public partial class view_bill : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=3b7ameed\sqlexpress;Initial Catalog=pos_sql;Integrated Security=True");

        public view_bill()
        {
            InitializeComponent();
            view();
        }
        private void view()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from bill", conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void view_bill_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

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
    public partial class Mbox : Form
    {
        
        public Mbox()
        {
            InitializeComponent();
            label2.Text = message;
        }

        public static string message;
        public static void  mShow(string msg)
        {
            message = msg;
            Mbox obj = new Mbox();
            obj.Show();

        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
/*using NewMsgBoxAsp.Holool.Anwar.Web.Controls.UI;*/

namespace A12
{
    public partial class Pretraga : Form
    {
        public Pretraga()
        {
            InitializeComponent();
            textBox1.Text = "";
        }

        public bool Canceled = true;

        public string GetText()
        {
            return textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)//ok
        {
            Canceled = false;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)//cancel
        {
            Canceled = true;
            this.Close();
        }
    }
}

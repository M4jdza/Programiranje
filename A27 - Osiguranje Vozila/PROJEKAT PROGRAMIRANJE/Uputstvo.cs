using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJEKAT_PROGRAMIRANJE
{
    public partial class Uputstvo : Form
    {
        Form1 f1;
        public Uputstvo(Form1 fm)
        {
            f1 = fm;
            InitializeComponent();
        }

        // VRACANJE NA PRETHODNU FORMU
        private void button1_Click(object sender, EventArgs e)
        {
            f1.Show();
            this.Hide();
        }

        private void Uputstvo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

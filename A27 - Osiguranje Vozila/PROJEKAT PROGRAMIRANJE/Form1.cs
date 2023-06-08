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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // POZIVANJE FORME ZA PRIKAZ MODELA AUTOMOBILA
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Modeli_automobila ma = new Modeli_automobila();
            this.Hide();
            ma.Show();
        }

        // ZATVARANJE APLIKACIJE
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // POZIVANJE FORME ZA PRIKAZ POLISA
        private void poliseKojeIsticuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Polise pl = new Polise();
            this.Hide();
            pl.Show();
        }

        // // ZATVARANJE APLIKACIJE
        private void krajRadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // POZIVANJE FORME ZA PRIKAZ UPUTSTVA
        private void uputstvoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uputstvo up = new Uputstvo(this);
            this.Hide();
            up.Show();
        }
    }
}

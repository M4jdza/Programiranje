using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJEKAT_PROGRAMIRANJE
{
    public partial class Polise : Form
    {
        public Polise()
        {
            InitializeComponent();
        }

        private void Polise_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // KONEKCIJA
        public void Konekcija()
        {
            konekcija = new SqlConnection();
            konekcija.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OsiguranjeVozila_A27;Integrated Security=True;";

            komanda = new SqlCommand();
            komanda.Connection = konekcija;

            da = new SqlDataAdapter();
            dt = new DataTable();
            dt1 = new DataTable();
        }
        SqlConnection konekcija;
        SqlCommand komanda;
        SqlDataAdapter da;
        DataTable dt;
        DataTable dt1;
        // Danasnji datum
        DateTime datum = DateTime.Today;

        // ISPIS DATUMA U LABELI
        private void Polise_Load(object sender, EventArgs e)
        {
            label3.Text = "Datum: " + datum.ToString("dd.MM.yyyy");
        }

        // PRIKAZ PODATAKA IZ BAZE U LISTVIEW
        private void button1_Click(object sender, EventArgs e)
        {
            // Uredjivanje listview-a
            listView1.Clear();
            listView1.Items.Clear();
            listView1.Columns.Add("Ime", 90);
            listView1.Columns.Add("Prezime", 90);
            listView1.Columns.Add("Model", 100);
            listView1.Columns.Add("Proizvodjac", 90);
            listView1.Columns.Add("Registracija", 100);
            listView1.Columns.Add("Broj polise", 80);
            listView1.Columns.Add("Vazi od", 100);
            listView1.Columns.Add("Vazi do", 100);

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            Konekcija();
            // SQL naredba za prikazivanje izmedju dva datuma
            komanda.CommandText = "SELECT v.ime, v.prezime, m.naziv, p.naziv, vo.RegistarskiBroj, pol.polisaid, pol.datumpocetka, pol.datumzavrsetka " +
                "FROM ((((Vozac v INNER JOIN vozilo_vozac vv ON v.VozacID=vv.VozacID) " +
                "INNER JOIN vozilo vo ON vv.VoziloID=vo.VoziloID) " +
                "INNER JOIN model m ON vo.ModelID=m.ModelID) " +
                "INNER JOIN proizvodjac p ON m.ProizvodjacID=p.ProizvodjacID) " +
                "INNER JOIN polisa pol ON vo.PolisaID=pol.PolisaID " +
                "WHERE pol.DatumZavrsetka BETWEEN @datum1 AND @datum2";
            komanda.Parameters.AddWithValue("@datum1", datum);
            komanda.Parameters.AddWithValue("@datum2", datum.AddDays(Convert.ToInt32(numericUpDown1.Value)));
            da.SelectCommand = komanda;
            da.Fill(dt);

            // Ispisivanje podataka u listview
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem listitem = new ListViewItem(row[0].ToString());
                listitem.SubItems.Add(row[1].ToString());
                listitem.SubItems.Add(row[2].ToString());
                listitem.SubItems.Add(row[3].ToString());
                listitem.SubItems.Add(row[4].ToString());
                listitem.SubItems.Add(row[5].ToString());
                DateTime od = (DateTime)row[6];
                listitem.SubItems.Add(od.ToString("dd.MM.yyyy."));

                DateTime dod = (DateTime)row[7];
                listitem.SubItems.Add(dod.ToString("dd.MM.yyyy."));

                listView1.Items.Add(listitem);
            }
        }

        // VRACANJE NA PRETHODNU PORUKU
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }
    }
}

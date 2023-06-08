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

namespace A12
{
    public partial class Stadion : Form
    {
        public Stadion()
        {
            InitializeComponent();
        }

        SqlConnection konekcija;
        SqlCommand komanda;
        DataTable dt, dt1;
        SqlDataAdapter da;

        void Konekcija()//funkcija za konekciju
        {
            konekcija = new SqlConnection();
            konekcija.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FudbalskiStadioni_A12;Integrated Security=True;";

            komanda = new SqlCommand();
            komanda.Connection = konekcija;

            dt = new DataTable();
            dt1 = new DataTable();
            da = new SqlDataAdapter();
        }

        public void Prikaz()
        {
            Konekcija();
                listView1.Clear();

                listView1.Columns.Add("Šifra", 40);
                listView1.Columns.Add("Naziv", 130);
                listView1.Columns.Add("Grad", 80);
                listView1.Columns.Add("Kapacitet", 70);
                listView1.Columns.Add("Adresa", 250);
                listView1.Columns.Add("Br. ulaza", 70);

                listView1.View = View.Details;
                listView1.FullRowSelect = true;

                komanda.CommandText = "SELECT stadion.StadionID,stadion.Naziv,grad.Grad,stadion.Kapacitet,stadion.Adresa, stadion.BrojUlaza FROM stadion JOIN grad  ON stadion.GradID=grad.GradID";
                da.SelectCommand = komanda;
                da.Fill(dt);

                foreach (DataRow red in dt.Rows){
                    string[] podaci ={
                        red[0].ToString(),
                        red[1].ToString(),
                        red[2].ToString(),
                        red[3].ToString(),
                        red[4].ToString(),
                        red[5].ToString()
                    };
                ListViewItem stavka = new ListViewItem(podaci);
                listView1.Items.Add(stavka);
                }
                dt.Clear();
                konekcija.Close();
        }

        private void Stadion_Load(object sender, EventArgs e)
        {
           
            Prikaz();
            Konekcija();
            komanda.CommandText = "SELECT * FROM grad";
            da.SelectCommand = komanda;
            da.Fill(dt1);

            //ispis svih gradova u comboBox1
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string grad = dt1.Rows[i][1].ToString();
                comboBox1.Items.Add(grad);
            }
            dt1.Clear();
            konekcija.Close();
        }

        private void button1_Click(object sender, EventArgs e)//pretraga
        {
            Pretraga p = new Pretraga();
            p.ShowDialog();

           //ako je kliknuto dugme cancel ne proverava vrednost
            if(p.Canceled) return;

            string drzava=p.GetText();
           
           //ukoliko se ne unese drzava za pretragu ispisuju se svi stadioni kao i na pocetku - Load
            if (drzava == "")
            {
               Prikaz();
            }
           //ispis stadiona koji se nalaze u unetoj drzavi
            else
            {
                Konekcija();
                listView1.Clear();

                listView1.Columns.Add("Šifra", 40);
                listView1.Columns.Add("Naziv", 130);
                listView1.Columns.Add("Grad", 80);
                listView1.Columns.Add("Kapacitet", 70);
                listView1.Columns.Add("Adresa", 250);
                listView1.Columns.Add("Br. ulaza", 70);

                listView1.View = View.Details;
                listView1.FullRowSelect = true;

                komanda.CommandText = "SELECT stadion.StadionID,stadion.Naziv,grad.Grad,stadion.Kapacitet,stadion.Adresa, stadion.BrojUlaza FROM stadion JOIN grad ON stadion.GradID=grad.GradID JOIN drzave ON grad.DrzavaID=drzave.DrzavaID WHERE drzave.naziv = @drzava";
                komanda.Parameters.AddWithValue("@drzava", drzava);
            
                da.SelectCommand = komanda;
                da.Fill(dt);
                listView1.Items.Clear();

                foreach (DataRow red in dt.Rows)
                {
                    string[] podaci ={
                            red[0].ToString(),
                            red[1].ToString(),
                            red[2].ToString(),
                            red[3].ToString(),
                            red[4].ToString(),
                            red[5].ToString()
                    };
                    ListViewItem stavka = new ListViewItem(podaci);
                    listView1.Items.Add(stavka);
                }dt.Clear();
                konekcija.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)//update
        {
            Konekcija();
            string update = "UPDATE stadion ";
            string set = "SET  Naziv=@naziv, Adresa=@adresa, Kapacitet=@kapacitet, BrojUlaza=@brulaza, GradID=(SELECT GradID FROM grad WHERE grad=@grad)";
            string where = "WHERE StadionID=@id";

            komanda.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
            komanda.Parameters.AddWithValue("@naziv", textBox2.Text);
            komanda.Parameters.AddWithValue("@adresa", textBox3.Text);
            komanda.Parameters.AddWithValue("@kapacitet",Convert.ToInt32(numericUpDown1.Value));        
            komanda.Parameters.AddWithValue("@brulaza", Convert.ToInt32(numericUpDown2.Value));
            komanda.Parameters.AddWithValue("@grad", comboBox1.Text);
            komanda.CommandText = update + set + where;

            try
            {
                konekcija.Open();
                komanda.ExecuteNonQuery();
                MessageBox.Show("Uspesno izvrsena izmena!");
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                konekcija.Close();
            }

            Stadion_Load(sender, e);
        }
        private void button3_Click(object sender, EventArgs e)//statistika
        {
            Statistika s = new Statistika();
            s.Show();
        }
        private void button4_Click(object sender, EventArgs e)//info
        {
            Info i = new Info();
            i.Show();
        }
        private void button5_Click(object sender, EventArgs e)//exit
        {
            Application.Exit();
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                textBox2.Enabled = textBox3.Enabled = comboBox1.Enabled = numericUpDown1.Enabled = numericUpDown2.Enabled = true;
                ListViewItem item = listView1.SelectedItems[0];

                textBox1.Text = item.SubItems[0].Text;
                textBox2.Text = item.SubItems[1].Text;
                textBox3.Text = item.SubItems[4].Text;

                numericUpDown1.Value = Convert.ToInt32(item.SubItems[3].Text);
                numericUpDown2.Value = Convert.ToInt32(item.SubItems[5].Text);

                
                comboBox1.Text = item.SubItems[2].Text;
            }
            else
            {
                textBox1.Text = textBox2.Text = textBox3.Text = comboBox1.Text = "";
                numericUpDown1.Value = numericUpDown2.Value = 0;
            }
        }
    }
}

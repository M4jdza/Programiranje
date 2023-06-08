using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace PROJEKAT_PROGRAMIRANJE
{
    public partial class Modeli_automobila : Form
    {
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

        // PRIKAZ PRILIKOM MENJANJA PROIZVODJACA AUTOMOBILA
        public void Prikazi(string naziv)
        {
            Konekcija();
            komanda.CommandText = "SELECT naziv, nazivfajla, slika FROM model WHERE naziv = @naziv";
            komanda.Parameters.AddWithValue("@naziv", naziv);
            da.SelectCommand = komanda;
            da.Fill(dt);
            label2.Text = dt.Rows[0][1].ToString();

            if (dt.Rows[0][2].ToString() != "")
            {
                var data = (Byte[])dt.Rows[0][2];
                var stream = new MemoryStream(data);
                pictureBox1.Image = Image.FromStream(stream);
            }
        }

        public Modeli_automobila()
        {
            InitializeComponent();
            comboBox1.Text = comboBox1.Items[0].ToString();
        }

        // DEFAULT PRIKAZ PRILIKOM OTVARANJA FORME
        private void Modeli_automobila_Load(object sender, EventArgs e)
        {
            Konekcija();
            komanda.CommandText = "SELECT naziv FROM proizvodjac";
            da.SelectCommand = komanda;
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr[0].ToString());
            }

            komanda.CommandText = "SELECT naziv, slika FROM model ORDER BY naziv ASC";
            da.SelectCommand = komanda;
            da.Fill(dt1);

            dataGridView1.DataSource = dt1;
            // Postavljanje malih ikonica u datagridview (bez ove linije fotografije su uvecane preko cele celije)
            ((DataGridViewImageColumn)dataGridView1.Columns[1]).ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView1.RowHeadersVisible = false;
            // Sirina kolona
            dataGridView1.Columns[0].Width = dataGridView1.Width / 2;
            dataGridView1.Columns[1].Width = dataGridView1.Width / 2 - 20;
        }
        SqlConnection konekcija;
        SqlCommand komanda;
        SqlDataAdapter da;
        DataTable dt;
        DataTable dt1;
        int index = -1; 
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            Prikazi(dataGridView1.Rows[index].Cells[0].Value.ToString());
        }

        // UPDATE SLIKE
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(index != -1)
            {
                // Otvaranje file dijaloga za izbor slike
                openFileDialog1.FileName = "";
                openFileDialog1.InitialDirectory = Path.Combine(Application.StartupPath, @"Slike");
                openFileDialog1.Filter = "Format slike|*.jpg;*png;*jpeg";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Load(openFileDialog1.FileName);
                    konekcija.Open();
                    komanda.Parameters.Clear();
                    var image = new ImageConverter().ConvertTo(pictureBox1.Image, typeof(Byte[]));
                    komanda.CommandText = "UPDATE model SET nazivfajla=@nazivfajla, slika=@slika WHERE naziv=@naziv";
                    komanda.Parameters.AddWithValue("@nazivfajla", openFileDialog1.SafeFileName);
                    komanda.Parameters.AddWithValue("@slika", image);
                    komanda.Parameters.AddWithValue("@naziv", dataGridView1.Rows[index].Cells[0].Value.ToString());

                    try
                    {
                        komanda.ExecuteNonQuery();
                        pictureBox1.Image = null;
                        MessageBox.Show("Slika dodata u bazu!");
                    }
                    catch
                    {
                        pictureBox1.Image = null;
                        MessageBox.Show("Greska!");
                    }
                    finally
                    {
                        konekcija.Close();
                    }
                    Modeli_automobila_Load(sender, e);
                }
            }
        }

        // BRISANJE SLIKE I VRACANJE NA DEFAULT-nu
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if(index != -1)
            {
                // Slika se ucitava u picturebox i izmena u bazi podataka
                pictureBox1.Image = Image.FromFile(@"./Slike\no_image.png");
                konekcija.Open();
                komanda.Parameters.Clear();
                var image = new ImageConverter().ConvertTo(pictureBox1.Image, typeof(Byte[]));
                komanda.CommandText = "UPDATE model SET nazivfajla=@nazivfajla, slika=@slika WHERE naziv=@naziv";
                komanda.Parameters.AddWithValue("@nazivfajla", "no_image.png");
                komanda.Parameters.AddWithValue("@slika", image);
                komanda.Parameters.AddWithValue("@naziv", dataGridView1.Rows[index].Cells[0].Value.ToString());

                try
                {
                    komanda.ExecuteNonQuery();
                    pictureBox1.Image = null;
                    MessageBox.Show("Slika izbrisana!");
                }
                catch
                {
                    pictureBox1.Image = null;
                    MessageBox.Show("Greska!");
                }
                finally
                {
                    konekcija.Close();
                }
                Modeli_automobila_Load(sender, e);
            }
        }

        // PROMENA PROIZVODJACA U COMBOBOXU
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                Modeli_automobila_Load(sender, e);
            }
            else
            {
                Konekcija();
                komanda.CommandText = "SELECT model.naziv, model.slika FROM model INNER JOIN proizvodjac ON proizvodjac.proizvodjacid=model.proizvodjacid WHERE proizvodjac.naziv = @naziv ORDER BY naziv ASC";
                komanda.Parameters.AddWithValue("@naziv", comboBox1.SelectedItem.ToString());
                da.SelectCommand = komanda;
                da.Fill(dt1);

                dataGridView1.DataSource = dt1;
                ((DataGridViewImageColumn)dataGridView1.Columns[1]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.Columns[0].Width = dataGridView1.Width / 2;
                dataGridView1.Columns[1].Width = dataGridView1.Width / 2 - 20;
            }
        }

        // VRACANJE NA PRETHODNU FORMU
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form1 forma = new Form1();
            this.Hide();
            forma.Show();
        }

        private void Modeli_automobila_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

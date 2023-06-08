using System;
using System.Collections;
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
    public partial class Statistika : Form
    {
        public Statistika()
        {
            InitializeComponent();
        }

        SqlConnection konekcija;
        SqlCommand komanda;

        void Konekcija()//funkcija za konekciju
        {
            konekcija = new SqlConnection();
            konekcija.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FudbalskiStadioni_A12;Integrated Security=True;";

            komanda = new SqlCommand();
            komanda.Connection = konekcija;

        }
        private void Statistika_Load(object sender, EventArgs e)
        {
           Konekcija();     
           //izdvajanje naziva stadiona i broja odigranih utakmica u protekloj godini
            komanda.CommandText = "SELECT s.naziv, COUNT(*) AS broj_utakmica " +
                           "FROM klub k " +
                           "JOIN stadion s ON k.StadionID = s.StadionID " +
                           "JOIN utakmica u ON k.KlubID = u.DomacinID "+
                           "WHERE YEAR(u.DatumIgranja) = YEAR(GETDATE())-1" +
                           "GROUP BY s.naziv";
           //podesavanje chart-a
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chart1.ChartAreas["ChartArea1"].AxisY.Interval = 2;
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new System.Drawing.Font("Vedrana", 10, System.Drawing.FontStyle.Regular);
            chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 20;
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
           //chart
            konekcija.Open();
           //citac podataka iz baze 
            SqlDataReader reader = komanda.ExecuteReader();        
           //brojac stadiona
            int i=0;
            while (reader.Read() && i<10){
                string naziv = reader["naziv"].ToString();
                int broj_utakmica = Convert.ToInt32(reader["broj_utakmica"]);
                chart1.Series["Series1"].Points.AddXY(naziv, broj_utakmica);
                i++;
            }
            konekcija.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A12
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
            label1.Text = @"Forma 'Stadion' sadrži prikaz  podataka o svim stadionima koji mogu da se menjaju klikom na UPDATE dugme.
Dugme SEARCH ima zadatak da otvori formu 'Pretraga' pomoću koje je obezbđeno lakše pretraživanje stadiona
koji se nalaze u zadatoj državi.
Dugme INFO otvara istoimenu formu na kojoj se nalazi sažeto uputstvo za aplikaciju.
Klikom na dugme GRAPH prikazuje se forma 'Statistika' koja sadrži tabelarni prikaz broja održanih utakmica
na svakom stadionu tokom protekle godine.";
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kontakty
{
    public partial class Edycja_listy : Form
    {
        Form1 Formularz_1;
        int Identyfikator_listy;
        public Edycja_listy(Form1 Parametr_formularza, int Paramter_identyfikatora_listy, string Parametr_nazwy_listy) {
            InitializeComponent();
            Formularz_1 = Parametr_formularza;
            Identyfikator_listy = Paramter_identyfikatora_listy;
            Nazwa_listy.Text = Parametr_nazwy_listy;
        }

        private void Zapisz_zmianę_Click(object sender, EventArgs e) {
            Formularz_1.Baza.Zmień_nazwę_listy(Identyfikator_listy, Nazwa_listy.Text);
            Formularz_1.Zaktualizuj_listę_list();
            this.Close();
        }
    }
}

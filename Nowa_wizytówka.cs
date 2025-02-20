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
    public partial class Nowa_wizytówka : Form {
        Form1 Formularz_1;
        int Identyfikator_kontaktu;
        public Nowa_wizytówka(Form1 Paramter_formularza) {
            InitializeComponent();
            Formularz_1 = Paramter_formularza;
        }
        private void Dodaj_wizytówkę_Click(object sender, EventArgs e) {
            if (!string.IsNullOrWhiteSpace(Wpisz_imię.Text) || !string.IsNullOrEmpty(Wpisz_nazwisko.Text)) {
                Formularz_1.Baza.Dodaj_wizytówkę(new List<string> {Wpisz_imię.Text, Wpisz_nazwisko.Text, Wpisz_adres_poczty_elektronicznej.Text,
                Wpisz_numer_telefonu.Text, Wpisz_nazwę_użytkownika_na_Facebooku.Text, Wpisz_nazwę_użytkownika_na_Instagramie.Text});
                Formularz_1.Zaktualizuj_listę_wizytówek();
                this.Close();
            }
        }
    }
}

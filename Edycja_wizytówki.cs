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
    public partial class Edycja_wizytówki : Form
    {
        Form1 Formularz_1;
        int Identyfikator_wizytówki;
        internal Edycja_wizytówki(Form1 Parametr_formularza, Wizytówka Parametr_wizytówki)
        {
            InitializeComponent();
            Formularz_1 = Parametr_formularza;
            Identyfikator_wizytówki = Parametr_wizytówki.Pobierz_identyfikator();
            Wpisz_imię.Text = Parametr_wizytówki.Pobierz_daną(0);
            Wpisz_nazwisko.Text = Parametr_wizytówki.Pobierz_daną(1);
            Wpisz_adres_poczty_elektronicznej.Text = Parametr_wizytówki.Pobierz_daną(2);
            Wpisz_numer_telefonu.Text = Parametr_wizytówki.Pobierz_daną(3);
            Wpisz_nazwę_użytkownika_na_Facebooku.Text = Parametr_wizytówki.Pobierz_daną(4);
            Wpisz_nazwę_użytkownika_na_Instagramie.Text = Parametr_wizytówki.Pobierz_daną(5);
        }

        private void Zapisz_zmiany_Click(object sender, EventArgs e) {
            Formularz_1.Baza.Zmień_dane_wizytówki(Identyfikator_wizytówki, new List <string> {
                Wpisz_imię.Text, Wpisz_nazwisko.Text, Wpisz_adres_poczty_elektronicznej.Text, Wpisz_numer_telefonu.Text,
                Wpisz_nazwę_użytkownika_na_Facebooku.Text, Wpisz_nazwę_użytkownika_na_Instagramie.Text
            });
            Formularz_1.Zaktualizuj_listę_wizytówek();
            Formularz_1.Zaktualizuj_podgląd_wizytówki();
            this.Close();
        }
    }
}

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
    public partial class Dodaj_do_listy : Form {
        Form1 Formularz_1;
        List <Lista> Bufor_list;
        int Identyfikator_wizytówki;
        public Dodaj_do_listy(Form1 Parametr_formularza, int Parametr_identyfikatora_wizytówki) {
            InitializeComponent();
            Formularz_1 = Parametr_formularza;
            Identyfikator_wizytówki = Parametr_identyfikatora_wizytówki;
            Bufor_list = Formularz_1.Baza.Pobierz_bufor_list();
            Wybór_listy.Items.Clear();
            for (int i = 0; i < Bufor_list.Count; i++) {
                Wybór_listy.Items.Add(Bufor_list[i].Pobierz_nazwę());
            }
            Wybór_listy.SelectedIndex = 0;
        }
        private void Dodaj_wizytówkę_do_poniższej_listy_Click(object sender, EventArgs e) {
            if (Wybór_listy.SelectedIndex == -1) return;
            Formularz_1.Baza.Dodaj_wizytówkę_do_listy(Identyfikator_wizytówki, Bufor_list[Wybór_listy.SelectedIndex].Pobierz_identyfikator());
            Formularz_1.Zaktualizuj_listę_wizytówek();
            this.Close();
        }
    }
}

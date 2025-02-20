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
    public partial class Nowa_lista : Form
    {
        Form1 Formularz_1;
        public Nowa_lista(Form1 Parametr_formularza) {
            InitializeComponent();
            Formularz_1 = Parametr_formularza;
        }
        private void Dodaj_listę_Click(object sender, EventArgs e) {
            if (!string.IsNullOrWhiteSpace(Nazwa_listy.Text) && Nazwa_listy.Text != "Wszystkie") {
                Formularz_1.Baza.Dodaj_listę(Nazwa_listy.Text);
                Formularz_1.Zaktualizuj_listę_list();
                this.Close();
            }
        }
    }
}

using System.Diagnostics;

namespace Kontakty
{
    public partial class Form1 : Form
    {
        internal Baza_danych Baza = new Baza_danych("Baza");
        public Form1()
        {
            InitializeComponent();
            Zaktualizuj_list�_list();
            Zaktualizuj_list�_wizyt�wek();
            Zaktualizuj_podgl�d_wizyt�wki();
        }
        internal void Zaktualizuj_list�_list()
        {
            int Zaznaczona_lista = 0;
            if (Form1_Listy.SelectedIndex > 0) Zaznaczona_lista = Baza.Pobierz_identyfikator_listy(Form1_Listy.SelectedIndex - 1);
            Baza.Zaktualizuj_listy();
            List<string> Nazwy_list = Baza.Pobierz_nazwy_list();
            Form1_Listy.Items.Clear();
            Form1_Listy.Items.Add("Wszystkie");
            for (int i = 0; i < Nazwy_list.Count; i++) Form1_Listy.Items.Add(Nazwy_list[i]);
            Form1_Listy.SelectedIndex = 0;
            if (Zaznaczona_lista != 0)
            {
                Form1_Listy.SelectedIndex = Baza.Pobierz_pozycj�_listy_w_buforze(Zaznaczona_lista) + 1;
            }
        }
        internal void Zaktualizuj_list�_wizyt�wek()
        {
            int Zaznaczona_lista = 0;
            if (Form1_Listy.SelectedIndex > 0) Zaznaczona_lista = Baza.Pobierz_identyfikator_listy(Form1_Listy.SelectedIndex - 1);
            Baza.Zaktualizuj_wizyt�wki(Form1_Szukaj.Text, Zaznaczona_lista);
            List<string> Imiona_i_nazwiska = Baza.Pobierz_imiona_i_nazwiska();
            Form1_Wizyt�wki.Items.Clear();
            for (int i = 0; i < Imiona_i_nazwiska.Count; i++) Form1_Wizyt�wki.Items.Add(Imiona_i_nazwiska[i]);
        }
        private void Nowa_wizyt�wka_Click(object sender, EventArgs e)
        {
            Nowa_wizyt�wka Nowa_wizyt�wka = new Nowa_wizyt�wka(this);
            Nowa_wizyt�wka.Show();
        }
        private void Usu�_zaznaczon�_wizyt�wk�_Click(object sender, EventArgs e)
        {
            if (Form1_Wizyt�wki.SelectedIndex == -1) return;
            Baza.Usu�_wizyt�wk�(Baza.Pobierz_wizyt�wk�(Form1_Wizyt�wki.SelectedIndex).Pobierz_identyfikator());
            Zaktualizuj_list�_list();
            Zaktualizuj_list�_wizyt�wek();
            Zaktualizuj_podgl�d_wizyt�wki();
        }

        private void Form1_Szukaj_TextChanged(object sender, EventArgs e)
        {
            Zaktualizuj_list�_wizyt�wek();
            Zaktualizuj_podgl�d_wizyt�wki();
        }

        private void Nowa_lista_Click(object sender, EventArgs e)
        {
            Nowa_lista Nowa_lista = new Nowa_lista(this);
            Nowa_lista.Show();
        }

        private void Usu�_zaznaczon�_list�_Click(object sender, EventArgs e)
        {
            if (Form1_Listy.SelectedIndex <= 0) return;
            Baza.Usu�_list�(Baza.Pobierz_identyfikator_listy(Form1_Listy.SelectedIndex - 1));
            Zaktualizuj_list�_list();
            Zaktualizuj_list�_wizyt�wek();
            Zaktualizuj_podgl�d_wizyt�wki();
        }
        internal void Zaktualizuj_podgl�d_wizyt�wki()
        {
            if (Form1_Wizyt�wki.SelectedIndex == -1)
            {
                Imi�_i_nazwisko.Visible = false;
                Wy�lij_list_elektroniczny.Visible = false;
                Numer_telefonu.Visible = false;
                Odwied�_profil_na_Facebooku.Visible = false;
                Wy�lij_wiadomo��_na_Messengerze.Visible = false;
                Odwied�_profil_na_Instagramie.Visible = false;
                Wy�lij_wiadomo��_na_Instagramie.Visible = false;
                Dodaj_zaznaczon�_wizyt�wk�_do_listy.Enabled = false;
            }
            else
            {
                Imi�_i_nazwisko.Visible = true;
                string Bufor_imienia = Baza.Pobierz_wizyt�wk�(Form1_Wizyt�wki.SelectedIndex).Pobierz_dan�(0);
                string Bufor_nazwiska = Baza.Pobierz_wizyt�wk�(Form1_Wizyt�wki.SelectedIndex).Pobierz_dan�(1);
                string Bufor_imienia_i_nazwiska = Bufor_imienia;
                if (!string.IsNullOrWhiteSpace(Bufor_imienia) && !string.IsNullOrWhiteSpace(Bufor_nazwiska)) Bufor_imienia_i_nazwiska += " ";
                Imi�_i_nazwisko.Text = Bufor_imienia_i_nazwiska + Bufor_nazwiska;
                Wy�lij_list_elektroniczny.Visible = true;
                if (!string.IsNullOrWhiteSpace(Baza.Pobierz_wizyt�wk�(Form1_Wizyt�wki.SelectedIndex).Pobierz_dan�(2))) Wy�lij_list_elektroniczny.Enabled = true;
                else Wy�lij_list_elektroniczny.Enabled = false;
                string Bufor_numeru_telefonu = Baza.Pobierz_wizyt�wk�(Form1_Wizyt�wki.SelectedIndex).Pobierz_dan�(3);
                if (!string.IsNullOrWhiteSpace(Bufor_numeru_telefonu))
                {
                    Numer_telefonu.Visible = true;
                    Numer_telefonu.Text = "Numer telefonu: " + Bufor_numeru_telefonu;
                }
                else Numer_telefonu.Visible = false;
                Odwied�_profil_na_Facebooku.Visible = true;
                Wy�lij_wiadomo��_na_Messengerze.Visible = true;
                if (!string.IsNullOrWhiteSpace(Baza.Pobierz_wizyt�wk�(Form1_Wizyt�wki.SelectedIndex).Pobierz_dan�(4)))
                {
                    Odwied�_profil_na_Facebooku.Enabled = true;
                    Wy�lij_wiadomo��_na_Messengerze.Enabled = true;
                }
                else
                {
                    Odwied�_profil_na_Facebooku.Enabled = false;
                    Wy�lij_wiadomo��_na_Messengerze.Enabled = false;
                }
                Odwied�_profil_na_Instagramie.Visible = true;
                Wy�lij_wiadomo��_na_Instagramie.Visible = true;
                if (!string.IsNullOrWhiteSpace(Baza.Pobierz_wizyt�wk�(Form1_Wizyt�wki.SelectedIndex).Pobierz_dan�(5)))
                {
                    Odwied�_profil_na_Instagramie.Enabled = true;
                    Wy�lij_wiadomo��_na_Instagramie.Enabled = true;
                }
                else
                {
                    Odwied�_profil_na_Instagramie.Enabled = false;
                    Wy�lij_wiadomo��_na_Instagramie.Enabled = false;
                }
                Dodaj_zaznaczon�_wizyt�wk�_do_listy.Enabled = true;
            }
            if (Form1_Listy.SelectedIndex > 0 && Form1_Wizyt�wki.SelectedIndex >= 0)
                Usu�_zaznaczon�_wizyt�wk�_z_zaznaczonej_listy.Enabled = true;
            else Usu�_zaznaczon�_wizyt�wk�_z_zaznaczonej_listy.Enabled = false;
        }

        private void Form1_Listy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zaktualizuj_list�_wizyt�wek();
            Zaktualizuj_podgl�d_wizyt�wki();
        }

        private void Form1_Wizyt�wki_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zaktualizuj_podgl�d_wizyt�wki();
        }

        private void Odwied�_profil_na_Facebooku_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = "https://www.facebook.com/" + Baza.Pobierz_wizyt�wk�(Form1_Wizyt�wki.SelectedIndex).Pobierz_dan�(4),
                UseShellExecute = true
            };
            Process.Start(psInfo);
        }

        private void Wy�lij_wiadomo��_na_Messengerze_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = "https://m.me/" + Baza.Pobierz_wizyt�wk�(Form1_Wizyt�wki.SelectedIndex).Pobierz_dan�(4),
                UseShellExecute = true
            };
            Process.Start(psInfo);
        }

        private void Odwied�_profil_na_Instagramie_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = "https://www.instagram.com/" + Baza.Pobierz_wizyt�wk�(Form1_Wizyt�wki.SelectedIndex).Pobierz_dan�(5),
                UseShellExecute = true
            };
            Process.Start(psInfo);
        }

        private void Wy�lij_wiadomo��_na_Instagramie_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = "https://ig.me/m/" + Baza.Pobierz_wizyt�wk�(Form1_Wizyt�wki.SelectedIndex).Pobierz_dan�(5),
                UseShellExecute = true
            };
            Process.Start(psInfo);
        }

        private void Wy�lij_list_elektroniczny_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = "mailto:" + Baza.Pobierz_wizyt�wk�(Form1_Wizyt�wki.SelectedIndex).Pobierz_dan�(2),
                UseShellExecute = true
            };
            Process.Start(psInfo);
        }

        private void Dodaj_zaznaczon�_wizyt�wk�_do_listy_Click(object sender, EventArgs e)
        {
            Dodaj_do_listy Dodaj_do_listy = new Dodaj_do_listy(this, Baza.Pobierz_wizyt�wk�(Form1_Wizyt�wki.SelectedIndex).Pobierz_identyfikator());
            Dodaj_do_listy.Show();
        }

        private void Usu�_zaznaczon�_wizyt�wk�_z_zaznaczonej_listy_Click(object sender, EventArgs e)
        {
            Baza.Usu�_wizyt�wk�_z_listy(
                Baza.Pobierz_wizyt�wk�(Form1_Wizyt�wki.SelectedIndex).Pobierz_identyfikator(),
                Baza.Pobierz_identyfikator_listy(Form1_Listy.SelectedIndex - 1)
            );
            Zaktualizuj_list�_wizyt�wek();
            Zaktualizuj_podgl�d_wizyt�wki();
        }

        private void Edytuj_zaznaczon�_list�_Click(object sender, EventArgs e)
        {
            if (Form1_Listy.SelectedIndex <= 0) return;
            Edycja_listy Edycja_listy = new Edycja_listy(this,
                Baza.Pobierz_identyfikator_listy(Form1_Listy.SelectedIndex - 1),
                Form1_Listy.Text
            );
            Edycja_listy.Show();
        }

        private void Edytuj_zaznaczon�_wizyt�wk�_Click(object sender, EventArgs e) {
            if (Form1_Wizyt�wki.SelectedIndex != -1) {
                Edycja_wizyt�wki Edycja_wizyt�wki = new Edycja_wizyt�wki(this, Baza.Pobierz_wizyt�wk�(Form1_Wizyt�wki.SelectedIndex));
                Edycja_wizyt�wki.Show();
            }
        }
    }
}

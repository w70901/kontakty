using System.Diagnostics;

namespace Kontakty
{
    public partial class Form1 : Form
    {
        internal Baza_danych Baza = new Baza_danych("Baza");
        public Form1()
        {
            InitializeComponent();
            Zaktualizuj_listê_list();
            Zaktualizuj_listê_wizytówek();
            Zaktualizuj_podgl¹d_wizytówki();
        }
        internal void Zaktualizuj_listê_list()
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
                Form1_Listy.SelectedIndex = Baza.Pobierz_pozycjê_listy_w_buforze(Zaznaczona_lista) + 1;
            }
        }
        internal void Zaktualizuj_listê_wizytówek()
        {
            int Zaznaczona_lista = 0;
            if (Form1_Listy.SelectedIndex > 0) Zaznaczona_lista = Baza.Pobierz_identyfikator_listy(Form1_Listy.SelectedIndex - 1);
            Baza.Zaktualizuj_wizytówki(Form1_Szukaj.Text, Zaznaczona_lista);
            List<string> Imiona_i_nazwiska = Baza.Pobierz_imiona_i_nazwiska();
            Form1_Wizytówki.Items.Clear();
            for (int i = 0; i < Imiona_i_nazwiska.Count; i++) Form1_Wizytówki.Items.Add(Imiona_i_nazwiska[i]);
        }
        private void Nowa_wizytówka_Click(object sender, EventArgs e)
        {
            Nowa_wizytówka Nowa_wizytówka = new Nowa_wizytówka(this);
            Nowa_wizytówka.Show();
        }
        private void Usuñ_zaznaczon¹_wizytówkê_Click(object sender, EventArgs e)
        {
            if (Form1_Wizytówki.SelectedIndex == -1) return;
            Baza.Usuñ_wizytówkê(Baza.Pobierz_wizytówkê(Form1_Wizytówki.SelectedIndex).Pobierz_identyfikator());
            Zaktualizuj_listê_list();
            Zaktualizuj_listê_wizytówek();
            Zaktualizuj_podgl¹d_wizytówki();
        }

        private void Form1_Szukaj_TextChanged(object sender, EventArgs e)
        {
            Zaktualizuj_listê_wizytówek();
            Zaktualizuj_podgl¹d_wizytówki();
        }

        private void Nowa_lista_Click(object sender, EventArgs e)
        {
            Nowa_lista Nowa_lista = new Nowa_lista(this);
            Nowa_lista.Show();
        }

        private void Usuñ_zaznaczon¹_listê_Click(object sender, EventArgs e)
        {
            if (Form1_Listy.SelectedIndex <= 0) return;
            Baza.Usuñ_listê(Baza.Pobierz_identyfikator_listy(Form1_Listy.SelectedIndex - 1));
            Zaktualizuj_listê_list();
            Zaktualizuj_listê_wizytówek();
            Zaktualizuj_podgl¹d_wizytówki();
        }
        internal void Zaktualizuj_podgl¹d_wizytówki()
        {
            if (Form1_Wizytówki.SelectedIndex == -1)
            {
                Imiê_i_nazwisko.Visible = false;
                Wyœlij_list_elektroniczny.Visible = false;
                Numer_telefonu.Visible = false;
                OdwiedŸ_profil_na_Facebooku.Visible = false;
                Wyœlij_wiadomoœæ_na_Messengerze.Visible = false;
                OdwiedŸ_profil_na_Instagramie.Visible = false;
                Wyœlij_wiadomoœæ_na_Instagramie.Visible = false;
                Dodaj_zaznaczon¹_wizytówkê_do_listy.Enabled = false;
            }
            else
            {
                Imiê_i_nazwisko.Visible = true;
                string Bufor_imienia = Baza.Pobierz_wizytówkê(Form1_Wizytówki.SelectedIndex).Pobierz_dan¹(0);
                string Bufor_nazwiska = Baza.Pobierz_wizytówkê(Form1_Wizytówki.SelectedIndex).Pobierz_dan¹(1);
                string Bufor_imienia_i_nazwiska = Bufor_imienia;
                if (!string.IsNullOrWhiteSpace(Bufor_imienia) && !string.IsNullOrWhiteSpace(Bufor_nazwiska)) Bufor_imienia_i_nazwiska += " ";
                Imiê_i_nazwisko.Text = Bufor_imienia_i_nazwiska + Bufor_nazwiska;
                Wyœlij_list_elektroniczny.Visible = true;
                if (!string.IsNullOrWhiteSpace(Baza.Pobierz_wizytówkê(Form1_Wizytówki.SelectedIndex).Pobierz_dan¹(2))) Wyœlij_list_elektroniczny.Enabled = true;
                else Wyœlij_list_elektroniczny.Enabled = false;
                string Bufor_numeru_telefonu = Baza.Pobierz_wizytówkê(Form1_Wizytówki.SelectedIndex).Pobierz_dan¹(3);
                if (!string.IsNullOrWhiteSpace(Bufor_numeru_telefonu))
                {
                    Numer_telefonu.Visible = true;
                    Numer_telefonu.Text = "Numer telefonu: " + Bufor_numeru_telefonu;
                }
                else Numer_telefonu.Visible = false;
                OdwiedŸ_profil_na_Facebooku.Visible = true;
                Wyœlij_wiadomoœæ_na_Messengerze.Visible = true;
                if (!string.IsNullOrWhiteSpace(Baza.Pobierz_wizytówkê(Form1_Wizytówki.SelectedIndex).Pobierz_dan¹(4)))
                {
                    OdwiedŸ_profil_na_Facebooku.Enabled = true;
                    Wyœlij_wiadomoœæ_na_Messengerze.Enabled = true;
                }
                else
                {
                    OdwiedŸ_profil_na_Facebooku.Enabled = false;
                    Wyœlij_wiadomoœæ_na_Messengerze.Enabled = false;
                }
                OdwiedŸ_profil_na_Instagramie.Visible = true;
                Wyœlij_wiadomoœæ_na_Instagramie.Visible = true;
                if (!string.IsNullOrWhiteSpace(Baza.Pobierz_wizytówkê(Form1_Wizytówki.SelectedIndex).Pobierz_dan¹(5)))
                {
                    OdwiedŸ_profil_na_Instagramie.Enabled = true;
                    Wyœlij_wiadomoœæ_na_Instagramie.Enabled = true;
                }
                else
                {
                    OdwiedŸ_profil_na_Instagramie.Enabled = false;
                    Wyœlij_wiadomoœæ_na_Instagramie.Enabled = false;
                }
                Dodaj_zaznaczon¹_wizytówkê_do_listy.Enabled = true;
            }
            if (Form1_Listy.SelectedIndex > 0 && Form1_Wizytówki.SelectedIndex >= 0)
                Usuñ_zaznaczon¹_wizytówkê_z_zaznaczonej_listy.Enabled = true;
            else Usuñ_zaznaczon¹_wizytówkê_z_zaznaczonej_listy.Enabled = false;
        }

        private void Form1_Listy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zaktualizuj_listê_wizytówek();
            Zaktualizuj_podgl¹d_wizytówki();
        }

        private void Form1_Wizytówki_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zaktualizuj_podgl¹d_wizytówki();
        }

        private void OdwiedŸ_profil_na_Facebooku_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = "https://www.facebook.com/" + Baza.Pobierz_wizytówkê(Form1_Wizytówki.SelectedIndex).Pobierz_dan¹(4),
                UseShellExecute = true
            };
            Process.Start(psInfo);
        }

        private void Wyœlij_wiadomoœæ_na_Messengerze_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = "https://m.me/" + Baza.Pobierz_wizytówkê(Form1_Wizytówki.SelectedIndex).Pobierz_dan¹(4),
                UseShellExecute = true
            };
            Process.Start(psInfo);
        }

        private void OdwiedŸ_profil_na_Instagramie_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = "https://www.instagram.com/" + Baza.Pobierz_wizytówkê(Form1_Wizytówki.SelectedIndex).Pobierz_dan¹(5),
                UseShellExecute = true
            };
            Process.Start(psInfo);
        }

        private void Wyœlij_wiadomoœæ_na_Instagramie_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = "https://ig.me/m/" + Baza.Pobierz_wizytówkê(Form1_Wizytówki.SelectedIndex).Pobierz_dan¹(5),
                UseShellExecute = true
            };
            Process.Start(psInfo);
        }

        private void Wyœlij_list_elektroniczny_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = "mailto:" + Baza.Pobierz_wizytówkê(Form1_Wizytówki.SelectedIndex).Pobierz_dan¹(2),
                UseShellExecute = true
            };
            Process.Start(psInfo);
        }

        private void Dodaj_zaznaczon¹_wizytówkê_do_listy_Click(object sender, EventArgs e)
        {
            Dodaj_do_listy Dodaj_do_listy = new Dodaj_do_listy(this, Baza.Pobierz_wizytówkê(Form1_Wizytówki.SelectedIndex).Pobierz_identyfikator());
            Dodaj_do_listy.Show();
        }

        private void Usuñ_zaznaczon¹_wizytówkê_z_zaznaczonej_listy_Click(object sender, EventArgs e)
        {
            Baza.Usuñ_wizytówkê_z_listy(
                Baza.Pobierz_wizytówkê(Form1_Wizytówki.SelectedIndex).Pobierz_identyfikator(),
                Baza.Pobierz_identyfikator_listy(Form1_Listy.SelectedIndex - 1)
            );
            Zaktualizuj_listê_wizytówek();
            Zaktualizuj_podgl¹d_wizytówki();
        }

        private void Edytuj_zaznaczon¹_listê_Click(object sender, EventArgs e)
        {
            if (Form1_Listy.SelectedIndex <= 0) return;
            Edycja_listy Edycja_listy = new Edycja_listy(this,
                Baza.Pobierz_identyfikator_listy(Form1_Listy.SelectedIndex - 1),
                Form1_Listy.Text
            );
            Edycja_listy.Show();
        }

        private void Edytuj_zaznaczon¹_wizytówkê_Click(object sender, EventArgs e) {
            if (Form1_Wizytówki.SelectedIndex != -1) {
                Edycja_wizytówki Edycja_wizytówki = new Edycja_wizytówki(this, Baza.Pobierz_wizytówkê(Form1_Wizytówki.SelectedIndex));
                Edycja_wizytówki.Show();
            }
        }
    }
}

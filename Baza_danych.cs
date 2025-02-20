using Accessibility;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakty
{
    internal class Lista {
        int Identyfikator;
        string Nazwa;
        public Lista(int Parametr_identyfikatora, string Parametr_nazwy) {
            Identyfikator = Parametr_identyfikatora;
            Nazwa = Parametr_nazwy;
        }
        public int Pobierz_identyfikator() {
            return Identyfikator;
        }
        public string Pobierz_nazwę() {
            return Nazwa;
        }
    }
    internal class Wizytówka {
        int Identyfikator;
        List <string> Dane;
        public Wizytówka(int Parametr_identyfikatora, List <string> Parametr_danych) {
            Identyfikator = Parametr_identyfikatora;
            Dane = Parametr_danych;
        }
        public int Pobierz_identyfikator() {
            return Identyfikator;
        }
        public string Pobierz_daną(int Identyfikator_pola) {
            string Bufor_danej = "";
            if (Identyfikator_pola >= 0 && Identyfikator_pola < Dane.Count()) Bufor_danej = Dane[Identyfikator_pola];
            return Bufor_danej;
        }
    }
    internal class Baza_danych {
        string Parametr_połączenia;
        List <string> Pola = ["Imię", "Nazwisko", "Adres poczty elektronicznej",
            "Numer telefonu", "Nazwa użytkownika na Facebooku", "Nazwa użytkownika na Instagramie"
        ];
        List <Lista> Bufor_list = []; List <Wizytówka> Bufor_wizytówek = [];
        public Baza_danych(string Nazwa_pliku) {
            Parametr_połączenia = "Data Source = " + Nazwa_pliku + ".db; Pooling = False";
            string Komenda_tworzenia_tabeli = "create table if not exists Wizytówki (" +
                "Identyfikator integer not null primary key autoincrement";
            foreach (string i in Pola) Komenda_tworzenia_tabeli = Komenda_tworzenia_tabeli + ",[" + i + "] text not null";
            Wyślij_komendę_niepytającą(Komenda_tworzenia_tabeli + ")");
            Wyślij_komendę_niepytającą("create table if not exists Listy (" +
                "Identyfikator integer not null primary key autoincrement," +
                "Nazwa text not null)");
            Wyślij_komendę_niepytającą("create table if not exists Powiązania (" +
                "[Identyfikator wizytówki] integer not null," +
                "[Identyfikator listy] integer not null," +
                "primary key ([Identyfikator wizytówki], [Identyfikator listy])," +
                "foreign key ([Identyfikator wizytówki]) references Wizytówki(Identyfikator) on delete cascade," +
                "foreign key ([Identyfikator listy]) references Listy(Identyfikator) on delete cascade)");
        }
        public void Wyślij_komendę_niepytającą(string Treść_komendy) {
            using (var Połączenie = new SqliteConnection(Parametr_połączenia)) {
                Połączenie.Open();
                var Komenda = Połączenie.CreateCommand();
                Komenda.CommandText = Treść_komendy;
                Komenda.ExecuteNonQuery();
            }
        }
        public void Zaktualizuj_listy() {
            Bufor_list.Clear();
            using (var Połączenie = new SqliteConnection(Parametr_połączenia)) {
                Połączenie.Open();
                var Komenda = Połączenie.CreateCommand();
                Komenda.CommandText = "select Identyfikator, Nazwa from Listy order by Nazwa, Identyfikator";
                using (var Czytnik = Komenda.ExecuteReader()) {
                    while (Czytnik.Read()) Bufor_list.Add(new Lista(Czytnik.GetInt32(0), Czytnik.GetString(1)));
                }
            }
        }
        public void Zaktualizuj_wizytówki(string Wyszukiwana_fraza, int Identyfikator_listy)
        {
            Bufor_wizytówek.Clear();
            using (var Połączenie = new SqliteConnection(Parametr_połączenia))
            {
                Połączenie.Open();
                var Komenda = Połączenie.CreateCommand();
                Komenda.CommandText = "select * from Wizytówki";
                if (Identyfikator_listy > 0) {
                    Komenda.CommandText = Komenda.CommandText + " join Powiązania on Wizytówki.Identyfikator = Powiązania.[Identyfikator wizytówki] " +
                        "where Powiązania.[Identyfikator listy] = " + Identyfikator_listy;
                    if (!string.IsNullOrEmpty(Wyszukiwana_fraza)) Komenda.CommandText += " and (";
                }
                else if (!string.IsNullOrEmpty(Wyszukiwana_fraza)) Komenda.CommandText += " where";
                if (!string.IsNullOrEmpty(Wyszukiwana_fraza)) {
                    Komenda.CommandText = Komenda.CommandText + " Wizytówki.[" + Pola[0] + "] like '%" + Wyszukiwana_fraza + "%'";
                    for (int i = 1; i < Pola.Count(); i++) Komenda.CommandText = Komenda.CommandText + " or Wizytówki.[" + Pola[i] + "] like '%" + Wyszukiwana_fraza + "%'";
                    if (Identyfikator_listy > 0) Komenda.CommandText += ")";
                }
                Komenda.CommandText = Komenda.CommandText + " order by [" + Pola[0] + "]";
                for (int i = 1; i < Pola.Count(); i++) Komenda.CommandText = Komenda.CommandText + ", [" + Pola[i] + "]";
                using (var Czytnik = Komenda.ExecuteReader()) {
                    while (Czytnik.Read()) {
                        List <string> Bufor_danych = new List <string> ();
                        for (int i = 1; i <= Pola.Count(); i++) Bufor_danych.Add(Czytnik.GetString(i));
                        Bufor_wizytówek.Add(new Wizytówka(Czytnik.GetInt32(0), Bufor_danych));
                    }
                }
            }
        }
        public void Dodaj_listę(string Nazwa) {
            Wyślij_komendę_niepytającą("insert into Listy (Nazwa) values ('" + Nazwa + "')");
        }
        public void Dodaj_wizytówkę(List <string> Dane) {
            if (Pola.Count() == 0 || Dane.Count() != Pola.Count()) return;
            string Komenda = "insert into Wizytówki ([" + Pola[0] + "]";
            for (int i = 1; i < Pola.Count(); i++) Komenda = Komenda + ", [" + Pola[i] + "]";
            Komenda = Komenda + ") values ('" + Dane[0] + "'";
            for (int i = 1; i < Dane.Count(); i++) Komenda = Komenda + ", '" + Dane[i] + "'";
            Wyślij_komendę_niepytającą(Komenda + ")");
        }
        public List <string> Pobierz_nazwy_list() {
            List <string> Bufor_nazw_list = [];
            for (int i = 0; i < Bufor_list.Count(); i++) Bufor_nazw_list.Add(Bufor_list[i].Pobierz_nazwę());
            return Bufor_nazw_list;
        }
        public int Pobierz_identyfikator_listy(int Pozycja_w_buforze) {
            return Bufor_list[Pozycja_w_buforze].Pobierz_identyfikator();
        }
        public int Pobierz_pozycję_listy_w_buforze(int Identyfikator) {
            int Bufor_pozycji = -1;
            for (int i = 0; i < Bufor_list.Count(); i++) {
                if (Bufor_list[i].Pobierz_identyfikator() == Identyfikator) {
                    Bufor_pozycji = i;
                }
            }
            return Bufor_pozycji;
        }
        public Wizytówka Pobierz_wizytówkę(int Pozycja_w_buforze) {
            return Bufor_wizytówek[Pozycja_w_buforze];
        }
        public List <string> Pobierz_imiona_i_nazwiska() {
            List <string> Bufor_imion_i_nazwisk = new List <string> ();
            string Bufor_imienia_i_nazwiska;
            for (int i = 0; i < Bufor_wizytówek.Count(); i++) {
                Bufor_imienia_i_nazwiska = Bufor_wizytówek[i].Pobierz_daną(0);
                if (!string.IsNullOrEmpty(Bufor_wizytówek[i].Pobierz_daną(0)) &&
                    !string.IsNullOrEmpty(Bufor_wizytówek[i].Pobierz_daną(1))) {
                    Bufor_imienia_i_nazwiska += " ";
                }
                Bufor_imion_i_nazwisk.Add(Bufor_imienia_i_nazwiska + Bufor_wizytówek[i].Pobierz_daną(1));
            }
            return Bufor_imion_i_nazwisk;
        }
        public void Usuń_listę(int Identyfikator) {
            Wyślij_komendę_niepytającą("delete from Listy where Identyfikator = " + Identyfikator.ToString());
        }
        public void Usuń_wizytówkę(int Identyfikator) {
            Wyślij_komendę_niepytającą("delete from Wizytówki where Identyfikator = " + Identyfikator.ToString());
        }
        public void Dodaj_wizytówkę_do_listy(int Identyfikator_wizytówki, int Identyfikator_listy) {
            string Komenda = "insert or ignore into Powiązania ([Identyfikator wizytówki], [Identyfikator listy]) values (" +
                 Identyfikator_wizytówki.ToString() + ", " + Identyfikator_listy.ToString() + ")";
            Wyślij_komendę_niepytającą(Komenda);
        }
        public void Usuń_wizytówkę_z_listy(int Identyfikator_wizytówki, int Identyfikator_listy) {
            string Komenda = "delete from Powiązania where [Identyfikator wizytówki] = " + Identyfikator_wizytówki.ToString() +
                " and [Identyfikator listy] = " + Identyfikator_listy.ToString();
            Wyślij_komendę_niepytającą(Komenda);
        }
        public List <Lista> Pobierz_bufor_list() {
            return Bufor_list;
        }
        public void Zmień_nazwę_listy(int Identyfikator, string Nazwa) {
            string Komenda = "update Listy set Nazwa = '" + Nazwa + "' where Identyfikator = " + Identyfikator.ToString();
            Wyślij_komendę_niepytającą(Komenda);
        }
        public void Zmień_dane_wizytówki(int Identyfikator, List <string> Dane) {
            string Komenda = "update Wizytówki set [" + Pola[0] + "] = '" + Dane[0] + "', [" + Pola[1] + "] = '" + Dane[1] +
                "', [" + Pola[2] + "] = '" + Dane[2] + "', [" + Pola[3] + "] = '" + Dane[3] + "', [" + Pola[4] + "] = '" +
                Dane[4] + "', [" + Pola[5] + "] = '" + Dane[5] + "' where Identyfikator = " + Identyfikator.ToString();
            Wyślij_komendę_niepytającą(Komenda);
        }
    }
}
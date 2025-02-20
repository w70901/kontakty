namespace Kontakty
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Form1_Label1 = new Label();
            Form1_Listy = new ListBox();
            Form1_Label2 = new Label();
            Form1_Wizytówki = new ListBox();
            Form1_Szukaj = new TextBox();
            Nowa_wizytówka = new Button();
            Usuń_zaznaczoną_wizytówkę = new Button();
            Nowa_lista = new Button();
            Usuń_zaznaczoną_listę = new Button();
            Imię_i_nazwisko = new Label();
            Wyślij_list_elektroniczny = new Button();
            Numer_telefonu = new Label();
            Odwiedź_profil_na_Facebooku = new Button();
            Wyślij_wiadomość_na_Messengerze = new Button();
            Odwiedź_profil_na_Instagramie = new Button();
            Wyślij_wiadomość_na_Instagramie = new Button();
            Dodaj_zaznaczoną_wizytówkę_do_listy = new Button();
            Usuń_zaznaczoną_wizytówkę_z_zaznaczonej_listy = new Button();
            Edytuj_zaznaczoną_listę = new Button();
            Edytuj_zaznaczoną_wizytówkę = new Button();
            SuspendLayout();
            // 
            // Form1_Label1
            // 
            Form1_Label1.AutoSize = true;
            Form1_Label1.Location = new Point(12, 9);
            Form1_Label1.Name = "Form1_Label1";
            Form1_Label1.Size = new Size(31, 15);
            Form1_Label1.TabIndex = 0;
            Form1_Label1.Text = "Listy";
            // 
            // Form1_Listy
            // 
            Form1_Listy.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            Form1_Listy.FormattingEnabled = true;
            Form1_Listy.ItemHeight = 15;
            Form1_Listy.Location = new Point(12, 27);
            Form1_Listy.Name = "Form1_Listy";
            Form1_Listy.Size = new Size(120, 409);
            Form1_Listy.TabIndex = 1;
            Form1_Listy.SelectedIndexChanged += Form1_Listy_SelectedIndexChanged;
            // 
            // Form1_Label2
            // 
            Form1_Label2.AutoSize = true;
            Form1_Label2.Location = new Point(138, 53);
            Form1_Label2.Name = "Form1_Label2";
            Form1_Label2.Size = new Size(61, 15);
            Form1_Label2.TabIndex = 2;
            Form1_Label2.Text = "Wizytówki";
            // 
            // Form1_Wizytówki
            // 
            Form1_Wizytówki.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            Form1_Wizytówki.FormattingEnabled = true;
            Form1_Wizytówki.ItemHeight = 15;
            Form1_Wizytówki.Location = new Point(138, 72);
            Form1_Wizytówki.Name = "Form1_Wizytówki";
            Form1_Wizytówki.Size = new Size(200, 364);
            Form1_Wizytówki.TabIndex = 3;
            Form1_Wizytówki.SelectedIndexChanged += Form1_Wizytówki_SelectedIndexChanged;
            // 
            // Form1_Szukaj
            // 
            Form1_Szukaj.Location = new Point(138, 27);
            Form1_Szukaj.Name = "Form1_Szukaj";
            Form1_Szukaj.PlaceholderText = "Szukaj";
            Form1_Szukaj.Size = new Size(200, 23);
            Form1_Szukaj.TabIndex = 4;
            Form1_Szukaj.TextChanged += Form1_Szukaj_TextChanged;
            // 
            // Nowa_wizytówka
            // 
            Nowa_wizytówka.Location = new Point(596, 297);
            Nowa_wizytówka.Name = "Nowa_wizytówka";
            Nowa_wizytówka.Size = new Size(192, 23);
            Nowa_wizytówka.TabIndex = 5;
            Nowa_wizytówka.Text = "Nowa wizytówka";
            Nowa_wizytówka.UseVisualStyleBackColor = true;
            Nowa_wizytówka.Click += Nowa_wizytówka_Click;
            // 
            // Usuń_zaznaczoną_wizytówkę
            // 
            Usuń_zaznaczoną_wizytówkę.Location = new Point(596, 355);
            Usuń_zaznaczoną_wizytówkę.Name = "Usuń_zaznaczoną_wizytówkę";
            Usuń_zaznaczoną_wizytówkę.Size = new Size(192, 23);
            Usuń_zaznaczoną_wizytówkę.TabIndex = 6;
            Usuń_zaznaczoną_wizytówkę.Text = "Usuń zaznaczoną wizytówkę";
            Usuń_zaznaczoną_wizytówkę.UseVisualStyleBackColor = true;
            Usuń_zaznaczoną_wizytówkę.Click += Usuń_zaznaczoną_wizytówkę_Click;
            // 
            // Nowa_lista
            // 
            Nowa_lista.Location = new Point(344, 297);
            Nowa_lista.Name = "Nowa_lista";
            Nowa_lista.Size = new Size(192, 23);
            Nowa_lista.TabIndex = 7;
            Nowa_lista.Text = "Nowa lista";
            Nowa_lista.UseVisualStyleBackColor = true;
            Nowa_lista.Click += Nowa_lista_Click;
            // 
            // Usuń_zaznaczoną_listę
            // 
            Usuń_zaznaczoną_listę.Location = new Point(344, 355);
            Usuń_zaznaczoną_listę.Name = "Usuń_zaznaczoną_listę";
            Usuń_zaznaczoną_listę.Size = new Size(192, 23);
            Usuń_zaznaczoną_listę.TabIndex = 8;
            Usuń_zaznaczoną_listę.Text = "Usuń zaznaczoną listę";
            Usuń_zaznaczoną_listę.UseVisualStyleBackColor = true;
            Usuń_zaznaczoną_listę.Click += Usuń_zaznaczoną_listę_Click;
            // 
            // Imię_i_nazwisko
            // 
            Imię_i_nazwisko.AutoSize = true;
            Imię_i_nazwisko.Font = new Font("Segoe UI", 18F);
            Imię_i_nazwisko.Location = new Point(466, 24);
            Imię_i_nazwisko.Name = "Imię_i_nazwisko";
            Imię_i_nazwisko.Size = new Size(176, 32);
            Imię_i_nazwisko.TabIndex = 9;
            Imię_i_nazwisko.Text = "Imię i nazwisko";
            Imię_i_nazwisko.TextAlign = ContentAlignment.TopCenter;
            // 
            // Wyślij_list_elektroniczny
            // 
            Wyślij_list_elektroniczny.Location = new Point(466, 71);
            Wyślij_list_elektroniczny.Name = "Wyślij_list_elektroniczny";
            Wyślij_list_elektroniczny.Size = new Size(200, 23);
            Wyślij_list_elektroniczny.TabIndex = 10;
            Wyślij_list_elektroniczny.Text = "Wyślij list elektroniczny";
            Wyślij_list_elektroniczny.UseVisualStyleBackColor = true;
            Wyślij_list_elektroniczny.Click += Wyślij_list_elektroniczny_Click;
            // 
            // Numer_telefonu
            // 
            Numer_telefonu.AutoSize = true;
            Numer_telefonu.Location = new Point(466, 110);
            Numer_telefonu.Name = "Numer_telefonu";
            Numer_telefonu.Size = new Size(91, 15);
            Numer_telefonu.TabIndex = 11;
            Numer_telefonu.Text = "Numer telefonu";
            // 
            // Odwiedź_profil_na_Facebooku
            // 
            Odwiedź_profil_na_Facebooku.Location = new Point(466, 141);
            Odwiedź_profil_na_Facebooku.Name = "Odwiedź_profil_na_Facebooku";
            Odwiedź_profil_na_Facebooku.Size = new Size(200, 23);
            Odwiedź_profil_na_Facebooku.TabIndex = 12;
            Odwiedź_profil_na_Facebooku.Text = "Odwiedź profil na Facebooku";
            Odwiedź_profil_na_Facebooku.UseVisualStyleBackColor = true;
            Odwiedź_profil_na_Facebooku.Click += Odwiedź_profil_na_Facebooku_Click;
            // 
            // Wyślij_wiadomość_na_Messengerze
            // 
            Wyślij_wiadomość_na_Messengerze.Location = new Point(466, 170);
            Wyślij_wiadomość_na_Messengerze.Name = "Wyślij_wiadomość_na_Messengerze";
            Wyślij_wiadomość_na_Messengerze.Size = new Size(200, 23);
            Wyślij_wiadomość_na_Messengerze.TabIndex = 13;
            Wyślij_wiadomość_na_Messengerze.Text = "Wyślij wiadomość na Messengerze";
            Wyślij_wiadomość_na_Messengerze.UseVisualStyleBackColor = true;
            Wyślij_wiadomość_na_Messengerze.Click += Wyślij_wiadomość_na_Messengerze_Click;
            // 
            // Odwiedź_profil_na_Instagramie
            // 
            Odwiedź_profil_na_Instagramie.Location = new Point(466, 199);
            Odwiedź_profil_na_Instagramie.Name = "Odwiedź_profil_na_Instagramie";
            Odwiedź_profil_na_Instagramie.Size = new Size(200, 23);
            Odwiedź_profil_na_Instagramie.TabIndex = 14;
            Odwiedź_profil_na_Instagramie.Text = "Odwiedź profil na Instagramie";
            Odwiedź_profil_na_Instagramie.UseVisualStyleBackColor = true;
            Odwiedź_profil_na_Instagramie.Click += Odwiedź_profil_na_Instagramie_Click;
            // 
            // Wyślij_wiadomość_na_Instagramie
            // 
            Wyślij_wiadomość_na_Instagramie.Location = new Point(466, 228);
            Wyślij_wiadomość_na_Instagramie.Name = "Wyślij_wiadomość_na_Instagramie";
            Wyślij_wiadomość_na_Instagramie.Size = new Size(200, 23);
            Wyślij_wiadomość_na_Instagramie.TabIndex = 15;
            Wyślij_wiadomość_na_Instagramie.Text = "Wyślij wiadomość na Instagramie";
            Wyślij_wiadomość_na_Instagramie.UseVisualStyleBackColor = true;
            Wyślij_wiadomość_na_Instagramie.Click += Wyślij_wiadomość_na_Instagramie_Click;
            // 
            // Dodaj_zaznaczoną_wizytówkę_do_listy
            // 
            Dodaj_zaznaczoną_wizytówkę_do_listy.Location = new Point(344, 384);
            Dodaj_zaznaczoną_wizytówkę_do_listy.Name = "Dodaj_zaznaczoną_wizytówkę_do_listy";
            Dodaj_zaznaczoną_wizytówkę_do_listy.Size = new Size(444, 23);
            Dodaj_zaznaczoną_wizytówkę_do_listy.TabIndex = 16;
            Dodaj_zaznaczoną_wizytówkę_do_listy.Text = "Dodaj zaznaczoną wizytówkę do listy";
            Dodaj_zaznaczoną_wizytówkę_do_listy.UseVisualStyleBackColor = true;
            Dodaj_zaznaczoną_wizytówkę_do_listy.Click += Dodaj_zaznaczoną_wizytówkę_do_listy_Click;
            // 
            // Usuń_zaznaczoną_wizytówkę_z_zaznaczonej_listy
            // 
            Usuń_zaznaczoną_wizytówkę_z_zaznaczonej_listy.Location = new Point(344, 413);
            Usuń_zaznaczoną_wizytówkę_z_zaznaczonej_listy.Name = "Usuń_zaznaczoną_wizytówkę_z_zaznaczonej_listy";
            Usuń_zaznaczoną_wizytówkę_z_zaznaczonej_listy.Size = new Size(444, 23);
            Usuń_zaznaczoną_wizytówkę_z_zaznaczonej_listy.TabIndex = 17;
            Usuń_zaznaczoną_wizytówkę_z_zaznaczonej_listy.Text = "Usuń zaznaczoną wizytówkę z zaznaczonej listy";
            Usuń_zaznaczoną_wizytówkę_z_zaznaczonej_listy.UseVisualStyleBackColor = true;
            Usuń_zaznaczoną_wizytówkę_z_zaznaczonej_listy.Click += Usuń_zaznaczoną_wizytówkę_z_zaznaczonej_listy_Click;
            // 
            // Edytuj_zaznaczoną_listę
            // 
            Edytuj_zaznaczoną_listę.Location = new Point(344, 326);
            Edytuj_zaznaczoną_listę.Name = "Edytuj_zaznaczoną_listę";
            Edytuj_zaznaczoną_listę.Size = new Size(192, 23);
            Edytuj_zaznaczoną_listę.TabIndex = 18;
            Edytuj_zaznaczoną_listę.Text = "Edytuj zaznaczoną listę";
            Edytuj_zaznaczoną_listę.UseVisualStyleBackColor = true;
            Edytuj_zaznaczoną_listę.Click += Edytuj_zaznaczoną_listę_Click;
            // 
            // Edytuj_zaznaczoną_wizytówkę
            // 
            Edytuj_zaznaczoną_wizytówkę.Location = new Point(596, 326);
            Edytuj_zaznaczoną_wizytówkę.Name = "Edytuj_zaznaczoną_wizytówkę";
            Edytuj_zaznaczoną_wizytówkę.Size = new Size(192, 23);
            Edytuj_zaznaczoną_wizytówkę.TabIndex = 19;
            Edytuj_zaznaczoną_wizytówkę.Text = "Edytuj zaznaczoną wizytówkę";
            Edytuj_zaznaczoną_wizytówkę.UseVisualStyleBackColor = true;
            Edytuj_zaznaczoną_wizytówkę.Click += Edytuj_zaznaczoną_wizytówkę_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.BurlyWood;
            ClientSize = new Size(800, 450);
            Controls.Add(Edytuj_zaznaczoną_wizytówkę);
            Controls.Add(Edytuj_zaznaczoną_listę);
            Controls.Add(Usuń_zaznaczoną_wizytówkę_z_zaznaczonej_listy);
            Controls.Add(Dodaj_zaznaczoną_wizytówkę_do_listy);
            Controls.Add(Wyślij_wiadomość_na_Instagramie);
            Controls.Add(Odwiedź_profil_na_Instagramie);
            Controls.Add(Wyślij_wiadomość_na_Messengerze);
            Controls.Add(Odwiedź_profil_na_Facebooku);
            Controls.Add(Numer_telefonu);
            Controls.Add(Wyślij_list_elektroniczny);
            Controls.Add(Imię_i_nazwisko);
            Controls.Add(Usuń_zaznaczoną_listę);
            Controls.Add(Nowa_lista);
            Controls.Add(Usuń_zaznaczoną_wizytówkę);
            Controls.Add(Nowa_wizytówka);
            Controls.Add(Form1_Szukaj);
            Controls.Add(Form1_Wizytówki);
            Controls.Add(Form1_Label2);
            Controls.Add(Form1_Listy);
            Controls.Add(Form1_Label1);
            Name = "Form1";
            Text = "Kontakty";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Form1_Label1;
        private ListBox Form1_Listy;
        private Label Form1_Label2;
        private ListBox Form1_Wizytówki;
        private TextBox Form1_Szukaj;
        private Button Nowa_wizytówka;
        private Button Usuń_zaznaczoną_wizytówkę;
        private Button Nowa_lista;
        private Button Usuń_zaznaczoną_listę;
        private Label Imię_i_nazwisko;
        private Button Wyślij_list_elektroniczny;
        private Label Numer_telefonu;
        private Button Odwiedź_profil_na_Facebooku;
        private Button Wyślij_wiadomość_na_Messengerze;
        private Button Odwiedź_profil_na_Instagramie;
        private Button Wyślij_wiadomość_na_Instagramie;
        private Button Dodaj_zaznaczoną_wizytówkę_do_listy;
        private Button Usuń_zaznaczoną_wizytówkę_z_zaznaczonej_listy;
        private Button Edytuj_zaznaczoną_listę;
        private Button Edytuj_zaznaczoną_wizytówkę;
    }
}

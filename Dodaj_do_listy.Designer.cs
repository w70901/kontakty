namespace Kontakty
{
    partial class Dodaj_do_listy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Dodaj_wizytówkę_do_poniższej_listy = new Button();
            Wybór_listy = new ComboBox();
            SuspendLayout();
            // 
            // Dodaj_wizytówkę_do_poniższej_listy
            // 
            Dodaj_wizytówkę_do_poniższej_listy.Location = new Point(12, 12);
            Dodaj_wizytówkę_do_poniższej_listy.Name = "Dodaj_wizytówkę_do_poniższej_listy";
            Dodaj_wizytówkę_do_poniższej_listy.Size = new Size(200, 23);
            Dodaj_wizytówkę_do_poniższej_listy.TabIndex = 0;
            Dodaj_wizytówkę_do_poniższej_listy.Text = "Dodaj wizytówkę do poniższej listy";
            Dodaj_wizytówkę_do_poniższej_listy.UseVisualStyleBackColor = true;
            Dodaj_wizytówkę_do_poniższej_listy.Click += Dodaj_wizytówkę_do_poniższej_listy_Click;
            // 
            // Wybór_listy
            // 
            Wybór_listy.DropDownStyle = ComboBoxStyle.DropDownList;
            Wybór_listy.FormattingEnabled = true;
            Wybór_listy.Location = new Point(12, 41);
            Wybór_listy.Name = "Wybór_listy";
            Wybór_listy.Size = new Size(200, 23);
            Wybór_listy.TabIndex = 1;
            // 
            // Dodaj_do_listy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.BurlyWood;
            ClientSize = new Size(226, 78);
            Controls.Add(Wybór_listy);
            Controls.Add(Dodaj_wizytówkę_do_poniższej_listy);
            Name = "Dodaj_do_listy";
            Text = "Dodaj wizytówkę do listy";
            ResumeLayout(false);
        }

        #endregion

        private Button Dodaj_wizytówkę_do_poniższej_listy;
        private ComboBox Wybór_listy;
    }
}
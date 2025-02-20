namespace Kontakty
{
    partial class Nowa_lista
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
            Nazwa_listy = new TextBox();
            Dodaj_listę = new Button();
            SuspendLayout();
            // 
            // Nazwa_listy
            // 
            Nazwa_listy.Location = new Point(12, 12);
            Nazwa_listy.Name = "Nazwa_listy";
            Nazwa_listy.PlaceholderText = "Nazwa listy";
            Nazwa_listy.Size = new Size(192, 23);
            Nazwa_listy.TabIndex = 1;
            // 
            // Dodaj_listę
            // 
            Dodaj_listę.Location = new Point(12, 41);
            Dodaj_listę.Name = "Dodaj_listę";
            Dodaj_listę.Size = new Size(192, 23);
            Dodaj_listę.TabIndex = 2;
            Dodaj_listę.Text = "Dodaj listę";
            Dodaj_listę.UseVisualStyleBackColor = true;
            Dodaj_listę.Click += Dodaj_listę_Click;
            // 
            // Nowa_lista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.BurlyWood;
            ClientSize = new Size(216, 77);
            Controls.Add(Dodaj_listę);
            Controls.Add(Nazwa_listy);
            Name = "Nowa_lista";
            Text = "Nowa lista";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Nazwa_listy;
        private Button Dodaj_listę;
    }
}
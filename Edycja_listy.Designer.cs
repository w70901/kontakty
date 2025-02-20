namespace Kontakty
{
    partial class Edycja_listy
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
            Zapisz_zmianę = new Button();
            SuspendLayout();
            // 
            // Nazwa_listy
            // 
            Nazwa_listy.Location = new Point(12, 12);
            Nazwa_listy.Name = "Nazwa_listy";
            Nazwa_listy.PlaceholderText = "(nazwa listy)";
            Nazwa_listy.Size = new Size(210, 23);
            Nazwa_listy.TabIndex = 0;
            // 
            // Zapisz_zmianę
            // 
            Zapisz_zmianę.Location = new Point(12, 41);
            Zapisz_zmianę.Name = "Zapisz_zmianę";
            Zapisz_zmianę.Size = new Size(210, 23);
            Zapisz_zmianę.TabIndex = 1;
            Zapisz_zmianę.Text = "Zapisz zmianę";
            Zapisz_zmianę.UseVisualStyleBackColor = true;
            Zapisz_zmianę.Click += Zapisz_zmianę_Click;
            // 
            // Edycja_listy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.BurlyWood;
            ClientSize = new Size(236, 73);
            Controls.Add(Zapisz_zmianę);
            Controls.Add(Nazwa_listy);
            Name = "Edycja_listy";
            Text = "Edycja listy";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Nazwa_listy;
        private Button Zapisz_zmianę;
    }
}
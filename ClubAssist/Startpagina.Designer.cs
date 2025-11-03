namespace ClubAssist
{
    partial class Startpagina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Startpagina));
            pictureBox1 = new PictureBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnRegistratie = new Button();
            btnInloggen = new Button();
            btnOrganisatortest = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(240, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(307, 72);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(197, 119);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(400, 23);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(197, 166);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(400, 23);
            txtPassword.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(113, 169);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 6;
            label2.Text = "Wachtwoord:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(95, 122);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 5;
            label1.Text = "Gebruikersnaam:";
            // 
            // btnRegistratie
            // 
            btnRegistratie.Location = new Point(197, 221);
            btnRegistratie.Name = "btnRegistratie";
            btnRegistratie.Size = new Size(92, 40);
            btnRegistratie.TabIndex = 23;
            btnRegistratie.Text = "Registreren";
            btnRegistratie.UseVisualStyleBackColor = true;
            btnRegistratie.Click += btnRegistratie_Click_1;
            // 
            // btnInloggen
            // 
            btnInloggen.BackColor = Color.DarkOrange;
            btnInloggen.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInloggen.Location = new Point(505, 221);
            btnInloggen.Name = "btnInloggen";
            btnInloggen.Size = new Size(92, 40);
            btnInloggen.TabIndex = 22;
            btnInloggen.Text = "Inloggen";
            btnInloggen.UseVisualStyleBackColor = false;
            btnInloggen.Click += btnInloggen_Click;
            // 
            // btnOrganisatortest
            // 
            btnOrganisatortest.BackColor = Color.DarkOrange;
            btnOrganisatortest.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOrganisatortest.Location = new Point(617, 12);
            btnOrganisatortest.Name = "btnOrganisatortest";
            btnOrganisatortest.Size = new Size(124, 55);
            btnOrganisatortest.TabIndex = 24;
            btnOrganisatortest.Text = "Organisator Testomgeving";
            btnOrganisatortest.UseVisualStyleBackColor = false;
            btnOrganisatortest.Click += btnTESTORGANISATOR_Click;
            // 
            // Startpagina
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(753, 282);
            Controls.Add(btnOrganisatortest);
            Controls.Add(btnRegistratie);
            Controls.Add(btnInloggen);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(pictureBox1);
            Name = "Startpagina";
            Text = "Club Assist";
            Load += Startpagina_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label label2;
        private Label label1;
        private Button btnRegistratie;
        private Button btnInloggen;
        private Button btnOrganisatortest;
    }
}

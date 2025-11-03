namespace ClubAssist.View.Organisator
{
    partial class frmActiviteitAanmaken
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActiviteitAanmaken));
            btnRegistratie = new Button();
            btnAanmaken = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtLocatie = new TextBox();
            label2 = new Label();
            txtOmschrijving = new TextBox();
            label1 = new Label();
            txtTitel = new TextBox();
            pictureBox1 = new PictureBox();
            cbBenodigd = new ComboBox();
            dtpStarttijd = new DateTimePicker();
            dtpEindtijd = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnRegistratie
            // 
            btnRegistratie.Location = new Point(181, 389);
            btnRegistratie.Name = "btnRegistratie";
            btnRegistratie.Size = new Size(92, 40);
            btnRegistratie.TabIndex = 38;
            btnRegistratie.Text = "Annuleren";
            btnRegistratie.UseVisualStyleBackColor = true;
            // 
            // btnAanmaken
            // 
            btnAanmaken.BackColor = Color.DarkOrange;
            btnAanmaken.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAanmaken.Location = new Point(451, 389);
            btnAanmaken.Name = "btnAanmaken";
            btnAanmaken.Size = new Size(130, 40);
            btnAanmaken.TabIndex = 37;
            btnAanmaken.Text = "Aanmaken Activiteit";
            btnAanmaken.UseVisualStyleBackColor = false;
            btnAanmaken.Click += btnAanmaken_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(45, 325);
            label6.Name = "label6";
            label6.Size = new Size(130, 15);
            label6.TabIndex = 34;
            label6.Text = "Benodigde Vrijwilligers:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(124, 287);
            label5.Name = "label5";
            label5.Size = new Size(50, 15);
            label5.TabIndex = 32;
            label5.Text = "Eindtijd:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(124, 249);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 30;
            label4.Text = "Starttijd:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(127, 211);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 28;
            label3.Text = "Locatie:";
            // 
            // txtLocatie
            // 
            txtLocatie.Location = new Point(181, 208);
            txtLocatie.Name = "txtLocatie";
            txtLocatie.Size = new Size(400, 23);
            txtLocatie.TabIndex = 27;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(100, 172);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 26;
            label2.Text = "Omschrijving:";
            // 
            // txtOmschrijving
            // 
            txtOmschrijving.Location = new Point(181, 169);
            txtOmschrijving.Name = "txtOmschrijving";
            txtOmschrijving.Size = new Size(400, 23);
            txtOmschrijving.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(143, 134);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 24;
            label1.Text = "Titel:";
            // 
            // txtTitel
            // 
            txtTitel.Location = new Point(181, 131);
            txtTitel.Name = "txtTitel";
            txtTitel.Size = new Size(400, 23);
            txtTitel.TabIndex = 23;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(216, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(307, 72);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // cbBenodigd
            // 
            cbBenodigd.FormattingEnabled = true;
            cbBenodigd.Location = new Point(181, 322);
            cbBenodigd.Name = "cbBenodigd";
            cbBenodigd.Size = new Size(400, 23);
            cbBenodigd.TabIndex = 39;
            // 
            // dtpStarttijd
            // 
            dtpStarttijd.CustomFormat = "dddd d MMMM yyyy HH:mm";
            dtpStarttijd.Format = DateTimePickerFormat.Custom;
            dtpStarttijd.Location = new Point(181, 245);
            dtpStarttijd.Name = "dtpStarttijd";
            dtpStarttijd.Size = new Size(400, 23);
            dtpStarttijd.TabIndex = 40;
            // 
            // dtpEindtijd
            // 
            dtpEindtijd.CustomFormat = "dddd d MMMM yyyy HH:mm";
            dtpEindtijd.Format = DateTimePickerFormat.Custom;
            dtpEindtijd.Location = new Point(181, 284);
            dtpEindtijd.Name = "dtpEindtijd";
            dtpEindtijd.Size = new Size(400, 23);
            dtpEindtijd.TabIndex = 41;
            // 
            // frmActiviteitAanmaken
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(705, 450);
            Controls.Add(dtpEindtijd);
            Controls.Add(dtpStarttijd);
            Controls.Add(cbBenodigd);
            Controls.Add(btnRegistratie);
            Controls.Add(btnAanmaken);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtLocatie);
            Controls.Add(label2);
            Controls.Add(txtOmschrijving);
            Controls.Add(label1);
            Controls.Add(txtTitel);
            Controls.Add(pictureBox1);
            Name = "frmActiviteitAanmaken";
            Text = "Activiteit aanmaken";
            Load += frmActiviteitAanmaken_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegistratie;
        private Button btnAanmaken;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtLocatie;
        private Label label2;
        private TextBox txtOmschrijving;
        private Label label1;
        private TextBox txtTitel;
        private PictureBox pictureBox1;
        private ComboBox cbBenodigd;
        private DateTimePicker dtpStarttijd;
        private DateTimePicker dtpEindtijd;
    }
}
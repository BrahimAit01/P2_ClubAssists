namespace ClubAssist.View.Organisator
{
    partial class frmActiviteitenschermOrganisator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActiviteitenschermOrganisator));
            btnVerwijderen = new Button();
            pictureBox1 = new PictureBox();
            lvActivities = new ListView();
            btnActiviteitAanpassen = new Button();
            btnActiviteitAanmaken = new Button();
            btnRefresh = new Button();
            btnToonVrijwilligers = new Button();
            pbUitloggen = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbUitloggen).BeginInit();
            SuspendLayout();
            // 
            // btnVerwijderen
            // 
            btnVerwijderen.BackColor = Color.DarkOrange;
            btnVerwijderen.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVerwijderen.Location = new Point(423, 415);
            btnVerwijderen.Name = "btnVerwijderen";
            btnVerwijderen.Size = new Size(161, 43);
            btnVerwijderen.TabIndex = 35;
            btnVerwijderen.Text = "Activiteit Verwijderen";
            btnVerwijderen.UseVisualStyleBackColor = false;
            btnVerwijderen.Click += btnVerwijderen_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(375, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(307, 72);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 34;
            pictureBox1.TabStop = false;
            // 
            // lvActivities
            // 
            lvActivities.Location = new Point(12, 96);
            lvActivities.Margin = new Padding(3, 2, 3, 2);
            lvActivities.Name = "lvActivities";
            lvActivities.Size = new Size(968, 303);
            lvActivities.TabIndex = 33;
            lvActivities.UseCompatibleStateImageBehavior = false;
            // 
            // btnActiviteitAanpassen
            // 
            btnActiviteitAanpassen.BackColor = Color.DarkOrange;
            btnActiviteitAanpassen.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActiviteitAanpassen.Location = new Point(624, 415);
            btnActiviteitAanpassen.Name = "btnActiviteitAanpassen";
            btnActiviteitAanpassen.Size = new Size(161, 43);
            btnActiviteitAanpassen.TabIndex = 32;
            btnActiviteitAanpassen.Text = "Activiteit Aanpassen";
            btnActiviteitAanpassen.UseVisualStyleBackColor = false;
            btnActiviteitAanpassen.Click += btnActiviteitAanpassen_Click;
            // 
            // btnActiviteitAanmaken
            // 
            btnActiviteitAanmaken.BackColor = Color.DarkOrange;
            btnActiviteitAanmaken.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActiviteitAanmaken.Location = new Point(219, 415);
            btnActiviteitAanmaken.Name = "btnActiviteitAanmaken";
            btnActiviteitAanmaken.Size = new Size(161, 43);
            btnActiviteitAanmaken.TabIndex = 31;
            btnActiviteitAanmaken.Text = "Activiteit Toevoegen";
            btnActiviteitAanmaken.UseVisualStyleBackColor = false;
            btnActiviteitAanmaken.Click += btnActiviteitAanmaken_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.DarkOrange;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.Location = new Point(11, 415);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(161, 43);
            btnRefresh.TabIndex = 30;
            btnRefresh.Text = "Beschikbare Activiteiten";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnToonVrijwilligers
            // 
            btnToonVrijwilligers.BackColor = Color.DarkOrange;
            btnToonVrijwilligers.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnToonVrijwilligers.Location = new Point(819, 415);
            btnToonVrijwilligers.Name = "btnToonVrijwilligers";
            btnToonVrijwilligers.Size = new Size(161, 43);
            btnToonVrijwilligers.TabIndex = 36;
            btnToonVrijwilligers.Text = "Aangemelde Vrijwilligers Tonen";
            btnToonVrijwilligers.UseVisualStyleBackColor = false;
            btnToonVrijwilligers.Click += btnToonVrijwilligers_Click;
            // 
            // pbUitloggen
            // 
            pbUitloggen.Image = (Image)resources.GetObject("pbUitloggen.Image");
            pbUitloggen.Location = new Point(880, 34);
            pbUitloggen.Name = "pbUitloggen";
            pbUitloggen.Size = new Size(100, 50);
            pbUitloggen.SizeMode = PictureBoxSizeMode.Zoom;
            pbUitloggen.TabIndex = 37;
            pbUitloggen.TabStop = false;
            pbUitloggen.Click += pbUitloggen_Click;
            // 
            // frmActiviteitenschermOrganisator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(992, 465);
            Controls.Add(pbUitloggen);
            Controls.Add(btnToonVrijwilligers);
            Controls.Add(btnVerwijderen);
            Controls.Add(pictureBox1);
            Controls.Add(lvActivities);
            Controls.Add(btnActiviteitAanpassen);
            Controls.Add(btnActiviteitAanmaken);
            Controls.Add(btnRefresh);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmActiviteitenschermOrganisator";
            Text = "Activiteiten Organisator";
            Load += frmActiviteitenschermOrganisator_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbUitloggen).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnVerwijderen;
        private PictureBox pictureBox1;
        private ListView lvActivities;
        private Button btnActiviteitAanpassen;
        private Button btnActiviteitAanmaken;
        private Button btnRefresh;
        private Button btnToonVrijwilligers;
        private PictureBox pbUitloggen;
    }
}
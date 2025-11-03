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
            button2 = new Button();
            btnActiviteitAanmaken = new Button();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnVerwijderen
            // 
            btnVerwijderen.BackColor = Color.DarkOrange;
            btnVerwijderen.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVerwijderen.Location = new Point(423, 404);
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
            pictureBox1.Location = new Point(268, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(307, 72);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 34;
            pictureBox1.TabStop = false;
            // 
            // lvActivities
            // 
            lvActivities.Location = new Point(33, 93);
            lvActivities.Name = "lvActivities";
            lvActivities.Size = new Size(735, 296);
            lvActivities.TabIndex = 33;
            lvActivities.UseCompatibleStateImageBehavior = false;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkOrange;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(607, 404);
            button2.Name = "button2";
            button2.Size = new Size(161, 43);
            button2.TabIndex = 32;
            button2.Text = "Activiteit Aanpassen";
            button2.UseVisualStyleBackColor = false;
            // 
            // btnActiviteitAanmaken
            // 
            btnActiviteitAanmaken.BackColor = Color.DarkOrange;
            btnActiviteitAanmaken.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActiviteitAanmaken.Location = new Point(229, 404);
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
            btnRefresh.Location = new Point(33, 404);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(161, 43);
            btnRefresh.TabIndex = 30;
            btnRefresh.Text = "Beschikbare Activiteiten";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // frmActiviteitenschermOrganisator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(800, 461);
            Controls.Add(btnVerwijderen);
            Controls.Add(pictureBox1);
            Controls.Add(lvActivities);
            Controls.Add(button2);
            Controls.Add(btnActiviteitAanmaken);
            Controls.Add(btnRefresh);
            Name = "frmActiviteitenschermOrganisator";
            Text = "Activiteiten Organisator";
            Load += frmActiviteitenschermOrganisator_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnVerwijderen;
        private PictureBox pictureBox1;
        private ListView lvActivities;
        private Button button2;
        private Button btnActiviteitAanmaken;
        private Button btnRefresh;
    }
}
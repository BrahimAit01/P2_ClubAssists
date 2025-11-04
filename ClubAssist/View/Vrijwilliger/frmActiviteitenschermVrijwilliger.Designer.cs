namespace ClubAssist.Pages
{
    partial class frmActiviteitenschermVrijwilliger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActiviteitenschermVrijwilliger));
            label1 = new Label();
            btnInloggen = new Button();
            button1 = new Button();
            lvActivities = new ListView();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            pbUitloggen = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbUitloggen).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F);
            label1.Location = new Point(219, 32);
            label1.Name = "label1";
            label1.Size = new Size(0, 54);
            label1.TabIndex = 0;
            // 
            // btnInloggen
            // 
            btnInloggen.BackColor = Color.DarkOrange;
            btnInloggen.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInloggen.Location = new Point(33, 400);
            btnInloggen.Name = "btnInloggen";
            btnInloggen.Size = new Size(161, 43);
            btnInloggen.TabIndex = 23;
            btnInloggen.Text = "Beschikbare Activiteiten";
            btnInloggen.UseVisualStyleBackColor = false;
            btnInloggen.Click += btnAlleActiviteiten_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkOrange;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(346, 401);
            button1.Name = "button1";
            button1.Size = new Size(161, 43);
            button1.TabIndex = 24;
            button1.Text = "Mijn Activiteiten";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnMijnActiviteiten_Click;
            // 
            // lvActivities
            // 
            lvActivities.Location = new Point(33, 89);
            lvActivities.Name = "lvActivities";
            lvActivities.Size = new Size(735, 296);
            lvActivities.TabIndex = 27;
            lvActivities.UseCompatibleStateImageBehavior = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(268, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(307, 72);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 28;
            pictureBox1.TabStop = false;
            // 
            // button3
            // 
            button3.BackColor = Color.DarkOrange;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(607, 400);
            button3.Name = "button3";
            button3.Size = new Size(161, 43);
            button3.TabIndex = 29;
            button3.Text = "Aanmelden Activiteit";
            button3.UseVisualStyleBackColor = false;
            button3.Click += btnAanmelden_Click;
            // 
            // pbUitloggen
            // 
            pbUitloggen.Image = (Image)resources.GetObject("pbUitloggen.Image");
            pbUitloggen.Location = new Point(702, 22);
            pbUitloggen.Name = "pbUitloggen";
            pbUitloggen.Size = new Size(100, 50);
            pbUitloggen.SizeMode = PictureBoxSizeMode.Zoom;
            pbUitloggen.TabIndex = 30;
            pbUitloggen.TabStop = false;
            pbUitloggen.Click += pbUitloggen_Click;
            // 
            // frmActiviteitenschermVrijwilliger
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(814, 456);
            Controls.Add(pbUitloggen);
            Controls.Add(button3);
            Controls.Add(pictureBox1);
            Controls.Add(lvActivities);
            Controls.Add(button1);
            Controls.Add(btnInloggen);
            Controls.Add(label1);
            Name = "frmActiviteitenschermVrijwilliger";
            Text = "Activiteiten Vrijwilliger";
            Load += frmActiviteitenscherm_Load;
            Click += btnMijnActiviteiten_Click;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbUitloggen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnInloggen;
        private Button button1;
        private ListView lvActivities;
        private PictureBox pictureBox1;
        private Button button3;
        private PictureBox pbUitloggen;
    }
}
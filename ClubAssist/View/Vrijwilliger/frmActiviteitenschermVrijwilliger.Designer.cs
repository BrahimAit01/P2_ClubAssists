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
            button2 = new Button();
            lvActivities = new ListView();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            // 
            // button1
            // 
            button1.BackColor = Color.DarkOrange;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(229, 400);
            button1.Name = "button1";
            button1.Size = new Size(161, 43);
            button1.TabIndex = 24;
            button1.Text = "Mijn Activiteiten";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkOrange;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(607, 400);
            button2.Name = "button2";
            button2.Size = new Size(161, 43);
            button2.TabIndex = 26;
            button2.Text = "Uitloggen";
            button2.UseVisualStyleBackColor = false;
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
            button3.Location = new Point(424, 400);
            button3.Name = "button3";
            button3.Size = new Size(161, 43);
            button3.TabIndex = 29;
            button3.Text = "Aanmelden Activiteit";
            button3.UseVisualStyleBackColor = false;
            // 
            // frmActiviteitenschermVrijwilliger
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(814, 456);
            Controls.Add(button3);
            Controls.Add(pictureBox1);
            Controls.Add(lvActivities);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnInloggen);
            Controls.Add(label1);
            Name = "frmActiviteitenschermVrijwilliger";
            Text = "Activiteiten Vrijwilliger";
            Load += frmActiviteitenscherm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnInloggen;
        private Button button1;
        private Button button2;
        private ListView lvActivities;
        private PictureBox pictureBox1;
        private Button button3;
    }
}
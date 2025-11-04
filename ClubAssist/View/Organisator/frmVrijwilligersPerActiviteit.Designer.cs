namespace ClubAssist.View.Organisator
{
    partial class frmVrijwilligersPerActiviteit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVrijwilligersPerActiviteit));
            lvVrijwilligers = new ListView();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lvVrijwilligers
            // 
            lvVrijwilligers.Location = new Point(12, 100);
            lvVrijwilligers.Name = "lvVrijwilligers";
            lvVrijwilligers.Size = new Size(776, 338);
            lvVrijwilligers.TabIndex = 0;
            lvVrijwilligers.UseCompatibleStateImageBehavior = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(266, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(307, 72);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 35;
            pictureBox1.TabStop = false;
            // 
            // frmVrijwilligersPerActiviteit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(lvVrijwilligers);
            Name = "frmVrijwilligersPerActiviteit";
            Text = "Vrijwilligers per Activiteit";
            Load += frmVrijwilligersPerActiviteit_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListView lvVrijwilligers;
        private PictureBox pictureBox1;
    }
}
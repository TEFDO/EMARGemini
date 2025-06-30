using System.Drawing;
using System.Windows.Forms;

namespace EMAR.UControls
{
    partial class BolgeGenelButonu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı Üretimi Kod

        private void InitializeComponent()
        {
            pictureBoxIcon = new PictureBox();
            lblBaslik = new Label();
            lblAciklama = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.Location = new Point(20, 26);
            pictureBoxIcon.Margin = new Padding(4);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(52, 51);
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxIcon.TabIndex = 0;
            pictureBoxIcon.TabStop = false;
            // 
            // lblBaslik
            // 
            lblBaslik.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblBaslik.ForeColor = Color.Black;
            lblBaslik.Location = new Point(79, 13);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(466, 57);
            lblBaslik.TabIndex = 1;
            lblBaslik.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAciklama
            // 
            lblAciklama.Font = new Font("Segoe UI", 9.5F);
            lblAciklama.ForeColor = Color.DimGray;
            lblAciklama.Location = new Point(79, 70);
            lblAciklama.Name = "lblAciklama";
            lblAciklama.Size = new Size(466, 60);
            lblAciklama.TabIndex = 0;
            // 
            // BolgeGenelButonu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 235, 235);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblAciklama);
            Controls.Add(lblBaslik);
            Controls.Add(pictureBoxIcon);
            Cursor = Cursors.Hand;
            Margin = new Padding(4);
            Name = "BolgeGenelButonu";
            Padding = new Padding(13);
            Size = new Size(561, 160);
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label lblAciklama;
    }
}

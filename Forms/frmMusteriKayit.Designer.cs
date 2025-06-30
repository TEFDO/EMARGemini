using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EMAR
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmMusteriKayit : Form
    {

        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            txtAd = new TextBox();
            txtAdres = new TextBox();
            picLogo = new PictureBox();
            btnLogoSec = new Button();
            btnKaydet = new Button();
            btnCikis = new Button();
            lblAd = new Label();
            lblAdres = new Label();
            lblLogo = new Label();
            ofdLogo = new OpenFileDialog();
            btnLogoTemizle = new Button();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // txtAd
            // 
            txtAd.Font = new Font("Segoe UI", 11F);
            txtAd.Location = new Point(429, 83);
            txtAd.Margin = new Padding(4);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(545, 47);
            txtAd.TabIndex = 0;
            // 
            // txtAdres
            // 
            txtAdres.Font = new Font("Segoe UI", 11F);
            txtAdres.Location = new Point(429, 205);
            txtAdres.Margin = new Padding(4);
            txtAdres.Multiline = true;
            txtAdres.Name = "txtAdres";
            txtAdres.Size = new Size(545, 127);
            txtAdres.TabIndex = 1;
            // 
            // picLogo
            // 
            picLogo.BorderStyle = BorderStyle.FixedSingle;
            picLogo.Location = new Point(65, 83);
            picLogo.Margin = new Padding(4);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(311, 249);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 3;
            picLogo.TabStop = false;
            // 
            // btnLogoSec
            // 
            btnLogoSec.Location = new Point(129, 346);
            btnLogoSec.Margin = new Padding(4);
            btnLogoSec.Name = "btnLogoSec";
            btnLogoSec.Size = new Size(182, 51);
            btnLogoSec.TabIndex = 2;
            btnLogoSec.Text = "Logo Seç";
            btnLogoSec.UseVisualStyleBackColor = true;
            btnLogoSec.Click += btnLogoSec_Click;
            // 
            // btnKaydet
            // 
            btnKaydet.Font = new Font("Segoe UI Semibold", 10F);
            btnKaydet.Location = new Point(676, 371);
            btnKaydet.Margin = new Padding(4);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(156, 64);
            btnKaydet.TabIndex = 3;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnCikis
            // 
            btnCikis.Font = new Font("Segoe UI Semibold", 10F);
            btnCikis.Location = new Point(494, 371);
            btnCikis.Margin = new Padding(4);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(156, 64);
            btnCikis.TabIndex = 4;
            btnCikis.Text = "Çıkış";
            btnCikis.UseVisualStyleBackColor = true;
            btnCikis.Click += btnCikis_Click;
            // 
            // lblAd
            // 
            lblAd.AutoSize = true;
            lblAd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAd.Location = new Point(429, 38);
            lblAd.Margin = new Padding(4, 0, 4, 0);
            lblAd.Name = "lblAd";
            lblAd.Size = new Size(174, 37);
            lblAd.TabIndex = 0;
            lblAd.Text = "Müşteri Adı:";
            // 
            // lblAdres
            // 
            lblAdres.AutoSize = true;
            lblAdres.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAdres.Location = new Point(429, 160);
            lblAdres.Margin = new Padding(4, 0, 4, 0);
            lblAdres.Name = "lblAdres";
            lblAdres.Size = new Size(212, 37);
            lblAdres.TabIndex = 1;
            lblAdres.Text = "Müşteri Adresi:";
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLogo.Location = new Point(65, 38);
            lblLogo.Margin = new Padding(4, 0, 4, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(223, 37);
            lblLogo.TabIndex = 2;
            lblLogo.Text = "Müşteri Logosu:";
            // 
            // btnLogoTemizle
            // 
            btnLogoTemizle.Location = new Point(151, 404);
            btnLogoTemizle.Name = "btnLogoTemizle";
            btnLogoTemizle.Size = new Size(139, 51);
            btnLogoTemizle.TabIndex = 5;
            btnLogoTemizle.Text = "Temizle";
            btnLogoTemizle.UseVisualStyleBackColor = true;
            btnLogoTemizle.Click += btnLogoTemizle_Click;
            // 
            // frmMusteriKayit
            // 
            AcceptButton = btnKaydet;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCikis;
            ClientSize = new Size(1040, 486);
            Controls.Add(btnLogoTemizle);
            Controls.Add(lblAd);
            Controls.Add(lblAdres);
            Controls.Add(lblLogo);
            Controls.Add(txtAd);
            Controls.Add(txtAdres);
            Controls.Add(picLogo);
            Controls.Add(btnLogoSec);
            Controls.Add(btnKaydet);
            Controls.Add(btnCikis);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMusteriKayit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Müşteri Kayıt";
            Load += frmMusteriKayit_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        internal TextBox txtAd;
        internal TextBox txtAdres;
        internal PictureBox picLogo;
        internal Button btnLogoSec;
        internal Button btnKaydet;
        internal Button btnCikis;
        internal Label lblAd;
        internal Label lblAdres;
        internal Label lblLogo;
        private OpenFileDialog ofdLogo;
        private Button btnLogoTemizle;
    }
}
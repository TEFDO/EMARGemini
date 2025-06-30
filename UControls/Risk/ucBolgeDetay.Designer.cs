namespace EMAR.UControls
{
    partial class ucBolgeDetay
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcı Kodu

        private void InitializeComponent()
        {
            this.lblBaslik = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.txtNotlar = new System.Windows.Forms.TextBox();
            this.picGorsel = new System.Windows.Forms.PictureBox();
            this.btnGorselSec = new System.Windows.Forms.Button();
            this.btnGorselTemizle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picGorsel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Location = new System.Drawing.Point(40, 30);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(312, 38);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Bölge 1 – Kontrol Sistemi";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtAciklama.Location = new System.Drawing.Point(40, 90);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAciklama.Size = new System.Drawing.Size(800, 120);
            this.txtAciklama.TabIndex = 1;
            this.txtAciklama.PlaceholderText = "Bölgeye ait açıklamaları buraya yazınız...";
            // 
            // txtNotlar
            // 
            this.txtNotlar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNotlar.Location = new System.Drawing.Point(40, 240);
            this.txtNotlar.Multiline = true;
            this.txtNotlar.Name = "txtNotlar";
            this.txtNotlar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotlar.Size = new System.Drawing.Size(800, 120);
            this.txtNotlar.TabIndex = 2;
            this.txtNotlar.PlaceholderText = "Ek notlar...";
            // 
            // picGorsel
            // 
            this.picGorsel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picGorsel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picGorsel.Location = new System.Drawing.Point(880, 90);
            this.picGorsel.Name = "picGorsel";
            this.picGorsel.Size = new System.Drawing.Size(300, 200);
            this.picGorsel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picGorsel.TabIndex = 3;
            this.picGorsel.TabStop = false;
            // 
            // btnGorselSec
            // 
            this.btnGorselSec.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGorselSec.Location = new System.Drawing.Point(880, 310);
            this.btnGorselSec.Name = "btnGorselSec";
            this.btnGorselSec.Size = new System.Drawing.Size(140, 40);
            this.btnGorselSec.TabIndex = 4;
            this.btnGorselSec.Text = "Görsel Seç...";
            this.btnGorselSec.UseVisualStyleBackColor = true;
            // 
            // btnGorselTemizle
            // 
            this.btnGorselTemizle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGorselTemizle.Location = new System.Drawing.Point(1040, 310);
            this.btnGorselTemizle.Name = "btnGorselTemizle";
            this.btnGorselTemizle.Size = new System.Drawing.Size(140, 40);
            this.btnGorselTemizle.TabIndex = 5;
            this.btnGorselTemizle.Text = "Temizle";
            this.btnGorselTemizle.UseVisualStyleBackColor = true;
            // 
            // ucBolgeDetay
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGorselTemizle);
            this.Controls.Add(this.btnGorselSec);
            this.Controls.Add(this.picGorsel);
            this.Controls.Add(this.txtNotlar);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.lblBaslik);
            this.Name = "ucBolgeDetay";
            this.Size = new System.Drawing.Size(1250, 400);
            ((System.ComponentModel.ISupportInitialize)(this.picGorsel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.TextBox txtNotlar;
        private System.Windows.Forms.PictureBox picGorsel;
        private System.Windows.Forms.Button btnGorselSec;
        private System.Windows.Forms.Button btnGorselTemizle;
    }
}

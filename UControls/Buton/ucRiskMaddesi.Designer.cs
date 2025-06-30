namespace EMAR.UControls
{
    partial class ucRiskMaddesi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcı Kodu

        private void InitializeComponent()
        {
            btnRiskBaslik = new System.Windows.Forms.Button();
            pnlAltBasliklar = new System.Windows.Forms.Panel();
            btnModifikasyon = new System.Windows.Forms.Button();
            btnMevcutDurum = new System.Windows.Forms.Button();
            btnRiskAzaltimi = new System.Windows.Forms.Button();
            btnGenelBilgilendirme = new System.Windows.Forms.Button();
            pnlAltBasliklar.SuspendLayout();
            SuspendLayout();
            // 
            // btnRiskBaslik
            // 
            btnRiskBaslik.BackColor = System.Drawing.Color.LightGray;
            btnRiskBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            btnRiskBaslik.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnRiskBaslik.Location = new System.Drawing.Point(0, 0);
            btnRiskBaslik.Name = "btnRiskBaslik";
            btnRiskBaslik.Size = new System.Drawing.Size(500, 50);
            btnRiskBaslik.TabIndex = 0;
            btnRiskBaslik.Text = "Risk ...";
            btnRiskBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnRiskBaslik.UseVisualStyleBackColor = false;
            // 
            // pnlAltBasliklar
            // 
            pnlAltBasliklar.Controls.Add(btnModifikasyon);
            pnlAltBasliklar.Controls.Add(btnMevcutDurum);
            pnlAltBasliklar.Controls.Add(btnRiskAzaltimi);
            pnlAltBasliklar.Controls.Add(btnGenelBilgilendirme);
            pnlAltBasliklar.Dock = System.Windows.Forms.DockStyle.Top;
            pnlAltBasliklar.Location = new System.Drawing.Point(0, 50);
            pnlAltBasliklar.Name = "pnlAltBasliklar";
            pnlAltBasliklar.Padding = new System.Windows.Forms.Padding(10);
            pnlAltBasliklar.Size = new System.Drawing.Size(500, 200);
            pnlAltBasliklar.TabIndex = 1;
            // 
            // btnModifikasyon
            // 
            btnModifikasyon.Location = new System.Drawing.Point(20, 160);
            btnModifikasyon.Name = "btnModifikasyon";
            btnModifikasyon.Size = new System.Drawing.Size(460, 40);
            btnModifikasyon.TabIndex = 3;
            btnModifikasyon.Text = "Modifikasyon Önerileri";
            btnModifikasyon.UseVisualStyleBackColor = true;
            // 
            // btnMevcutDurum
            // 
            btnMevcutDurum.Location = new System.Drawing.Point(20, 110);
            btnMevcutDurum.Name = "btnMevcutDurum";
            btnMevcutDurum.Size = new System.Drawing.Size(460, 40);
            btnMevcutDurum.TabIndex = 2;
            btnMevcutDurum.Text = "Mevcut Durum";
            btnMevcutDurum.UseVisualStyleBackColor = true;
            // 
            // btnRiskAzaltimi
            // 
            btnRiskAzaltimi.Location = new System.Drawing.Point(20, 60);
            btnRiskAzaltimi.Name = "btnRiskAzaltimi";
            btnRiskAzaltimi.Size = new System.Drawing.Size(460, 40);
            btnRiskAzaltimi.TabIndex = 1;
            btnRiskAzaltimi.Text = "Risk Azaltımı";
            btnRiskAzaltimi.UseVisualStyleBackColor = true;
            // 
            // btnGenelBilgilendirme
            // 
            btnGenelBilgilendirme.Location = new System.Drawing.Point(20, 10);
            btnGenelBilgilendirme.Name = "btnGenelBilgilendirme";
            btnGenelBilgilendirme.Size = new System.Drawing.Size(460, 40);
            btnGenelBilgilendirme.TabIndex = 0;
            btnGenelBilgilendirme.Text = "Genel Bilgilendirme";
            btnGenelBilgilendirme.UseVisualStyleBackColor = true;

            // 
            // ucRiskMaddesi
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.WhiteSmoke;
            Controls.Add(pnlAltBasliklar);
            Controls.Add(btnRiskBaslik);
            Name = "ucRiskMaddesi";
            Size = new System.Drawing.Size(500, 250);
            pnlAltBasliklar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.Button btnRiskBaslik;
        public System.Windows.Forms.Panel pnlAltBasliklar;
        public System.Windows.Forms.Button btnGenelBilgilendirme;
        public System.Windows.Forms.Button btnRiskAzaltimi;
        public System.Windows.Forms.Button btnMevcutDurum;
        public System.Windows.Forms.Button btnModifikasyon;


    }
}

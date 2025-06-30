namespace EMAR.UControls
{
    using EMAR.UControls.Buton; // ucTextEditor bu namespace altında

    partial class ucRiskAzaltimi
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new System.Windows.Forms.Panel();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            lblBaslikRiskOnlemleri = new System.Windows.Forms.Label();
            lblBaslikHRNDegeri = new System.Windows.Forms.Label();
            lblOlasıHasarDerecesi = new System.Windows.Forms.Label();
            lblKazaOlmaOlasiligi = new System.Windows.Forms.Label();
            lblKacinmaOlasiligi = new System.Windows.Forms.Label();
            lblMaruzKalmaSikligi = new System.Windows.Forms.Label();
            lblRiskSkoruBaslik = new System.Windows.Forms.Label();
            lblSeviyeBaslik = new System.Windows.Forms.Label();
            lblDegerRiskSkoru = new System.Windows.Forms.Label();
            lblDegerSeviye = new System.Windows.Forms.Label();
            lblBaslikArtikRisk = new System.Windows.Forms.Label();
            cmbOlasıHasar = new System.Windows.Forms.ComboBox();
            cmbKazaOlma = new System.Windows.Forms.ComboBox();
            cmbKacinma = new System.Windows.Forms.ComboBox();
            cmbMaruzKalma = new System.Windows.Forms.ComboBox();
            ucTextEditor1 = new ucTextEditor();
            ucTextEditor2 = new ucTextEditor();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Location = new System.Drawing.Point(29, 27);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1941, 1019);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.6666718F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            tableLayoutPanel1.Controls.Add(lblBaslikRiskOnlemleri, 0, 0);
            tableLayoutPanel1.Controls.Add(lblBaslikHRNDegeri, 0, 3);
            tableLayoutPanel1.Controls.Add(lblOlasıHasarDerecesi, 0, 4);
            tableLayoutPanel1.Controls.Add(lblKazaOlmaOlasiligi, 1, 4);
            tableLayoutPanel1.Controls.Add(lblKacinmaOlasiligi, 2, 4);
            tableLayoutPanel1.Controls.Add(lblMaruzKalmaSikligi, 3, 4);
            tableLayoutPanel1.Controls.Add(lblRiskSkoruBaslik, 4, 4);
            tableLayoutPanel1.Controls.Add(lblSeviyeBaslik, 5, 4);
            tableLayoutPanel1.Controls.Add(lblDegerRiskSkoru, 4, 5);
            tableLayoutPanel1.Controls.Add(lblDegerSeviye, 5, 5);
            tableLayoutPanel1.Controls.Add(lblBaslikArtikRisk, 0, 7);
            tableLayoutPanel1.Controls.Add(cmbOlasıHasar, 0, 5);
            tableLayoutPanel1.Controls.Add(cmbKazaOlma, 1, 5);
            tableLayoutPanel1.Controls.Add(cmbKacinma, 2, 5);
            tableLayoutPanel1.Controls.Add(cmbMaruzKalma, 3, 5);
            tableLayoutPanel1.Controls.Add(ucTextEditor1, 0, 1);
            tableLayoutPanel1.Controls.Add(ucTextEditor2, 0, 8);
            tableLayoutPanel1.Location = new System.Drawing.Point(36, 36);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 9;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.1428566F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.8571434F));
            tableLayoutPanel1.Size = new System.Drawing.Size(1807, 947);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblBaslikRiskOnlemleri
            // 
            lblBaslikRiskOnlemleri.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lblBaslikRiskOnlemleri, 6);
            lblBaslikRiskOnlemleri.Dock = System.Windows.Forms.DockStyle.Fill;
            lblBaslikRiskOnlemleri.Location = new System.Drawing.Point(3, 0);
            lblBaslikRiskOnlemleri.Name = "lblBaslikRiskOnlemleri";
            lblBaslikRiskOnlemleri.Size = new System.Drawing.Size(1801, 50);
            lblBaslikRiskOnlemleri.TabIndex = 0;
            lblBaslikRiskOnlemleri.Text = "RİSK AZALTIM ÖNLEMLERİ";
            lblBaslikRiskOnlemleri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBaslikHRNDegeri
            // 
            lblBaslikHRNDegeri.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lblBaslikHRNDegeri, 6);
            lblBaslikHRNDegeri.Dock = System.Windows.Forms.DockStyle.Fill;
            lblBaslikHRNDegeri.Location = new System.Drawing.Point(3, 399);
            lblBaslikHRNDegeri.Name = "lblBaslikHRNDegeri";
            lblBaslikHRNDegeri.Size = new System.Drawing.Size(1801, 50);
            lblBaslikHRNDegeri.TabIndex = 0;
            lblBaslikHRNDegeri.Text = "Risk Azaltma Önlemi Sonrası Tehlike Derece Numarası";
            lblBaslikHRNDegeri.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOlasıHasarDerecesi
            // 
            lblOlasıHasarDerecesi.AutoSize = true;
            lblOlasıHasarDerecesi.Dock = System.Windows.Forms.DockStyle.Fill;
            lblOlasıHasarDerecesi.Location = new System.Drawing.Point(3, 449);
            lblOlasıHasarDerecesi.Name = "lblOlasıHasarDerecesi";
            lblOlasıHasarDerecesi.Size = new System.Drawing.Size(295, 120);
            lblOlasıHasarDerecesi.TabIndex = 0;
            lblOlasıHasarDerecesi.Text = "Olası Hasar Derecesi";
            lblOlasıHasarDerecesi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKazaOlmaOlasiligi
            // 
            lblKazaOlmaOlasiligi.AutoSize = true;
            lblKazaOlmaOlasiligi.Dock = System.Windows.Forms.DockStyle.Fill;
            lblKazaOlmaOlasiligi.Location = new System.Drawing.Point(304, 449);
            lblKazaOlmaOlasiligi.Name = "lblKazaOlmaOlasiligi";
            lblKazaOlmaOlasiligi.Size = new System.Drawing.Size(295, 120);
            lblKazaOlmaOlasiligi.TabIndex = 0;
            lblKazaOlmaOlasiligi.Text = "Kaza Olma Olasılığı";
            lblKazaOlmaOlasiligi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKacinmaOlasiligi
            // 
            lblKacinmaOlasiligi.AutoSize = true;
            lblKacinmaOlasiligi.Dock = System.Windows.Forms.DockStyle.Fill;
            lblKacinmaOlasiligi.Location = new System.Drawing.Point(605, 449);
            lblKacinmaOlasiligi.Name = "lblKacinmaOlasiligi";
            lblKacinmaOlasiligi.Size = new System.Drawing.Size(295, 120);
            lblKacinmaOlasiligi.TabIndex = 0;
            lblKacinmaOlasiligi.Text = "Kaçınma Olasılığı";
            lblKacinmaOlasiligi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaruzKalmaSikligi
            // 
            lblMaruzKalmaSikligi.AutoSize = true;
            lblMaruzKalmaSikligi.Dock = System.Windows.Forms.DockStyle.Fill;
            lblMaruzKalmaSikligi.Location = new System.Drawing.Point(906, 449);
            lblMaruzKalmaSikligi.Name = "lblMaruzKalmaSikligi";
            lblMaruzKalmaSikligi.Size = new System.Drawing.Size(295, 120);
            lblMaruzKalmaSikligi.TabIndex = 0;
            lblMaruzKalmaSikligi.Text = "Maruz Kalma Sıklığı";
            lblMaruzKalmaSikligi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRiskSkoruBaslik
            // 
            lblRiskSkoruBaslik.AutoSize = true;
            lblRiskSkoruBaslik.Dock = System.Windows.Forms.DockStyle.Fill;
            lblRiskSkoruBaslik.Location = new System.Drawing.Point(1207, 449);
            lblRiskSkoruBaslik.Name = "lblRiskSkoruBaslik";
            lblRiskSkoruBaslik.Size = new System.Drawing.Size(295, 120);
            lblRiskSkoruBaslik.TabIndex = 0;
            lblRiskSkoruBaslik.Text = "Risk Skoru";
            lblRiskSkoruBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSeviyeBaslik
            // 
            lblSeviyeBaslik.AutoSize = true;
            lblSeviyeBaslik.Dock = System.Windows.Forms.DockStyle.Fill;
            lblSeviyeBaslik.Location = new System.Drawing.Point(1508, 449);
            lblSeviyeBaslik.Name = "lblSeviyeBaslik";
            lblSeviyeBaslik.Size = new System.Drawing.Size(296, 120);
            lblSeviyeBaslik.TabIndex = 0;
            lblSeviyeBaslik.Text = "Seviye";
            lblSeviyeBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDegerRiskSkoru
            // 
            lblDegerRiskSkoru.AutoSize = true;
            lblDegerRiskSkoru.Dock = System.Windows.Forms.DockStyle.Fill;
            lblDegerRiskSkoru.Location = new System.Drawing.Point(1207, 569);
            lblDegerRiskSkoru.Name = "lblDegerRiskSkoru";
            lblDegerRiskSkoru.Size = new System.Drawing.Size(295, 60);
            lblDegerRiskSkoru.TabIndex = 0;
            lblDegerRiskSkoru.Text = "label1";
            lblDegerRiskSkoru.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDegerSeviye
            // 
            lblDegerSeviye.AutoSize = true;
            lblDegerSeviye.Dock = System.Windows.Forms.DockStyle.Fill;
            lblDegerSeviye.Location = new System.Drawing.Point(1508, 569);
            lblDegerSeviye.Name = "lblDegerSeviye";
            lblDegerSeviye.Size = new System.Drawing.Size(296, 60);
            lblDegerSeviye.TabIndex = 0;
            lblDegerSeviye.Text = "label1";
            lblDegerSeviye.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBaslikArtikRisk
            // 
            lblBaslikArtikRisk.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lblBaslikArtikRisk, 6);
            lblBaslikArtikRisk.Dock = System.Windows.Forms.DockStyle.Fill;
            lblBaslikArtikRisk.Location = new System.Drawing.Point(3, 649);
            lblBaslikArtikRisk.Name = "lblBaslikArtikRisk";
            lblBaslikArtikRisk.Size = new System.Drawing.Size(1801, 50);
            lblBaslikArtikRisk.TabIndex = 0;
            lblBaslikArtikRisk.Text = "ARTIK RİSK";
            lblBaslikArtikRisk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbOlasıHasar
            // 
            cmbOlasıHasar.Dock = System.Windows.Forms.DockStyle.Fill;
            cmbOlasıHasar.FormattingEnabled = true;
            cmbOlasıHasar.Location = new System.Drawing.Point(3, 572);
            cmbOlasıHasar.Name = "cmbOlasıHasar";
            cmbOlasıHasar.Size = new System.Drawing.Size(295, 40);
            cmbOlasıHasar.TabIndex = 2;
            // 
            // cmbKazaOlma
            // 
            cmbKazaOlma.Dock = System.Windows.Forms.DockStyle.Fill;
            cmbKazaOlma.FormattingEnabled = true;
            cmbKazaOlma.Location = new System.Drawing.Point(304, 572);
            cmbKazaOlma.Name = "cmbKazaOlma";
            cmbKazaOlma.Size = new System.Drawing.Size(295, 40);
            cmbKazaOlma.TabIndex = 2;
            // 
            // cmbKacinma
            // 
            cmbKacinma.Dock = System.Windows.Forms.DockStyle.Fill;
            cmbKacinma.FormattingEnabled = true;
            cmbKacinma.Location = new System.Drawing.Point(605, 572);
            cmbKacinma.Name = "cmbKacinma";
            cmbKacinma.Size = new System.Drawing.Size(295, 40);
            cmbKacinma.TabIndex = 2;
            // 
            // cmbMaruzKalma
            // 
            cmbMaruzKalma.Dock = System.Windows.Forms.DockStyle.Fill;
            cmbMaruzKalma.FormattingEnabled = true;
            cmbMaruzKalma.Location = new System.Drawing.Point(906, 572);
            cmbMaruzKalma.Name = "cmbMaruzKalma";
            cmbMaruzKalma.Size = new System.Drawing.Size(295, 40);
            cmbMaruzKalma.TabIndex = 2;
            // 
            // ucTextEditor1
            // 
            ucTextEditor1.Alan = null;
            ucTextEditor1.BagliId = 0;
            tableLayoutPanel1.SetColumnSpan(ucTextEditor1, 6);
            ucTextEditor1.DbYolu = null;
            ucTextEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucTextEditor1.Location = new System.Drawing.Point(3, 53);
            ucTextEditor1.Name = "ucTextEditor1";
            ucTextEditor1.RtfText = "{\\rtf1\\ansi\\ansicpg1254\\deff0\\nouicompat\\deflang1055{\\fonttbl{\\f0\\fnil\\fcharset162 Segoe UI;}}\r\n{\\*\\generator Riched20 10.0.26100}\\viewkind4\\uc1 \r\n\\pard\\li450\\ri450\\f0\\fs24\\par\r\n}\r\n";
            ucTextEditor1.Size = new System.Drawing.Size(1801, 323);
            ucTextEditor1.TabIndex = 3;
            // 
            // ucTextEditor2
            // 
            ucTextEditor2.Alan = null;
            ucTextEditor2.BagliId = 0;
            tableLayoutPanel1.SetColumnSpan(ucTextEditor2, 6);
            ucTextEditor2.DbYolu = null;
            ucTextEditor2.Location = new System.Drawing.Point(3, 702);
            ucTextEditor2.Name = "ucTextEditor2";
            ucTextEditor2.RtfText = "{\\rtf1\\ansi\\ansicpg1254\\deff0\\nouicompat\\deflang1055{\\fonttbl{\\f0\\fnil\\fcharset162 Segoe UI;}}\r\n{\\*\\generator Riched20 10.0.26100}\\viewkind4\\uc1 \r\n\\pard\\li450\\ri450\\f0\\fs24\\par\r\n}\r\n";
            ucTextEditor2.Size = new System.Drawing.Size(1800, 242);
            ucTextEditor2.TabIndex = 4;
            // 
            // ucRiskAzaltimi
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "ucRiskAzaltimi";
            Size = new System.Drawing.Size(2047, 1109);
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblBaslikRiskOnlemleri;
        private System.Windows.Forms.Label lblBaslikHRNDegeri;
        private System.Windows.Forms.Label lblOlasıHasarDerecesi;
        private System.Windows.Forms.Label lblKazaOlmaOlasiligi;
        private System.Windows.Forms.Label lblKacinmaOlasiligi;
        private System.Windows.Forms.Label lblMaruzKalmaSikligi;
        private System.Windows.Forms.Label lblRiskSkoruBaslik;
        private System.Windows.Forms.Label lblSeviyeBaslik;
        private System.Windows.Forms.Label lblDegerRiskSkoru;
        private System.Windows.Forms.Label lblDegerSeviye;
        private System.Windows.Forms.Label lblBaslikArtikRisk;
        private System.Windows.Forms.ComboBox cmbOlasıHasar;
        private System.Windows.Forms.ComboBox cmbKazaOlma;
        private System.Windows.Forms.ComboBox cmbKacinma;
        private System.Windows.Forms.ComboBox cmbMaruzKalma;
        private ucTextEditor ucTextEditor1;
        private ucTextEditor ucTextEditor2;
    }
}

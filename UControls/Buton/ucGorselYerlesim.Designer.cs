namespace EMAR.UControls.Buton
{
    partial class ucGorselYerlesim
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        private void InitializeComponent()
        {
            cmbYerlesim = new System.Windows.Forms.ComboBox();
            layoutMain = new System.Windows.Forms.TableLayoutPanel();
            layoutHeader = new System.Windows.Forms.TableLayoutPanel();
            btnGorselEkle = new System.Windows.Forms.Button();
            btnSil = new System.Windows.Forms.Button();
            btnKaydet = new System.Windows.Forms.Button();
            tblGorseller = new System.Windows.Forms.TableLayoutPanel();
            layoutMain.SuspendLayout();
            layoutHeader.SuspendLayout();
            SuspendLayout();
            // 
            // cmbYerlesim
            // 
            cmbYerlesim.Dock = System.Windows.Forms.DockStyle.Fill;
            cmbYerlesim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbYerlesim.FormattingEnabled = true;
            cmbYerlesim.Items.AddRange(new object[] { "Grid (2 Sütun)", "Tekli (Alt Alta)" });
            cmbYerlesim.Location = new System.Drawing.Point(109, 3);
            cmbYerlesim.Name = "cmbYerlesim";
            cmbYerlesim.Size = new System.Drawing.Size(418, 40);
            cmbYerlesim.TabIndex = 1;
            // 
            // layoutMain
            // 
            layoutMain.AutoSize = true;
            layoutMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            layoutMain.ColumnCount = 1;
            layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            layoutMain.Controls.Add(layoutHeader, 0, 0);
            layoutMain.Controls.Add(tblGorseller, 0, 1);
            layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutMain.Location = new System.Drawing.Point(0, 0);
            layoutMain.Name = "layoutMain";
            layoutMain.RowCount = 2;
            layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            layoutMain.Size = new System.Drawing.Size(1300, 850);
            layoutMain.TabIndex = 2;
            // 
            // layoutHeader
            // 
            layoutHeader.ColumnCount = 7;
            layoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333403F));
            layoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33361F));
            layoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            layoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.6668053F));
            layoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.6668053F));
            layoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.6668072F));
            layoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.33257F));
            layoutHeader.Controls.Add(btnGorselEkle, 3, 0);
            layoutHeader.Controls.Add(btnSil, 4, 0);
            layoutHeader.Controls.Add(cmbYerlesim, 1, 0);
            layoutHeader.Controls.Add(btnKaydet, 5, 0);
            layoutHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutHeader.Location = new System.Drawing.Point(3, 3);
            layoutHeader.Name = "layoutHeader";
            layoutHeader.RowCount = 1;
            layoutHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            layoutHeader.Size = new System.Drawing.Size(1294, 70);
            layoutHeader.TabIndex = 0;
            // 
            // btnGorselEkle
            // 
            btnGorselEkle.Dock = System.Windows.Forms.DockStyle.Fill;
            btnGorselEkle.Location = new System.Drawing.Point(553, 3);
            btnGorselEkle.Name = "btnGorselEkle";
            btnGorselEkle.Size = new System.Drawing.Size(206, 64);
            btnGorselEkle.TabIndex = 2;
            btnGorselEkle.Text = "📷 Görsel Ekle";
            btnGorselEkle.UseVisualStyleBackColor = true;
            // 
            // btnSil
            // 
            btnSil.Dock = System.Windows.Forms.DockStyle.Fill;
            btnSil.Location = new System.Drawing.Point(765, 3);
            btnSil.Name = "btnSil";
            btnSil.Size = new System.Drawing.Size(206, 64);
            btnSil.TabIndex = 3;
            btnSil.Text = "🗑️ Sil";
            btnSil.UseVisualStyleBackColor = true;
            // 
            // btnKaydet
            // 
            btnKaydet.Dock = System.Windows.Forms.DockStyle.Fill;
            btnKaydet.Location = new System.Drawing.Point(977, 3);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new System.Drawing.Size(206, 64);
            btnKaydet.TabIndex = 4;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            // 
            // tblGorseller
            // 
            tblGorseller.AutoSize = true;
            tblGorseller.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tblGorseller.ColumnCount = 2;
            tblGorseller.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tblGorseller.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tblGorseller.Dock = System.Windows.Forms.DockStyle.Fill;
            tblGorseller.Location = new System.Drawing.Point(3, 79);
            tblGorseller.Name = "tblGorseller";
            tblGorseller.Size = new System.Drawing.Size(1294, 768);
            tblGorseller.TabIndex = 1;
            // 
            // ucGorselYerlesim
            // 
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(layoutMain);
            Name = "ucGorselYerlesim";
            Size = new System.Drawing.Size(1300, 850);
            layoutMain.ResumeLayout(false);
            layoutMain.PerformLayout();
            layoutHeader.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbYerlesim;
        private System.Windows.Forms.TableLayoutPanel layoutMain;
        private System.Windows.Forms.TableLayoutPanel layoutHeader;
        private System.Windows.Forms.Button btnGorselEkle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.TableLayoutPanel tblGorseller;
        private System.Windows.Forms.Button btnKaydet;
    }
}
namespace EMAR.UControls.Risk
{
    partial class ucMevcutDurum
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
            ucGorselYerlesim2 = new EMAR.UControls.Buton.ucGorselYerlesim();
            label3 = new System.Windows.Forms.Label();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            lblTehlikeNo = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ucGorselYerlesim1 = new EMAR.UControls.Buton.ucGorselYerlesim();
            ucStandartlar1 = new ucStandartlar();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            ucTextEditor1 = new EMAR.UControls.Buton.ucTextEditor();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AllowDrop = true;
            panel1.AutoSize = true;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Location = new System.Drawing.Point(114, 65);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(5);
            panel1.Size = new System.Drawing.Size(1495, 1961);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AllowDrop = true;
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(ucGorselYerlesim2, 0, 7);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(label4, 0, 9);
            tableLayoutPanel1.Controls.Add(ucGorselYerlesim1, 0, 4);
            tableLayoutPanel1.Controls.Add(ucStandartlar1, 0, 10);
            tableLayoutPanel1.Controls.Add(label5, 0, 3);
            tableLayoutPanel1.Controls.Add(label6, 0, 6);
            tableLayoutPanel1.Controls.Add(ucTextEditor1, 0, 2);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 11;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 645F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 780F));
            tableLayoutPanel1.Size = new System.Drawing.Size(1485, 1939);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // ucGorselYerlesim2
            // 
            ucGorselYerlesim2.AllowDrop = true;
            ucGorselYerlesim2.AutoSize = true;
            ucGorselYerlesim2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ucGorselYerlesim2.BolgeNo = 0;
            ucGorselYerlesim2.DbYolu = null;
            ucGorselYerlesim2.Dock = System.Windows.Forms.DockStyle.Top;
            ucGorselYerlesim2.GorselTip = "MevcutDurum";
            ucGorselYerlesim2.Location = new System.Drawing.Point(3, 954);
            ucGorselYerlesim2.MakineAdi = null;
            ucGorselYerlesim2.Name = "ucGorselYerlesim2";
            ucGorselYerlesim2.ProjeKodu = null;
            ucGorselYerlesim2.RaporTuru = null;
            ucGorselYerlesim2.RiskNo = 0;
            ucGorselYerlesim2.SiraNo = 0;
            ucGorselYerlesim2.Size = new System.Drawing.Size(1479, 82);
            ucGorselYerlesim2.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = System.Windows.Forms.DockStyle.Fill;
            label3.Location = new System.Drawing.Point(3, 49);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(1479, 49);
            label3.TabIndex = 0;
            label3.Text = "Mevcut Durum";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(lblTehlikeNo, 1, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new System.Drawing.Size(1479, 41);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(733, 41);
            label1.TabIndex = 0;
            label1.Text = "Emniyet Konsepti";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTehlikeNo
            // 
            lblTehlikeNo.AutoSize = true;
            lblTehlikeNo.Dock = System.Windows.Forms.DockStyle.Fill;
            lblTehlikeNo.Location = new System.Drawing.Point(742, 0);
            lblTehlikeNo.Name = "lblTehlikeNo";
            lblTehlikeNo.Size = new System.Drawing.Size(734, 41);
            lblTehlikeNo.TabIndex = 0;
            lblTehlikeNo.Text = "label1";
            lblTehlikeNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = System.Windows.Forms.DockStyle.Fill;
            label4.Font = new System.Drawing.Font("Segoe UI", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            label4.Location = new System.Drawing.Point(3, 1079);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(1479, 80);
            label4.TabIndex = 0;
            label4.Text = "REFERANS ALINAN STANDARTLAR";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucGorselYerlesim1
            // 
            ucGorselYerlesim1.AllowDrop = true;
            ucGorselYerlesim1.AutoSize = true;
            ucGorselYerlesim1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ucGorselYerlesim1.BolgeNo = 0;
            ucGorselYerlesim1.DbYolu = null;
            ucGorselYerlesim1.Dock = System.Windows.Forms.DockStyle.Top;
            ucGorselYerlesim1.GorselTip = "MevcutDurum";
            ucGorselYerlesim1.Location = new System.Drawing.Point(3, 786);
            ucGorselYerlesim1.MakineAdi = null;
            ucGorselYerlesim1.Name = "ucGorselYerlesim1";
            ucGorselYerlesim1.ProjeKodu = null;
            ucGorselYerlesim1.RaporTuru = null;
            ucGorselYerlesim1.RiskNo = 0;
            ucGorselYerlesim1.SiraNo = 0;
            ucGorselYerlesim1.Size = new System.Drawing.Size(1479, 82);
            ucGorselYerlesim1.TabIndex = 4;
            // 
            // ucStandartlar1
            // 
            ucStandartlar1.AutoSize = true;
            ucStandartlar1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ucStandartlar1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucStandartlar1.Location = new System.Drawing.Point(3, 1162);
            ucStandartlar1.Name = "ucStandartlar1";
            ucStandartlar1.Size = new System.Drawing.Size(1479, 774);
            ucStandartlar1.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = System.Windows.Forms.DockStyle.Fill;
            label5.Location = new System.Drawing.Point(3, 743);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(1479, 40);
            label5.TabIndex = 7;
            label5.Text = "Mevcut Durum Görselleri";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = System.Windows.Forms.DockStyle.Fill;
            label6.Location = new System.Drawing.Point(3, 911);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(1479, 40);
            label6.TabIndex = 7;
            label6.Text = "Mevcut Durum Görselleri";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucTextEditor1
            // 
            ucTextEditor1.Alan = null;
            ucTextEditor1.BagliId = 0;
            ucTextEditor1.DbYolu = null;
            ucTextEditor1.Location = new System.Drawing.Point(3, 101);
            ucTextEditor1.Name = "ucTextEditor1";
            ucTextEditor1.RtfText = "{\\rtf1\\ansi\\ansicpg1254\\deff0\\nouicompat\\deflang1055{\\fonttbl{\\f0\\fnil\\fcharset162 Segoe UI;}}\r\n{\\*\\generator Riched20 10.0.26100}\\viewkind4\\uc1 \r\n\\pard\\f0\\fs18\\par\r\n}\r\n";
            ucTextEditor1.Size = new System.Drawing.Size(1479, 621);
            ucTextEditor1.TabIndex = 3;
            // 
            // ucMevcutDurum
            // 
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            Controls.Add(panel1);
            Name = "ucMevcutDurum";
            Size = new System.Drawing.Size(1678, 2134);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTehlikeNo;
        private System.Windows.Forms.Label label4;
        private Buton.ucTextEditor ucTextEditor1;
        private Buton.ucGorselYerlesim ucGorselYerlesim1;
        private Buton.ucGorselYerlesim ucGorselYerlesim2;
        private ucStandartlar ucStandartlar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

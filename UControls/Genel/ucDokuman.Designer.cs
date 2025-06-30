using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EMAR
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class ucDokuman : UserControl
    {

        // UserControl, bileşen listesini temizlemeyi bırakmayı geçersiz kılar.
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

        // Windows Form Tasarımcısı tarafından gerektirilir
        private System.ComponentModel.IContainer components;

        // NOT: Aşağıdaki yordam Windows Form Tasarımcısı için gereklidir
        // Windows Form Tasarımcısı kullanılarak değiştirilebilir.  
        // Kod düzenleyicisini kullanarak değiştirmeyin.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            dgvDokumanlar = new DataGridView();
            txtAd = new TextBox();
            cmbTip = new ComboBox();
            dtpIletilme = new DateTimePicker();
            btnEkle = new Button();
            btnSil = new Button();
            Label1 = new Label();
            tblMain = new TableLayoutPanel();
            pnlInputs = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvDokumanlar).BeginInit();
            tblMain.SuspendLayout();
            pnlInputs.SuspendLayout();
            SuspendLayout();
            // 
            // dgvDokumanlar
            // 
            dgvDokumanlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDokumanlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDokumanlar.Dock = DockStyle.Fill;
            dgvDokumanlar.Location = new Point(3, 83);
            dgvDokumanlar.Name = "dgvDokumanlar";
            dgvDokumanlar.RowHeadersWidth = 82;
            dgvDokumanlar.Size = new Size(1933, 1017);
            dgvDokumanlar.TabIndex = 0;
            // 
            // txtAd
            // 
            txtAd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAd.Location = new Point(17, 20);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(662, 39);
            txtAd.TabIndex = 1;
            // 
            // cmbTip
            // 
            cmbTip.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbTip.FormattingEnabled = true;
            cmbTip.Location = new Point(707, 20);
            cmbTip.Name = "cmbTip";
            cmbTip.Size = new Size(412, 40);
            cmbTip.TabIndex = 2;
            // 
            // dtpIletilme
            // 
            dtpIletilme.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpIletilme.Location = new Point(1158, 21);
            dtpIletilme.Name = "dtpIletilme";
            dtpIletilme.Size = new Size(396, 39);
            dtpIletilme.TabIndex = 3;
            // 
            // btnEkle
            // 
            btnEkle.Anchor = AnchorStyles.Bottom;
            btnEkle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEkle.Location = new Point(1626, 15);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(128, 55);
            btnEkle.TabIndex = 4;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnSil
            // 
            btnSil.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSil.Location = new Point(1793, 15);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(118, 55);
            btnSil.TabIndex = 4;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // Label1
            // 
            Label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Label1.AutoSize = true;
            Label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            Label1.Location = new Point(3, 0);
            Label1.Name = "Label1";
            Label1.Size = new Size(1933, 65);
            Label1.TabIndex = 5;
            Label1.Text = "İNCELENEN DÖKÜMANLAR";
            Label1.TextAlign = ContentAlignment.MiddleCenter;
            
            // 
            // tblMain
            // 
            tblMain.AutoScroll = true;
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(pnlInputs, 0, 2);
            tblMain.Controls.Add(Label1, 0, 0);
            tblMain.Controls.Add(dgvDokumanlar, 0, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 3;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            tblMain.Size = new Size(1939, 1193);
            tblMain.TabIndex = 6;
            // 
            // pnlInputs
            // 
            pnlInputs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlInputs.Controls.Add(txtAd);
            pnlInputs.Controls.Add(btnSil);
            pnlInputs.Controls.Add(cmbTip);
            pnlInputs.Controls.Add(btnEkle);
            pnlInputs.Controls.Add(dtpIletilme);
            pnlInputs.Location = new Point(3, 1106);
            pnlInputs.Name = "pnlInputs";
            pnlInputs.Size = new Size(1933, 84);
            pnlInputs.TabIndex = 0;
            // 
            // ucDokuman
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tblMain);
            Name = "ucDokuman";
            Size = new Size(1939, 1193);
            Load += ucDokuman_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDokumanlar).EndInit();
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            pnlInputs.ResumeLayout(false);
            pnlInputs.PerformLayout();
            ResumeLayout(false);
        }

        internal DataGridView dgvDokumanlar;
        internal TextBox txtAd;
        internal ComboBox cmbTip;
        internal DateTimePicker dtpIletilme;
        internal Button btnEkle;
        internal Button btnSil;
        internal Label Label1;
        internal TableLayoutPanel tblMain;
        internal Panel pnlInputs;

    }
}
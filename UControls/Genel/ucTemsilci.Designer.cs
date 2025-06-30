using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EMAR
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class ucTemsilci : UserControl
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
            DataGridView1 = new DataGridView();
            txtIsim = new TextBox();
            cmbGorev = new ComboBox();
            txtFirma = new TextBox();
            lblBaslik = new Label();
            Label1 = new Label();
            Label2 = new Label();
            Label3 = new Label();
            btnEkle = new Button();
            btnEkle.Click += new EventHandler(btnEkle_Click);
            btnDuzenle = new Button();
            btnDuzenle.Click += new EventHandler(btnDuzenle_Click);
            btnSil = new Button();
            btnSil.Click += new EventHandler(btnSil_Click);
            btnKaydet = new Button();
            btnKaydet.Click += new EventHandler(btnKaydet_Click);
            ((System.ComponentModel.ISupportInitialize)DataGridView1).BeginInit();
            SuspendLayout();
            // 
            // DataGridView1
            // 
            DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView1.Location = new Point(75, 503);
            DataGridView1.Name = "DataGridView1";
            DataGridView1.RowHeadersWidth = 82;
            DataGridView1.Size = new Size(1316, 589);
            DataGridView1.TabIndex = 0;
            // 
            // txtIsim
            // 
            txtIsim.Location = new Point(209, 179);
            txtIsim.Name = "txtIsim";
            txtIsim.Size = new Size(575, 39);
            txtIsim.TabIndex = 1;
            // 
            // cmbGorev
            // 
            cmbGorev.FormattingEnabled = true;
            cmbGorev.Location = new Point(209, 357);
            cmbGorev.Name = "cmbGorev";
            cmbGorev.Size = new Size(575, 40);
            cmbGorev.TabIndex = 3;
            // 
            // txtFirma
            // 
            txtFirma.Location = new Point(209, 268);
            txtFirma.Name = "txtFirma";
            txtFirma.Size = new Size(575, 39);
            txtFirma.TabIndex = 1;
            // 
            // lblBaslik
            // 
            lblBaslik.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("Segoe UI", 18.0f, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(461, 39);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(557, 65);
            lblBaslik.TabIndex = 4;
            lblBaslik.Text = "MÜŞTERİ TEMSİLCİLERİ";
            lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Segoe UI", 12.0f);
            Label1.Location = new Point(75, 176);
            Label1.Name = "Label1";
            Label1.Size = new Size(86, 45);
            Label1.TabIndex = 5;
            Label1.Text = "İsim:";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Segoe UI", 12.0f);
            Label2.Location = new Point(75, 266);
            Label2.Name = "Label2";
            Label2.Size = new Size(106, 45);
            Label2.TabIndex = 5;
            Label2.Text = "Firma:";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Segoe UI", 12.0f);
            Label3.Location = new Point(75, 356);
            Label3.Name = "Label3";
            Label3.Size = new Size(111, 45);
            Label3.TabIndex = 5;
            Label3.Text = "Görev:";
            // 
            // btnEkle
            // 
            btnEkle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEkle.FlatStyle = FlatStyle.Flat;
            btnEkle.Location = new Point(935, 167);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(199, 63);
            btnEkle.TabIndex = 6;
            btnEkle.Text = "➕ Ekle";
            // 
            // btnDuzenle
            // 
            btnDuzenle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDuzenle.FlatStyle = FlatStyle.Flat;
            btnDuzenle.Location = new Point(935, 257);
            btnDuzenle.Name = "btnDuzenle";
            btnDuzenle.Size = new Size(199, 63);
            btnDuzenle.TabIndex = 7;
            btnDuzenle.Text = "✏️ Düzenle";
            // 
            // btnSil
            // 
            btnSil.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSil.FlatStyle = FlatStyle.Flat;
            btnSil.Location = new Point(935, 347);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(199, 63);
            btnSil.TabIndex = 8;
            btnSil.Text = "🗑️ Sil";
            // 
            // btnKaydet
            // 
            btnKaydet.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnKaydet.FlatStyle = FlatStyle.Flat;
            btnKaydet.Location = new Point(1192, 347);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(199, 63);
            btnKaydet.TabIndex = 9;
            btnKaydet.Text = "💾 Kaydet";
            // 
            // ucTemsilci
            // 
            AutoScaleDimensions = new SizeF(13.0f, 32.0f);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnEkle);
            Controls.Add(btnDuzenle);
            Controls.Add(btnSil);
            Controls.Add(btnKaydet);
            Controls.Add(Label3);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Controls.Add(lblBaslik);
            Controls.Add(cmbGorev);
            Controls.Add(txtFirma);
            Controls.Add(txtIsim);
            Controls.Add(DataGridView1);
            Name = "ucTemsilci";
            Size = new Size(1479, 1154);
            ((System.ComponentModel.ISupportInitialize)DataGridView1).EndInit();
            Load += new EventHandler(ucTemsilci_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal DataGridView DataGridView1;
        internal TextBox txtIsim;
        internal ComboBox cmbGorev;
        internal TextBox txtFirma;
        internal Label lblBaslik;
        internal Label Label1;
        internal Label Label2;
        internal Label Label3;
        internal Button btnEkle;
        internal Button btnDuzenle;
        internal Button btnSil;
        internal Button btnKaydet;

    }
}
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EMAR
{

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmMakineLimitleri : Form
    {

        // Form, bileşen listesini temizlemeyi bırakmayı geçersiz kılar.
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
            cmbMakine = new ComboBox();
            txtKullanimAmaci = new TextBox();
            clbKullaniciSeviyeleri = new CheckedListBox();
            txtPersonelTipi = new TextBox();
            txtBakimSikligi = new TextBox();
            btnIptal = new Button();
            btnKaydet = new Button();
            Label1 = new Label();
            Label2 = new Label();
            Label3 = new Label();
            Label4 = new Label();
            txtOlculer = new TextBox();
            Label5 = new Label();
            txtZamanLimitleri = new TextBox();
            Label6 = new Label();
            txtSeviyeYeni = new TextBox();
            btnSeviyeEkle = new Button();
            btnTumunuSec = new Button();
            Label7 = new Label();
            btnIptalSecim = new Button();
            SuspendLayout();
            // 
            // cmbMakine
            // 
            cmbMakine.FormattingEnabled = true;
            cmbMakine.Location = new Point(334, 34);
            cmbMakine.Name = "cmbMakine";
            cmbMakine.Size = new Size(412, 40);
            cmbMakine.TabIndex = 0;
            cmbMakine.SelectedIndexChanged += cmbMakine_SelectedIndexChanged;
            // 
            // txtKullanimAmaci
            // 
            txtKullanimAmaci.Location = new Point(43, 152);
            txtKullanimAmaci.Multiline = true;
            txtKullanimAmaci.Name = "txtKullanimAmaci";
            txtKullanimAmaci.Size = new Size(905, 222);
            txtKullanimAmaci.TabIndex = 1;
            // 
            // clbKullaniciSeviyeleri
            // 
            clbKullaniciSeviyeleri.CheckOnClick = true;
            clbKullaniciSeviyeleri.FormattingEnabled = true;
            clbKullaniciSeviyeleri.Items.AddRange(new object[] { "Makine Operatörü", "Bakım Personeli", "Temizlik Görevlisi" });
            clbKullaniciSeviyeleri.Location = new Point(976, 90);
            clbKullaniciSeviyeleri.Name = "clbKullaniciSeviyeleri";
            clbKullaniciSeviyeleri.Size = new Size(412, 184);
            clbKullaniciSeviyeleri.TabIndex = 2;
            // 
            // txtPersonelTipi
            // 
            txtPersonelTipi.Location = new Point(43, 418);
            txtPersonelTipi.Multiline = true;
            txtPersonelTipi.Name = "txtPersonelTipi";
            txtPersonelTipi.Size = new Size(905, 149);
            txtPersonelTipi.TabIndex = 1;
            txtPersonelTipi.Text = "Makine kullanımı ile ilgili eğitim almış operatör";
            // 
            // txtBakimSikligi
            // 
            txtBakimSikligi.Location = new Point(43, 612);
            txtBakimSikligi.Multiline = true;
            txtBakimSikligi.Name = "txtBakimSikligi";
            txtBakimSikligi.Size = new Size(905, 125);
            txtBakimSikligi.TabIndex = 1;
            txtBakimSikligi.Text = "Aylık, 3 Aylık ve 6 Aylık";
            // 
            // btnIptal
            // 
            btnIptal.Location = new Point(1444, 80);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(150, 46);
            btnIptal.TabIndex = 3;
            btnIptal.Text = "İptal";
            btnIptal.UseVisualStyleBackColor = true;
            btnIptal.Click += btnIptal_Click;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(1444, 28);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(150, 46);
            btnKaydet.TabIndex = 4;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(43, 115);
            Label1.Name = "Label1";
            Label1.Size = new Size(179, 32);
            Label1.TabIndex = 5;
            Label1.Text = "Kullanım Amacı";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(43, 381);
            Label2.Name = "Label2";
            Label2.Size = new Size(203, 32);
            Label2.TabIndex = 5;
            Label2.Text = "Kullanan Personel";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Location = new Point(43, 575);
            Label3.Name = "Label3";
            Label3.Size = new Size(149, 32);
            Label3.TabIndex = 5;
            Label3.Text = "Bakım Sıklığı";
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Location = new Point(179, 37);
            Label4.Name = "Label4";
            Label4.Size = new Size(149, 32);
            Label4.TabIndex = 6;
            Label4.Text = "Makine Seç :";
            // 
            // txtOlculer
            // 
            txtOlculer.Location = new Point(954, 418);
            txtOlculer.Multiline = true;
            txtOlculer.Name = "txtOlculer";
            txtOlculer.Size = new Size(772, 149);
            txtOlculer.TabIndex = 1;
            txtOlculer.Text = "Aylık, 3 Aylık ve 6 Aylık";
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Location = new Point(954, 381);
            Label5.Name = "Label5";
            Label5.Size = new Size(182, 32);
            Label5.TabIndex = 5;
            Label5.Text = "Makine Ölçüleri";
            // 
            // txtZamanLimitleri
            // 
            txtZamanLimitleri.Location = new Point(954, 612);
            txtZamanLimitleri.Multiline = true;
            txtZamanLimitleri.Name = "txtZamanLimitleri";
            txtZamanLimitleri.Size = new Size(772, 125);
            txtZamanLimitleri.TabIndex = 1;
            txtZamanLimitleri.Text = "Aylık, 3 Aylık ve 6 Aylık";
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Location = new Point(954, 575);
            Label6.Name = "Label6";
            Label6.Size = new Size(179, 32);
            Label6.TabIndex = 5;
            Label6.Text = "Zaman Limitleri";
            // 
            // txtSeviyeYeni
            // 
            txtSeviyeYeni.Location = new Point(976, 296);
            txtSeviyeYeni.Multiline = true;
            txtSeviyeYeni.Name = "txtSeviyeYeni";
            txtSeviyeYeni.PlaceholderText = "Eğitimli Kullanıcı Ekle";
            txtSeviyeYeni.Size = new Size(412, 78);
            txtSeviyeYeni.TabIndex = 7;
            // 
            // btnSeviyeEkle
            // 
            btnSeviyeEkle.Location = new Point(1412, 328);
            btnSeviyeEkle.Name = "btnSeviyeEkle";
            btnSeviyeEkle.Size = new Size(182, 46);
            btnSeviyeEkle.TabIndex = 8;
            btnSeviyeEkle.Text = "Ekle";
            btnSeviyeEkle.UseVisualStyleBackColor = true;
            btnSeviyeEkle.Click += btnSeviyeEkle_Click;
            // 
            // btnTumunuSec
            // 
            btnTumunuSec.Location = new Point(1412, 199);
            btnTumunuSec.Name = "btnTumunuSec";
            btnTumunuSec.Size = new Size(182, 46);
            btnTumunuSec.TabIndex = 9;
            btnTumunuSec.Text = "Tümünü Seç";
            btnTumunuSec.UseVisualStyleBackColor = true;
            btnTumunuSec.Click += btnTumunuSec_Click;
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Location = new Point(976, 42);
            Label7.Name = "Label7";
            Label7.Size = new Size(321, 32);
            Label7.TabIndex = 10;
            Label7.Text = "Beklenen Eğitimli Kullanıcılar";
            // 
            // btnIptalSecim
            // 
            btnIptalSecim.Location = new Point(1412, 251);
            btnIptalSecim.Name = "btnIptalSecim";
            btnIptalSecim.Size = new Size(182, 46);
            btnIptalSecim.TabIndex = 9;
            btnIptalSecim.Text = "İptal";
            btnIptalSecim.UseVisualStyleBackColor = true;
            btnIptalSecim.Click += btnIptalSecim_Click;
            // 
            // frmMakineLimitleri
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1762, 751);
            Controls.Add(Label7);
            Controls.Add(btnIptalSecim);
            Controls.Add(btnTumunuSec);
            Controls.Add(btnSeviyeEkle);
            Controls.Add(txtSeviyeYeni);
            Controls.Add(Label4);
            Controls.Add(Label6);
            Controls.Add(Label5);
            Controls.Add(Label3);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Controls.Add(btnKaydet);
            Controls.Add(btnIptal);
            Controls.Add(clbKullaniciSeviyeleri);
            Controls.Add(txtZamanLimitleri);
            Controls.Add(txtOlculer);
            Controls.Add(txtBakimSikligi);
            Controls.Add(txtPersonelTipi);
            Controls.Add(txtKullanimAmaci);
            Controls.Add(cmbMakine);
            Name = "frmMakineLimitleri";
            StartPosition = FormStartPosition.CenterParent;
            Text = "frmMakineLimitleri";
            Load += frmMakineLimitleri_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        internal ComboBox cmbMakine;
        internal TextBox txtKullanimAmaci;
        internal CheckedListBox CheckedListBox1;
        internal CheckedListBox clbKullaniciSeviyeleri;
        internal TextBox txtPersonelTipi;
        internal TextBox txtBakimSikligi;
        internal Button btnIptal;
        internal Button btnKaydet;
        internal Label Label1;
        internal Label Label2;
        internal Label Label3;
        internal Label Label4;
        internal TextBox txtOlculer;
        internal Label Label5;
        internal TextBox txtZamanLimitleri;
        internal Label Label6;
        internal TextBox txtSeviyeYeni;
        internal Button btnSeviyeEkle;
        internal Button btnTumunuSec;
        internal Label Label7;
        internal Button btnIptalSecim;
    }
}
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EMAR
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmMakineKayit : Form
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
            lblAd = new Label();
            txtAd = new TextBox();
            lblUretimYili = new Label();
            lblImalatci = new Label();
            txtImalatci = new TextBox();
            lblSeriNo = new Label();
            txtSeriNo = new TextBox();
            lblTipi = new Label();
            cmbTipi = new ComboBox();
            lblSertifikasyon = new Label();
            cmbSertifikasyon = new ComboBox();
            lblMusteri = new Label();
            cmbMusteri = new ComboBox();
            btnYeniMusteri = new Button();
            btnMusteriyiDuzenle = new Button();
            lblElektrik = new Label();
            clbElektrik = new CheckedListBox();
            txtElektrikYeni = new TextBox();
            btnElektrikEkle = new Button();
            lblPnomatik = new Label();
            clbPnomatik = new CheckedListBox();
            txtPnomatikYeni = new TextBox();
            btnPnomatikEkle = new Button();
            lblHidrolik = new Label();
            clbHidrolik = new CheckedListBox();
            txtHidrolikYeni = new TextBox();
            btnHidrolikEkle = new Button();
            btnMakineLimitleri = new Button();
            btnKaydet = new Button();
            btnIptal = new Button();
            Label1 = new Label();
            numYil = new NumericUpDown();
            lblName = new Label();
            txtName = new TextBox();
            txtDiger = new TextBox();
            lblDiger = new Label();
            ((System.ComponentModel.ISupportInitialize)numYil).BeginInit();
            SuspendLayout();
            // 
            // lblAd
            // 
            lblAd.AutoSize = true;
            lblAd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAd.ForeColor = Color.Black;
            lblAd.Location = new Point(50, 30);
            lblAd.Name = "lblAd";
            lblAd.Size = new Size(170, 37);
            lblAd.TabIndex = 0;
            lblAd.Text = "Makine Adı:";
            // 
            // txtAd
            // 
            txtAd.BackColor = Color.White;
            txtAd.Font = new Font("Segoe UI", 10F);
            txtAd.ForeColor = Color.Black;
            txtAd.Location = new Point(226, 27);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(380, 43);
            txtAd.TabIndex = 1;
            // 
            // lblUretimYili
            // 
            lblUretimYili.AutoSize = true;
            lblUretimYili.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUretimYili.ForeColor = Color.Black;
            lblUretimYili.Location = new Point(50, 102);
            lblUretimYili.Name = "lblUretimYili";
            lblUretimYili.Size = new Size(161, 37);
            lblUretimYili.TabIndex = 2;
            lblUretimYili.Text = "Üretim Yılı:";
            // 
            // lblImalatci
            // 
            lblImalatci.AutoSize = true;
            lblImalatci.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblImalatci.ForeColor = Color.Black;
            lblImalatci.Location = new Point(50, 174);
            lblImalatci.Name = "lblImalatci";
            lblImalatci.Size = new Size(128, 37);
            lblImalatci.TabIndex = 4;
            lblImalatci.Text = "İmalatçı:";
            // 
            // txtImalatci
            // 
            txtImalatci.BackColor = Color.White;
            txtImalatci.Font = new Font("Segoe UI", 10F);
            txtImalatci.ForeColor = Color.Black;
            txtImalatci.Location = new Point(226, 171);
            txtImalatci.Name = "txtImalatci";
            txtImalatci.Size = new Size(380, 43);
            txtImalatci.TabIndex = 5;
            // 
            // lblSeriNo
            // 
            lblSeriNo.AutoSize = true;
            lblSeriNo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSeriNo.ForeColor = Color.Black;
            lblSeriNo.Location = new Point(50, 246);
            lblSeriNo.Name = "lblSeriNo";
            lblSeriNo.Size = new Size(118, 37);
            lblSeriNo.TabIndex = 6;
            lblSeriNo.Text = "Seri No:";
            // 
            // txtSeriNo
            // 
            txtSeriNo.BackColor = Color.White;
            txtSeriNo.Font = new Font("Segoe UI", 10F);
            txtSeriNo.ForeColor = Color.Black;
            txtSeriNo.Location = new Point(226, 243);
            txtSeriNo.Name = "txtSeriNo";
            txtSeriNo.Size = new Size(380, 43);
            txtSeriNo.TabIndex = 7;
            // 
            // lblTipi
            // 
            lblTipi.AutoSize = true;
            lblTipi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTipi.ForeColor = Color.Black;
            lblTipi.Location = new Point(710, 30);
            lblTipi.Name = "lblTipi";
            lblTipi.Size = new Size(175, 37);
            lblTipi.TabIndex = 8;
            lblTipi.Text = "Makine Tipi:";
            // 
            // cmbTipi
            // 
            cmbTipi.BackColor = Color.White;
            cmbTipi.Font = new Font("Segoe UI", 10F);
            cmbTipi.ForeColor = Color.Black;
            cmbTipi.Location = new Point(932, 26);
            cmbTipi.Name = "cmbTipi";
            cmbTipi.Size = new Size(380, 45);
            cmbTipi.TabIndex = 9;
            // 
            // lblSertifikasyon
            // 
            lblSertifikasyon.AutoSize = true;
            lblSertifikasyon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSertifikasyon.ForeColor = Color.Black;
            lblSertifikasyon.Location = new Point(710, 102);
            lblSertifikasyon.Name = "lblSertifikasyon";
            lblSertifikasyon.Size = new Size(193, 37);
            lblSertifikasyon.TabIndex = 10;
            lblSertifikasyon.Text = "Sertifikasyon:";
            // 
            // cmbSertifikasyon
            // 
            cmbSertifikasyon.BackColor = Color.White;
            cmbSertifikasyon.Font = new Font("Segoe UI", 10F);
            cmbSertifikasyon.ForeColor = Color.Black;
            cmbSertifikasyon.Location = new Point(932, 98);
            cmbSertifikasyon.Name = "cmbSertifikasyon";
            cmbSertifikasyon.Size = new Size(380, 45);
            cmbSertifikasyon.TabIndex = 11;
            // 
            // lblMusteri
            // 
            lblMusteri.AutoSize = true;
            lblMusteri.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMusteri.ForeColor = Color.Black;
            lblMusteri.Location = new Point(711, 174);
            lblMusteri.Name = "lblMusteri";
            lblMusteri.Size = new Size(174, 37);
            lblMusteri.TabIndex = 12;
            lblMusteri.Text = "Müşteri Adı:";
            // 
            // cmbMusteri
            // 
            cmbMusteri.BackColor = Color.White;
            cmbMusteri.Font = new Font("Segoe UI", 10F);
            cmbMusteri.ForeColor = Color.Black;
            cmbMusteri.Location = new Point(932, 170);
            cmbMusteri.Name = "cmbMusteri";
            cmbMusteri.Size = new Size(380, 45);
            cmbMusteri.TabIndex = 13;
            // 
            // btnYeniMusteri
            // 
            btnYeniMusteri.BackColor = Color.FromArgb(63, 63, 70);
            btnYeniMusteri.FlatStyle = FlatStyle.Flat;
            btnYeniMusteri.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnYeniMusteri.ForeColor = Color.White;
            btnYeniMusteri.Location = new Point(613, 305);
            btnYeniMusteri.Name = "btnYeniMusteri";
            btnYeniMusteri.Size = new Size(193, 50);
            btnYeniMusteri.TabIndex = 14;
            btnYeniMusteri.Text = "Yeni Müşteri";
            btnYeniMusteri.UseVisualStyleBackColor = false;
            // 
            // btnMusteriyiDuzenle
            // 
            btnMusteriyiDuzenle.BackColor = Color.FromArgb(63, 63, 70);
            btnMusteriyiDuzenle.FlatStyle = FlatStyle.Flat;
            btnMusteriyiDuzenle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMusteriyiDuzenle.ForeColor = Color.White;
            btnMusteriyiDuzenle.Location = new Point(812, 305);
            btnMusteriyiDuzenle.Name = "btnMusteriyiDuzenle";
            btnMusteriyiDuzenle.Size = new Size(280, 50);
            btnMusteriyiDuzenle.TabIndex = 15;
            btnMusteriyiDuzenle.Text = "Müşteri Düzenle";
            btnMusteriyiDuzenle.UseVisualStyleBackColor = false;
            // 
            // lblElektrik
            // 
            lblElektrik.AutoSize = true;
            lblElektrik.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblElektrik.ForeColor = Color.Black;
            lblElektrik.Location = new Point(54, 381);
            lblElektrik.Name = "lblElektrik";
            lblElektrik.Size = new Size(122, 37);
            lblElektrik.TabIndex = 16;
            lblElektrik.Text = "Elektrik:";
            // 
            // clbElektrik
            // 
            clbElektrik.BackColor = Color.White;
            clbElektrik.Font = new Font("Segoe UI", 10F);
            clbElektrik.ForeColor = Color.Black;
            clbElektrik.Location = new Point(49, 430);
            clbElektrik.Name = "clbElektrik";
            clbElektrik.Size = new Size(319, 164);
            clbElektrik.TabIndex = 17;
            // 
            // txtElektrikYeni
            // 
            txtElektrikYeni.BackColor = Color.White;
            txtElektrikYeni.Font = new Font("Segoe UI", 10F);
            txtElektrikYeni.ForeColor = Color.Black;
            txtElektrikYeni.Location = new Point(50, 619);
            txtElektrikYeni.Name = "txtElektrikYeni";
            txtElektrikYeni.Size = new Size(155, 43);
            txtElektrikYeni.TabIndex = 18;
            // 
            // btnElektrikEkle
            // 
            btnElektrikEkle.BackColor = Color.FromArgb(63, 63, 70);
            btnElektrikEkle.FlatStyle = FlatStyle.Flat;
            btnElektrikEkle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnElektrikEkle.ForeColor = Color.White;
            btnElektrikEkle.Location = new Point(218, 615);
            btnElektrikEkle.Name = "btnElektrikEkle";
            btnElektrikEkle.Size = new Size(150, 50);
            btnElektrikEkle.TabIndex = 19;
            btnElektrikEkle.Text = "Ekle";
            btnElektrikEkle.UseVisualStyleBackColor = false;
            // 
            // lblPnomatik
            // 
            lblPnomatik.AutoSize = true;
            lblPnomatik.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPnomatik.ForeColor = Color.Black;
            lblPnomatik.Location = new Point(419, 378);
            lblPnomatik.Name = "lblPnomatik";
            lblPnomatik.Size = new Size(155, 37);
            lblPnomatik.TabIndex = 20;
            lblPnomatik.Text = "Pnomatik :";
            // 
            // clbPnomatik
            // 
            clbPnomatik.BackColor = Color.White;
            clbPnomatik.Font = new Font("Segoe UI", 10F);
            clbPnomatik.ForeColor = Color.Black;
            clbPnomatik.Location = new Point(419, 431);
            clbPnomatik.Name = "clbPnomatik";
            clbPnomatik.Size = new Size(314, 164);
            clbPnomatik.TabIndex = 21;
            // 
            // txtPnomatikYeni
            // 
            txtPnomatikYeni.BackColor = Color.White;
            txtPnomatikYeni.Font = new Font("Segoe UI", 10F);
            txtPnomatikYeni.ForeColor = Color.Black;
            txtPnomatikYeni.Location = new Point(415, 619);
            txtPnomatikYeni.Name = "txtPnomatikYeni";
            txtPnomatikYeni.Size = new Size(155, 43);
            txtPnomatikYeni.TabIndex = 22;
            // 
            // btnPnomatikEkle
            // 
            btnPnomatikEkle.BackColor = Color.FromArgb(63, 63, 70);
            btnPnomatikEkle.FlatStyle = FlatStyle.Flat;
            btnPnomatikEkle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPnomatikEkle.ForeColor = Color.White;
            btnPnomatikEkle.Location = new Point(583, 615);
            btnPnomatikEkle.Name = "btnPnomatikEkle";
            btnPnomatikEkle.Size = new Size(150, 50);
            btnPnomatikEkle.TabIndex = 23;
            btnPnomatikEkle.Text = "Ekle";
            btnPnomatikEkle.UseVisualStyleBackColor = false;
            // 
            // lblHidrolik
            // 
            lblHidrolik.AutoSize = true;
            lblHidrolik.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHidrolik.ForeColor = Color.Black;
            lblHidrolik.Location = new Point(783, 381);
            lblHidrolik.Name = "lblHidrolik";
            lblHidrolik.Size = new Size(136, 37);
            lblHidrolik.TabIndex = 24;
            lblHidrolik.Text = "Hidrolik :";
            // 
            // clbHidrolik
            // 
            clbHidrolik.BackColor = Color.White;
            clbHidrolik.Font = new Font("Segoe UI", 10F);
            clbHidrolik.ForeColor = Color.Black;
            clbHidrolik.Location = new Point(784, 431);
            clbHidrolik.Name = "clbHidrolik";
            clbHidrolik.Size = new Size(328, 164);
            clbHidrolik.TabIndex = 25;
            // 
            // txtHidrolikYeni
            // 
            txtHidrolikYeni.BackColor = Color.White;
            txtHidrolikYeni.Font = new Font("Segoe UI", 10F);
            txtHidrolikYeni.ForeColor = Color.Black;
            txtHidrolikYeni.Location = new Point(785, 619);
            txtHidrolikYeni.Name = "txtHidrolikYeni";
            txtHidrolikYeni.Size = new Size(155, 43);
            txtHidrolikYeni.TabIndex = 26;
            // 
            // btnHidrolikEkle
            // 
            btnHidrolikEkle.BackColor = Color.FromArgb(63, 63, 70);
            btnHidrolikEkle.FlatStyle = FlatStyle.Flat;
            btnHidrolikEkle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHidrolikEkle.ForeColor = Color.White;
            btnHidrolikEkle.Location = new Point(962, 615);
            btnHidrolikEkle.Name = "btnHidrolikEkle";
            btnHidrolikEkle.Size = new Size(150, 50);
            btnHidrolikEkle.TabIndex = 27;
            btnHidrolikEkle.Text = "Ekle";
            btnHidrolikEkle.UseVisualStyleBackColor = false;
            // 
            // btnMakineLimitleri
            // 
            btnMakineLimitleri.BackColor = Color.FromArgb(63, 63, 70);
            btnMakineLimitleri.FlatStyle = FlatStyle.Flat;
            btnMakineLimitleri.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMakineLimitleri.ForeColor = Color.White;
            btnMakineLimitleri.Location = new Point(1111, 305);
            btnMakineLimitleri.Name = "btnMakineLimitleri";
            btnMakineLimitleri.Size = new Size(250, 110);
            btnMakineLimitleri.TabIndex = 28;
            btnMakineLimitleri.Text = "Makine Limitleri";
            btnMakineLimitleri.UseVisualStyleBackColor = false;
            btnMakineLimitleri.Click += btnMakineLimitleri_Click;
            // 
            // btnKaydet
            // 
            btnKaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnKaydet.BackColor = Color.FromArgb(63, 63, 70);
            btnKaydet.FlatStyle = FlatStyle.Flat;
            btnKaydet.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnKaydet.ForeColor = Color.White;
            btnKaydet.Location = new Point(1211, 609);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(150, 50);
            btnKaydet.TabIndex = 29;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnIptal
            // 
            btnIptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnIptal.BackColor = Color.FromArgb(63, 63, 70);
            btnIptal.FlatStyle = FlatStyle.Flat;
            btnIptal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnIptal.ForeColor = Color.White;
            btnIptal.Location = new Point(1211, 671);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(150, 50);
            btnIptal.TabIndex = 30;
            btnIptal.Text = "İptal";
            btnIptal.UseVisualStyleBackColor = false;
            btnIptal.Click += btnIptal_Click;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            Label1.ForeColor = Color.Black;
            Label1.Location = new Point(49, 332);
            Label1.Name = "Label1";
            Label1.Size = new Size(283, 37);
            Label1.TabIndex = 24;
            Label1.Text = "ENERJİ KAYNAKLARI";
            // 
            // numYil
            // 
            numYil.Location = new Point(226, 102);
            numYil.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numYil.Minimum = new decimal(new int[] { 1900, 0, 0, 0 });
            numYil.Name = "numYil";
            numYil.Size = new Size(380, 39);
            numYil.TabIndex = 31;
            numYil.Value = new decimal(new int[] { 1900, 0, 0, 0 });
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblName.ForeColor = Color.Black;
            lblName.Location = new Point(710, 243);
            lblName.Name = "lblName";
            lblName.Size = new Size(216, 37);
            lblName.TabIndex = 32;
            lblName.Text = "Machine Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(932, 241);
            txtName.Name = "txtName";
            txtName.Size = new Size(380, 39);
            txtName.TabIndex = 33;
            // 
            // txtDiger
            // 
            txtDiger.Location = new Point(363, 698);
            txtDiger.Name = "txtDiger";
            txtDiger.Size = new Size(457, 39);
            txtDiger.TabIndex = 34;
            txtDiger.Text = "N/A";
            // 
            // lblDiger
            // 
            lblDiger.AutoSize = true;
            lblDiger.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDiger.ForeColor = Color.Black;
            lblDiger.Location = new Point(54, 697);
            lblDiger.Name = "lblDiger";
            lblDiger.Size = new Size(311, 42);
            lblDiger.TabIndex = 35;
            lblDiger.Text = "Diğer Enerji Kaynakları:";
            lblDiger.UseCompatibleTextRendering = true;
            // 
            // frmMakineKayit
            // 
            ClientSize = new Size(1415, 760);
            Controls.Add(lblDiger);
            Controls.Add(txtDiger);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(numYil);
            Controls.Add(lblAd);
            Controls.Add(txtAd);
            Controls.Add(lblUretimYili);
            Controls.Add(lblImalatci);
            Controls.Add(txtImalatci);
            Controls.Add(lblSeriNo);
            Controls.Add(txtSeriNo);
            Controls.Add(lblTipi);
            Controls.Add(cmbTipi);
            Controls.Add(lblSertifikasyon);
            Controls.Add(cmbSertifikasyon);
            Controls.Add(lblMusteri);
            Controls.Add(cmbMusteri);
            Controls.Add(btnYeniMusteri);
            Controls.Add(btnMusteriyiDuzenle);
            Controls.Add(lblElektrik);
            Controls.Add(clbElektrik);
            Controls.Add(txtElektrikYeni);
            Controls.Add(btnElektrikEkle);
            Controls.Add(lblPnomatik);
            Controls.Add(clbPnomatik);
            Controls.Add(txtPnomatikYeni);
            Controls.Add(btnPnomatikEkle);
            Controls.Add(Label1);
            Controls.Add(lblHidrolik);
            Controls.Add(clbHidrolik);
            Controls.Add(txtHidrolikYeni);
            Controls.Add(btnHidrolikEkle);
            Controls.Add(btnMakineLimitleri);
            Controls.Add(btnKaydet);
            Controls.Add(btnIptal);
            Name = "frmMakineKayit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Makine Kayıt";
            Load += frmMakineKayit_Load;
            ((System.ComponentModel.ISupportInitialize)numYil).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        internal Label lblAd;
        internal TextBox txtAd;
        internal Label lblUretimYili;
        internal Label lblImalatci;
        internal TextBox txtImalatci;
        internal Label lblSeriNo;
        internal TextBox txtSeriNo;
        internal Label lblTipi;
        internal ComboBox cmbTipi;
        internal Label lblSertifikasyon;
        internal ComboBox cmbSertifikasyon;
        internal Label lblMusteri;
        internal ComboBox cmbMusteri;
        internal Button btnYeniMusteri;
        internal Button btnMusteriyiDuzenle;
        internal Label lblElektrik;
        internal CheckedListBox clbElektrik;
        internal TextBox txtElektrikYeni;
        internal Button btnElektrikEkle;
        internal Label lblPnomatik;
        internal CheckedListBox clbPnomatik;
        internal TextBox txtPnomatikYeni;
        internal Button btnPnomatikEkle;
        internal Label lblHidrolik;
        internal CheckedListBox clbHidrolik;
        internal TextBox txtHidrolikYeni;
        internal Button btnHidrolikEkle;
        internal Button btnMakineLimitleri;
        internal Button btnKaydet;
        internal Button btnIptal;
        internal Label Label1;
        private NumericUpDown numYil;
        internal Label lblName;
        private TextBox txtName;
        private TextBox txtDiger;
        internal Label lblDiger;
    }
}
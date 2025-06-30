using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EMAR
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmProjeKayit : Form
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
            lblProjeAdi = new Label();
            txtAd = new TextBox();
            lblProjeKodu = new Label();
            txtProjeKodu = new TextBox();
            lblMusteri = new Label();
            cmbMusteri = new ComboBox();
            lblTarih = new Label();
            dtpTarih = new DateTimePicker();
            lblHizmetKodu = new Label();
            cmbHizmetKodu = new ComboBox();
            txtHizmetYeni = new TextBox();
            btnHizmetEkle = new Button();
            btnHizmetEkle.Click += new EventHandler(btnHizmetEkle_Click);
            lblAciklama = new Label();
            txtAciklama = new TextBox();
            btnKaydet = new Button();
            btnKaydet.Click += new EventHandler(btnKaydet_Click);
            btnIptal = new Button();
            btnIptal.Click += new EventHandler(btnIptal_Click);
            SuspendLayout();
            // 
            // lblProjeAdi
            // 
            lblProjeAdi.Location = new Point(40, 40);
            lblProjeAdi.Name = "lblProjeAdi";
            lblProjeAdi.Size = new Size(200, 30);
            lblProjeAdi.TabIndex = 0;
            lblProjeAdi.Text = "Proje Adı:";
            // 
            // txtAd
            // 
            txtAd.Location = new Point(250, 35);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(460, 39);
            txtAd.TabIndex = 1;
            // 
            // lblProjeKodu
            // 
            lblProjeKodu.Location = new Point(40, 90);
            lblProjeKodu.Name = "lblProjeKodu";
            lblProjeKodu.Size = new Size(200, 30);
            lblProjeKodu.TabIndex = 2;
            lblProjeKodu.Text = "Proje Kodu:";
            // 
            // txtProjeKodu
            // 
            txtProjeKodu.Location = new Point(250, 85);
            txtProjeKodu.Name = "txtProjeKodu";
            txtProjeKodu.Size = new Size(460, 39);
            txtProjeKodu.TabIndex = 3;
            // 
            // lblMusteri
            // 
            lblMusteri.Location = new Point(40, 140);
            lblMusteri.Name = "lblMusteri";
            lblMusteri.Size = new Size(200, 30);
            lblMusteri.TabIndex = 4;
            lblMusteri.Text = "Müşteri:";
            // 
            // cmbMusteri
            // 
            cmbMusteri.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMusteri.Location = new Point(250, 135);
            cmbMusteri.Name = "cmbMusteri";
            cmbMusteri.Size = new Size(460, 40);
            cmbMusteri.TabIndex = 5;
            // 
            // lblTarih
            // 
            lblTarih.Location = new Point(40, 190);
            lblTarih.Name = "lblTarih";
            lblTarih.Size = new Size(200, 30);
            lblTarih.TabIndex = 6;
            lblTarih.Text = "Proje Tarihi:";
            // 
            // dtpTarih
            // 
            dtpTarih.Location = new Point(250, 185);
            dtpTarih.Name = "dtpTarih";
            dtpTarih.Size = new Size(460, 39);
            dtpTarih.TabIndex = 7;
            // 
            // lblHizmetKodu
            // 
            lblHizmetKodu.Location = new Point(40, 240);
            lblHizmetKodu.Name = "lblHizmetKodu";
            lblHizmetKodu.Size = new Size(200, 30);
            lblHizmetKodu.TabIndex = 8;
            lblHizmetKodu.Text = "Hizmet Kodu:";
            // 
            // cmbHizmetKodu
            // 
            cmbHizmetKodu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHizmetKodu.Location = new Point(250, 235);
            cmbHizmetKodu.Name = "cmbHizmetKodu";
            cmbHizmetKodu.Size = new Size(280, 40);
            cmbHizmetKodu.TabIndex = 9;
            // 
            // txtHizmetYeni
            // 
            txtHizmetYeni.Location = new Point(250, 285);
            txtHizmetYeni.Name = "txtHizmetYeni";
            txtHizmetYeni.PlaceholderText = "Yeni Hizmet Kodu";
            txtHizmetYeni.Size = new Size(280, 39);
            txtHizmetYeni.TabIndex = 10;
            // 
            // btnHizmetEkle
            // 
            btnHizmetEkle.Location = new Point(540, 285);
            btnHizmetEkle.Name = "btnHizmetEkle";
            btnHizmetEkle.Size = new Size(120, 39);
            btnHizmetEkle.TabIndex = 11;
            btnHizmetEkle.Text = "Ekle";
            // 
            // lblAciklama
            // 
            lblAciklama.Location = new Point(40, 340);
            lblAciklama.Name = "lblAciklama";
            lblAciklama.Size = new Size(200, 30);
            lblAciklama.TabIndex = 12;
            lblAciklama.Text = "Proje Açıklaması:";
            // 
            // txtAciklama
            // 
            txtAciklama.Location = new Point(40, 375);
            txtAciklama.Multiline = true;
            txtAciklama.Name = "txtAciklama";
            txtAciklama.ScrollBars = ScrollBars.Vertical;
            txtAciklama.Size = new Size(670, 180);
            txtAciklama.TabIndex = 13;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(400, 580);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(120, 45);
            btnKaydet.TabIndex = 14;
            btnKaydet.Text = "Kaydet";
            // 
            // btnIptal
            // 
            btnIptal.Location = new Point(540, 580);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(120, 45);
            btnIptal.TabIndex = 15;
            btnIptal.Text = "İptal";
            // 
            // frmProjeKayit
            // 
            AutoScaleDimensions = new SizeF(13.0f, 32.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 660);
            Controls.Add(lblProjeAdi);
            Controls.Add(txtAd);
            Controls.Add(lblProjeKodu);
            Controls.Add(txtProjeKodu);
            Controls.Add(lblMusteri);
            Controls.Add(cmbMusteri);
            Controls.Add(lblTarih);
            Controls.Add(dtpTarih);
            Controls.Add(lblHizmetKodu);
            Controls.Add(cmbHizmetKodu);
            Controls.Add(txtHizmetYeni);
            Controls.Add(btnHizmetEkle);
            Controls.Add(lblAciklama);
            Controls.Add(txtAciklama);
            Controls.Add(btnKaydet);
            Controls.Add(btnIptal);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "frmProjeKayit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Proje Kaydı";
            Load += new EventHandler(frmProjeKayit_Load);
            ResumeLayout(false);
            PerformLayout();

        }

        internal Label lblProjeAdi;
        internal TextBox txtAd;
        internal Label lblProjeKodu;
        internal TextBox txtProjeKodu;
        internal Label lblMusteri;
        internal ComboBox cmbMusteri;
        internal Label lblTarih;
        internal DateTimePicker dtpTarih;
        internal Label lblHizmetKodu;
        internal ComboBox cmbHizmetKodu;
        internal TextBox txtHizmetYeni;
        internal Button btnHizmetEkle;
        internal Label lblAciklama;
        internal TextBox txtAciklama;
        internal Button btnKaydet;
        internal Button btnIptal;
    }
}
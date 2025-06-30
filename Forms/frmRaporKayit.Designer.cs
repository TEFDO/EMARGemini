using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EMAR
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmRaporKayit : Form
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
            lblRaporKodu = new Label();
            txtRaporKodu = new TextBox();
            lblTarih = new Label();
            dtpTarih = new DateTimePicker();
            lblAciklama = new Label();
            txtAciklama = new TextBox();
            btnKaydet = new Button();
            btnIptal = new Button();
            cmbProjeKodu = new ComboBox();
            cmbRaporTuru = new ComboBox();
            Label1 = new Label();
            Label2 = new Label();
            Label3 = new Label();
            cmbMakine = new ComboBox();
            Label4 = new Label();
            cmbMusteriAdi = new ComboBox();
            SuspendLayout();
            // 
            // lblRaporKodu
            // 
            lblRaporKodu.Location = new Point(30, 273);
            lblRaporKodu.Name = "lblRaporKodu";
            lblRaporKodu.Size = new Size(150, 30);
            lblRaporKodu.TabIndex = 0;
            lblRaporKodu.Text = "Rapor Kodu:";
            // 
            // txtRaporKodu
            // 
            txtRaporKodu.Location = new Point(200, 269);
            txtRaporKodu.Name = "txtRaporKodu";
            txtRaporKodu.ReadOnly = true;
            txtRaporKodu.Size = new Size(400, 39);
            txtRaporKodu.TabIndex = 1;
            // 
            // lblTarih
            // 
            lblTarih.Location = new Point(30, 324);
            lblTarih.Name = "lblTarih";
            lblTarih.Size = new Size(150, 30);
            lblTarih.TabIndex = 2;
            lblTarih.Text = "Tarih:";
            // 
            // dtpTarih
            // 
            dtpTarih.Location = new Point(200, 319);
            dtpTarih.Name = "dtpTarih";
            dtpTarih.Size = new Size(400, 39);
            dtpTarih.TabIndex = 3;
            // 
            // lblAciklama
            // 
            lblAciklama.Location = new Point(30, 374);
            lblAciklama.Name = "lblAciklama";
            lblAciklama.Size = new Size(200, 30);
            lblAciklama.TabIndex = 4;
            lblAciklama.Text = "Açıklama / Not:";
            // 
            // txtAciklama
            // 
            txtAciklama.Location = new Point(30, 409);
            txtAciklama.Multiline = true;
            txtAciklama.Name = "txtAciklama";
            txtAciklama.ScrollBars = ScrollBars.Vertical;
            txtAciklama.Size = new Size(570, 180);
            txtAciklama.TabIndex = 5;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(360, 614);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(110, 45);
            btnKaydet.TabIndex = 6;
            btnKaydet.Text = "Kaydet";
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnIptal
            // 
            btnIptal.Location = new Point(490, 613);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(110, 45);
            btnIptal.TabIndex = 7;
            btnIptal.Text = "İptal";
            btnIptal.Click += btnIptal_Click;
            // 
            // cmbProjeKodu
            // 
            cmbProjeKodu.FormattingEnabled = true;
            cmbProjeKodu.Location = new Point(200, 223);
            cmbProjeKodu.Name = "cmbProjeKodu";
            cmbProjeKodu.Size = new Size(242, 40);
            cmbProjeKodu.TabIndex = 8;
            cmbProjeKodu.SelectedIndexChanged += cmbProjeKodu_SelectedIndexChanged;
            // 
            // cmbRaporTuru
            // 
            cmbRaporTuru.FormattingEnabled = true;
            cmbRaporTuru.Location = new Point(200, 164);
            cmbRaporTuru.Name = "cmbRaporTuru";
            cmbRaporTuru.Size = new Size(242, 40);
            cmbRaporTuru.TabIndex = 8;
            cmbRaporTuru.SelectedIndexChanged += cmbRaporTuru_SelectedIndexChanged;
            // 
            // Label1
            // 
            Label1.Location = new Point(30, 223);
            Label1.Name = "Label1";
            Label1.Size = new Size(150, 30);
            Label1.TabIndex = 0;
            Label1.Text = "Proje Kodu:";
            // 
            // Label2
            // 
            Label2.Location = new Point(30, 165);
            Label2.Name = "Label2";
            Label2.Size = new Size(150, 30);
            Label2.TabIndex = 0;
            Label2.Text = "Rapor Türü:";
            // 
            // Label3
            // 
            Label3.Location = new Point(30, 107);
            Label3.Name = "Label3";
            Label3.Size = new Size(150, 30);
            Label3.TabIndex = 0;
            Label3.Text = "Makine Adı:";
            // 
            // cmbMakine
            // 
            cmbMakine.FormattingEnabled = true;
            cmbMakine.Location = new Point(200, 105);
            cmbMakine.Name = "cmbMakine";
            cmbMakine.Size = new Size(400, 40);
            cmbMakine.TabIndex = 8;
            // 
            // Label4
            // 
            Label4.Location = new Point(30, 49);
            Label4.Name = "Label4";
            Label4.Size = new Size(150, 30);
            Label4.TabIndex = 0;
            Label4.Text = "Müşteri Adı:";
            // 
            // cmbMusteriAdi
            // 
            cmbMusteriAdi.FormattingEnabled = true;
            cmbMusteriAdi.Location = new Point(200, 46);
            cmbMusteriAdi.Name = "cmbMusteriAdi";
            cmbMusteriAdi.Size = new Size(400, 40);
            cmbMusteriAdi.TabIndex = 8;
            // 
            // frmRaporKayit
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 670);
            Controls.Add(cmbMusteriAdi);
            Controls.Add(cmbMakine);
            Controls.Add(Label4);
            Controls.Add(cmbRaporTuru);
            Controls.Add(Label3);
            Controls.Add(cmbProjeKodu);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Controls.Add(lblRaporKodu);
            Controls.Add(txtRaporKodu);
            Controls.Add(lblTarih);
            Controls.Add(dtpTarih);
            Controls.Add(lblAciklama);
            Controls.Add(txtAciklama);
            Controls.Add(btnKaydet);
            Controls.Add(btnIptal);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "frmRaporKayit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Rapor Kaydı";
            Load += frmRaporKayit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        internal Label lblRaporKodu;
        internal TextBox txtRaporKodu;
        internal Label lblTarih;
        internal DateTimePicker dtpTarih;
        internal Label lblAciklama;
        internal TextBox txtAciklama;
        internal Button btnKaydet;
        internal Button btnIptal;
        internal ComboBox cmbProjeKodu;
        internal ComboBox cmbRaporTuru;
        internal Label Label1;
        internal Label Label2;
        internal Label Label3;
        internal ComboBox cmbMakine;
        internal Label Label4;
        internal ComboBox cmbMusteriAdi;
    }
}
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EMAR
{
    // ucMakine - EMAR Stilinde Designer Uyumlu Makine Özeti Kullanıcı Denetimi
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class ucMakine : UserControl
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
            lblBaslik = new Label();
            grpGenel = new GroupBox();
            lblMakineAdi = new Label();
            lblImalatci = new Label();
            lblSeriNo = new Label();
            lblTip = new Label();
            lblYil = new Label();
            grpEnerji = new GroupBox();
            lblElektrik = new Label();
            lblPnomatik = new Label();
            lblHidrolik = new Label();
            lblSertifikasyon = new Label();
            txtSertifikasyon = new TextBox();
            grpGenel.SuspendLayout();
            grpEnerji.SuspendLayout();
            SuspendLayout();
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("Segoe UI", 18f, FontStyle.Bold);
            lblBaslik.Location = new Point(30, 30);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(327, 65);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "Makine Özeti";
            // 
            // grpGenel
            // 
            grpGenel.Controls.Add(lblMakineAdi);
            grpGenel.Controls.Add(lblImalatci);
            grpGenel.Controls.Add(lblSeriNo);
            grpGenel.Controls.Add(lblTip);
            grpGenel.Controls.Add(lblYil);
            grpGenel.Location = new Point(30, 90);
            grpGenel.Name = "grpGenel";
            grpGenel.Size = new Size(802, 365);
            grpGenel.TabIndex = 1;
            grpGenel.TabStop = false;
            grpGenel.Text = "Genel Bilgiler";
            // 
            // lblMakineAdi
            // 
            lblMakineAdi.AutoSize = true;
            lblMakineAdi.Location = new Point(20, 52);
            lblMakineAdi.Name = "lblMakineAdi";
            lblMakineAdi.Size = new Size(236, 45);
            lblMakineAdi.TabIndex = 0;
            lblMakineAdi.Text = "Makine Adı: ---";
            // 
            // lblImalatci
            // 
            lblImalatci.AutoSize = true;
            lblImalatci.Location = new Point(20, 113);
            lblImalatci.Name = "lblImalatci";
            lblImalatci.Size = new Size(186, 45);
            lblImalatci.TabIndex = 1;
            lblImalatci.Text = "İmalatçı: ---";
            // 
            // lblSeriNo
            // 
            lblSeriNo.AutoSize = true;
            lblSeriNo.Location = new Point(20, 174);
            lblSeriNo.Name = "lblSeriNo";
            lblSeriNo.Size = new Size(180, 45);
            lblSeriNo.TabIndex = 2;
            lblSeriNo.Text = "Seri No: ---";
            // 
            // lblTip
            // 
            lblTip.AutoSize = true;
            lblTip.Location = new Point(20, 235);
            lblTip.Name = "lblTip";
            lblTip.Size = new Size(127, 45);
            lblTip.TabIndex = 3;
            lblTip.Text = "Tipi: ---";
            // 
            // lblYil
            // 
            lblYil.AutoSize = true;
            lblYil.Location = new Point(20, 296);
            lblYil.Name = "lblYil";
            lblYil.Size = new Size(223, 45);
            lblYil.TabIndex = 4;
            lblYil.Text = "Üretim Yılı: ---";
            // 
            // grpEnerji
            // 
            grpEnerji.Controls.Add(lblElektrik);
            grpEnerji.Controls.Add(lblPnomatik);
            grpEnerji.Controls.Add(lblHidrolik);
            grpEnerji.Location = new Point(30, 461);
            grpEnerji.Name = "grpEnerji";
            grpEnerji.Size = new Size(802, 261);
            grpEnerji.TabIndex = 2;
            grpEnerji.TabStop = false;
            grpEnerji.Text = "Enerji Kaynakları (Seçilen Değerler)";
            // 
            // lblElektrik
            // 
            lblElektrik.AutoSize = true;
            lblElektrik.Location = new Point(20, 61);
            lblElektrik.Name = "lblElektrik";
            lblElektrik.Size = new Size(178, 45);
            lblElektrik.TabIndex = 0;
            lblElektrik.Text = "Elektrik: ---";
            // 
            // lblPnomatik
            // 
            lblPnomatik.AutoSize = true;
            lblPnomatik.Location = new Point(20, 123);
            lblPnomatik.Name = "lblPnomatik";
            lblPnomatik.Size = new Size(209, 45);
            lblPnomatik.TabIndex = 1;
            lblPnomatik.Text = "Pnomatik: ---";
            // 
            // lblHidrolik
            // 
            lblHidrolik.AutoSize = true;
            lblHidrolik.Location = new Point(20, 185);
            lblHidrolik.Name = "lblHidrolik";
            lblHidrolik.Size = new Size(187, 45);
            lblHidrolik.TabIndex = 2;
            lblHidrolik.Text = "Hidrolik: ---";
            // 
            // lblSertifikasyon
            // 
            lblSertifikasyon.AutoSize = true;
            lblSertifikasyon.Location = new Point(30, 755);
            lblSertifikasyon.Name = "lblSertifikasyon";
            lblSertifikasyon.Size = new Size(207, 45);
            lblSertifikasyon.TabIndex = 3;
            lblSertifikasyon.Text = "Sertifikasyon:";
            // 
            // txtSertifikasyon
            // 
            txtSertifikasyon.Location = new Point(223, 750);
            txtSertifikasyon.Name = "txtSertifikasyon";
            txtSertifikasyon.ReadOnly = true;
            txtSertifikasyon.Size = new Size(587, 50);
            txtSertifikasyon.TabIndex = 4;
            // 
            // ucMakine
            // 
            AutoScaleDimensions = new SizeF(18f, 45f);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtSertifikasyon);
            Controls.Add(lblSertifikasyon);
            Controls.Add(grpEnerji);
            Controls.Add(grpGenel);
            Controls.Add(lblBaslik);
            Font = new Font("Segoe UI", 12f);
            Name = "ucMakine";
            Size = new Size(882, 829);
            grpGenel.ResumeLayout(false);
            grpGenel.PerformLayout();
            grpEnerji.ResumeLayout(false);
            grpEnerji.PerformLayout();
            Load += new EventHandler(ucMakine_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal Label lblBaslik;
        internal GroupBox grpGenel;
        internal Label lblMakineAdi;
        internal Label lblImalatci;
        internal Label lblSeriNo;
        internal Label lblTip;
        internal Label lblYil;
        internal GroupBox grpEnerji;
        internal Label lblElektrik;
        internal Label lblPnomatik;
        internal Label lblHidrolik;
        internal Label lblSertifikasyon;
        internal TextBox txtSertifikasyon;
    }
}
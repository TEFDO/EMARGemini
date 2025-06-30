using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EMAR
{
    // ucGenel - Rapor Genel Bilgiler Kullanıcı Denetimi (Modern ve Profesyonel Tasarım)
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class ucGenel : UserControl
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
            lblMusteriLabel = new Label();
            lblProjeLabel = new Label();
            lblMakineLabel = new Label();
            lblTarih = new Label();
            lblAciklama = new Label();
            lblMusteri = new Label();
            lblProje = new Label();
            lblMakine = new Label();
            dtTarih = new DateTimePicker();
            txtAciklama = new TextBox();
            SuspendLayout();
            // 
            // lblMusteriLabel
            // 
            lblMusteriLabel.AutoSize = true;
            lblMusteriLabel.Font = new Font("Segoe UI", 12.0f);
            lblMusteriLabel.Location = new Point(40, 40);
            lblMusteriLabel.Name = "lblMusteriLabel";
            lblMusteriLabel.Size = new Size(192, 45);
            lblMusteriLabel.TabIndex = 0;
            lblMusteriLabel.Text = "Müşteri Adı:";
            // 
            // lblProjeLabel
            // 
            lblProjeLabel.AutoSize = true;
            lblProjeLabel.Font = new Font("Segoe UI", 12.0f);
            lblProjeLabel.Location = new Point(44, 98);
            lblProjeLabel.Name = "lblProjeLabel";
            lblProjeLabel.Size = new Size(157, 45);
            lblProjeLabel.TabIndex = 1;
            lblProjeLabel.Text = "Proje Adı:";
            // 
            // lblMakineLabel
            // 
            lblMakineLabel.AutoSize = true;
            lblMakineLabel.Font = new Font("Segoe UI", 12.0f);
            lblMakineLabel.Location = new Point(44, 158);
            lblMakineLabel.Name = "lblMakineLabel";
            lblMakineLabel.Size = new Size(188, 45);
            lblMakineLabel.TabIndex = 2;
            lblMakineLabel.Text = "Makine Adı:";
            // 
            // lblTarih
            // 
            lblTarih.AutoSize = true;
            lblTarih.Font = new Font("Segoe UI", 12.0f);
            lblTarih.Location = new Point(44, 219);
            lblTarih.Name = "lblTarih";
            lblTarih.Size = new Size(93, 45);
            lblTarih.TabIndex = 3;
            lblTarih.Text = "Tarih:";
            // 
            // lblAciklama
            // 
            lblAciklama.AutoSize = true;
            lblAciklama.Font = new Font("Segoe UI", 12.0f);
            lblAciklama.Location = new Point(44, 308);
            lblAciklama.Name = "lblAciklama";
            lblAciklama.Size = new Size(155, 45);
            lblAciklama.TabIndex = 4;
            lblAciklama.Text = "Açıklama:";
            // 
            // lblMusteri
            // 
            lblMusteri.Font = new Font("Segoe UI", 12.0f, FontStyle.Bold);
            lblMusteri.Location = new Point(238, 40);
            lblMusteri.Name = "lblMusteri";
            lblMusteri.Size = new Size(556, 45);
            lblMusteri.TabIndex = 5;
            // 
            // lblProje
            // 
            lblProje.Font = new Font("Segoe UI", 12.0f, FontStyle.Bold);
            lblProje.Location = new Point(238, 98);
            lblProje.Name = "lblProje";
            lblProje.Size = new Size(556, 45);
            lblProje.TabIndex = 6;
            // 
            // lblMakine
            // 
            lblMakine.Font = new Font("Segoe UI", 12.0f, FontStyle.Bold);
            lblMakine.Location = new Point(238, 158);
            lblMakine.Name = "lblMakine";
            lblMakine.Size = new Size(400, 45);
            lblMakine.TabIndex = 7;
            // 
            // dtTarih
            // 
            dtTarih.Font = new Font("Segoe UI", 11.0f);
            dtTarih.Location = new Point(238, 219);
            dtTarih.Name = "dtTarih";
            dtTarih.Size = new Size(441, 47);
            dtTarih.TabIndex = 8;
            // 
            // txtAciklama
            // 
            txtAciklama.Font = new Font("Segoe UI", 11.0f);
            txtAciklama.Location = new Point(238, 308);
            txtAciklama.Multiline = true;
            txtAciklama.Name = "txtAciklama";
            txtAciklama.Size = new Size(556, 195);
            txtAciklama.TabIndex = 9;
            // 
            // ucGenel
            // 
            Controls.Add(lblMusteriLabel);
            Controls.Add(lblProjeLabel);
            Controls.Add(lblMakineLabel);
            Controls.Add(lblTarih);
            Controls.Add(lblAciklama);
            Controls.Add(lblMusteri);
            Controls.Add(lblProje);
            Controls.Add(lblMakine);
            Controls.Add(dtTarih);
            Controls.Add(txtAciklama);
            Name = "ucGenel";
            Size = new Size(839, 550);
            Load += new EventHandler(ucGenel_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal Label lblMusteriLabel;
        internal Label lblProjeLabel;
        internal Label lblMakineLabel;
        internal Label lblTarih;
        internal Label lblAciklama;

        internal Label lblMusteri;
        internal Label lblProje;
        internal Label lblMakine;
        internal DateTimePicker dtTarih;
        internal TextBox txtAciklama;

    }
}
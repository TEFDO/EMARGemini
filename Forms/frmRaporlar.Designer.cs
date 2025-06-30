using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EMAR
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmRaporlar : Form
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
            cmbProjeler = new ComboBox();
            cmbProjeler.SelectedIndexChanged += new EventHandler(cmbProjeler_SelectedIndexChanged);
            cmbRaporTurleri = new ComboBox();
            cmbRaporTurleri.SelectedIndexChanged += new EventHandler(cmbRaporTurleri_SelectedIndexChanged);
            dgvRaporlar = new DataGridView();
            dgvRaporlar.CellDoubleClick += new DataGridViewCellEventHandler(dgvRaporlar_CellDoubleClick);
            btnYeniRapor = new Button();
            btnYeniRapor.Click += new EventHandler(btnYeniRapor_Click);
            btnDuzenle = new Button();
            btnDuzenle.Click += new EventHandler(btnDuzenle_Click);
            btnGeri = new Button();
            btnGeri.Click += new EventHandler(btnGeri_Click);
            btnSil = new Button();
            btnSil.Click += new EventHandler(btnSil_Click);
            btnIceriAktar = new Button();
            btnIceriAktar.Click += new EventHandler(btnIceriAktar_Click);
            btnDisariAktar = new Button();
            btnDisariAktar.Click += new EventHandler(btnDisariAktar_Click);
            ((System.ComponentModel.ISupportInitialize)dgvRaporlar).BeginInit();
            SuspendLayout();
            // 
            // cmbProjeler
            // 
            cmbProjeler.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProjeler.Font = new Font("Segoe UI", 10f);
            cmbProjeler.Location = new Point(30, 54);
            cmbProjeler.Name = "cmbProjeler";
            cmbProjeler.Size = new Size(300, 45);
            cmbProjeler.TabIndex = 0;
            // 
            // cmbRaporTurleri
            // 
            cmbRaporTurleri.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRaporTurleri.Font = new Font("Segoe UI", 10f);
            cmbRaporTurleri.Location = new Point(350, 54);
            cmbRaporTurleri.Name = "cmbRaporTurleri";
            cmbRaporTurleri.Size = new Size(250, 45);
            cmbRaporTurleri.TabIndex = 1;
            // 
            // dgvRaporlar
            // 
            dgvRaporlar.AllowUserToAddRows = false;
            dgvRaporlar.AllowUserToDeleteRows = false;
            dgvRaporlar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRaporlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRaporlar.Location = new Point(30, 125);
            dgvRaporlar.MultiSelect = false;
            dgvRaporlar.Name = "dgvRaporlar";
            dgvRaporlar.ReadOnly = true;
            dgvRaporlar.RowHeadersVisible = false;
            dgvRaporlar.RowHeadersWidth = 82;
            dgvRaporlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRaporlar.Size = new Size(2300, 720);
            dgvRaporlar.TabIndex = 2;
            // 
            // btnYeniRapor
            // 
            btnYeniRapor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnYeniRapor.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            btnYeniRapor.Location = new Point(1742, 49);
            btnYeniRapor.Name = "btnYeniRapor";
            btnYeniRapor.Size = new Size(134, 50);
            btnYeniRapor.TabIndex = 3;
            btnYeniRapor.Text = "Yeni Rapor";
            // 
            // btnDuzenle
            // 
            btnDuzenle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDuzenle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            btnDuzenle.Location = new Point(1893, 49);
            btnDuzenle.Name = "btnDuzenle";
            btnDuzenle.Size = new Size(134, 50);
            btnDuzenle.TabIndex = 4;
            btnDuzenle.Text = "Düzenle";
            // 
            // btnGeri
            // 
            btnGeri.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGeri.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            btnGeri.Location = new Point(2195, 49);
            btnGeri.Name = "btnGeri";
            btnGeri.Size = new Size(134, 50);
            btnGeri.TabIndex = 5;
            btnGeri.Text = "Geri";
            // 
            // btnSil
            // 
            btnSil.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSil.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            btnSil.Location = new Point(2044, 49);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(134, 50);
            btnSil.TabIndex = 5;
            btnSil.Text = "Sil";
            // 
            // btnIceriAktar
            // 
            btnIceriAktar.Location = new Point(956, 51);
            btnIceriAktar.Name = "btnIceriAktar";
            btnIceriAktar.Size = new Size(269, 50);
            btnIceriAktar.TabIndex = 6;
            btnIceriAktar.Text = "İçeri Aktar";
            btnIceriAktar.UseVisualStyleBackColor = true;
            // 
            // btnDisariAktar
            // 
            btnDisariAktar.Location = new Point(654, 51);
            btnDisariAktar.Name = "btnDisariAktar";
            btnDisariAktar.Size = new Size(269, 50);
            btnDisariAktar.TabIndex = 6;
            btnDisariAktar.Text = "Dışarı Aktar";
            btnDisariAktar.UseVisualStyleBackColor = true;
            // 
            // frmRaporlar
            // 
            AutoScaleDimensions = new SizeF(13f, 32f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2382, 880);
            Controls.Add(btnDisariAktar);
            Controls.Add(btnIceriAktar);
            Controls.Add(cmbProjeler);
            Controls.Add(cmbRaporTurleri);
            Controls.Add(dgvRaporlar);
            Controls.Add(btnYeniRapor);
            Controls.Add(btnDuzenle);
            Controls.Add(btnSil);
            Controls.Add(btnGeri);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "frmRaporlar";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Raporlar";
            ((System.ComponentModel.ISupportInitialize)dgvRaporlar).EndInit();
            Load += new EventHandler(frmRaporlar_Load);
            ResumeLayout(false);
        }

        internal ComboBox cmbProjeler;
        internal ComboBox cmbRaporTurleri;
        internal DataGridView dgvRaporlar;
        internal Button btnYeniRapor;
        internal Button btnDuzenle;
        internal Button btnGeri;
        internal Button btnSil;
        internal Button btnIceriAktar;
        internal Button btnDisariAktar;
    }
}
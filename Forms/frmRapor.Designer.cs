using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EMAR
{
    // frmRapor - EMAR Tasarım Şablonuna Uygun Modern Form
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmRapor : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRapor));
            pnlSidebar = new Panel();
            btnGorseller = new Button();
            btnToggleMenu = new Button();
            btnTemsilci = new Button();
            btnDokuman = new Button();
            btnRevizyon = new Button();
            btnMakine = new Button();
            btnGenel = new Button();
            btnKontrolSistemi = new Button();
            btnRiskler = new Button();
            pnlContent = new Panel();
            btnYazdir = new Button();
            pnlSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(45, 45, 48);
            pnlSidebar.Controls.Add(btnGorseller);
            pnlSidebar.Controls.Add(btnYazdir);
            pnlSidebar.Controls.Add(btnToggleMenu);
            pnlSidebar.Controls.Add(btnTemsilci);
            pnlSidebar.Controls.Add(btnDokuman);
            pnlSidebar.Controls.Add(btnRevizyon);
            pnlSidebar.Controls.Add(btnMakine);
            pnlSidebar.Controls.Add(btnGenel);
            pnlSidebar.Controls.Add(btnKontrolSistemi);
            pnlSidebar.Controls.Add(btnRiskler);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(404, 1201);
            pnlSidebar.TabIndex = 0;
            // 
            // btnGorseller
            // 
            btnGorseller.BackColor = Color.FromArgb(64, 64, 64);
            btnGorseller.FlatAppearance.BorderSize = 0;
            btnGorseller.FlatStyle = FlatStyle.Flat;
            btnGorseller.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGorseller.ForeColor = Color.White;
            btnGorseller.Location = new Point(12, 311);
            btnGorseller.Name = "btnGorseller";
            btnGorseller.Padding = new Padding(15, 0, 0, 0);
            btnGorseller.Size = new Size(381, 77);
            btnGorseller.TabIndex = 6;
            btnGorseller.Text = "Makine Görselleri";
            btnGorseller.TextAlign = ContentAlignment.MiddleLeft;
            btnGorseller.UseVisualStyleBackColor = false;
            btnGorseller.Click += btnGorseller_Click;
            // 
            // btnToggleMenu
            // 
            btnToggleMenu.Location = new Point(10, 1102);
            btnToggleMenu.Name = "btnToggleMenu";
            btnToggleMenu.Size = new Size(381, 87);
            btnToggleMenu.TabIndex = 0;
            btnToggleMenu.Text = "Button1";
            btnToggleMenu.UseVisualStyleBackColor = true;
            btnToggleMenu.Click += btnToggleMenu_Click;
            // 
            // btnTemsilci
            // 
            btnTemsilci.BackColor = Color.FromArgb(64, 64, 64);
            btnTemsilci.FlatAppearance.BorderSize = 0;
            btnTemsilci.FlatStyle = FlatStyle.Flat;
            btnTemsilci.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnTemsilci.ForeColor = Color.White;
            btnTemsilci.Location = new Point(12, 497);
            btnTemsilci.Name = "btnTemsilci";
            btnTemsilci.Padding = new Padding(15, 0, 0, 0);
            btnTemsilci.Size = new Size(381, 77);
            btnTemsilci.TabIndex = 4;
            btnTemsilci.Text = "Temsilciler";
            btnTemsilci.TextAlign = ContentAlignment.MiddleLeft;
            btnTemsilci.UseVisualStyleBackColor = false;
            btnTemsilci.Click += btnTemsilci_Click;
            // 
            // btnDokuman
            // 
            btnDokuman.BackColor = Color.FromArgb(64, 64, 64);
            btnDokuman.FlatAppearance.BorderSize = 0;
            btnDokuman.FlatStyle = FlatStyle.Flat;
            btnDokuman.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDokuman.ForeColor = Color.White;
            btnDokuman.Location = new Point(12, 404);
            btnDokuman.Name = "btnDokuman";
            btnDokuman.Padding = new Padding(15, 0, 0, 0);
            btnDokuman.Size = new Size(381, 77);
            btnDokuman.TabIndex = 3;
            btnDokuman.Text = "İncelenen Dokümanlar";
            btnDokuman.TextAlign = ContentAlignment.MiddleLeft;
            btnDokuman.UseVisualStyleBackColor = false;
            btnDokuman.Click += btnDokuman_Click;
            // 
            // btnRevizyon
            // 
            btnRevizyon.BackColor = Color.FromArgb(64, 64, 64);
            btnRevizyon.FlatAppearance.BorderSize = 0;
            btnRevizyon.FlatStyle = FlatStyle.Flat;
            btnRevizyon.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRevizyon.ForeColor = Color.White;
            btnRevizyon.Location = new Point(12, 218);
            btnRevizyon.Name = "btnRevizyon";
            btnRevizyon.Padding = new Padding(15, 0, 0, 0);
            btnRevizyon.Size = new Size(381, 77);
            btnRevizyon.TabIndex = 2;
            btnRevizyon.Text = "Revizyonlar";
            btnRevizyon.TextAlign = ContentAlignment.MiddleLeft;
            btnRevizyon.UseVisualStyleBackColor = false;
            btnRevizyon.Click += btnRevizyon_Click;
            // 
            // btnMakine
            // 
            btnMakine.BackColor = Color.FromArgb(64, 64, 64);
            btnMakine.FlatAppearance.BorderSize = 0;
            btnMakine.FlatStyle = FlatStyle.Flat;
            btnMakine.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnMakine.ForeColor = Color.White;
            btnMakine.Location = new Point(12, 125);
            btnMakine.Name = "btnMakine";
            btnMakine.Padding = new Padding(15, 0, 0, 0);
            btnMakine.Size = new Size(381, 77);
            btnMakine.TabIndex = 1;
            btnMakine.Text = "Makine Özeti";
            btnMakine.TextAlign = ContentAlignment.MiddleLeft;
            btnMakine.UseVisualStyleBackColor = false;
            btnMakine.Click += btnMakine_Click;
            // 
            // btnGenel
            // 
            btnGenel.BackColor = Color.FromArgb(64, 64, 64);
            btnGenel.FlatAppearance.BorderSize = 0;
            btnGenel.FlatStyle = FlatStyle.Flat;
            btnGenel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGenel.ForeColor = Color.White;
            btnGenel.Location = new Point(12, 32);
            btnGenel.Name = "btnGenel";
            btnGenel.Padding = new Padding(15, 0, 0, 0);
            btnGenel.Size = new Size(381, 77);
            btnGenel.TabIndex = 0;
            btnGenel.Text = "Genel Bilgiler";
            btnGenel.TextAlign = ContentAlignment.MiddleLeft;
            btnGenel.UseVisualStyleBackColor = false;
            btnGenel.Click += btnGenel_Click;
            // 
            // btnKontrolSistemi
            // 
            btnKontrolSistemi.BackColor = Color.FromArgb(64, 64, 64);
            btnKontrolSistemi.FlatAppearance.BorderSize = 0;
            btnKontrolSistemi.FlatStyle = FlatStyle.Flat;
            btnKontrolSistemi.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnKontrolSistemi.ForeColor = Color.White;
            btnKontrolSistemi.Location = new Point(12, 590);
            btnKontrolSistemi.Name = "btnKontrolSistemi";
            btnKontrolSistemi.Padding = new Padding(15, 0, 0, 0);
            btnKontrolSistemi.Size = new Size(381, 77);
            btnKontrolSistemi.TabIndex = 5;
            btnKontrolSistemi.Text = "Kontrol Sistemi";
            btnKontrolSistemi.TextAlign = ContentAlignment.MiddleLeft;
            btnKontrolSistemi.UseVisualStyleBackColor = false;
            btnKontrolSistemi.Click += btnKontrolSistemi_Click;
            // 
            // btnRiskler
            // 
            btnRiskler.BackColor = Color.FromArgb(64, 64, 64);
            btnRiskler.FlatAppearance.BorderSize = 0;
            btnRiskler.FlatStyle = FlatStyle.Flat;
            btnRiskler.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRiskler.ForeColor = Color.White;
            btnRiskler.Location = new Point(12, 683);
            btnRiskler.Name = "btnRiskler";
            btnRiskler.Padding = new Padding(15, 0, 0, 0);
            btnRiskler.Size = new Size(381, 77);
            btnRiskler.TabIndex = 5;
            btnRiskler.Text = "Bölgeler ve Riskler";
            btnRiskler.TextAlign = ContentAlignment.MiddleLeft;
            btnRiskler.UseVisualStyleBackColor = false;
            btnRiskler.Click += btnRiskler_Click;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(250, 250, 250);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(404, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1932, 1201);
            pnlContent.TabIndex = 1;
            // 
            // btnYazdir
            // 
            btnYazdir.Location = new Point(10, 986);
            btnYazdir.Name = "btnYazdir";
            btnYazdir.Size = new Size(381, 87);
            btnYazdir.TabIndex = 0;
            btnYazdir.Text = "Yazdır";
            btnYazdir.UseVisualStyleBackColor = true;
            btnYazdir.Click += btnYazdir_Click;
            // 
            // frmRapor
            // 
            AutoScaleDimensions = new SizeF(18F, 45F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(2336, 1201);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Font = new Font("Segoe UI", 12F);
            ForeColor = Color.FromArgb(30, 30, 30);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmRapor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EMAR - Rapor Düzenleyici";
            Load += frmRapor_Load;
            pnlSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        internal Panel pnlSidebar;
        internal Panel pnlContent;
        internal Button btnGenel;
        internal Button btnMakine;
        internal Button btnRevizyon;
        internal Button btnDokuman;
        internal Button btnTemsilci;
        internal Button btnKontrolSistemi;
        internal Button btnToggleMenu;
        internal Button btnRiskler;
        internal Button btnGorseller;
        internal Button btnYazdir;
    }
}
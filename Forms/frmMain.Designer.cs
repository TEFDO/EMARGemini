using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EMAR
{
    // frmMain - EMAR Temasına Uygun Ana Form
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmMain : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            panelHeader = new Panel();
            PictureBox1 = new PictureBox();
            Label1 = new Label();
            panelSidebar = new Panel();
            btnMusteriler = new Button();
            btnProjeler = new Button();
            btnRaporlar = new Button();
            btnAyarlar = new Button();
            btnVeritabaniSifirla = new Button();
            btnCikis = new Button();
            btnMakineler = new Button();
            panelContent = new Panel();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(37, 37, 38);
            panelHeader.Controls.Add(PictureBox1);
            panelHeader.Controls.Add(Label1);
            resources.ApplyResources(panelHeader, "panelHeader");
            panelHeader.Name = "panelHeader";
            // 
            // PictureBox1
            // 
            resources.ApplyResources(PictureBox1, "PictureBox1");
            PictureBox1.Name = "PictureBox1";
            PictureBox1.TabStop = false;
            // 
            // Label1
            // 
            resources.ApplyResources(Label1, "Label1");
            Label1.ForeColor = Color.White;
            Label1.Name = "Label1";
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(37, 37, 38);
            panelSidebar.Controls.Add(btnMusteriler);
            panelSidebar.Controls.Add(btnProjeler);
            panelSidebar.Controls.Add(btnRaporlar);
            panelSidebar.Controls.Add(btnAyarlar);
            panelSidebar.Controls.Add(btnVeritabaniSifirla);
            panelSidebar.Controls.Add(btnCikis);
            panelSidebar.Controls.Add(btnMakineler);
            resources.ApplyResources(panelSidebar, "panelSidebar");
            panelSidebar.Name = "panelSidebar";
            // 
            // btnMusteriler
            // 
            btnMusteriler.BackColor = Color.FromArgb(63, 63, 70);
            btnMusteriler.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnMusteriler, "btnMusteriler");
            btnMusteriler.ForeColor = Color.White;
            btnMusteriler.Name = "btnMusteriler";
            btnMusteriler.UseVisualStyleBackColor = false;
            btnMusteriler.Click += BtnMusteriler_Click;
            // 
            // btnProjeler
            // 
            btnProjeler.BackColor = Color.FromArgb(63, 63, 70);
            btnProjeler.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnProjeler, "btnProjeler");
            btnProjeler.ForeColor = Color.White;
            btnProjeler.Name = "btnProjeler";
            btnProjeler.UseVisualStyleBackColor = false;
            btnProjeler.Click += BtnProjeler_Click;
            // 
            // btnRaporlar
            // 
            btnRaporlar.BackColor = Color.FromArgb(63, 63, 70);
            btnRaporlar.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnRaporlar, "btnRaporlar");
            btnRaporlar.ForeColor = Color.White;
            btnRaporlar.Name = "btnRaporlar";
            btnRaporlar.UseVisualStyleBackColor = false;
            btnRaporlar.Click += btnRaporlar_Click;
            // 
            // btnAyarlar
            // 
            resources.ApplyResources(btnAyarlar, "btnAyarlar");
            btnAyarlar.BackColor = Color.FromArgb(63, 63, 70);
            btnAyarlar.FlatAppearance.BorderSize = 0;
            btnAyarlar.ForeColor = Color.White;
            btnAyarlar.Name = "btnAyarlar";
            btnAyarlar.UseVisualStyleBackColor = false;
            btnAyarlar.Click += btnAyarlar_Click;
            // 
            // btnVeritabaniSifirla
            // 
            resources.ApplyResources(btnVeritabaniSifirla, "btnVeritabaniSifirla");
            btnVeritabaniSifirla.BackColor = Color.FromArgb(63, 63, 70);
            btnVeritabaniSifirla.FlatAppearance.BorderSize = 0;
            btnVeritabaniSifirla.ForeColor = Color.White;
            btnVeritabaniSifirla.Name = "btnVeritabaniSifirla";
            btnVeritabaniSifirla.UseVisualStyleBackColor = false;
            btnVeritabaniSifirla.Click += btnVeritabaniSifirla_Click;
            // 
            // btnCikis
            // 
            resources.ApplyResources(btnCikis, "btnCikis");
            btnCikis.BackColor = Color.FromArgb(63, 63, 70);
            btnCikis.FlatAppearance.BorderSize = 0;
            btnCikis.ForeColor = Color.White;
            btnCikis.Name = "btnCikis";
            btnCikis.UseVisualStyleBackColor = false;
            btnCikis.Click += btnCikis_Click;
            // 
            // btnMakineler
            // 
            btnMakineler.BackColor = Color.FromArgb(63, 63, 70);
            btnMakineler.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnMakineler, "btnMakineler");
            btnMakineler.ForeColor = Color.White;
            btnMakineler.Name = "btnMakineler";
            btnMakineler.UseVisualStyleBackColor = false;
            btnMakineler.Click += BtnMakineler_Click;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            resources.ApplyResources(panelContent, "panelContent");
            panelContent.Name = "panelContent";
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelContent);
            Controls.Add(panelSidebar);
            Controls.Add(panelHeader);
            Name = "frmMain";
            WindowState = FormWindowState.Maximized;
            Load += FrmMain_Load;
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            panelSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        internal Panel panelHeader;
        internal Panel panelSidebar;
        internal Button btnMusteriler;
        internal Button btnProjeler;
        internal Button btnMakineler;
        internal Button btnRaporlar;
        internal Button btnAyarlar;
        internal Button btnVeritabaniSifirla;
        internal Button btnCikis;
        internal Panel panelContent;
        internal PictureBox PictureBox1;
        internal Label Label1;
    }
}
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EMAR.UControls
{
    partial class ucGenelBilgilendirme
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlMain = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            grpTehlike = new GroupBox();
            tableLayoutPanel6 = new TableLayoutPanel();
            picPiktogram = new PictureBox();
            cmbTehlikeHedefi = new ComboBox();
            cmbTehlikeTipi = new ComboBox();
            cmbGorevAsamasi = new ComboBox();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            grpAciklama = new GroupBox();
            ucTextEditor1 = new EMAR.UControls.Buton.ucTextEditor();
            btnPicSil = new Button();
            btnGorselSil = new Button();
            grpKullanicilar = new GroupBox();
            tableLayoutPanel7 = new TableLayoutPanel();
            chkBakim = new CheckBox();
            chkTemizlik = new CheckBox();
            chkOperator = new CheckBox();
            chkZiyaretci = new CheckBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            lblPLg = new Label();
            contextMenuPLg = new ContextMenuStrip(components);
            düzenleToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutPanel5 = new TableLayoutPanel();
            label10 = new Label();
            lblRiskSkoru = new Label();
            label12 = new Label();
            lblSeviye = new Label();
            label11 = new Label();
            lblTehlikeNo = new Label();
            groupBox1 = new GroupBox();
            picGorsel = new PictureBox();
            grpPLg = new GroupBox();
            txtPLg = new TextBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            cmbS = new ComboBox();
            cmbP = new ComboBox();
            cmbF = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            grpHRN = new GroupBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            cmbDPH = new ComboBox();
            cmbFE = new ComboBox();
            cmbPA = new ComboBox();
            cmbLO = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            pnlMain.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            grpTehlike.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPiktogram).BeginInit();
            grpAciklama.SuspendLayout();
            grpKullanicilar.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            contextMenuPLg.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picGorsel).BeginInit();
            grpPLg.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            grpHRN.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.AutoScroll = true;
            pnlMain.Controls.Add(tableLayoutPanel1);
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1676, 1859);
            pnlMain.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48.58934F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 51.41066F));
            tableLayoutPanel1.Controls.Add(grpTehlike, 0, 1);
            tableLayoutPanel1.Controls.Add(grpAciklama, 0, 7);
            tableLayoutPanel1.Controls.Add(btnPicSil, 0, 9);
            tableLayoutPanel1.Controls.Add(btnGorselSil, 1, 9);
            tableLayoutPanel1.Controls.Add(grpKullanicilar, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 3);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel5, 1, 3);
            tableLayoutPanel1.Controls.Add(label11, 0, 0);
            tableLayoutPanel1.Controls.Add(lblTehlikeNo, 1, 0);
            tableLayoutPanel1.Controls.Add(groupBox1, 1, 1);
            tableLayoutPanel1.Controls.Add(grpPLg, 0, 4);
            tableLayoutPanel1.Controls.Add(grpHRN, 0, 5);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 11;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 402F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 225F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 230F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 230F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 400F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tableLayoutPanel1.Size = new Size(1642, 1856);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // grpTehlike
            // 
            grpTehlike.Controls.Add(tableLayoutPanel6);
            grpTehlike.Dock = DockStyle.Fill;
            grpTehlike.Location = new Point(3, 59);
            grpTehlike.Name = "grpTehlike";
            grpTehlike.Padding = new Padding(10);
            grpTehlike.Size = new Size(791, 396);
            grpTehlike.TabIndex = 0;
            grpTehlike.TabStop = false;
            grpTehlike.Text = "Tehlike Bilgileri";
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 3;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33555F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3322258F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3322258F));
            tableLayoutPanel6.Controls.Add(picPiktogram, 0, 0);
            tableLayoutPanel6.Controls.Add(cmbTehlikeHedefi, 1, 3);
            tableLayoutPanel6.Controls.Add(cmbTehlikeTipi, 1, 1);
            tableLayoutPanel6.Controls.Add(cmbGorevAsamasi, 1, 2);
            tableLayoutPanel6.Controls.Add(label14, 1, 0);
            tableLayoutPanel6.Controls.Add(label15, 0, 2);
            tableLayoutPanel6.Controls.Add(label16, 0, 3);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(10, 42);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 4;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 66.66667F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel6.Size = new Size(771, 344);
            tableLayoutPanel6.TabIndex = 4;
            // 
            // picPiktogram
            // 
            picPiktogram.BackgroundImageLayout = ImageLayout.Zoom;
            picPiktogram.BorderStyle = BorderStyle.FixedSingle;
            picPiktogram.Dock = DockStyle.Fill;
            picPiktogram.Location = new Point(3, 3);
            picPiktogram.Name = "picPiktogram";
            tableLayoutPanel6.SetRowSpan(picPiktogram, 2);
            picPiktogram.Size = new Size(251, 247);
            picPiktogram.SizeMode = PictureBoxSizeMode.Zoom;
            picPiktogram.TabIndex = 0;
            picPiktogram.TabStop = false;
            // 
            // cmbTehlikeHedefi
            // 
            tableLayoutPanel6.SetColumnSpan(cmbTehlikeHedefi, 2);
            cmbTehlikeHedefi.Dock = DockStyle.Fill;
            cmbTehlikeHedefi.Location = new Point(260, 301);
            cmbTehlikeHedefi.Name = "cmbTehlikeHedefi";
            cmbTehlikeHedefi.Size = new Size(508, 40);
            cmbTehlikeHedefi.TabIndex = 2;
            // 
            // cmbTehlikeTipi
            // 
            tableLayoutPanel6.SetColumnSpan(cmbTehlikeTipi, 2);
            cmbTehlikeTipi.Dock = DockStyle.Fill;
            cmbTehlikeTipi.Location = new Point(260, 87);
            cmbTehlikeTipi.Name = "cmbTehlikeTipi";
            cmbTehlikeTipi.Size = new Size(508, 40);
            cmbTehlikeTipi.TabIndex = 0;
            // 
            // cmbGorevAsamasi
            // 
            tableLayoutPanel6.SetColumnSpan(cmbGorevAsamasi, 2);
            cmbGorevAsamasi.Dock = DockStyle.Fill;
            cmbGorevAsamasi.Location = new Point(260, 256);
            cmbGorevAsamasi.Name = "cmbGorevAsamasi";
            cmbGorevAsamasi.Size = new Size(508, 40);
            cmbGorevAsamasi.TabIndex = 1;
            // 
            // label14
            // 
            label14.AutoSize = true;
            tableLayoutPanel6.SetColumnSpan(label14, 2);
            label14.Dock = DockStyle.Fill;
            label14.Location = new Point(260, 0);
            label14.Name = "label14";
            label14.Size = new Size(508, 84);
            label14.TabIndex = 3;
            label14.Text = "Tehlike Tipi";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Dock = DockStyle.Fill;
            label15.Location = new Point(3, 253);
            label15.Name = "label15";
            label15.Size = new Size(251, 45);
            label15.TabIndex = 4;
            label15.Text = "Görev Aşaması";
            label15.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Dock = DockStyle.Fill;
            label16.Location = new Point(3, 298);
            label16.Name = "label16";
            label16.Size = new Size(251, 46);
            label16.TabIndex = 5;
            label16.Text = "Tehlike Hedefi";
            label16.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpAciklama
            // 
            tableLayoutPanel1.SetColumnSpan(grpAciklama, 2);
            grpAciklama.Controls.Add(ucTextEditor1);
            grpAciklama.Dock = DockStyle.Fill;
            grpAciklama.Location = new Point(3, 1316);
            grpAciklama.Name = "grpAciklama";
            grpAciklama.Size = new Size(1636, 394);
            grpAciklama.TabIndex = 4;
            grpAciklama.TabStop = false;
            grpAciklama.Text = "Tehlike Açıklaması";
            // 
            // ucTextEditor1
            // 
            ucTextEditor1.Alan = null;
            ucTextEditor1.BagliId = 0;
            ucTextEditor1.DbYolu = null;
            ucTextEditor1.Dock = DockStyle.Fill;
            ucTextEditor1.Location = new Point(3, 35);
            ucTextEditor1.Name = "ucTextEditor1";
            ucTextEditor1.RtfText = "{\\rtf1\\ansi\\ansicpg1254\\deff0\\nouicompat\\deflang1055{\\fonttbl{\\f0\\fnil\\fcharset162 Segoe UI;}}\r\n{\\*\\generator Riched20 10.0.26100}\\viewkind4\\uc1 \r\n\\pard\\f0\\fs18\\par\r\n}\r\n";
            ucTextEditor1.Size = new Size(1630, 356);
            ucTextEditor1.TabIndex = 0;
            // 
            // btnPicSil
            // 
            btnPicSil.Dock = DockStyle.Fill;
            btnPicSil.Location = new Point(3, 1766);
            btnPicSil.Name = "btnPicSil";
            btnPicSil.Size = new Size(791, 54);
            btnPicSil.TabIndex = 6;
            btnPicSil.Text = "Piktogram Sil";
            btnPicSil.Click += BtnPiktogramSil_Click;
            // 
            // btnGorselSil
            // 
            btnGorselSil.Dock = DockStyle.Fill;
            btnGorselSil.Location = new Point(800, 1766);
            btnGorselSil.Name = "btnGorselSil";
            btnGorselSil.Size = new Size(839, 54);
            btnGorselSil.TabIndex = 7;
            btnGorselSil.Text = "Görseli Sil";
            btnGorselSil.Click += BtnGorselSil_Click;
            // 
            // grpKullanicilar
            // 
            grpKullanicilar.Controls.Add(tableLayoutPanel7);
            grpKullanicilar.Dock = DockStyle.Fill;
            grpKullanicilar.Location = new Point(3, 461);
            grpKullanicilar.Name = "grpKullanicilar";
            grpKullanicilar.Padding = new Padding(10);
            grpKullanicilar.Size = new Size(791, 219);
            grpKullanicilar.TabIndex = 1;
            grpKullanicilar.TabStop = false;
            grpKullanicilar.Text = "Etkilenebilecek Kullanıcılar";
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Controls.Add(chkBakim, 0, 0);
            tableLayoutPanel7.Controls.Add(chkTemizlik, 0, 1);
            tableLayoutPanel7.Controls.Add(chkOperator, 1, 0);
            tableLayoutPanel7.Controls.Add(chkZiyaretci, 1, 1);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(10, 42);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 2;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new Size(771, 167);
            tableLayoutPanel7.TabIndex = 4;
            // 
            // chkBakim
            // 
            chkBakim.Dock = DockStyle.Fill;
            chkBakim.Location = new Point(3, 3);
            chkBakim.Name = "chkBakim";
            chkBakim.Size = new Size(379, 77);
            chkBakim.TabIndex = 1;
            chkBakim.Text = "Bakım Görevlisi";
            // 
            // chkTemizlik
            // 
            chkTemizlik.Dock = DockStyle.Fill;
            chkTemizlik.Location = new Point(3, 86);
            chkTemizlik.Name = "chkTemizlik";
            chkTemizlik.Size = new Size(379, 78);
            chkTemizlik.TabIndex = 2;
            chkTemizlik.Text = "Temizlik Görevlisi";
            // 
            // chkOperator
            // 
            chkOperator.Dock = DockStyle.Fill;
            chkOperator.Location = new Point(388, 3);
            chkOperator.Name = "chkOperator";
            chkOperator.Size = new Size(380, 77);
            chkOperator.TabIndex = 0;
            chkOperator.Text = "Operatör";
            // 
            // chkZiyaretci
            // 
            chkZiyaretci.Dock = DockStyle.Fill;
            chkZiyaretci.Location = new Point(388, 86);
            chkZiyaretci.Name = "chkZiyaretci";
            chkZiyaretci.Size = new Size(380, 78);
            chkZiyaretci.TabIndex = 3;
            chkZiyaretci.Text = "Ziyaretçi";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(lblPLg, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 686);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(791, 114);
            tableLayoutPanel2.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(666, 114);
            label1.TabIndex = 0;
            label1.Text = "EN ISO 13849-1'e Göre Ulaşılması Gereken Performans Seviyesi (PLg)";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPLg
            // 
            lblPLg.AutoSize = true;
            lblPLg.ContextMenuStrip = contextMenuPLg;
            lblPLg.Dock = DockStyle.Fill;
            lblPLg.Location = new Point(675, 0);
            lblPLg.Name = "lblPLg";
            lblPLg.Size = new Size(113, 114);
            lblPLg.TabIndex = 1;
            lblPLg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contextMenuPLg
            // 
            contextMenuPLg.ImageScalingSize = new Size(32, 32);
            contextMenuPLg.Items.AddRange(new ToolStripItem[] { düzenleToolStripMenuItem });
            contextMenuPLg.Name = "contextMenuPLg";
            contextMenuPLg.Size = new Size(177, 42);
            // 
            // düzenleToolStripMenuItem
            // 
            düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            düzenleToolStripMenuItem.Size = new Size(176, 38);
            düzenleToolStripMenuItem.Text = "Düzenle";
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 4;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.Controls.Add(label10, 0, 0);
            tableLayoutPanel5.Controls.Add(lblRiskSkoru, 1, 0);
            tableLayoutPanel5.Controls.Add(label12, 2, 0);
            tableLayoutPanel5.Controls.Add(lblSeviye, 3, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(800, 686);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Size = new Size(839, 114);
            tableLayoutPanel5.TabIndex = 9;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = DockStyle.Fill;
            label10.Location = new Point(3, 0);
            label10.Name = "label10";
            label10.Size = new Size(203, 114);
            label10.TabIndex = 0;
            label10.Text = "Risk Skoru:";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRiskSkoru
            // 
            lblRiskSkoru.AutoSize = true;
            lblRiskSkoru.Dock = DockStyle.Fill;
            lblRiskSkoru.Location = new Point(212, 0);
            lblRiskSkoru.Name = "lblRiskSkoru";
            lblRiskSkoru.Size = new Size(203, 114);
            lblRiskSkoru.TabIndex = 0;
            lblRiskSkoru.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Dock = DockStyle.Fill;
            label12.Location = new Point(421, 0);
            label12.Name = "label12";
            label12.Size = new Size(203, 114);
            label12.TabIndex = 0;
            label12.Text = "Seviye:";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSeviye
            // 
            lblSeviye.AutoSize = true;
            lblSeviye.Dock = DockStyle.Fill;
            lblSeviye.Location = new Point(630, 0);
            lblSeviye.Name = "lblSeviye";
            lblSeviye.Size = new Size(206, 114);
            lblSeviye.TabIndex = 0;
            lblSeviye.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Dock = DockStyle.Fill;
            label11.Location = new Point(3, 0);
            label11.Name = "label11";
            label11.Size = new Size(791, 56);
            label11.TabIndex = 10;
            label11.Text = "Tehlike Tanımlama";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTehlikeNo
            // 
            lblTehlikeNo.AutoSize = true;
            lblTehlikeNo.Dock = DockStyle.Fill;
            lblTehlikeNo.Location = new Point(800, 0);
            lblTehlikeNo.Name = "lblTehlikeNo";
            lblTehlikeNo.Size = new Size(839, 56);
            lblTehlikeNo.TabIndex = 11;
            lblTehlikeNo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(picGorsel);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(800, 59);
            groupBox1.Name = "groupBox1";
            tableLayoutPanel1.SetRowSpan(groupBox1, 2);
            groupBox1.Size = new Size(839, 621);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tehlike Görseli";
            // 
            // picGorsel
            // 
            picGorsel.Dock = DockStyle.Fill;
            picGorsel.Location = new Point(3, 35);
            picGorsel.Name = "picGorsel";
            picGorsel.Size = new Size(833, 583);
            picGorsel.SizeMode = PictureBoxSizeMode.Zoom;
            picGorsel.TabIndex = 5;
            picGorsel.TabStop = false;
            // 
            // grpPLg
            // 
            tableLayoutPanel1.SetColumnSpan(grpPLg, 2);
            grpPLg.Controls.Add(txtPLg);
            grpPLg.Controls.Add(tableLayoutPanel4);
            grpPLg.Dock = DockStyle.Fill;
            grpPLg.Location = new Point(3, 806);
            grpPLg.Name = "grpPLg";
            grpPLg.Padding = new Padding(10);
            grpPLg.Size = new Size(1636, 224);
            grpPLg.TabIndex = 2;
            grpPLg.TabStop = false;
            grpPLg.Text = "PLg Parametreleri";
            // 
            // txtPLg
            // 
            txtPLg.Location = new Point(631, 0);
            txtPLg.Name = "txtPLg";
            txtPLg.Size = new Size(200, 39);
            txtPLg.TabIndex = 4;
            txtPLg.Visible = false;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel4.Controls.Add(cmbS, 0, 1);
            tableLayoutPanel4.Controls.Add(cmbP, 2, 1);
            tableLayoutPanel4.Controls.Add(cmbF, 1, 1);
            tableLayoutPanel4.Controls.Add(label2, 0, 0);
            tableLayoutPanel4.Controls.Add(label3, 1, 0);
            tableLayoutPanel4.Controls.Add(label4, 2, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(10, 42);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel4.Size = new Size(1616, 172);
            tableLayoutPanel4.TabIndex = 3;
            // 
            // cmbS
            // 
            cmbS.Dock = DockStyle.Fill;
            cmbS.Location = new Point(3, 123);
            cmbS.Name = "cmbS";
            cmbS.Size = new Size(532, 40);
            cmbS.TabIndex = 1;
            // 
            // cmbP
            // 
            cmbP.Dock = DockStyle.Fill;
            cmbP.Location = new Point(1079, 123);
            cmbP.Name = "cmbP";
            cmbP.Size = new Size(534, 40);
            cmbP.TabIndex = 2;
            // 
            // cmbF
            // 
            cmbF.Dock = DockStyle.Fill;
            cmbF.Location = new Point(541, 123);
            cmbF.Name = "cmbF";
            cmbF.Size = new Size(532, 40);
            cmbF.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(532, 120);
            label2.TabIndex = 3;
            label2.Text = "Yaralanmanın Şiddeti";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(541, 0);
            label3.Name = "label3";
            label3.Size = new Size(532, 120);
            label3.TabIndex = 3;
            label3.Text = "Tehlikeye Maruz Kalma Sıklığı";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(1079, 0);
            label4.Name = "label4";
            label4.Size = new Size(534, 120);
            label4.TabIndex = 3;
            label4.Text = "Tehlikeden Kaçınma İhtimali";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpHRN
            // 
            tableLayoutPanel1.SetColumnSpan(grpHRN, 2);
            grpHRN.Controls.Add(tableLayoutPanel3);
            grpHRN.Dock = DockStyle.Fill;
            grpHRN.Location = new Point(3, 1036);
            grpHRN.Name = "grpHRN";
            grpHRN.Padding = new Padding(10);
            grpHRN.Size = new Size(1636, 224);
            grpHRN.TabIndex = 3;
            grpHRN.TabStop = false;
            grpHRN.Text = "HRN Parametreleri";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 4;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.4777222F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.6089115F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.2277222F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.6237621F));
            tableLayoutPanel3.Controls.Add(cmbDPH, 0, 1);
            tableLayoutPanel3.Controls.Add(cmbFE, 3, 1);
            tableLayoutPanel3.Controls.Add(cmbPA, 2, 1);
            tableLayoutPanel3.Controls.Add(cmbLO, 1, 1);
            tableLayoutPanel3.Controls.Add(label5, 0, 0);
            tableLayoutPanel3.Controls.Add(label6, 1, 0);
            tableLayoutPanel3.Controls.Add(label7, 2, 0);
            tableLayoutPanel3.Controls.Add(label8, 3, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(10, 42);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel3.Size = new Size(1616, 172);
            tableLayoutPanel3.TabIndex = 5;
            // 
            // cmbDPH
            // 
            cmbDPH.Dock = DockStyle.Fill;
            cmbDPH.DropDownWidth = 700;
            cmbDPH.Location = new Point(3, 123);
            cmbDPH.Name = "cmbDPH";
            cmbDPH.Size = new Size(535, 40);
            cmbDPH.TabIndex = 3;
            // 
            // cmbFE
            // 
            cmbFE.Dock = DockStyle.Fill;
            cmbFE.Location = new Point(1414, 123);
            cmbFE.Name = "cmbFE";
            cmbFE.Size = new Size(199, 40);
            cmbFE.TabIndex = 2;
            // 
            // cmbPA
            // 
            cmbPA.Dock = DockStyle.Fill;
            cmbPA.Location = new Point(974, 123);
            cmbPA.Name = "cmbPA";
            cmbPA.Size = new Size(434, 40);
            cmbPA.TabIndex = 1;
            // 
            // cmbLO
            // 
            cmbLO.Dock = DockStyle.Fill;
            cmbLO.Location = new Point(544, 123);
            cmbLO.Name = "cmbLO";
            cmbLO.Size = new Size(424, 40);
            cmbLO.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(535, 120);
            label5.TabIndex = 3;
            label5.Text = "OLASI HASAR DERECESİ";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(544, 0);
            label6.Name = "label6";
            label6.Size = new Size(424, 120);
            label6.TabIndex = 3;
            label6.Text = "KAZA OLMA OLASILIĞI";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(974, 0);
            label7.Name = "label7";
            label7.Size = new Size(434, 120);
            label7.TabIndex = 3;
            label7.Text = "KAÇINMA OLASILIĞI";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Location = new Point(1414, 0);
            label8.Name = "label8";
            label8.Size = new Size(199, 120);
            label8.TabIndex = 3;
            label8.Text = "MARUZ KALMA SIKLIĞI";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ucGenelBilgilendirme
            // 
            AutoScroll = true;
            Controls.Add(pnlMain);
            Name = "ucGenelBilgilendirme";
            Size = new Size(1709, 1914);
            pnlMain.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            grpTehlike.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPiktogram).EndInit();
            grpAciklama.ResumeLayout(false);
            grpKullanicilar.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            contextMenuPLg.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picGorsel).EndInit();
            grpPLg.ResumeLayout(false);
            grpPLg.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            grpHRN.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox cmbTehlikeTipi;
        private ComboBox cmbGorevAsamasi;
        private ComboBox cmbTehlikeHedefi;

        private GroupBox grpKullanicilar;
        private CheckBox chkOperator;
        private CheckBox chkBakim;
        private CheckBox chkTemizlik;
        private CheckBox chkZiyaretci;

        private GroupBox grpPLg;
        private ComboBox cmbF;
        private ComboBox cmbS;
        private ComboBox cmbP;

        private GroupBox grpHRN;
        private ComboBox cmbLO;
        private ComboBox cmbPA;
        private ComboBox cmbFE;
        private ComboBox cmbDPH;
        

        private GroupBox grpAciklama;

        private PictureBox picGorsel;
        private Button btnPicSil;
        private Button btnGorselSil;
        private GroupBox grpTehlike;
        private PictureBox picPiktogram;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label lblPLg;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label10;
        private Label lblRiskSkoru;
        private Label label12;
        private Label lblSeviye;
        private TableLayoutPanel tableLayoutPanel6;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label11;
        private Label lblTehlikeNo;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel7;
        private Buton.ucTextEditor ucTextEditor1;
        private TextBox txtPLg;
        private ContextMenuStrip contextMenuPLg;
        private ToolStripMenuItem düzenleToolStripMenuItem;
    }
}
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EMAR
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmMakineler : Form
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMakineler));
            lblFiltre = new Label();
            cmbProjeler = new ComboBox();
            dgvMakineler = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Ad = new DataGridViewTextBoxColumn();
            MusteriAd = new DataGridViewTextBoxColumn();
            Tipi = new DataGridViewTextBoxColumn();
            SeriNo = new DataGridViewTextBoxColumn();
            btnEkle = new Button();
            btnDuzenle = new Button();
            btnSil = new Button();
            btnMakineLimitleri = new Button();
            btnGeri = new Button();
            MusteriBindingSource = new BindingSource(components);
            btnKopyala = new Button();
            txtArama = new TextBox();
            btnAra = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMakineler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MusteriBindingSource).BeginInit();
            SuspendLayout();
            // 
            // lblFiltre
            // 
            lblFiltre.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFiltre.AutoSize = true;
            lblFiltre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFiltre.Location = new Point(1396, 390);
            lblFiltre.Name = "lblFiltre";
            lblFiltre.Size = new Size(288, 37);
            lblFiltre.TabIndex = 6;
            lblFiltre.Text = "Projeye Göre Filtrele:";
            // 
            // cmbProjeler
            // 
            cmbProjeler.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbProjeler.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProjeler.Font = new Font("Segoe UI", 10F);
            cmbProjeler.Location = new Point(1390, 446);
            cmbProjeler.Name = "cmbProjeler";
            cmbProjeler.Size = new Size(300, 45);
            cmbProjeler.TabIndex = 7;
            cmbProjeler.SelectedIndexChanged += cmbProjeler_SelectedIndexChanged;
            // 
            // dgvMakineler
            // 
            dgvMakineler.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMakineler.BackgroundColor = SystemColors.Window;
            dgvMakineler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMakineler.Columns.AddRange(new DataGridViewColumn[] { Id, Ad, MusteriAd, Tipi, SeriNo });
            dgvMakineler.Location = new Point(39, 38);
            dgvMakineler.Margin = new Padding(4);
            dgvMakineler.Name = "dgvMakineler";
            dgvMakineler.RowHeadersWidth = 82;
            dgvMakineler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMakineler.Size = new Size(1300, 896);
            dgvMakineler.TabIndex = 0;
            dgvMakineler.CellContentClick += dgvMakineler_CellContentClick;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.MinimumWidth = 10;
            Id.Name = "Id";
            Id.Visible = false;
            Id.Width = 50;
            // 
            // Ad
            // 
            Ad.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Ad.FillWeight = 50F;
            Ad.HeaderText = "Ad";
            Ad.MinimumWidth = 10;
            Ad.Name = "Ad";
            // 
            // MusteriAd
            // 
            MusteriAd.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            MusteriAd.FillWeight = 40F;
            MusteriAd.HeaderText = "Müşteri Adı";
            MusteriAd.MinimumWidth = 10;
            MusteriAd.Name = "MusteriAd";
            // 
            // Tipi
            // 
            Tipi.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Tipi.FillWeight = 20F;
            Tipi.HeaderText = "Tipi";
            Tipi.MinimumWidth = 10;
            Tipi.Name = "Tipi";
            // 
            // SeriNo
            // 
            SeriNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            SeriNo.FillWeight = 30F;
            SeriNo.HeaderText = "Seri No";
            SeriNo.MinimumWidth = 10;
            SeriNo.Name = "SeriNo";
            // 
            // btnEkle
            // 
            btnEkle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEkle.Location = new Point(1378, 64);
            btnEkle.Margin = new Padding(4);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(325, 77);
            btnEkle.TabIndex = 1;
            btnEkle.Text = "Yeni Makine Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnDuzenle
            // 
            btnDuzenle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDuzenle.Location = new Point(1378, 166);
            btnDuzenle.Margin = new Padding(4);
            btnDuzenle.Name = "btnDuzenle";
            btnDuzenle.Size = new Size(325, 77);
            btnDuzenle.TabIndex = 2;
            btnDuzenle.Text = "Makineyi Düzenle";
            btnDuzenle.UseVisualStyleBackColor = true;
            btnDuzenle.Click += btnDuzenle_Click;
            // 
            // btnSil
            // 
            btnSil.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSil.Location = new Point(1378, 269);
            btnSil.Margin = new Padding(4);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(325, 77);
            btnSil.TabIndex = 3;
            btnSil.Text = "Makineyi Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnMakineLimitleri
            // 
            btnMakineLimitleri.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnMakineLimitleri.Location = new Point(1378, 781);
            btnMakineLimitleri.Margin = new Padding(4);
            btnMakineLimitleri.Name = "btnMakineLimitleri";
            btnMakineLimitleri.Size = new Size(325, 77);
            btnMakineLimitleri.TabIndex = 4;
            btnMakineLimitleri.Text = "Makine Limitleri";
            btnMakineLimitleri.UseVisualStyleBackColor = true;
            btnMakineLimitleri.Click += btnMakineLimitleri_Click;
            // 
            // btnGeri
            // 
            btnGeri.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGeri.Location = new Point(1378, 883);
            btnGeri.Margin = new Padding(4);
            btnGeri.Name = "btnGeri";
            btnGeri.Size = new Size(325, 77);
            btnGeri.TabIndex = 5;
            btnGeri.Text = "GERİ";
            btnGeri.UseVisualStyleBackColor = true;
            btnGeri.Click += btnGeri_Click;
            // 
            // btnKopyala
            // 
            btnKopyala.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnKopyala.Location = new Point(1378, 669);
            btnKopyala.Margin = new Padding(4);
            btnKopyala.Name = "btnKopyala";
            btnKopyala.Size = new Size(325, 77);
            btnKopyala.TabIndex = 4;
            btnKopyala.Text = "KOPYALA";
            btnKopyala.UseVisualStyleBackColor = true;
            btnKopyala.Click += btnKopyala_Click;
            // 
            // txtArama
            // 
            txtArama.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtArama.Location = new Point(1402, 512);
            txtArama.Name = "txtArama";
            txtArama.PlaceholderText = "Makine adı veya seri no";
            txtArama.Size = new Size(288, 39);
            txtArama.TabIndex = 8;
            txtArama.KeyDown += txtArama_KeyDown;
            // 
            // btnAra
            // 
            btnAra.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAra.Location = new Point(1471, 573);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(150, 46);
            btnAra.TabIndex = 9;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = true;
            btnAra.Click += btnAra_Click;
            // 
            // frmMakineler
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(1755, 1024);
            Controls.Add(btnAra);
            Controls.Add(txtArama);
            Controls.Add(dgvMakineler);
            Controls.Add(btnEkle);
            Controls.Add(btnDuzenle);
            Controls.Add(btnSil);
            Controls.Add(btnKopyala);
            Controls.Add(btnMakineLimitleri);
            Controls.Add(btnGeri);
            Controls.Add(lblFiltre);
            Controls.Add(cmbProjeler);
            ForeColor = SystemColors.ControlText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "frmMakineler";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Makine Listesi";
            Load += frmMakineler_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMakineler).EndInit();
            ((System.ComponentModel.ISupportInitialize)MusteriBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        internal DataGridView dgvMakineler;
        internal Button btnEkle;
        internal Button btnDuzenle;
        internal Button btnSil;
        internal Button btnMakineLimitleri;
        internal Button btnGeri;
        internal BindingSource MusteriBindingSource;
        internal DataGridViewTextBoxColumn Id;
        internal DataGridViewTextBoxColumn Ad;
        internal DataGridViewTextBoxColumn MusteriAd;
        internal DataGridViewTextBoxColumn Tipi;
        internal DataGridViewTextBoxColumn SeriNo;
        internal ComboBox cmbProjeler;
        internal Label lblFiltre;
        internal Button btnKopyala;
        private TextBox txtArama;
        private Button btnAra;
    }
}
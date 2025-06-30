using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EMAR.UControls
{
    public partial class ucRevizyon : UserControl
    {
        private System.ComponentModel.IContainer components;

        internal Panel Panel1;
        internal DataGridView dgvRevizyonlar;
        internal Button btnSil;
        internal Button btnDuzenle;
        internal Button btnEkle;
        internal Button btnKaydet;

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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.Panel1 = new System.Windows.Forms.Panel();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.dgvRevizyonlar = new System.Windows.Forms.DataGridView();

            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevizyonlar)).BeginInit();
            this.SuspendLayout();

            // 
            // Panel1
            // 
            this.Panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            this.Panel1.BackColor = Color.FromArgb(240, 240, 240);
            this.Panel1.Controls.Add(this.btnEkle);
            this.Panel1.Controls.Add(this.btnDuzenle);
            this.Panel1.Controls.Add(this.btnSil);
            this.Panel1.Controls.Add(this.btnKaydet);
            this.Panel1.Location = new Point(1174, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new Size(280, 766);
            this.Panel1.TabIndex = 0;

            // 
            // btnEkle
            // 
            this.btnEkle.FlatStyle = FlatStyle.Flat;
            this.btnEkle.Location = new Point(39, 88);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new Size(199, 63);
            this.btnEkle.TabIndex = 0;
            this.btnEkle.Text = "➕ Ekle";
            this.btnEkle.Click += new EventHandler(this.btnEkle_Click);

            // 
            // btnDuzenle
            // 
            this.btnDuzenle.FlatStyle = FlatStyle.Flat;
            this.btnDuzenle.Location = new Point(39, 188);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new Size(199, 63);
            this.btnDuzenle.TabIndex = 1;
            this.btnDuzenle.Text = "✏️ Düzenle";
            this.btnDuzenle.Click += new EventHandler(this.btnDuzenle_Click);

            // 
            // btnSil
            // 
            this.btnSil.FlatStyle = FlatStyle.Flat;
            this.btnSil.Location = new Point(39, 288);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new Size(199, 63);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "🗑️ Sil";
            this.btnSil.Click += new EventHandler(this.btnSil_Click);

            // 
            // btnKaydet
            // 
            this.btnKaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnKaydet.FlatStyle = FlatStyle.Flat;
            this.btnKaydet.Location = new Point(39, 640);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new Size(199, 63);
            this.btnKaydet.TabIndex = 3;
            this.btnKaydet.Text = "💾 Kaydet";
            this.btnKaydet.Click += new EventHandler(this.btnKaydet_Click);

            // 
            // dgvRevizyonlar
            // 
            this.dgvRevizyonlar.AllowUserToAddRows = false;
            this.dgvRevizyonlar.AllowUserToDeleteRows = false;
            this.dgvRevizyonlar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvRevizyonlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRevizyonlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRevizyonlar.Location = new Point(40, 40);
            this.dgvRevizyonlar.MultiSelect = false;
            this.dgvRevizyonlar.Name = "dgvRevizyonlar";
            this.dgvRevizyonlar.RowHeadersVisible = false;
            this.dgvRevizyonlar.RowHeadersWidth = 82;
            this.dgvRevizyonlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvRevizyonlar.Size = new Size(1095, 680);
            this.dgvRevizyonlar.TabIndex = 0;

            // 
            // ucRevizyon
            // 
            this.AutoScaleDimensions = new SizeF(13F, 32F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.dgvRevizyonlar);
            this.Controls.Add(this.Panel1);
            this.Name = "ucRevizyon";
            this.Size = new Size(1480, 766);
            this.Load += new EventHandler(this.ucRevizyon_Load);

            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevizyonlar)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

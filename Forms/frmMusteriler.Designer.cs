using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EMAR
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmMusteriler : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMusteriler));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvMusteriler = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colAd = new DataGridViewTextBoxColumn();
            colAdres = new DataGridViewTextBoxColumn();
            btnEkle = new Button();
            btnDuzenle = new Button();
            btnSil = new Button();
            btnYazdir = new Button();
            btnGeri = new Button();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvMusteriler).BeginInit();
            SuspendLayout();
            // 
            // dgvMusteriler
            // 
            dgvMusteriler.AllowUserToAddRows = false;
            dgvMusteriler.AllowUserToDeleteRows = false;
            resources.ApplyResources(dgvMusteriler, "dgvMusteriler");
            dgvMusteriler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMusteriler.BackgroundColor = SystemColors.Control;
            dgvMusteriler.BorderStyle = BorderStyle.None;
            dgvMusteriler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMusteriler.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            dgvMusteriler.MultiSelect = false;
            dgvMusteriler.Name = "dgvMusteriler";
            dgvMusteriler.ReadOnly = true;
            dgvMusteriler.RowHeadersVisible = false;
            dgvMusteriler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMusteriler.CellContentClick += dgvMusteriler_CellContentClick;
            // 
            // colId
            // 
            colId.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.BackColor = Color.Red;
            colId.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(colId, "colId");
            colId.Name = "colId";
            // 
            // colAd
            // 
            colAd.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.BackColor = Color.White;
            colAd.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(colAd, "colAd");
            colAd.Name = "colAd";
            // 
            // colAdres
            // 
            colAdres.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(colAdres, "colAdres");
            colAdres.Name = "colAdres";
            // 
            // btnEkle
            // 
            resources.ApplyResources(btnEkle, "btnEkle");
            btnEkle.Name = "btnEkle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnDuzenle
            // 
            resources.ApplyResources(btnDuzenle, "btnDuzenle");
            btnDuzenle.Name = "btnDuzenle";
            btnDuzenle.UseVisualStyleBackColor = true;
            btnDuzenle.Click += btnDuzenle_Click;
            // 
            // btnSil
            // 
            resources.ApplyResources(btnSil, "btnSil");
            btnSil.Name = "btnSil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnYazdir
            // 
            resources.ApplyResources(btnYazdir, "btnYazdir");
            btnYazdir.Name = "btnYazdir";
            btnYazdir.UseVisualStyleBackColor = true;
            btnYazdir.Click += btnYazdir_Click;
            // 
            // btnGeri
            // 
            resources.ApplyResources(btnGeri, "btnGeri");
            btnGeri.Name = "btnGeri";
            btnGeri.UseVisualStyleBackColor = true;
            btnGeri.Click += btnGeri_Click;
            // 
            // dataGridViewTextBoxColumn1
            // 
            resources.ApplyResources(dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            resources.ApplyResources(dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            resources.ApplyResources(dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // frmMusteriler
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnGeri);
            Controls.Add(btnYazdir);
            Controls.Add(btnSil);
            Controls.Add(btnDuzenle);
            Controls.Add(btnEkle);
            Controls.Add(dgvMusteriler);
            Name = "frmMusteriler";
            Load += frmMusteriler_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMusteriler).EndInit();
            ResumeLayout(false);

        }

        internal DataGridView dgvMusteriler;
        internal Button btnEkle;
        internal Button btnDuzenle;
        internal Button btnSil;
        internal Button btnYazdir;
        internal Button btnGeri;
        internal DataGridViewTextBoxColumn colId;
        internal DataGridViewTextBoxColumn colAd;
        internal DataGridViewTextBoxColumn colAdres;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}
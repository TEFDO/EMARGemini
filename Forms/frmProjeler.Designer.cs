using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EMAR
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmProjeler : Form
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
            dgvProjeler = new DataGridView();
            btnEkle = new Button();
            btnDuzenle = new Button();
            btnSil = new Button();
            btnGeri = new Button();
            btnMakineEkle = new Button();
            txtArama = new TextBox();
            btnAra = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProjeler).BeginInit();
            SuspendLayout();
            // 
            // dgvProjeler
            // 
            dgvProjeler.AllowUserToAddRows = false;
            dgvProjeler.AllowUserToDeleteRows = false;
            dgvProjeler.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProjeler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProjeler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProjeler.Location = new Point(25, 100);
            dgvProjeler.MultiSelect = false;
            dgvProjeler.Name = "dgvProjeler";
            dgvProjeler.ReadOnly = true;
            dgvProjeler.RowHeadersVisible = false;
            dgvProjeler.RowHeadersWidth = 82;
            dgvProjeler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProjeler.Size = new Size(1300, 600);
            dgvProjeler.TabIndex = 0;
            dgvProjeler.CellContentClick += dgvProjeler_CellContentClick;
            // 
            // btnEkle
            // 
            btnEkle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEkle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEkle.Location = new Point(840, 25);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(110, 50);
            btnEkle.TabIndex = 1;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnDuzenle
            // 
            btnDuzenle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDuzenle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDuzenle.Location = new Point(970, 25);
            btnDuzenle.Name = "btnDuzenle";
            btnDuzenle.Size = new Size(110, 50);
            btnDuzenle.TabIndex = 2;
            btnDuzenle.Text = "Düzenle";
            btnDuzenle.UseVisualStyleBackColor = true;
            btnDuzenle.Click += btnDuzenle_Click;
            // 
            // btnSil
            // 
            btnSil.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSil.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSil.Location = new Point(1100, 25);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(110, 50);
            btnSil.TabIndex = 3;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnGeri
            // 
            btnGeri.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGeri.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGeri.Location = new Point(1230, 25);
            btnGeri.Name = "btnGeri";
            btnGeri.Size = new Size(110, 50);
            btnGeri.TabIndex = 4;
            btnGeri.Text = "Geri";
            btnGeri.UseVisualStyleBackColor = true;
            btnGeri.Click += btnGeri_Click;
            // 
            // btnMakineEkle
            // 
            btnMakineEkle.Location = new Point(25, 25);
            btnMakineEkle.Name = "btnMakineEkle";
            btnMakineEkle.Size = new Size(202, 50);
            btnMakineEkle.TabIndex = 5;
            btnMakineEkle.Text = "Makine Ekle";
            btnMakineEkle.UseVisualStyleBackColor = true;
            btnMakineEkle.Click += btnMakineEkle_Click;
            // 
            // txtArama
            // 
            txtArama.Location = new Point(329, 28);
            txtArama.Name = "txtArama";
            txtArama.Size = new Size(215, 47);
            txtArama.TabIndex = 6;
            // 
            // btnAra
            // 
            btnAra.Location = new Point(600, 27);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(150, 46);
            btnAra.TabIndex = 7;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = true;
            btnAra.Click += btnAra_Click;
            // 
            // frmProjeler
            // 
            AutoScaleDimensions = new SizeF(16F, 40F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 731);
            Controls.Add(btnAra);
            Controls.Add(txtArama);
            Controls.Add(btnMakineEkle);
            Controls.Add(dgvProjeler);
            Controls.Add(btnGeri);
            Controls.Add(btnSil);
            Controls.Add(btnDuzenle);
            Controls.Add(btnEkle);
            Font = new Font("Segoe UI", 11F);
            Name = "frmProjeler";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Projeler";
            Load += frmProjeler_Load;
            KeyDown += txtArama_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgvProjeler).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        internal DataGridView dgvProjeler;
        internal Button btnEkle;
        internal Button btnDuzenle;
        internal Button btnSil;
        internal Button btnGeri;
        internal Button btnMakineEkle;
        private TextBox txtArama;
        private Button btnAra;
    }
}
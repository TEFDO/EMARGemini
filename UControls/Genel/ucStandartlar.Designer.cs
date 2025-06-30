namespace EMAR.UControls
{
    partial class ucStandartlar
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvStandartlar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSecili;
        private System.Windows.Forms.DataGridViewComboBoxColumn colStandartNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBaslik;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvStandartlar = new System.Windows.Forms.DataGridView();
            colSecili = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            colStandartNo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            colBaslik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvStandartlar).BeginInit();
            SuspendLayout();
            // 
            // dgvStandartlar
            // 
            dgvStandartlar.AllowUserToAddRows = false;
            dgvStandartlar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvStandartlar.BackgroundColor = System.Drawing.Color.White;
            dgvStandartlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStandartlar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colSecili, colStandartNo, colBaslik });
            dgvStandartlar.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvStandartlar.Location = new System.Drawing.Point(0, 0);
            dgvStandartlar.Name = "dgvStandartlar";
            dgvStandartlar.RowHeadersVisible = false;
            dgvStandartlar.RowTemplate.Height = 35;
            dgvStandartlar.Size = new System.Drawing.Size(700, 400);
            dgvStandartlar.TabIndex = 0;
            // 
            // colSecili
            // 
            colSecili.FillWeight = 10F;
            colSecili.HeaderText = "#";
            colSecili.MinimumWidth = 10;
            colSecili.Name = "Secili";
            // 
            // colStandartNo
            // 
            colStandartNo.FillWeight = 30F;
            colStandartNo.HeaderText = "Standart No";
            colStandartNo.MinimumWidth = 10;
            colStandartNo.Name = "StandartNo";
            colStandartNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            colStandartNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colBaslik
            // 
            colBaslik.FillWeight = 60F;
            colBaslik.HeaderText = "Açıklama";
            colBaslik.MinimumWidth = 10;
            colBaslik.Name = "Baslik";
            colBaslik.ReadOnly = true;
            // 
            // ucStandartlar
            // 
            Controls.Add(dgvStandartlar);
            Name = "ucStandartlar";
            Size = new System.Drawing.Size(700, 400);
            ((System.ComponentModel.ISupportInitialize)dgvStandartlar).EndInit();
            ResumeLayout(false);
        }
    }
}

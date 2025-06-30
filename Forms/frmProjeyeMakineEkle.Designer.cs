using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EMAR
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmProjeyeMakineEkle : Form
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
            lstTumMakineler = new ListBox();
            lstProjedeMakineler = new ListBox();
            btnEkle = new Button();
            btnEkle.Click += new EventHandler(btnEkle_Click);
            btnCikar = new Button();
            btnCikar.Click += new EventHandler(btnCikar_Click);
            lblTum = new Label();
            lblProjede = new Label();
            SuspendLayout();
            // 
            // lstTumMakineler
            // 
            lstTumMakineler.FormattingEnabled = true;
            lstTumMakineler.Location = new Point(22, 68);
            lstTumMakineler.Margin = new Padding(6, 6, 6, 6);
            lstTumMakineler.Name = "lstTumMakineler";
            lstTumMakineler.Size = new Size(368, 580);
            lstTumMakineler.TabIndex = 0;
            // 
            // lstProjedeMakineler
            // 
            lstProjedeMakineler.FormattingEnabled = true;
            lstProjedeMakineler.Location = new Point(609, 68);
            lstProjedeMakineler.Margin = new Padding(6, 6, 6, 6);
            lstProjedeMakineler.Name = "lstProjedeMakineler";
            lstProjedeMakineler.Size = new Size(368, 580);
            lstProjedeMakineler.TabIndex = 1;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(427, 213);
            btnEkle.Margin = new Padding(6, 6, 6, 6);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(149, 64);
            btnEkle.TabIndex = 2;
            btnEkle.Text = "→";
            btnEkle.UseVisualStyleBackColor = true;
            // 
            // btnCikar
            // 
            btnCikar.Location = new Point(427, 341);
            btnCikar.Margin = new Padding(6, 6, 6, 6);
            btnCikar.Name = "btnCikar";
            btnCikar.Size = new Size(149, 64);
            btnCikar.TabIndex = 3;
            btnCikar.Text = "←";
            btnCikar.UseVisualStyleBackColor = true;
            // 
            // lblTum
            // 
            lblTum.AutoSize = true;
            lblTum.Location = new Point(22, 30);
            lblTum.Margin = new Padding(6, 0, 6, 0);
            lblTum.Name = "lblTum";
            lblTum.Size = new Size(175, 32);
            lblTum.TabIndex = 4;
            lblTum.Text = "Tüm Makineler";
            // 
            // lblProjede
            // 
            lblProjede.AutoSize = true;
            lblProjede.Location = new Point(609, 30);
            lblProjede.Margin = new Padding(6, 0, 6, 0);
            lblProjede.Name = "lblProjede";
            lblProjede.Size = new Size(242, 32);
            lblProjede.TabIndex = 5;
            lblProjede.Text = "Projeye Ait Makineler";
            // 
            // frmProjeyeMakineEkle
            // 
            AutoScaleDimensions = new SizeF(13.0f, 32.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1003, 683);
            Controls.Add(lblProjede);
            Controls.Add(lblTum);
            Controls.Add(btnCikar);
            Controls.Add(btnEkle);
            Controls.Add(lstProjedeMakineler);
            Controls.Add(lstTumMakineler);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(6, 6, 6, 6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmProjeyeMakineEkle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Projeye Makine Ekle";
            Load += new EventHandler(frmProjeyeMakineEkle_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal ListBox lstTumMakineler;
        internal ListBox lstProjedeMakineler;
        internal Button btnEkle;
        internal Button btnCikar;
        internal Label lblTum;
        internal Label lblProjede;
    }
}
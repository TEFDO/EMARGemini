using System.Windows.Forms;

namespace EMAR.UControls
{
    partial class ucAyarListesi
    {
        private System.ComponentModel.IContainer components = null;
        private GroupBox grp;
        private ListBox lst;
        private TextBox txt;
        private Button btnEkle;
        private Button btnSil;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grp = new GroupBox();
            lst = new ListBox();
            txt = new TextBox();
            btnEkle = new Button();
            btnSil = new Button();
            grp.SuspendLayout();
            SuspendLayout();
            // 
            // grp
            // 
            grp.Controls.Add(lst);
            grp.Controls.Add(txt);
            grp.Controls.Add(btnEkle);
            grp.Controls.Add(btnSil);
            grp.Dock = DockStyle.Fill;
            grp.Location = new System.Drawing.Point(0, 0);
            grp.Name = "grp";
            grp.Size = new System.Drawing.Size(686, 276);
            grp.TabIndex = 0;
            grp.TabStop = false;
            grp.Text = "Ayar Başlığı";
            // 
            // lst
            // 
            lst.FormattingEnabled = true;
            lst.Location = new System.Drawing.Point(10, 50);
            lst.Name = "lst";
            lst.Size = new System.Drawing.Size(346, 196);
            lst.TabIndex = 0;
            // 
            // txt
            // 
            txt.Location = new System.Drawing.Point(380, 50);
            txt.Multiline = true;
            txt.Name = "txt";
            txt.Size = new System.Drawing.Size(292, 65);
            txt.TabIndex = 1;
            // 
            // btnEkle
            // 
            btnEkle.Location = new System.Drawing.Point(413, 137);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new System.Drawing.Size(226, 52);
            btnEkle.TabIndex = 2;
            btnEkle.Text = "➕ Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new System.Drawing.Point(413, 198);
            btnSil.Name = "btnSil";
            btnSil.Size = new System.Drawing.Size(226, 46);
            btnSil.TabIndex = 3;
            btnSil.Text = "🗑️ Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // ucAyarListesi
            // 
            Controls.Add(grp);
            Name = "ucAyarListesi";
            Size = new System.Drawing.Size(686, 276);
            Load += ucAyarListesi_Load;
            grp.ResumeLayout(false);
            grp.PerformLayout();
            ResumeLayout(false);
        }
    }
}

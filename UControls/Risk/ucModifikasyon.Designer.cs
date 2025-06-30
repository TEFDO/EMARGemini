using System.Windows.Forms;

namespace EMAR
{
    partial class ucModifikasyon
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnMetinEkle;
        private Button btnGorselEkle;
        private FlowLayoutPanel flwAlanlar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnMetinEkle = new Button();
            btnGorselEkle = new Button();
            flwAlanlar = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // btnMetinEkle
            // 
            btnMetinEkle.Location = new System.Drawing.Point(10, 10);
            btnMetinEkle.Name = "btnMetinEkle";
            btnMetinEkle.Size = new System.Drawing.Size(120, 41);
            btnMetinEkle.TabIndex = 0;
            btnMetinEkle.Text = "📝 Metin Ekle";
            btnMetinEkle.Click += btnMetinEkle_Click;
            // 
            // btnGorselEkle
            // 
            btnGorselEkle.Location = new System.Drawing.Point(140, 10);
            btnGorselEkle.Name = "btnGorselEkle";
            btnGorselEkle.Size = new System.Drawing.Size(120, 41);
            btnGorselEkle.TabIndex = 1;
            btnGorselEkle.Text = "🖼️ Görsel Ekle";
            btnGorselEkle.Click += btnGorselEkle_Click;
            // 
            // flwAlanlar
            // 
            flwAlanlar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flwAlanlar.AutoScroll = true;
            flwAlanlar.FlowDirection = FlowDirection.TopDown;
            flwAlanlar.Location = new System.Drawing.Point(10, 74);
            flwAlanlar.Name = "flwAlanlar";
            flwAlanlar.Size = new System.Drawing.Size(800, 476);
            flwAlanlar.TabIndex = 2;
            flwAlanlar.WrapContents = false;
            // 
            // ucModifikasyon
            // 
            Controls.Add(btnMetinEkle);
            Controls.Add(btnGorselEkle);
            Controls.Add(flwAlanlar);
            Name = "ucModifikasyon";
            Size = new System.Drawing.Size(820, 560);
            ResumeLayout(false);
        }
    }
}

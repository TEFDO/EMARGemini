using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EMAR
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class ucMakineGorselleri : UserControl
    {

        // UserControl, bileşen listesini temizlemeyi bırakmayı geçersiz kılar.
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

        // Windows Form Tasarımcısı tarafından gerektirilir
        private System.ComponentModel.IContainer components;

        // NOT: Aşağıdaki yordam Windows Form Tasarımcısı için gereklidir
        // Windows Form Tasarımcısı kullanılarak değiştirilebilir.  
        // Kod düzenleyicisini kullanarak değiştirmeyin.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            pnlKontroller = new FlowLayoutPanel();
            btnEkle = new Button();
            btnEkle.Click += new EventHandler(btnEkle_Click);
            btnSil = new Button();
            btnSil.Click += new EventHandler(btnSil_Click);
            btnKaydet = new Button();
            btnKaydet.Click += new EventHandler(btnKaydet_Click);
            ofdResim = new OpenFileDialog();
            flwGorseller = new FlowLayoutPanel();
            flwGorseller.DragDrop += new DragEventHandler(flwGorseller_DragDrop);
            flwGorseller.DragEnter += new DragEventHandler(flwGorseller_DragEnter);
            pnlKontroller.SuspendLayout();
            SuspendLayout();
            // 
            // pnlKontroller
            // 
            pnlKontroller.Controls.Add(btnEkle);
            pnlKontroller.Controls.Add(btnSil);
            pnlKontroller.Controls.Add(btnKaydet);
            pnlKontroller.Dock = DockStyle.Bottom;
            pnlKontroller.Location = new Point(0, 1020);
            pnlKontroller.Name = "pnlKontroller";
            pnlKontroller.Size = new Size(1629, 137);
            pnlKontroller.TabIndex = 1;
            // 
            // btnEkle
            // 
            btnEkle.FlatStyle = FlatStyle.Flat;
            btnEkle.Location = new Point(3, 3);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(199, 63);
            btnEkle.TabIndex = 4;
            btnEkle.Text = "➕ Ekle";
            // 
            // btnSil
            // 
            btnSil.FlatStyle = FlatStyle.Flat;
            btnSil.Location = new Point(208, 3);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(199, 63);
            btnSil.TabIndex = 5;
            btnSil.Text = "🗑️ Sil";
            // 
            // btnKaydet
            // 
            btnKaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnKaydet.FlatStyle = FlatStyle.Flat;
            btnKaydet.Location = new Point(413, 3);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(199, 63);
            btnKaydet.TabIndex = 6;
            btnKaydet.Text = "💾 Kaydet";
            // 
            // ofdResim
            // 
            ofdResim.FileName = "OpenFileDialog1";
            // 
            // flwGorseller
            // 
            flwGorseller.AutoScroll = true;
            flwGorseller.Dock = DockStyle.Fill;
            flwGorseller.Location = new Point(0, 0);
            flwGorseller.Name = "flwGorseller";
            flwGorseller.Size = new Size(1629, 1020);
            flwGorseller.TabIndex = 2;
            // 
            // ucMakineGorselleri
            // 
            AutoScaleDimensions = new SizeF(13f, 32f);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flwGorseller);
            Controls.Add(pnlKontroller);
            Name = "ucMakineGorselleri";
            Size = new Size(1629, 1157);
            pnlKontroller.ResumeLayout(false);
            Load += new EventHandler(ucMakineGorselleri_Load);
            ResumeLayout(false);
        }
        internal FlowLayoutPanel pnlKontroller;
        internal Button btnEkle;
        internal Button btnSil;
        internal Button btnKaydet;
        internal OpenFileDialog ofdResim;
        internal FlowLayoutPanel flwGorseller;

    }
}
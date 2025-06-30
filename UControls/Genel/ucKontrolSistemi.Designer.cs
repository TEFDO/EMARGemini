using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EMAR
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class ucKontrolSistemi : UserControl
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
            TableLayoutPanel1 = new TableLayoutPanel();
            Label1 = new Label();
            FlowLayoutPanel1 = new FlowLayoutPanel();
            GroupBox1 = new GroupBox();
            txtGenel = new TextBox();
            GroupBox2 = new GroupBox();
            txtGiris = new TextBox();
            GroupBox3 = new GroupBox();
            txtMantik = new TextBox();
            GroupBox4 = new GroupBox();
            txtCikis = new TextBox();
            btnKaydet = new Button();
            btnKaydet.Click += new EventHandler(btnKaydet_Click);
            TableLayoutPanel1.SuspendLayout();
            FlowLayoutPanel1.SuspendLayout();
            GroupBox1.SuspendLayout();
            GroupBox2.SuspendLayout();
            GroupBox3.SuspendLayout();
            GroupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            TableLayoutPanel1.ColumnCount = 1;
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0f));
            TableLayoutPanel1.Controls.Add(Label1, 0, 0);
            TableLayoutPanel1.Controls.Add(FlowLayoutPanel1, 0, 1);
            TableLayoutPanel1.Location = new Point(8, 8);
            TableLayoutPanel1.Name = "TableLayoutPanel1";
            TableLayoutPanel1.RowCount = 2;
            TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70.0f));
            TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f));
            TableLayoutPanel1.Size = new Size(1200, 1250);
            TableLayoutPanel1.TabIndex = 1;
            // 
            // Label1
            // 
            Label1.Dock = DockStyle.Fill;
            Label1.Font = new Font("Segoe UI", 18.0f, FontStyle.Bold);
            Label1.Location = new Point(3, 0);
            Label1.Name = "Label1";
            Label1.Size = new Size(1194, 70);
            Label1.TabIndex = 0;
            Label1.Text = "MAKİNE KONTROL SİSTEMİ";
            Label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FlowLayoutPanel1
            // 
            FlowLayoutPanel1.AutoScroll = true;
            FlowLayoutPanel1.Controls.Add(GroupBox1);
            FlowLayoutPanel1.Controls.Add(GroupBox2);
            FlowLayoutPanel1.Controls.Add(GroupBox3);
            FlowLayoutPanel1.Controls.Add(GroupBox4);
            FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            FlowLayoutPanel1.Location = new Point(3, 73);
            FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            FlowLayoutPanel1.Size = new Size(1194, 1158);
            FlowLayoutPanel1.TabIndex = 1;
            FlowLayoutPanel1.WrapContents = false;
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(txtGenel);
            GroupBox1.Location = new Point(3, 3);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(1150, 283);
            GroupBox1.TabIndex = 0;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "Genel Açıklama";
            // 
            // txtGenel
            // 
            txtGenel.Dock = DockStyle.Fill;
            txtGenel.Location = new Point(3, 35);
            txtGenel.Multiline = true;
            txtGenel.Name = "txtGenel";
            txtGenel.ScrollBars = ScrollBars.Vertical;
            txtGenel.Size = new Size(1144, 245);
            txtGenel.TabIndex = 0;
            // 
            // GroupBox2
            // 
            GroupBox2.Controls.Add(txtGiris);
            GroupBox2.Location = new Point(3, 292);
            GroupBox2.Name = "GroupBox2";
            GroupBox2.Size = new Size(1150, 283);
            GroupBox2.TabIndex = 1;
            GroupBox2.TabStop = false;
            GroupBox2.Text = "Giriş Katı Bilgileri";
            // 
            // txtGiris
            // 
            txtGiris.Dock = DockStyle.Fill;
            txtGiris.Location = new Point(3, 35);
            txtGiris.Multiline = true;
            txtGiris.Name = "txtGiris";
            txtGiris.ScrollBars = ScrollBars.Vertical;
            txtGiris.Size = new Size(1144, 245);
            txtGiris.TabIndex = 0;
            // 
            // GroupBox3
            // 
            GroupBox3.Controls.Add(txtMantik);
            GroupBox3.Location = new Point(3, 581);
            GroupBox3.Name = "GroupBox3";
            GroupBox3.Size = new Size(1150, 283);
            GroupBox3.TabIndex = 2;
            GroupBox3.TabStop = false;
            GroupBox3.Text = "Mantık Katı Bilgileri";
            // 
            // txtMantik
            // 
            txtMantik.Dock = DockStyle.Fill;
            txtMantik.Location = new Point(3, 35);
            txtMantik.Multiline = true;
            txtMantik.Name = "txtMantik";
            txtMantik.ScrollBars = ScrollBars.Vertical;
            txtMantik.Size = new Size(1144, 245);
            txtMantik.TabIndex = 0;
            // 
            // GroupBox4
            // 
            GroupBox4.Controls.Add(txtCikis);
            GroupBox4.Location = new Point(3, 870);
            GroupBox4.Name = "GroupBox4";
            GroupBox4.Size = new Size(1150, 283);
            GroupBox4.TabIndex = 3;
            GroupBox4.TabStop = false;
            GroupBox4.Text = "Çıkış Katı Bilgileri";
            // 
            // txtCikis
            // 
            txtCikis.Dock = DockStyle.Fill;
            txtCikis.Location = new Point(3, 35);
            txtCikis.Multiline = true;
            txtCikis.Name = "txtCikis";
            txtCikis.ScrollBars = ScrollBars.Vertical;
            txtCikis.Size = new Size(1144, 245);
            txtCikis.TabIndex = 0;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(1283, 1193);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(150, 46);
            btnKaydet.TabIndex = 2;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            // 
            // ucKontrolSistemi
            // 
            AutoScaleDimensions = new SizeF(13.0f, 32.0f);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnKaydet);
            Controls.Add(TableLayoutPanel1);
            Name = "ucKontrolSistemi";
            Size = new Size(1520, 1276);
            TableLayoutPanel1.ResumeLayout(false);
            FlowLayoutPanel1.ResumeLayout(false);
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            GroupBox2.ResumeLayout(false);
            GroupBox2.PerformLayout();
            GroupBox3.ResumeLayout(false);
            GroupBox3.PerformLayout();
            GroupBox4.ResumeLayout(false);
            GroupBox4.PerformLayout();
            ResumeLayout(false);
        }

        internal TableLayoutPanel TableLayoutPanel1;
        internal Label Label1;
        internal FlowLayoutPanel FlowLayoutPanel1;
        internal GroupBox GroupBox1;
        internal TextBox txtGenel;
        internal GroupBox GroupBox2;
        internal TextBox txtGiris;
        internal GroupBox GroupBox3;
        internal TextBox txtMantik;
        internal GroupBox GroupBox4;
        internal TextBox txtCikis;
        internal Button btnKaydet;

    }
}
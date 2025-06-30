using System.Windows.Forms;
using EMAR.UControls;

namespace EMAR
{
    partial class frmAyarlar
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flowPanel;
        private Button btnKaydet;
        private Button btnGeri;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            flowPanel = new FlowLayoutPanel();
            btnKaydet = new Button();
            btnGeri = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowPanel
            // 
            flowPanel.AutoScroll = true;
            flowPanel.Dock = DockStyle.Fill;
            flowPanel.Location = new System.Drawing.Point(5, 5);
            flowPanel.Margin = new Padding(5);
            flowPanel.Name = "flowPanel";
            flowPanel.Size = new System.Drawing.Size(1589, 942);
            flowPanel.TabIndex = 0;
            // 
            // btnKaydet
            // 
            btnKaydet.Anchor = AnchorStyles.Bottom;
            btnKaydet.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnKaydet.Location = new System.Drawing.Point(426, 8);
            btnKaydet.Margin = new Padding(5);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new System.Drawing.Size(292, 80);
            btnKaydet.TabIndex = 1;
            btnKaydet.Text = "💾 Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnGeri
            // 
            btnGeri.Anchor = AnchorStyles.Bottom;
            btnGeri.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnGeri.Location = new System.Drawing.Point(867, 9);
            btnGeri.Margin = new Padding(5);
            btnGeri.Name = "btnGeri";
            btnGeri.Size = new System.Drawing.Size(292, 80);
            btnGeri.TabIndex = 2;
            btnGeri.Text = "⏪ Geri";
            btnGeri.UseVisualStyleBackColor = true;
            btnGeri.Click += btnGeri_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Controls.Add(flowPanel, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Size = new System.Drawing.Size(1599, 1058);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnKaydet);
            panel1.Controls.Add(btnGeri);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(3, 955);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1593, 100);
            panel1.TabIndex = 4;
            // 
            // frmAyarlar
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1599, 1058);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(5);
            Name = "frmAyarlar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Uygulama Ayarları";
            Load += frmAyarlar_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
    }
}

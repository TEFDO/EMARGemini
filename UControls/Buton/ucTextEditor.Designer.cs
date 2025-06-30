using System.Drawing;
using System.Windows.Forms;

namespace EMAR.UControls.Buton
{
    partial class ucTextEditor
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnBold;
        private System.Windows.Forms.ToolStripButton btnItalic;
        private System.Windows.Forms.ToolStripButton btnUnderline;
        private System.Windows.Forms.ToolStripComboBox cmbFont;
        private System.Windows.Forms.ToolStripComboBox cmbFontSize;
        private System.Windows.Forms.ToolStripButton btnTextColor;
        private System.Windows.Forms.ToolStripButton btnBackColor;
        private System.Windows.Forms.ToolStripButton btnClearFormatting;
        private System.Windows.Forms.ToolStripButton btnAlignLeft;
        private System.Windows.Forms.ToolStripButton btnAlignCenter;
        private System.Windows.Forms.ToolStripButton btnAlignRight;
        private System.Windows.Forms.ToolStripButton btnBullet;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripButton btnRedo;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripButton btnBulletDot;
        private System.Windows.Forms.ToolStripButton btnBulletDash;
        private System.Windows.Forms.ToolStripButton btnBulletSquare;
        private System.Windows.Forms.ToolStripButton btnNumberedList;
        private System.Windows.Forms.ToolStripButton btnIndent;
        private System.Windows.Forms.ToolStripButton btnOutdent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            toolStrip1 = new ToolStrip();
            btnIndent = new ToolStripButton();
            btnOutdent = new ToolStripButton();
            btnBold = new ToolStripButton();
            btnItalic = new ToolStripButton();
            btnUnderline = new ToolStripButton();
            cmbFont = new ToolStripComboBox();
            cmbFontSize = new ToolStripComboBox();
            btnTextColor = new ToolStripButton();
            btnBackColor = new ToolStripButton();
            btnClearFormatting = new ToolStripButton();
            btnAlignLeft = new ToolStripButton();
            btnAlignCenter = new ToolStripButton();
            btnAlignRight = new ToolStripButton();
            btnBullet = new ToolStripButton();
            btnUndo = new ToolStripButton();
            btnRedo = new ToolStripButton();
            colorDialog = new ColorDialog();
            richTextBox = new RichTextBox();
            btnBulletDot = new ToolStripButton();
            btnBulletDash = new ToolStripButton();
            btnBulletSquare = new ToolStripButton();
            btnNumberedList = new ToolStripButton();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnIndent, btnOutdent, btnBold, btnItalic, btnUnderline, cmbFont, cmbFontSize, btnTextColor, btnBackColor, btnClearFormatting, btnAlignLeft, btnAlignCenter, btnAlignRight, btnBullet, btnUndo, btnRedo });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1411, 42);
            toolStrip1.TabIndex = 1;
            // 
            // btnIndent
            // 
            btnIndent.Name = "btnIndent";
            btnIndent.Size = new Size(46, 36);
            btnIndent.Text = "»";
            // 
            // btnOutdent
            // 
            btnOutdent.Name = "btnOutdent";
            btnOutdent.Size = new Size(46, 36);
            btnOutdent.Text = "«";
            // 
            // btnBold
            // 
            btnBold.Name = "btnBold";
            btnBold.Size = new Size(46, 36);
            btnBold.Text = "B";
            // 
            // btnItalic
            // 
            btnItalic.Name = "btnItalic";
            btnItalic.Size = new Size(46, 36);
            btnItalic.Text = "I";
            // 
            // btnUnderline
            // 
            btnUnderline.Name = "btnUnderline";
            btnUnderline.Size = new Size(46, 36);
            btnUnderline.Text = "U";
            // 
            // cmbFont
            // 
            cmbFont.DropDownWidth = 300;
            cmbFont.Name = "cmbFont";
            cmbFont.Size = new Size(300, 42);
            // 
            // cmbFontSize
            // 
            cmbFontSize.AutoSize = false;
            cmbFontSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFontSize.Items.AddRange(new object[] { "12", "14", "18" });
            cmbFontSize.Name = "cmbFontSize";
            cmbFontSize.Size = new Size(75, 40);
            // 
            // btnTextColor
            // 
            btnTextColor.Name = "btnTextColor";
            btnTextColor.Size = new Size(46, 36);
            btnTextColor.Text = "A";
            // 
            // btnBackColor
            // 
            btnBackColor.Name = "btnBackColor";
            btnBackColor.Size = new Size(46, 36);
            btnBackColor.Text = "Bg";
            // 
            // btnClearFormatting
            // 
            btnClearFormatting.Name = "btnClearFormatting";
            btnClearFormatting.Size = new Size(46, 36);
            btnClearFormatting.Text = "X";
            // 
            // btnAlignLeft
            // 
            btnAlignLeft.Name = "btnAlignLeft";
            btnAlignLeft.Size = new Size(46, 36);
            btnAlignLeft.Text = "⯇";
            // 
            // btnAlignCenter
            // 
            btnAlignCenter.Name = "btnAlignCenter";
            btnAlignCenter.Size = new Size(46, 36);
            btnAlignCenter.Text = "↔";
            // 
            // btnAlignRight
            // 
            btnAlignRight.Name = "btnAlignRight";
            btnAlignRight.Size = new Size(46, 36);
            btnAlignRight.Text = "⯈";
            // 
            // btnBullet
            // 
            btnBullet.Name = "btnBullet";
            btnBullet.Size = new Size(46, 36);
            btnBullet.Text = "•";
            // 
            // btnUndo
            // 
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(46, 36);
            btnUndo.Text = "↺";
            // 
            // btnRedo
            // 
            btnRedo.Name = "btnRedo";
            btnRedo.Size = new Size(46, 36);
            btnRedo.Text = "↻";
            // 
            // richTextBox
            // 
            richTextBox.BulletIndent = 20;
            richTextBox.Dock = DockStyle.Fill;
            richTextBox.Font = new Font("Segoe UI", 12F);
            richTextBox.Location = new Point(0, 42);
            richTextBox.Name = "richTextBox";
            richTextBox.Size = new Size(1411, 620);
            richTextBox.TabIndex = 0;
            richTextBox.Text = "";
            // 
            // btnBulletDot
            // 
            btnBulletDot.Name = "btnBulletDot";
            btnBulletDot.Size = new Size(23, 23);
            btnBulletDot.Text = "•";
            // 
            // btnBulletDash
            // 
            btnBulletDash.Name = "btnBulletDash";
            btnBulletDash.Size = new Size(23, 23);
            btnBulletDash.Text = "–";
            // 
            // btnBulletSquare
            // 
            btnBulletSquare.Name = "btnBulletSquare";
            btnBulletSquare.Size = new Size(23, 23);
            btnBulletSquare.Text = "■";
            // 
            // btnNumberedList
            // 
            btnNumberedList.Name = "btnNumberedList";
            btnNumberedList.Size = new Size(23, 23);
            btnNumberedList.Text = "1.";
            // 
            // ucTextEditor
            // 
            Controls.Add(richTextBox);
            Controls.Add(toolStrip1);
            Name = "ucTextEditor";
            Size = new Size(1411, 662);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private RichTextBox richTextBox;

    }
}

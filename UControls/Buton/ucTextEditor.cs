using EMAR.Models;
using EMAR.Repository;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EMAR.UControls.Buton
{
    public partial class ucTextEditor : UserControl
    {
        public string Alan { get; set; }
        public string DbYolu { get; set; }
        public int BagliId { get; set; }

        public ucTextEditor()
        {
            InitializeComponent();
            InitDefaultFormatting(60, 60, 12);
            SetupToolbar();
            SetupEvents();
            InitFonts();
            SetupContextMenu();
            SetupZoom();
            SetupAutoSave();
            SetupStatusBar();
        }

        public string RtfText
        {
            get => GetRtfText();
            set => SetRtfText(value);
        }
        // ucTextEditor.cs içinde:
        public void Yukle()
        {
            if (!string.IsNullOrEmpty(DbYolu) && BagliId > 0 && !string.IsNullOrEmpty(Alan))
            {
                // TextEditorRepository kullanılmakta
                var icerik = TextEditorRepository.Getir(DbYolu, BagliId, Alan);
                if (!string.IsNullOrEmpty(icerik))
                    SetRtfText(icerik);
                else
                    SetRtfText(""); // Temizle
            }
        }

        public void Kaydet()
        {
            if (!string.IsNullOrEmpty(DbYolu) && BagliId > 0 && !string.IsNullOrEmpty(Alan))
            {
                var model = new TextEditorData
                {
                    Id = BagliId,
                    Alan = Alan,
                    Icerik = GetRtfText()
                };
                TextEditorRepository.Kaydet(DbYolu, model);
            }
        }

        // Toolbar ayarları (ikonları ve stilleri burada güncelleyebilirsin)
        private void SetupToolbar()
        {
            btnBold.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnItalic.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            btnUnderline.Font = new Font("Segoe UI", 9, FontStyle.Underline);
            btnTextColor.ForeColor = Color.Red;
            btnBackColor.ForeColor = Color.Black;
        }

        // Event handler'ları tek yerde ekle
        // ... diğer kodlar aynen kalacak ...
        private void SetupEvents()
        {
            btnBold.Click += (s, e) => ToggleStyle(FontStyle.Bold);
            btnItalic.Click += (s, e) => ToggleStyle(FontStyle.Italic);
            btnUnderline.Click += (s, e) => ToggleStyle(FontStyle.Underline);

            cmbFont.SelectedIndexChanged += (s, e) => ChangeFontFamily();
            cmbFontSize.SelectedIndexChanged += (s, e) => ChangeFontSize();

            btnTextColor.Click += (s, e) => PickColor();
            btnBackColor.Click += (s, e) => PickBackColor();

            btnClearFormatting.Click += (s, e) => ClearFormatting();

            btnAlignLeft.Click += (s, e) => { SetAlignment(HorizontalAlignment.Left); UpdateToolbarAlignmentState(); };
            btnAlignCenter.Click += (s, e) => { SetAlignment(HorizontalAlignment.Center); UpdateToolbarAlignmentState(); };
            btnAlignRight.Click += (s, e) => { SetAlignment(HorizontalAlignment.Right); UpdateToolbarAlignmentState(); };
            
            btnBullet.Click += (s, e) => richTextBox.SelectionBullet = !richTextBox.SelectionBullet;

            btnUndo.Click += (s, e) => { if (richTextBox.CanUndo) richTextBox.Undo(); };
            btnRedo.Click += (s, e) => { if (richTextBox.CanRedo) richTextBox.Redo(); };
            btnIndent.Click += (s, e) => IndentSelection(true);
            btnOutdent.Click += (s, e) => IndentSelection(false);

            richTextBox.SelectionChanged += RichTextBox_SelectionChanged;
            richTextBox.SelectionChanged += (s, e) => { UpdateStatus(); UpdateToolbarAlignmentState(); }; // Satır hizasını güncelle!
            richTextBox.KeyDown += RichTextBox_KeyDown;
        }



        private const int INDENT_STEP = 10;  // Piksel cinsinden girinti (isteğe göre ayarla)
        private void IndentSelection(bool indent)
        {
            if (indent)
            {
                richTextBox.SelectionIndent += INDENT_STEP;
                richTextBox.SelectionRightIndent += INDENT_STEP;
            }
            else
            {
                richTextBox.SelectionIndent = Math.Max(0, richTextBox.SelectionIndent - INDENT_STEP);
                richTextBox.SelectionRightIndent = Math.Max(0, richTextBox.SelectionRightIndent - INDENT_STEP);
            }
        }

        public void InitDefaultFormatting(
            int leftIndent , int rightIndent ,
            int fontSize , string fontName = "Segoe UI",
            int spaceBeforeTwip = 120, int spaceAfterTwip = 120)
        {
            richTextBox.SelectAll();
            richTextBox.SelectionIndent = leftIndent;
            richTextBox.SelectionRightIndent = rightIndent;
            richTextBox.SelectionFont = new Font(fontName, fontSize, FontStyle.Regular);
            SetParagraphSpacing(spaceBeforeTwip, spaceAfterTwip);
            richTextBox.SelectionColor = Color.Black;
            richTextBox.SelectionBackColor = Color.White;
            richTextBox.DeselectAll();
        }


        // Font listesini ve boyutunu doldur
        private void InitFonts()
        {
            cmbFont.Items.Clear();
            foreach (FontFamily font in FontFamily.Families)
                cmbFont.Items.Add(font.Name);

            if (cmbFont.Items.Contains("Segoe UI"))
                cmbFont.SelectedItem = "Segoe UI";
            else if (cmbFont.Items.Count > 0)
                cmbFont.SelectedIndex = 0;

            cmbFontSize.Items.Clear();
            for (int i = 8; i <= 48; i += 2)
                cmbFontSize.Items.Add(i.ToString());
            cmbFontSize.SelectedItem = "12";
        }

        // Bağlam menüsü (sağ tık)
        private void SetupContextMenu()
        {
            var menu = new ContextMenuStrip();
            menu.Items.Add("Kes", null, (s, e) => richTextBox.Cut());
            menu.Items.Add("Kopyala", null, (s, e) => richTextBox.Copy());
            menu.Items.Add("Yapıştır", null, (s, e) => richTextBox.Paste());
            menu.Items.Add("-");
            menu.Items.Add("Tümünü Seç", null, (s, e) => richTextBox.SelectAll());
            menu.Items.Add("-");
            menu.Items.Add("Biçimlendirmeyi Temizle", null, (s, e) => ClearFormatting());
            richTextBox.ContextMenuStrip = menu;
        }

        // Stil değiştir (kalın/italik/altı çizili)
        private void ToggleStyle(FontStyle style)
        {
            if (richTextBox.SelectionLength > 0)
            {
                var currentFont = richTextBox.SelectionFont ?? richTextBox.Font;
                richTextBox.SelectionFont = new Font(
                    currentFont,
                    currentFont.Style ^ style
                );
            }
        }

        private void ChangeFontFamily()
        {
            if (richTextBox.SelectionLength > 0 && cmbFont.SelectedItem != null)
            {
                var currentFont = richTextBox.SelectionFont ?? richTextBox.Font;
                richTextBox.SelectionFont = new Font(
                    cmbFont.SelectedItem.ToString(),
                    currentFont.Size,
                    currentFont.Style
                );
            }
        }

        private void ChangeFontSize()
        {
            if (richTextBox.SelectionLength > 0 && int.TryParse(cmbFontSize.SelectedItem?.ToString(), out int size))
            {
                var currentFont = richTextBox.SelectionFont ?? richTextBox.Font;
                richTextBox.SelectionFont = new Font(
                    currentFont.FontFamily,
                    size,
                    currentFont.Style
                );
            }
        }

        private void PickColor()
        {
            if (colorDialog.ShowDialog() == DialogResult.OK && richTextBox.SelectionLength > 0)
                richTextBox.SelectionColor = colorDialog.Color;
        }

        private void PickBackColor()
        {
            if (colorDialog.ShowDialog() == DialogResult.OK && richTextBox.SelectionLength > 0)
                richTextBox.SelectionBackColor = colorDialog.Color;
        }

        private void SetAlignment(HorizontalAlignment align)
        {
            richTextBox.SelectionAlignment = align;
        }

        private void ClearFormatting()
        {
            if (richTextBox.SelectionLength > 0)
            {
                var defaultFont = this.Font;
                richTextBox.SelectionFont = defaultFont;
                richTextBox.SelectionColor = Color.Black;
                richTextBox.SelectionBackColor = Color.White;
                richTextBox.SelectionAlignment = HorizontalAlignment.Left;
                richTextBox.SelectionBullet = false;
            }
        }

        // Gerçek zamanlı toolbar güncelle
        private void RichTextBox_SelectionChanged(object sender, EventArgs e)
        {
            var f = richTextBox.SelectionFont;
            if (f != null)
            {
                btnBold.Checked = f.Bold;
                btnItalic.Checked = f.Italic;
                btnUnderline.Checked = f.Underline;
                cmbFont.Text = f.FontFamily.Name;
                cmbFontSize.Text = ((int)f.Size).ToString();
            }
            btnTextColor.ForeColor = richTextBox.SelectionColor;
            btnBackColor.BackColor = richTextBox.SelectionBackColor;

            btnBullet.Checked = richTextBox.SelectionBullet;
            btnAlignLeft.Checked = richTextBox.SelectionAlignment == HorizontalAlignment.Left;
            btnAlignCenter.Checked = richTextBox.SelectionAlignment == HorizontalAlignment.Center;
            btnAlignRight.Checked = richTextBox.SelectionAlignment == HorizontalAlignment.Right;
        }

        // RTF get/set fonksiyonları
        public string GetRtfText() => richTextBox.Rtf;
        public void SetRtfText(string rtf) => richTextBox.Rtf = rtf;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.B)) { ToggleStyle(FontStyle.Bold); return true; }
            if (keyData == (Keys.Control | Keys.I)) { ToggleStyle(FontStyle.Italic); return true; }
            if (keyData == (Keys.Control | Keys.U)) { ToggleStyle(FontStyle.Underline); return true; }
            if (keyData == (Keys.Control | Keys.Z)) { if (richTextBox.CanUndo) richTextBox.Undo(); return true; }
            if (keyData == (Keys.Control | Keys.Y)) { if (richTextBox.CanRedo) richTextBox.Redo(); return true; }
            if (keyData == (Keys.Control | Keys.V)) { richTextBox.Paste(); return true; }
            // CTRL+SHIFT+V için KeyDown ile devam et
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private bool lastWasShiftEnter;
        private void RichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.V)
            {
                if (Clipboard.ContainsText())
                    richTextBox.SelectedText = Clipboard.GetText(TextDataFormat.Text);
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.B)
            {
                ToggleStyle(FontStyle.Bold);
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.I)
            {
                ToggleStyle(FontStyle.Italic);
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.U)
            {
                ToggleStyle(FontStyle.Underline);
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                lastWasShiftEnter = e.Shift;
            }
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                var backup = Clipboard.GetDataObject();
                Clipboard.SetText(@"{\rtf1\ansi\deff0{\pard\sa120\sb0 \par}}", TextDataFormat.Rtf);
                richTextBox.Paste();
                if (backup != null) Clipboard.SetDataObject(backup); // Clipboard'u geri döndür
            };
        }

        private float zoom = 1.0f;
        private void SetupZoom()
        {
            var btnZoomIn = new ToolStripButton("+") { ToolTipText = "Yakınlaştır" };
            var btnZoomOut = new ToolStripButton("-") { ToolTipText = "Uzaklaştır" };
            btnZoomIn.Click += (s, e) => { zoom += 0.1f; richTextBox.ZoomFactor = zoom; };
            btnZoomOut.Click += (s, e) => { zoom = Math.Max(0.5f, zoom - 0.1f); richTextBox.ZoomFactor = zoom; };
            toolStrip1.Items.Add(btnZoomIn);
            toolStrip1.Items.Add(btnZoomOut);
            richTextBox.MouseWheel += (s, e) =>
            {
                if (ModifierKeys == Keys.Control)
                {
                    zoom += e.Delta > 0 ? 0.1f : -0.1f;
                    zoom = Math.Max(0.5f, Math.Min(3.0f, zoom));
                    richTextBox.ZoomFactor = zoom;
                }
            };
        }
        private Timer autosaveTimer;
        private void SetupAutoSave()
        {
            autosaveTimer = new Timer();
            autosaveTimer.Interval = 2000; // 15 sn
            autosaveTimer.Tick += (s, e) => AutoSave();
            autosaveTimer.Start();
        }
        private void AutoSave()
        {
            Kaydet();
            // örnek: veritabanına kaydet veya dosyaya yaz
            // TextEditorRepository.Kaydet(dbYolu, new TextEditorData { Id=..., Alan=..., Icerik=GetRtfText() });
        }
        private ToolStripLabel lblStatus;
        private void SetupStatusBar()
        {
            lblStatus = new ToolStripLabel();
            toolStrip1.Items.Add(new ToolStripSeparator());
            toolStrip1.Items.Add(lblStatus);
            UpdateStatus();
            richTextBox.SelectionChanged += (s, e) => UpdateStatus();
            richTextBox.TextChanged += (s, e) => UpdateStatus();
        }
        private void UpdateStatus()
        {
            string text = richTextBox.Text;
            string selected = richTextBox.SelectedText;

            int totalWords = WordCount(text);
            int selectedWords = WordCount(selected);
            int totalChars = text.Length;
            int selectedChars = selected.Length;

            int pos = richTextBox.SelectionStart;
            int line = richTextBox.GetLineFromCharIndex(pos) + 1;
            int col = pos - richTextBox.GetFirstCharIndexOfCurrentLine() + 1;

            // Satır başı/paragraf ayrımı
            string lineType = lastWasShiftEnter ? "SHIFT+ENTER: satırbaşı" : "ENTER: yeni paragraf";

            lblStatus.Text =
                $"Satır: {line} Sütun: {col}  " +
                $"Tüm: {totalWords} kelime / {totalChars} karakter  " +
                $"Seçili: {selectedWords} kelime / {selectedChars} karakter";
            //$"{...}   |   {lineType}";
        }


        private int WordCount(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;
            return s.Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
        const int EM_SETPARAFORMAT = 1095;
        const int SCF_SELECTION = 1;
        const uint PFM_SPACEBEFORE = 0x40;
        const uint PFM_SPACEAFTER = 0x80;
        const uint PFM_LINESPACING = 0x100;
        const uint PFM_ALIGNMENT = 0x00000008;
        
        const int EM_GETPARAFORMAT = 1085;
        
        private const short PFA_LEFT = 0, PFA_CENTER = 1, PFA_RIGHT = 2;

        [StructLayout(LayoutKind.Sequential)]
        struct PARAFORMAT2
        {
            public int cbSize;
            public uint dwMask;
            public short wNumbering, wReserved;
            public int dxStartIndent, dxRightIndent, dxOffset;
            public short wAlignment, cTabCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public int[] rgxTabs;
            public int dySpaceBefore, dySpaceAfter, dyLineSpacing;
            public byte bLineSpacingRule;
            public byte bOutlineLevel;
            public short wShadingWeight, wShadingStyle;
            public short wNumberingStart, wNumberingStyle, wNumberingTab;
            public short wBorderSpace, wBorderWidth, wBorders;
            // Ekstra
            public uint dwReserved;
            public short wReserved2, wReserved3;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(
            IntPtr hWnd,
            int msg,
            IntPtr wParam,
            ref PARAFORMAT2 lParam
        );

        private void SetParagraphSpacing(int beforeTwip, int afterTwip)
        {
            PARAFORMAT2 fmt = new PARAFORMAT2();
            fmt.cbSize = Marshal.SizeOf<PARAFORMAT2>();
            fmt.dwMask = PFM_SPACEBEFORE | PFM_SPACEAFTER; // Sadece bu iki alan
            fmt.dySpaceBefore = beforeTwip; // Paragraf öncesi boşluk (twip)
            fmt.dySpaceAfter = afterTwip; // Paragraf sonrası boşluk (twip)

            SendMessage(
                richTextBox.Handle,
                EM_SETPARAFORMAT,
                (IntPtr)SCF_SELECTION,
                ref fmt
            );
        }
        private void UpdateToolbarAlignmentState()
        {
            btnAlignLeft.Checked = false;
            btnAlignCenter.Checked = false;
            btnAlignRight.Checked = false;

            PARAFORMAT2 pf = new PARAFORMAT2();
            pf.cbSize = Marshal.SizeOf(typeof(PARAFORMAT2));
            SendMessage(richTextBox.Handle, EM_GETPARAFORMAT, (IntPtr)SCF_SELECTION, ref pf);

            switch (pf.wAlignment)
            {
                case PFA_LEFT: btnAlignLeft.Checked = true; break;
                case PFA_CENTER: btnAlignCenter.Checked = true; break;
                case PFA_RIGHT: btnAlignRight.Checked = true; break;
            }
        }
        
    }
}

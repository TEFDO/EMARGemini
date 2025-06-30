using EMAR.Helpers;
using EMAR.Models;
using EMAR.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EMAR.UControls.Buton
{
    public partial class ucGorselYerlesim : UserControl
    {
        // Parametreler (tümünü üstten set etmen gerekir)
        public string DbYolu { get; set; } // Üst formdan set edilecek!
        public string ProjeKodu { get; set; }
        public string RaporTuru { get; set; }
        public int SiraNo { get; set; }
        public string MakineAdi { get; set; }
        public int BolgeNo { get; set; }
        public int RiskNo { get; set; }
        public string GorselTip { get; set; } = "MevcutDurum"; // "Modifikasyon", "GenelBilgilendirme" vs.

        private List<GorselYerlesimModel> gorselListesi = new();

        private int selectedIndex = -1;
        private Panel draggingPanel = null;
        private Point dragStart;
        private Panel scrollPanel;

        public ucGorselYerlesim()
        {
            InitializeComponent();

            scrollPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                AutoSize = true,
            };
            scrollPanel.Controls.Add(tblGorseller);
            layoutMain.Controls.Remove(tblGorseller);
            layoutMain.Controls.Add(scrollPanel, 0, 1);

            tblGorseller.Dock = DockStyle.Top;

            cmbYerlesim.SelectedIndex = 0;
            cmbYerlesim.SelectedIndexChanged += (s, e) => YenidenYerlesim();
            btnGorselEkle.Click += BtnGorselEkle_Click;
            btnSil.Click += BtnSil_Click;
            btnKaydet.Click += BtnKaydet_Click;
        }
        // --- THUMBNAIL YÜKLEYEN KÜÇÜK YARDIMCI FONKSİYON ---
        private Image LoadThumbnail(string path, Size maxSize)
        {
            using (var img = Image.FromFile(path))
            {
                var ratioX = (double)maxSize.Width / img.Width;
                var ratioY = (double)maxSize.Height / img.Height;
                var ratio = Math.Min(ratioX, ratioY);

                var newWidth = (int)(img.Width * ratio);
                var newHeight = (int)(img.Height * ratio);

                var thumb = new Bitmap(newWidth, newHeight);
                using (var g = Graphics.FromImage(thumb))
                    g.DrawImage(img, 0, 0, newWidth, newHeight);
                return thumb;
            }
        }
        // --- 2) GÖRSEL EKLEME ---
        // --- GÖRSEL EKLEME ---
        private void BtnGorselEkle_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "Görsel Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp",
                Multiselect = true
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;

            if (BolgeNo <= 0 || RiskNo <= 0)
            {
                MessageBox.Show("Görsel klasörü için geçersiz BölgeNo veya RiskNo.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string baseDir = Path.GetDirectoryName(DbYolu);
            string hedefKlasor = Path.Combine(baseDir, "Gorseller", GorselTip, $"Risk_{BolgeNo}.{RiskNo}");
            Directory.CreateDirectory(hedefKlasor);

            foreach (var path in ofd.FileNames)
            {
                // --- Güvenli dosya adı kontrolü ---
                string hedefDosyaAdi = Path.GetFileName(path);

                // Geçersiz karakter kontrolü
                if (hedefDosyaAdi.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                {
                    MessageBox.Show($"Geçersiz dosya adı: {hedefDosyaAdi}");
                    continue;
                }
                // Path traversal engelle
                if (hedefDosyaAdi.Contains("..") || hedefDosyaAdi.Contains("/") || hedefDosyaAdi.Contains("\\"))
                {
                    MessageBox.Show($"Geçersiz yol: {hedefDosyaAdi}");
                    continue;
                }

                string hedefDosyaYolu = Path.Combine(hedefKlasor, hedefDosyaAdi);
                int counter = 1;
                while (File.Exists(hedefDosyaYolu))
                {
                    string nameNoExt = Path.GetFileNameWithoutExtension(hedefDosyaAdi);
                    string ext = Path.GetExtension(hedefDosyaAdi);
                    hedefDosyaAdi = $"{nameNoExt}_{counter}{ext}";
                    hedefDosyaYolu = Path.Combine(hedefKlasor, hedefDosyaAdi);
                    counter++;
                }

                // Son güvenlik: hedef yol ana klasör altında mı?
                string fullPath = Path.GetFullPath(hedefDosyaYolu);
                if (!fullPath.StartsWith(hedefKlasor, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Yetkisiz yol oluşturma girişimi engellendi.");
                    continue;
                }

                File.Copy(path, hedefDosyaYolu, true);

                string relativePath = Path.Combine("Gorseller", GorselTip, $"Risk_{BolgeNo}.{RiskNo}", hedefDosyaAdi).Replace("\\", "/");

                using var titleForm = new TitleInputForm(Path.GetFileName(path));
                if (titleForm.ShowDialog() == DialogResult.OK)
                {
                    gorselListesi.Add(new GorselYerlesimModel()
                    {
                        ImagePath = relativePath,
                        Title = titleForm.TitleText
                    });
                }
            }

            YenidenYerlesim();
        }
        // --- PANEL SİLİNİRKEN İÇİNDEKİ TÜM GÖRSELLERİ RAM'DEN TEMİZLE ---
        private void TemizleTumGorselPaneller()
        {
            foreach (Control ctrl in tblGorseller.Controls)
            {
                if (ctrl is Panel p)
                {
                    foreach (Control inner in p.Controls)
                        if (inner is PictureBox pb && pb.Image != null)
                        {
                            pb.Image.Dispose();
                            pb.Image = null;
                        }
                    p.Dispose();
                }
            }
            tblGorseller.Controls.Clear();
            tblGorseller.RowStyles.Clear();
            tblGorseller.ColumnStyles.Clear();
        }

        // --- 3) SİLME ---
        // --- SİLME ---
        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 0 || selectedIndex >= gorselListesi.Count)
            {
                MessageBox.Show("Silinecek görsel yok.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string baseDir = Path.GetDirectoryName(DbYolu);
            string tamYol = Path.Combine(baseDir, gorselListesi[selectedIndex].ImagePath);
            if (File.Exists(tamYol))
            {
                // İlgili PictureBox RAM’den atılıyor
                foreach (Control control in tblGorseller.Controls)
                {
                    if (control is Panel p)
                    {
                        foreach (Control inner in p.Controls)
                        {
                            if (inner is PictureBox pb && pb.Image != null && pb.Tag?.ToString() == gorselListesi[selectedIndex].ImagePath)
                            {
                                pb.Image.Dispose();
                                pb.Image = null;
                            }
                        }
                    }
                }
                File.Delete(tamYol);
            }

            gorselListesi.RemoveAt(selectedIndex);
            selectedIndex = -1;
            YenidenYerlesim();
        }

        // --- 4) KAYDETME (UI'de tablo/yerleşim, DB'ye yazma dışarıdan) ---
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // Diğer tüm resimleri default yap
            for (int j = 0; j < gorselListesi.Count; j++)
            {
                gorselListesi[j].LayoutType = cmbYerlesim.SelectedIndex;
                gorselListesi[j].IsFill = false;
                gorselListesi[j].IsCenter = false;
            }

            if (cmbYerlesim.SelectedIndex == 0 && gorselListesi.Count % 2 == 1)
            {
                // Kullanıcıya ortalama/büyütme/sola yaslama seçenekleri
                var secim = MessageBox.Show(
                    "Son görseli küçük ortalı mı (Evet), büyük yay mı (İptal), yoksa sola mı yaslansın (Hayır)?",
                    "Son Görsel Yerleşimi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (secim == DialogResult.Yes) // Küçük ve ortalı
                {
                    gorselListesi[^1].IsCenter = true;
                    gorselListesi[^1].IsFill = false;
                }
                else if (secim == DialogResult.Cancel) // Büyük yay
                {
                    gorselListesi[^1].IsCenter = false;
                    gorselListesi[^1].IsFill = true;
                }
                else // Hayır: sola yasla (default)
                {
                    gorselListesi[^1].IsCenter = false;
                    gorselListesi[^1].IsFill = false;
                }
            }

            YenidenYerlesim();
        }

        // --- 5) YENİDEN YERLEŞİM VE PANEL OLUŞTURMA ---
        // --- YENİDEN YERLEŞİM ---
        private void YenidenYerlesim()
        {
            TemizleTumGorselPaneller();

            tblGorseller.SuspendLayout();

            int columns = cmbYerlesim.SelectedIndex == 0 ? 2 : 1;
            tblGorseller.ColumnCount = columns;
            for (int i = 0; i < columns; i++)
                tblGorseller.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / columns));

            int idx = 0;
            while (idx < gorselListesi.Count)
            {
                bool isLast = (idx == gorselListesi.Count - 1);
                var item = gorselListesi[idx];

                if (columns == 1)
                {
                    tblGorseller.RowCount++;
                    tblGorseller.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    var panel = CreateGorselPanel(item, idx, columns);
                    tblGorseller.Controls.Add(panel, 0, tblGorseller.RowCount - 1);
                    idx++;
                }
                else
                {
                    if (isLast && item.IsCenter && !item.IsFill)
                    {
                        tblGorseller.RowCount++;
                        tblGorseller.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        var panel = CreateGorselPanel(item, idx, columns);
                        tblGorseller.Controls.Add(panel, 0, tblGorseller.RowCount - 1);
                        tblGorseller.SetColumnSpan(panel, 2);
                        idx++;
                    }
                    else if (isLast && item.IsFill)
                    {
                        tblGorseller.RowCount++;
                        tblGorseller.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        var panel = CreateGorselPanel(item, idx, columns);
                        tblGorseller.Controls.Add(panel, 0, tblGorseller.RowCount - 1);
                        tblGorseller.SetColumnSpan(panel, 2);
                        idx++;
                    }
                    else if (isLast)
                    {
                        tblGorseller.RowCount++;
                        tblGorseller.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        var panel = CreateGorselPanel(item, idx, columns);
                        tblGorseller.Controls.Add(panel, 0, tblGorseller.RowCount - 1);

                        var dummy = new Panel
                        {
                            Width = panel.Width,
                            Height = panel.Height,
                            BackColor = Color.Transparent
                        };
                        tblGorseller.Controls.Add(dummy, 1, tblGorseller.RowCount - 1);

                        idx++;
                    }
                    else
                    {
                        tblGorseller.RowCount++;
                        tblGorseller.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        var panel1 = CreateGorselPanel(gorselListesi[idx], idx, columns);
                        var panel2 = CreateGorselPanel(gorselListesi[idx + 1], idx + 1, columns);
                        tblGorseller.Controls.Add(panel1, 0, tblGorseller.RowCount - 1);
                        tblGorseller.Controls.Add(panel2, 1, tblGorseller.RowCount - 1);
                        idx += 2;
                    }
                }
            }
            tblGorseller.ResumeLayout();
        }

        // --- GÖRSEL PANEL OLUŞTURURKEN RAM OPTİMİZASYONU ---
        private Panel CreateGorselPanel(GorselYerlesimModel item, int index, int columns)
        {
            int availableWidth = scrollPanel.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 30;
            if (availableWidth < 200) availableWidth = 200;

            int panelWidth = columns == 1
                ? availableWidth
                : (availableWidth / 2 - 15);

            if (columns == 2 && item.IsFill)
                panelWidth = availableWidth;

            int imageHeight = (int)(panelWidth * 0.66);
            int titleHeight = 30;
            int totalHeight = imageHeight + titleHeight;

            var panel = new Panel
            {
                Width = panelWidth,
                Height = totalHeight,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle,
                Tag = item,
                AllowDrop = true,
                BackColor = (index == selectedIndex) ? Color.LightBlue : SystemColors.Control
            };

            if (item.IsCenter && columns == 2)
                panel.Anchor = AnchorStyles.None;

            var title = new TextBox
            {
                Text = item.Title,
                Dock = DockStyle.Top,
                Height = titleHeight,
                TextAlign = HorizontalAlignment.Center,
                ReadOnly = false,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = Color.WhiteSmoke
            };
            title.TextChanged += (s, e) => { item.Title = title.Text.Trim(); };

            var pb = new PictureBox
            {
                Height = imageHeight,
                Dock = DockStyle.Top,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.White,
                AllowDrop = true,
                Tag = item.ImagePath,
                BorderStyle = BorderStyle.None
            };

            string baseDir = Path.GetDirectoryName(DbYolu);
            string tamYol = Path.Combine(baseDir, item.ImagePath);
            try
            {
                if (File.Exists(tamYol))
                {
                    pb.Image = LoadThumbnail(tamYol, new Size(panelWidth, imageHeight));
                }
                else
                    pb.BackColor = Color.Red;
            }
            catch
            {
                pb.BackColor = Color.Red;
            }

            title.MouseDown += Drag_MouseDown;
            title.MouseMove += Drag_MouseMove;

            pb.Click += (s, e) => SelectPanel(panel, item);
            pb.MouseDown += Drag_MouseDown;
            pb.MouseMove += Drag_MouseMove;
            pb.DragEnter += (s, e) =>
            {
                if (e.Data.GetDataPresent(typeof(Panel))) e.Effect = DragDropEffects.Move;
            };
            pb.DragDrop += Drag_Drop;

            panel.MouseDown += Drag_MouseDown;
            panel.MouseMove += Drag_MouseMove;
            panel.DragEnter += (s, e) =>
            {
                if (e.Data.GetDataPresent(typeof(Panel))) e.Effect = DragDropEffects.Move;
            };
            panel.DragDrop += Drag_Drop;

            panel.Controls.Add(pb);
            panel.Controls.Add(title);

            return panel;
        }

        private void SelectPanel(Panel panel, GorselYerlesimModel item)
        {
            selectedIndex = gorselListesi.FindIndex(g => g.ImagePath == item.ImagePath);

            foreach (Control c in tblGorseller.Controls)
            {
                if (c is Panel p)
                {
                    p.BackColor = SystemColors.Control;
                    foreach (Control inner in p.Controls)
                        if (inner is PictureBox pb)
                            pb.BorderStyle = BorderStyle.None;
                }
            }

            panel.BackColor = Color.LightBlue;
            panel.BringToFront();

            foreach (Control inner in panel.Controls)
                if (inner is PictureBox pb)
                    pb.BorderStyle = BorderStyle.Fixed3D;
        }
        private void Drag_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Control ctrl && ctrl.Parent is Panel p)
            {
                draggingPanel = p;
                dragStart = e.Location;
            }
        }

        private void Drag_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggingPanel == null || e.Button != MouseButtons.Left)
                return;

            var delta = new Point(e.X - dragStart.X, e.Y - dragStart.Y);
            if (Math.Abs(delta.X) > SystemInformation.DragSize.Width / 2 ||
                Math.Abs(delta.Y) > SystemInformation.DragSize.Height / 2)
            {
                draggingPanel.DoDragDrop(draggingPanel, DragDropEffects.Move);
            }
        }

        private void Drag_Drop(object sender, DragEventArgs e)
        {
            if (draggingPanel == null || !(e.Data.GetData(typeof(Panel)) is Panel targetPanel)) return;

            var sourceItem = draggingPanel.Tag as GorselYerlesimModel;
            var targetItem = targetPanel.Tag as GorselYerlesimModel;

            if (sourceItem == null || targetItem == null) return;

            int sourceIndex = gorselListesi.FindIndex(g => g.ImagePath == sourceItem.ImagePath);
            int targetIndex = gorselListesi.FindIndex(g => g.ImagePath == targetItem.ImagePath);

            if (sourceIndex == -1 || targetIndex == -1 || sourceIndex == targetIndex) return;

            var temp = gorselListesi[sourceIndex];
            gorselListesi.RemoveAt(sourceIndex);
            gorselListesi.Insert(targetIndex, temp);
            selectedIndex = targetIndex;

            draggingPanel = null;
            YenidenYerlesim();
        }

        // --- 6) JSON FONKSİYONLARI (DB için) ---
        public string GetGorselListesiJson() => JsonConvert.SerializeObject(gorselListesi);
        public void LoadGorselListesiFromJson(string json)
        {
            gorselListesi = string.IsNullOrEmpty(json)
                ? new List<GorselYerlesimModel>()
                : JsonConvert.DeserializeObject<List<GorselYerlesimModel>>(json);

            // 🔧 LayoutType değeri varsa ilkinden ayarla
            if (gorselListesi.Count > 0)
                cmbYerlesim.SelectedIndex = gorselListesi[0].LayoutType;

            YenidenYerlesim();
        }

        // İsteyen için doğrudan liste referansı (readonly önerilir)
        public IReadOnlyList<GorselYerlesimModel> GetCurrentList() => gorselListesi.AsReadOnly();

        // --- Güvenli yol oluşturma örneği ---
        private void SecurePathExample(string userInput)
        {
            string baseDir = "C:\\Data"; // Ana dizin (sabit)

            // 1. Geçersiz karakter kontrolü
            if (userInput.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                MessageBox.Show("Geçersiz dosya adı!");
                return;
            }

            // 2. Path traversal engelle
            if (userInput.Contains("..") || userInput.Contains("/") || userInput.Contains("\\"))
            {
                MessageBox.Show("Geçersiz yol!");
                return;
            }

            // 3. Tam yolu oluştur ve normalize et
            string fullPath = Path.Combine(baseDir, userInput);
            fullPath = Path.GetFullPath(fullPath);

            // 4. Ana dizin sınırı kontrolü
            if (!fullPath.StartsWith(baseDir, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Yetkisiz yol!");
                return;
            }

            // 5. Artık güvenli şekilde kullanabilirsiniz
            if (File.Exists(fullPath))
            {
                string content = File.ReadAllText(fullPath);
                // ... işlemler ...
            }
            else
            {
                MessageBox.Show("Dosya bulunamadı!");
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            // Örnek: kullanıcıdan alınan bir dosya adı ile çağır
            string kullaniciGirdisi = "kullanici_girdisi.txt";
            SecurePathExample(kullaniciGirdisi);
        }
    }


    // --- Görsele Başlık Input Formu ---
    public class TitleInputForm : Form
    {
        public string TitleText { get; private set; }
        private TextBox txtTitle;

        public TitleInputForm(string defaultTitle = "")
        {
            this.Text = "Görsele Başlık Ekle";
            this.Size = new Size(400, 250);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var lbl = new Label
            {
                Text = "Başlık:",
                Left = 15,
                Top = 10,
                Width = 340,
                Height = 40,
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };

            txtTitle = new TextBox
            {
                Left = 20,
                Top = 50,
                Width = 340,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Text = defaultTitle
            };

            var btnOK = new Button
            {
                Text = "Tamam",
                Left = 140,
                Top = 120,
                Width = 100,
                Height = 50,
                DialogResult = DialogResult.OK
            };

            btnOK.Click += (s, e) =>
            {
                TitleText = txtTitle.Text.Trim();
                Close();
            };

            Controls.Add(lbl);
            Controls.Add(txtTitle);
            Controls.Add(btnOK);
        }

    }

}


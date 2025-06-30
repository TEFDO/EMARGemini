using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using EMAR.Models;
using EMAR.Repositories;

namespace EMAR
{
    public partial class ucMakineGorselleri : UserControl
    {
        public string DbYolu { get; set; }
        public string RaporKodu { get; set; }
        private PictureBox selectedPictureBox = null;
        private Point dragStartPoint;
        private MakineGorselRepository repository;

        public ucMakineGorselleri()
        {
            InitializeComponent();
        }

        private void ucMakineGorselleri_Load(object sender, EventArgs e)
        {
            TemizleGorseller();
            ofdResim.Multiselect = true;
            ofdResim.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            flwGorseller.AllowDrop = true;
            repository = new MakineGorselRepository(DbYolu);
            repository.EnsureTable();

            try
            {
                LoadGorsellerFromDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Görseller yüklenirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGorsellerFromDatabase()
        {
            TemizleGorseller();
            if (string.IsNullOrWhiteSpace(DbYolu) || !File.Exists(DbYolu))
                return;

            var liste = repository.GetAll();
            string dbKlasor = Path.GetDirectoryName(DbYolu);

            foreach (var gorsel in liste)
            {
                string relPath = gorsel.DosyaYolu.Replace("/", Path.DirectorySeparatorChar.ToString());
                string fullPath = Path.Combine(dbKlasor, relPath);

                if (File.Exists(fullPath))
                {
                    try { AddPictureBox(fullPath); }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"'{Path.GetFileName(fullPath)}' yüklenemedi:\n{ex.Message}", "Görsel Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        // RESİMLERİ THUMBNAIL OLARAK YÜKLE
        private void AddPictureBox(string imagePath)
        {
            var pb = new PictureBox
            {
                Size = new Size(500, 360),
                SizeMode = PictureBoxSizeMode.Zoom,
                Margin = new Padding(20),
                Tag = imagePath,
                AllowDrop = true
            };

            // Thumbnail üret!
            pb.Image = LoadThumbnail(imagePath, pb.Size);

            pb.Click += PictureBox_Click;
            pb.MouseDown += PictureBox_MouseDown;
            pb.MouseMove += PictureBox_MouseMove;
            pb.MouseUp += PictureBox_MouseUp;
            pb.DragEnter += PictureBox_DragEnter;
            pb.DragDrop += PictureBox_DragDrop;

            flwGorseller.Controls.Add(pb);
        }

        // Thumbnail için RAM dostu yöntem
        private Image LoadThumbnail(string imagePath, Size maxSize)
        {
            using (var img = Image.FromFile(imagePath))
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

        // ... (Diğer eventler aynen devam, sadece resim eklemede de thumbnail yüklemesi olacak) ...

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (ofdResim.ShowDialog() != DialogResult.OK)
                return;

            foreach (var filePath in ofdResim.FileNames)
            {
                try
                {
                    if (!File.Exists(filePath))
                        continue;

                    // Aynı içerikte resim zaten varsa tekrar ekleme:
                    bool alreadyExists = false;
                    foreach (Control ctrl in flwGorseller.Controls)
                    {
                        if (ctrl is PictureBox pb && pb.Image != null)
                        {
                            // Sadece boyut ve dosya adıyla kontrol et (çok büyük RAM tasarrufu için)
                            if (pb.Tag?.ToString() == filePath)
                            {
                                alreadyExists = true;
                                break;
                            }
                        }
                    }
                    if (alreadyExists)
                        continue;

                    // RAM dostu thumbnail yükle
                    PictureBox newPb = new PictureBox
                    {
                        Size = new Size(500, 360),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Margin = new Padding(20),
                        AllowDrop = true,
                        Image = LoadThumbnail(filePath, new Size(500, 360)),
                        Tag = filePath
                    };
                    newPb.Click += PictureBox_Click;
                    // ... diğer eventler
                    flwGorseller.Controls.Add(newPb);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Geçersiz görsel: {Path.GetFileName(filePath)}\n{ex.Message}", "Görsel Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // ... (Drag/drop, mouse, sıralama vs. tüm eventler aynen kalabilir) ...

        public void TemizleGorseller()
        {
            try
            {
                foreach (Control ctrl in flwGorseller.Controls)
                {
                    if (ctrl is PictureBox pb)
                    {
                        pb.Image?.Dispose();
                        pb.Dispose();
                    }
                }
                flwGorseller.Controls.Clear();
                // GC.Collect ve GC.WaitForPendingFinalizers KALDIRILDI!
            }
            catch (Exception ex)
            {
                MessageBox.Show("Görseller temizlenirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void PictureBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(PictureBox)) ? DragDropEffects.Move : DragDropEffects.None;
        }
        private void PictureBox_DragDrop(object sender, DragEventArgs e)
        {
            flwGorseller_DragDrop(flwGorseller, e);
        }
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                dragStartPoint = e.Location;
        }
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is not PictureBox pb || e.Button != MouseButtons.Left)
                return;

            var dragThreshold = SystemInformation.DragSize;
            if (Math.Abs(e.X - dragStartPoint.X) >= dragThreshold.Width / 2 ||
                Math.Abs(e.Y - dragStartPoint.Y) >= dragThreshold.Height / 2)
            {
                pb.DoDragDrop(pb, DragDropEffects.Move);
            }
        }
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            dragStartPoint = Point.Empty;
        }
        private void flwGorseller_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(PictureBox)) ? DragDropEffects.Move : DragDropEffects.None;
        }
        private void flwGorseller_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(PictureBox)) is not PictureBox draggedBox)
                return;

            Point dropPoint = flwGorseller.PointToClient(new Point(e.X, e.Y));
            Control target = flwGorseller.GetChildAtPoint(dropPoint);

            if (target is null || ReferenceEquals(target, draggedBox))
            {
                foreach (Control ctrl in flwGorseller.Controls)
                {
                    if (ctrl != draggedBox && ctrl.Bounds.Contains(dropPoint))
                    {
                        target = ctrl;
                        break;
                    }
                }
            }

            if (target is null || ReferenceEquals(target, draggedBox))
                return;

            if (flwGorseller.Controls.Contains(draggedBox) && flwGorseller.Controls.Contains(target))
            {
                int targetIndex = flwGorseller.Controls.GetChildIndex(target);
                flwGorseller.Controls.SetChildIndex(draggedBox, targetIndex);
                flwGorseller.Invalidate();

                KaydetSiralama();
            }
        }
        private void KaydetSiralama()
        {
            if (string.IsNullOrWhiteSpace(DbYolu) || !File.Exists(DbYolu))
            {
                MessageBox.Show("Veritabanı yolu geçerli değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string gorselKlasor = Path.Combine(Path.GetDirectoryName(DbYolu), "MakineGorselleri");
            Directory.CreateDirectory(gorselKlasor);

            // Eski görselleri temizle
            foreach (var file in Directory.GetFiles(gorselKlasor, "MakineGorsel_*.png"))
            {
                try { File.Delete(file); } catch { }
            }

            var gorselListesi = new List<MakineGorsel>();
            int index = 1;

            foreach (Control ctrl in flwGorseller.Controls)
            {
                if (ctrl is PictureBox pb && pb.Image != null)
                {
                    string fileName = $"MakineGorsel_{index:00}.png";
                    string fullPath = Path.Combine(gorselKlasor, fileName);

                    // Dosyayı yeni isimle kaydet
                    using (var bmp = new Bitmap(pb.Image))
                    {
                        bmp.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);
                    }

                    string relativePath = Path.Combine("MakineGorselleri", fileName).Replace("\\", "/");
                    gorselListesi.Add(new MakineGorsel { DosyaYolu = relativePath });

                    // UI'daki Tag'i de güncelle (ileri kaydetmelerde doğru yol olsun!)
                    pb.Tag = fullPath;

                    index++;
                }
            }

            repository.ClearAll();
            repository.InsertBulk(gorselListesi);

            // Orijinal adla eklenmiş dosyaları silebilirsin:
            // (MakineGorsel_*.png dışındaki dosyaları buradan silebilirsin)
            foreach (var file in Directory.GetFiles(gorselKlasor))
            {
                if (!file.Contains("MakineGorsel_"))
                {
                    try { File.Delete(file); } catch { }
                }
            }

            MessageBox.Show("Sıralama ve görseller başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TemizleMakineGorselleriKlasoru();
        }
        public static bool FilesAreEqual(string filePath, Image image)
        {
            using (var bmp = new Bitmap(filePath))
            {
                if (bmp.Size != image.Size) return false;
                for (int x = 0; x < bmp.Width; x++)
                for (int y = 0; y < bmp.Height; y++)
                    if (bmp.GetPixel(x, y) != ((Bitmap)image).GetPixel(x, y))
                        return false;
                return true;
            }
        }
        private void TemizleMakineGorselleriKlasoru()
        {
            string gorselKlasor = Path.Combine(Path.GetDirectoryName(DbYolu), "MakineGorselleri");
            foreach (var file in Directory.GetFiles(gorselKlasor))
            {
                if (!Path.GetFileName(file).StartsWith("MakineGorsel_"))
                {
                    try { File.Delete(file); } catch { }
                }
            }
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            foreach (PictureBox pb in flwGorseller.Controls)
                pb.BorderStyle = BorderStyle.None;

            if (sender is PictureBox clicked)
            {
                selectedPictureBox = clicked;
                selectedPictureBox.BorderStyle = BorderStyle.Fixed3D;
                selectedPictureBox.BringToFront();
            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (selectedPictureBox == null)
            {
                MessageBox.Show("Lütfen silinecek bir görsel seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filePath = selectedPictureBox.Tag?.ToString();

            if (string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("Seçili görselin dosya yolu bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string dbKlasor = Path.GetDirectoryName(DbYolu);
                string relativePath = Path.GetRelativePath(dbKlasor, filePath).Replace("\\", "/");

                repository.DeleteByPath(relativePath);

                if (File.Exists(filePath))
                    File.Delete(filePath);

                selectedPictureBox.Image?.Dispose();
                flwGorseller.Controls.Remove(selectedPictureBox);
                selectedPictureBox.Dispose();
                selectedPictureBox = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi sırasında hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        // Thumbnail fonksiyonunu burada kullanmıyoruz, eklemek istersen aynı mantıkla kullanabilirsin.
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            KaydetSiralama();
        }
        
    }
}

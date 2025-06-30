using EMAR.Models;
using EMAR.Repository;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EMAR.UControls
{
    public partial class ucBolgeDetay : UserControl
    {
        public int BolgeId { get; set; }
        public string DbYolu { get; set; }
        public string BolgeGorselYolu { get; set; }
        public string BolgeAdi
        {
            get => lblBaslik.Text;
            set => lblBaslik.Text = value;
        }

        public string Aciklama
        {
            get => txtAciklama.Text;
            set => txtAciklama.Text = value;
        }

        public string Notlar
        {
            get => txtNotlar.Text;
            set => txtNotlar.Text = value;
        }

        public Image BolgeGorsel
        {
            get => picGorsel.Image;
            set => picGorsel.Image = value;
        }

        public ucBolgeDetay()
        {
            InitializeComponent();

            btnGorselSec.Click += btnGorselSec_Click;
            btnGorselTemizle.Click += btnGorselTemizle_Click;
        }

        public void Yukle()
        {
            if (!File.Exists(DbYolu)) return;

            var repo = new BolgeGenelRepository(DbYolu);
            repo.EnsureTable();

            var veri = repo.GetById(BolgeId);
            if (veri == null) return;

            txtAciklama.Text = veri.Aciklama;
            txtNotlar.Text = veri.Notlar;

            if (!string.IsNullOrWhiteSpace(veri.Gorsel))
            {
                string tamYol = Path.Combine(Path.GetDirectoryName(DbYolu), veri.Gorsel);
                if (File.Exists(tamYol))
                {
                    using var fs = new FileStream(tamYol, FileMode.Open, FileAccess.Read);
                    picGorsel.Image?.Dispose();
                    picGorsel.Image = Image.FromStream(fs);
                }
            }
        }
        public void Kaydet()
        {
            if (!File.Exists(DbYolu)) return;

            string gorselYolu = null;
            string klasor = Path.Combine(Path.GetDirectoryName(DbYolu), "Gorseller", "Bolge");
            Directory.CreateDirectory(klasor);

            if (picGorsel.Image != null)
            {
                string dosyaAdi = $"Bolge_{BolgeId}_Gorsel.png";
                string tamYol = Path.Combine(klasor, dosyaAdi);
                picGorsel.Image.Save(tamYol, System.Drawing.Imaging.ImageFormat.Png);
                gorselYolu = Path.GetRelativePath(Path.GetDirectoryName(DbYolu), tamYol).Replace("\\", "/");
            }

            var veri = new BolgeGenel
            {
                BolgeId = BolgeId,
                Aciklama = txtAciklama.Text,
                Notlar = txtNotlar.Text,
                Gorsel = this.BolgeGorselYolu
            };


            var repo = new BolgeGenelRepository(DbYolu);
            repo.EnsureTable();
            repo.Save(veri);
        }

        private void btnGorselSec_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Bölge Görseli Seç"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string hedefKlasor = Path.Combine(Path.GetDirectoryName(DbYolu), "Gorseller", "Bolge");
                Directory.CreateDirectory(hedefKlasor);

                string ext = Path.GetExtension(ofd.FileName);
                string dosyaAdi = $"Bolge_{BolgeId}_{DateTime.Now:yyyyMMddHHmmssfff}{ext}";
                string hedef = Path.Combine(hedefKlasor, dosyaAdi);

                File.Copy(ofd.FileName, hedef, true);
                picGorsel.Image?.Dispose();
                picGorsel.Image = Image.FromFile(hedef);

                // Kayıt için property’ye yaz
                this.BolgeGorselYolu = Path.Combine("Gorseller", "Bolge", dosyaAdi).Replace("\\", "/");
            }
        }



        private void btnGorselTemizle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.BolgeGorselYolu))
            {
                string tamYol = Path.Combine(Path.GetDirectoryName(DbYolu), this.BolgeGorselYolu);
                if (File.Exists(tamYol)) File.Delete(tamYol);
            }

            picGorsel.Image?.Dispose();
            picGorsel.Image = null;
        }
    }
}
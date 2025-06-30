// Güncellenmiş frmMusteriKayit.cs – Repository entegrasyonu ile
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using EMAR.Helpers;
using EMAR.Models;
using EMAR.Repository;

namespace EMAR
{
    public partial class frmMusteriKayit : Form
    {
        public Musteri Musteri { get; set; } = new();
        public bool DuzenlemeModu { get; set; } = false;
        private Size orijinalLogoSize;

        public frmMusteriKayit()
        {
            InitializeComponent();
        }

        public frmMusteriKayit(Musteri musteri) : this()
        {
            Musteri = musteri;
            DuzenlemeModu = true;
        }

        private void frmMusteriKayit_Load(object sender, EventArgs e)
        {
            Text = DuzenlemeModu ? "Müşteri Düzenle" : "Yeni Müşteri Ekle";

            if (Musteri is not null)
            {
                txtAd.Text = Musteri.Ad;
                txtAdres.Text = Musteri.Adres;

                if (Musteri.Logo is not null)
                {
                    using var ms = new MemoryStream(Musteri.Logo);
                    picLogo.Image = Image.FromStream(ms);
                }
            }

            orijinalLogoSize = picLogo.Size;
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.MouseEnter += picLogo_MouseEnter;
            picLogo.MouseLeave += picLogo_MouseLeave;
        }

        private void picLogo_MouseEnter(object sender, EventArgs e)
        {
            picLogo.Size = new Size(orijinalLogoSize.Width + 20, orijinalLogoSize.Height + 20);
        }

        private void picLogo_MouseLeave(object sender, EventArgs e)
        {
            picLogo.Size = orijinalLogoSize;
        }

        private void btnLogoSec_Click(object sender, EventArgs e)
        {
            ofdLogo.Filter = "Resim Dosyaları (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";
            ofdLogo.Title = "Logo Seç";
            ofdLogo.RestoreDirectory = true;

            if (ofdLogo.ShowDialog() == DialogResult.OK)
            {
                picLogo.Image = Image.FromFile(ofdLogo.FileName);
            }
        }

        private void btnLogoTemizle_Click(object sender, EventArgs e)
        {
            picLogo.Image?.Dispose();
            picLogo.Image = null;
            Musteri.Logo = null;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!FormValidator.ZorunluAlanlariKontrolEt(
                ("Müşteri Adı", txtAd.Text),
                ("Adres", txtAdres.Text)))
                return;

            Musteri.Ad = txtAd.Text.Trim();
            Musteri.Adres = txtAdres.Text.Trim();

            if (picLogo.Image is Bitmap bmp)
            {
                using var ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                Musteri.Logo = ms.ToArray();
            }

            try
            {
                Musteri.Id = MusteriRepository.Kaydet(Musteri, DuzenlemeModu);

                MessageBox.Show("Müşteri bilgileri başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
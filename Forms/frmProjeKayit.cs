// frmProjeKayit.cs – Repository uyumlu güncellenmiş hali
using System;
using System.Data;
using System.Windows.Forms;
using EMAR.Helpers;
using EMAR.Models;
using EMAR.Repository;

namespace EMAR
{
    public partial class frmProjeKayit : Form
    {
        public Proje Proje { get; set; } = new Proje();
        public bool DuzenlemeModu { get; set; } = false;
        public int SeciliProjeId { get; set; } = -1;

        public frmProjeKayit()
        {
            InitializeComponent();
        }

        private void frmProjeKayit_Load(object sender, EventArgs e)
        {
            Text = DuzenlemeModu ? "Proje Düzenle" : "Yeni Proje Ekle";

            YukleMusteriler();
            YukleHizmetKodlari();

            if (DuzenlemeModu && SeciliProjeId > -1)
            {
                Proje = ProjeRepository.Getir(SeciliProjeId);
                if (Proje == null)
                {
                    MessageBox.Show("Proje bilgisi yüklenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }
            }

            ModeliFormaAktar();
        }

        private void YukleMusteriler()
        {
            try
            {
                var dt = VeritabaniHelper.TabloGetir("SELECT Id, Ad FROM Musteriler");
                cmbMusteri.DataSource = dt;
                cmbMusteri.DisplayMember = "Ad";
                cmbMusteri.ValueMember = "Id";
                cmbMusteri.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteriler yüklenemedi: " + ex.Message);
            }
        }
        private void YukleHizmetKodlari()
        {
            try
            {
                cmbHizmetKodu.Items.Clear();
                INIHelper.YukleCommaSeparated(cmbHizmetKodu, "HizmetKodlari"); // ✅ önerilen
                cmbHizmetKodu.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hizmet kodları yüklenemedi: " + ex.Message);
            }
        }
        private void ModeliFormaAktar()
        {
            txtAd.Text = Proje.Ad;
            txtProjeKodu.Text = Proje.ProjeKodu;
            txtAciklama.Text = Proje.Aciklama;
            if (!string.IsNullOrWhiteSpace(Proje.HizmetKodu) && cmbHizmetKodu.Items.Contains(Proje.HizmetKodu))
                cmbHizmetKodu.SelectedItem = Proje.HizmetKodu;
            else
                cmbHizmetKodu.Text = Proje.HizmetKodu;

            if (cmbMusteri.DataSource is DataTable dtMusteri)
            {
                foreach (DataRow row in dtMusteri.Rows)
                {
                    if (Convert.ToInt32(row["Id"]) == Proje.MusteriId)
                    {
                        cmbMusteri.SelectedValue = row["Id"];
                        break;
                    }
                }
            }

            if (DateTime.TryParse(Proje.Tarih, out DateTime parsedDate))
                dtpTarih.Value = parsedDate;
            else
                dtpTarih.Value = DateTime.Today;
        }

        private void FormuModeleAktar()
        {
            Proje.Ad = txtAd.Text.Trim();
            Proje.ProjeKodu = txtProjeKodu.Text.Trim();
            if (cmbMusteri.SelectedValue != null && int.TryParse(cmbMusteri.SelectedValue.ToString(), out int musteriId))
                Proje.MusteriId = musteriId;
            else
                Proje.MusteriId = -1;

            Proje.Tarih = dtpTarih.Value.ToString("yyyy-MM-dd");
            Proje.HizmetKodu = cmbHizmetKodu.Text.Trim();
            Proje.Aciklama = txtAciklama.Text.Trim();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!FormValidator.ZorunluAlanlariKontrolEt(
                ("Proje Adı", txtAd.Text),
                ("Proje Kodu", txtProjeKodu.Text)))
                return;

            if (cmbMusteri.SelectedValue == null || !int.TryParse(cmbMusteri.SelectedValue.ToString(), out int musteriId))
            {
                MessageBox.Show("Geçerli bir müşteri seçiniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FormuModeleAktar();

            if (ProjeRepository.ProjeKoduZatenVar(Proje.ProjeKodu, DuzenlemeModu ? Proje.Id : -1))
            {
                MessageBox.Show("Bu proje kodu zaten kullanılıyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ProjeRepository.Kaydet(Proje, DuzenlemeModu);
                MessageBox.Show("Proje başarıyla " + (DuzenlemeModu ? "güncellendi." : "kaydedildi."), "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHizmetEkle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hizmet kodları geçici olarak eklendi. Kalıcı hale gelmesi için INI dosyasına manuel eklenmesi gerekir.");
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
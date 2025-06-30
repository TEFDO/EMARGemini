using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EMAR.Models;
using EMAR.Repository;
using EMAR.Helpers;

namespace EMAR
{
    public partial class frmRaporlar : Form
    {
        private bool initializing = false;

        public frmRaporlar()
        {
            InitializeComponent();
        }

        private void frmRaporlar_Load(object sender, EventArgs e)
        {
            initializing = true;
            YukleProjeler();
            YukleRaporTurleri();
            initializing = false;
            RaporlariYukle();
        }

        private void YukleProjeler()
        {
            cmbProjeler.Items.Clear();
            cmbProjeler.Items.Add(new Proje { Id = 0, ProjeKodu = "Tüm Projeler" });
            var projeler = RaporRepository.Listele();
            foreach (var proje in projeler.Select(r => new Proje { Id = r.ProjeId, ProjeKodu = r.ProjeKodu }).DistinctBy(p => p.Id))
            {
                cmbProjeler.Items.Add(proje);
            }
            cmbProjeler.DisplayMember = "ProjeKodu";
            cmbProjeler.SelectedIndex = 0;
        }

        private void YukleRaporTurleri()
        {
            cmbRaporTurleri.Items.Clear();
            cmbRaporTurleri.Items.Add(new RaporTuru { Kod = "Tüm Raporlar" });

            var turler = RaporRepository.Listele()
                .Select(r => r.RaporTuruKod)
                .Distinct()
                .ToList();

            foreach (var kod in turler)
                cmbRaporTurleri.Items.Add(new RaporTuru { Kod = kod });

            cmbRaporTurleri.DisplayMember = "Kod";
            cmbRaporTurleri.SelectedIndex = 0;
        }

        private void RaporlariYukle()
        {
            if (cmbProjeler.SelectedItem is not Proje selectedProje || cmbRaporTurleri.SelectedItem is not RaporTuru selectedTur)
                return;

            int? pid = selectedProje.Id == 0 ? null : selectedProje.Id;
            string? kod = selectedTur.Kod == "Tüm Raporlar" ? null : selectedTur.Kod;

            var raporlar = RaporRepository.Listele(pid, kod);

            dgvRaporlar.DataSource = raporlar;
            dgvRaporlar.Columns["Id"].Visible = false;
            dgvRaporlar.Columns["ProjeId"].Visible = false;
            dgvRaporlar.Columns["MakineId"].Visible = false;

            dgvRaporlar.Columns["RaporKodu"].HeaderText = "Rapor Kodu";
            dgvRaporlar.Columns["ProjeKodu"].HeaderText = "Proje Kodu";
            dgvRaporlar.Columns["RaporTuruKod"].HeaderText = "Rapor Türü";
            dgvRaporlar.Columns["Tarih"].HeaderText = "Tarih";
            dgvRaporlar.Columns["MakineAdi"].HeaderText = "Makine Adı";
            dgvRaporlar.Columns["MusteriAdi"].HeaderText = "Müşteri Adı";
            // Sadece içeriğe göre genişlik ayarla
            dgvRaporlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Geniş olmasını istediğin sütunları elle genişlet (örneğin: Müşteri Adı, Rapor Kodu)
            dgvRaporlar.Columns["MusteriAdi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRaporlar.Columns["RaporKodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void cmbProjeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initializing) return;
            RaporlariYukle();
        }

        private void cmbRaporTurleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initializing) return;
            RaporlariYukle();
        }

        private void btnYeniRapor_Click(object sender, EventArgs e)
        {
            var frm = new frmRaporKayit();
            if (frm.ShowDialog() == DialogResult.OK)
                RaporlariYukle();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (dgvRaporlar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir rapor seçin.");
                return;
            }

            var rapor = dgvRaporlar.SelectedRows[0].DataBoundItem as Rapor;
            if (rapor == null) return;

            var frm = new frmRaporKayit
            {
                DuzenlemeModu = true,
                RaporKodu = rapor.RaporKodu,
                SiraNo = rapor.SiraNo,
                ProjeKodu = rapor.ProjeKodu,
                MakineAdi = rapor.MakineAdi,
                RaporTuruKod = rapor.RaporTuruKod,
                ProjeId = rapor.ProjeId,
                MakineId = rapor.MakineId
                // ... varsa diğer alanlar
            };
            if (frm.ShowDialog() == DialogResult.OK)
                RaporlariYukle();
        }


        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvRaporlar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir rapor seçin.");
                return;
            }

            string raporKodu = dgvRaporlar.SelectedRows[0].Cells["RaporKodu"].Value.ToString();

            // Güncel rapor modelini bul:
            var rapor = RaporRepository.Listele().FirstOrDefault(r => r.RaporKodu == raporKodu);
            if (rapor == null)
            {
                MessageBox.Show("Rapor bulunamadı!");
                return;
            }

            if (MessageBox.Show("Bu raporu silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                // --- .db dosyasını ve klasörleri sil ---
                string dbYolu = RaporKlasorYardimcisi.RaporDbYolu(
                    rapor.ProjeKodu,
                    rapor.RaporTuruKod,
                    rapor.SiraNo,
                    rapor.MakineAdi
                );

                // .db dosyasını sil
                if (File.Exists(dbYolu)) File.Delete(dbYolu);

                // Ana rapor klasörünü (Raporlar\ProjeKodu\RaporTuru\SiraNo-MakineAdi) komple silmek istersen:
                string raporAnaKlasor = RaporKlasorYardimcisi.RaporKlasoru(
                    rapor.ProjeKodu,
                    rapor.RaporTuruKod,
                    rapor.SiraNo,
                    rapor.MakineAdi
                );
                if (Directory.Exists(raporAnaKlasor))
                    Directory.Delete(raporAnaKlasor, true);

                RaporRepository.Sil(raporKodu);
                RaporlariYukle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme hatası: " + ex.Message);
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvRaporlar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var rapor = dgvRaporlar.Rows[e.RowIndex].DataBoundItem as Rapor;
            if (rapor == null) return;

            // .db yolunu güncel klasörleme ile bul:
            string dbYolu = RaporKlasorYardimcisi.RaporDbYolu(
                rapor.ProjeKodu,
                rapor.RaporTuruKod,
                rapor.SiraNo,
                rapor.MakineAdi
            );

            var frm = new frmRapor
            {
                RaporKodu = rapor.RaporKodu,
                MakineId = rapor.MakineId,
                DbYolu = dbYolu
            };
            frm.ShowDialog();
        }

        private void btnDisariAktar_Click(object sender, EventArgs e) { /* Geliştirilebilir */ }

        private void btnIceriAktar_Click(object sender, EventArgs e) { /* Geliştirilebilir */ }
    }
}

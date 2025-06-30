using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EMAR.Helpers;
using EMAR.Models;
using EMAR.Repository;

namespace EMAR
{
    public partial class frmRaporKayit : Form
    {
        public int ProjeId { get; set; }
        public int MakineId { get; set; }
        public string RaporKodu { get; set; } = string.Empty;
        public bool DuzenlemeModu { get; set; } = false;
        public int SiraNo { get; set; } = 0;
        public string ProjeKodu { get; set; } = string.Empty;
        public string MakineAdi { get; set; } = string.Empty;
        public string RaporTuruKod { get; set; } = string.Empty;
        // ... gerekirse diğer rapor bilgileri

        public frmRaporKayit() => InitializeComponent();

        private void frmRaporKayit_Load(object sender, EventArgs e)
        {
            YukleProjeler();
            YukleRaporTurleri();
            YukleMusteriler();

            cmbProjeKodu.DisplayMember = "ProjeKodu";
            cmbRaporTuru.DisplayMember = "Kod";
            cmbMakine.DisplayMember = "Ad";
            cmbMusteriAdi.DisplayMember = "Ad";
            cmbMusteriAdi.ValueMember = "Id";

            cmbProjeKodu.SelectedIndexChanged += cmbProjeKodu_SelectedIndexChanged;

            if (DuzenlemeModu)
            {
                // Var olan rapor bilgileriyle kontrolleri DOLDUR!
                // Proje, Makine, RaporTuru, SiraNo, MakineAdi vs.
                // Sadece bir örnek aşağıda, kendi modeline göre uyarlayabilirsin:
                cmbProjeKodu.SelectedItem = cmbProjeKodu.Items
                    .Cast<Proje>().FirstOrDefault(p => p.ProjeKodu == ProjeKodu);
                cmbRaporTuru.SelectedItem = cmbRaporTuru.Items
                    .Cast<RaporTuru>().FirstOrDefault(r => r.Kod == RaporTuruKod);
                cmbMakine.SelectedItem = cmbMakine.Items
                    .Cast<Makine>().FirstOrDefault(m => m.Ad == MakineAdi);
                txtRaporKodu.Text = RaporKodu;
                // Diğer kontroller için de aynısını yap
            }
            else
            {
                txtRaporKodu.Text = "(kaydedince oluşacak)";
            }
        }


        private void btnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbProjeKodu.SelectedItem is not Proje seciliProje ||
                cmbRaporTuru.SelectedItem is not RaporTuru seciliTur ||
                cmbMakine.SelectedItem is not Makine seciliMakine)
            {
                MessageBox.Show("Lütfen proje, rapor türü ve makine seçiniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProjeId = seciliProje.Id;
            MakineId = seciliMakine.Id;
            string projeKodu = seciliProje.ProjeKodu;
            string raporTuru = seciliTur.Kod;
            string makineAdi = seciliMakine.Ad;

            int siraNo;

            string dbYolu = null;
            string klasorYolu = null;

            if (!DuzenlemeModu)
            {
                // !!! YENİ: GetNextSiraNo artık ID ile çağrılıyor !!!
                siraNo = RaporRepository.GetNextSiraNo(ProjeId, MakineId, raporTuru);

                dbYolu = RaporKlasorYardimcisi.RaporDbYolu(projeKodu, raporTuru, siraNo, makineAdi);
                klasorYolu = RaporKlasorYardimcisi.RaporKlasoru(projeKodu, raporTuru, siraNo, makineAdi);
                RaporKlasorYardimcisi.KlasorOlustur(klasorYolu);

                if (!File.Exists(dbYolu))
                {
                    File.Create(dbYolu).Dispose();
                    DatabaseSchemaCreator.InitializeRaporDatabase(dbYolu);
                }
            }
            else
            {
                siraNo = SiraNo;
                dbYolu = RaporKlasorYardimcisi.RaporDbYolu(projeKodu, raporTuru, siraNo, makineAdi);
            }

            // YENİ: Modelde yine gösterim amaçlı alanları doldurabilirsin, veritabanına yazılmaz.
            var rapor = new Rapor
            {
                ProjeId = ProjeId,
                MakineId = MakineId,
                RaporTuruKod = raporTuru,
                Tarih = DateTime.Today.ToString("yyyy-MM-dd"),
                SiraNo = siraNo,
                // Bu iki alan modelde gösterim için tutulabilir, tabloya yazılmaz:
                MakineAdi = makineAdi,
                ProjeKodu = projeKodu
            };

            try
            {
                string raporKodu = RaporRepository.KaydetVeKodUret(rapor, "raporlar.db");
                RaporKodu = raporKodu;
                txtRaporKodu.Text = raporKodu;

                MessageBox.Show(DuzenlemeModu ? "Rapor başarıyla güncellendi." : "Rapor başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }



        private void YukleProjeler()
        {
            cmbProjeKodu.Items.Clear();
            var dt = VeritabaniHelper.TabloGetir("SELECT Id, ProjeKodu FROM Projeler");
            foreach (DataRow row in dt.Rows)
            {
                cmbProjeKodu.Items.Add(new Proje
                {
                    Id = Convert.ToInt32(row["Id"]),
                    ProjeKodu = row["ProjeKodu"].ToString()
                });
            }
        }

        private void YukleRaporTurleri()
        {
            cmbRaporTuru.Items.Clear();
            var satirlar = INIHelper.OkuBolum("RaporTurleri");
            foreach (var satir in satirlar)
            {
                cmbRaporTuru.Items.Add(new RaporTuru { Kod = satir.Key });
            }
        }

        private void YukleMusteriler()
        {
            var dt = VeritabaniHelper.TabloGetir("SELECT Id, Ad FROM Musteriler");
            cmbMusteriAdi.DataSource = dt;
            cmbMusteriAdi.DisplayMember = "Ad";
            cmbMusteriAdi.ValueMember = "Id";
            cmbMusteriAdi.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cmbProjeKodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMakine.Items.Clear();

            if (cmbProjeKodu.SelectedItem is not Proje proje) return;

            // ✅ Makine listesini projeye göre getir
            var dtMakineler = VeritabaniHelper.TabloGetir(
                @"SELECT M.Id, M.Ad FROM Makineler M
                  JOIN ProjeMakineleri PM ON M.Id = PM.MakineId
                  WHERE PM.ProjeId = @pid",
                new() { ["@pid"] = proje.Id }
            );

            foreach (DataRow row in dtMakineler.Rows)
            {
                cmbMakine.Items.Add(new Makine
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Ad = row["Ad"].ToString()
                });
            }

            if (cmbMakine.Items.Count > 0)
                cmbMakine.SelectedIndex = 0;

            // ✅ Müşteri bilgisini projeden al
            var dtProje = VeritabaniHelper.TabloGetir(
                "SELECT MusteriId FROM Projeler WHERE Id = @id",
                new() { ["@id"] = proje.Id }
            );

            if (dtProje.Rows.Count > 0)
            {
                int musteriId = Convert.ToInt32(dtProje.Rows[0]["MusteriId"]);
                cmbMusteriAdi.SelectedValue = musteriId;
            }
        }
        private void cmbRaporTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Gerekirse açıklama gösterilebilir
        }
    }
}

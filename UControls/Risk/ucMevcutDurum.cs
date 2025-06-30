using EMAR.Helpers;
using EMAR.Models;
using EMAR.Repository;
using System;
using System.IO;
using System.Windows.Forms;

namespace EMAR.UControls.Risk
{
    public partial class ucMevcutDurum : UserControl
    {
        public int RiskId { get; set; }
        public string DbYolu { get; set; }
        public int BolgeNo { get; set; }
        public int RiskNo { get; set; }
        public string ProjeKodu { get; set; }
        public string MakineAdi { get; set; }
        public string RaporTuru { get; set; }

        public ucMevcutDurum()
        {
            InitializeComponent();
            
        }
        public void SetTehlikeKonum(int bolgeNo, int riskNo)
        {
            this.BolgeNo = bolgeNo;
            this.RiskNo = riskNo;
            lblTehlikeNo.Text = $"Tehlike No: {bolgeNo}.{riskNo}";
        }
        public void Yukle()
        {
            if (!File.Exists(DbYolu)) return;

            var mevcutRepo = new MevcutDurumRepository(DbYolu);
            mevcutRepo.EnsureTable();
            var mevcut = mevcutRepo.GetByRiskId(RiskId);
            if (mevcut != null && !string.IsNullOrWhiteSpace(mevcut.Metin))
                ucTextEditor1.SetRtfText(mevcut.Metin);

            // 1. Görsel yerleşim
            ucGorselYerlesim1.ProjeKodu = ProjeKodu;
            ucGorselYerlesim1.RaporTuru = RaporTuru;
            ucGorselYerlesim1.MakineAdi = MakineAdi;
            ucGorselYerlesim1.BolgeNo = BolgeNo;
            ucGorselYerlesim1.RiskNo = RiskNo;
            ucGorselYerlesim1.GorselTip = "MevcutDurum";
            ucGorselYerlesim1.DbYolu = DbYolu;

            var gorseller1 = GorselYerlesimRepository.Load(DbYolu, RiskId, "MevcutDurum");
            ucGorselYerlesim1.LoadGorselListesiFromJson(
                Newtonsoft.Json.JsonConvert.SerializeObject(gorseller1)
            );

            // 2. Görsel yerleşim
            ucGorselYerlesim2.ProjeKodu = ProjeKodu;
            ucGorselYerlesim2.RaporTuru = RaporTuru;
            ucGorselYerlesim2.MakineAdi = MakineAdi;
            ucGorselYerlesim2.BolgeNo = BolgeNo;
            ucGorselYerlesim2.RiskNo = RiskNo;
            ucGorselYerlesim2.GorselTip = "MevcutDurum2";
            ucGorselYerlesim2.DbYolu = DbYolu;

            var gorseller2 = GorselYerlesimRepository.Load(DbYolu, RiskId, "MevcutDurum2");
            ucGorselYerlesim2.LoadGorselListesiFromJson(
                Newtonsoft.Json.JsonConvert.SerializeObject(gorseller2)
            );

            // Standartlar
            if (mevcut != null && !string.IsNullOrWhiteSpace(mevcut.StandartlarJson))
            {
                var list = StandartlarSerializer.Deserialize(mevcut.StandartlarJson);
                ucStandartlar1.SetRowsFromList(list);
            }

        }


        public void Kaydet()
        {
            if (!File.Exists(DbYolu)) return;

            var mevcutRepo = new MevcutDurumRepository(DbYolu);
            mevcutRepo.EnsureTable();

            var mevcut = mevcutRepo.GetByRiskId(RiskId) ?? new MevcutDurum();
            mevcut.RiskId = RiskId;
            mevcut.Metin = ucTextEditor1.GetRtfText();

            // ---- EN DOĞRU KAYIT ŞEKLİ ----
            var selectedList = ucStandartlar1.GetSelectedList();
            mevcut.StandartlarJson = StandartlarSerializer.Serialize(selectedList);

            mevcutRepo.Save(mevcut);

            GorselYerlesimRepository.Save(
                DbYolu,
                RiskId,
                "MevcutDurum",
                new System.Collections.Generic.List<EMAR.Models.GorselYerlesimModel>(ucGorselYerlesim1.GetCurrentList())
            );

            GorselYerlesimRepository.Save(
                DbYolu,
                RiskId,
                "MevcutDurum2",
                new System.Collections.Generic.List<EMAR.Models.GorselYerlesimModel>(ucGorselYerlesim2.GetCurrentList())
            );
        }



        public void TumGorselleriTemizle()
        {
            ucGorselYerlesim1.LoadGorselListesiFromJson(null);
            ucGorselYerlesim2.LoadGorselListesiFromJson(null);

            // DB'den de silmek için:
            GorselYerlesimRepository.Delete(DbYolu, RiskId, "MevcutDurum");
            GorselYerlesimRepository.Delete(DbYolu, RiskId, "MevcutDurum2");
        }

        public void MevcutDurumGorselKlasorunuSil()
        {
            if (string.IsNullOrEmpty(DbYolu)) return;

            string basePath = Path.GetDirectoryName(DbYolu);
            string[] tipler = { "MevcutDurum", "MevcutDurum2" };

            foreach (var tip in tipler)
            {
                string gorselKlasoru = Path.Combine(basePath, "Gorseller", tip, $"Risk_{BolgeNo}.{RiskNo}");
                if (Directory.Exists(gorselKlasoru))
                {
                    try
                    {
                        Directory.Delete(gorselKlasoru, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Mevcut Durum ({tip}) görselleri silinemedi:\n" + ex.Message);
                    }
                }
            }
        }

    }
}

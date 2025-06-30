using EMAR.Models;
using EMAR.Repository;
using EMAR.UControls;
using EMAR.UControls.Risk;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EMAR
{
    public partial class frmRASCDetay : Form
    {
        public string ProjeKodu { get; set; }
        public string MakineAdi { get; set; }
        public string RaporTuru { get; set; }

        public string DbYolu { get; set; }
        public frmRASCDetay()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += frmRASCDetay_KeyDown;
        }

        private void frmRASCDetay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                // Her bolge için ana kaydet butonunu bulup tıkla
                // Her bolgenin TableLayoutPanel'inde en üstte panelButton var
                foreach (var bolgeId in Enumerable.Range(1, 4))
                {
                    var tbl = Controls.Find($"tblBolge{bolgeId}", true).FirstOrDefault() as TableLayoutPanel;
                    if (tbl == null) continue;

                    // FlowLayoutPanel’in ilk kontrolü panelButton olacak (AddBolgeButtonEvents ile ekleniyor)
                    var panelButton = tbl.Controls.OfType<FlowLayoutPanel>().FirstOrDefault();
                    if (panelButton == null) continue;

                    var btnKaydet = panelButton.Controls
                        .OfType<Button>()
                        .FirstOrDefault(b => b.Text.Contains("Kaydet"));
                    if (btnKaydet != null)
                        btnKaydet.PerformClick();
                }

                e.SuppressKeyPress = true; // “ding” sesi çıkmaz
            }
        }

        private ucRiskMaddesi GetSelectedRisk(FlowLayoutPanel flowPanel)
        {
            return flowPanel.Controls.OfType<ucRiskMaddesi>()
                .FirstOrDefault(r => r.IsSelected);
        }

        private void frmRASCDetay_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DbYolu))
            {
                MessageBox.Show("Veritabanı yolu geçerli değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(DbYolu))
                SQLiteConnection.CreateFile(DbYolu);

            RiskRepository.EnsureSchema(DbYolu);

            for (int bolgeId = 1; bolgeId <= 4; bolgeId++)
            {
                var iniSatir = INIHelper.Oku("Bolgeler", bolgeId.ToString());
                if (string.IsNullOrWhiteSpace(iniSatir)) continue;

                var parcalar = iniSatir.Split('|');
                if (parcalar.Length < 2) continue;

                string bolgeAdi = parcalar[0];
                string aciklama = parcalar[1];

                var flowPanel = Controls.Find($"flowRiskList{bolgeId}", true).FirstOrDefault() as FlowLayoutPanel;
                var tbl = Controls.Find($"tblBolge{bolgeId}", true).FirstOrDefault() as TableLayoutPanel;
                var pnl = Controls.Find($"pnlIcerik{bolgeId}", true).FirstOrDefault() as Panel;

                if (flowPanel != null && tbl != null && pnl != null)
                    AddBolge(flowPanel, tbl, pnl, bolgeId, bolgeAdi, aciklama);
            }
        }
        // --- ÖNEMLİ: Panel ve FlowPanel temizleme fonksiyonu ---
        private void SafeClearPanel(Panel panel)
        {
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is IDisposable disposable)
                    disposable.Dispose();
            }
            panel.Controls.Clear();
        }

        private void SafeClearFlow(FlowLayoutPanel flowPanel)
        {
            foreach (Control ctrl in flowPanel.Controls)
            {
                if (ctrl is IDisposable disposable)
                    disposable.Dispose();
            }
            flowPanel.Controls.Clear();
        }
        private void AddBolge(FlowLayoutPanel flowPanel, TableLayoutPanel tblSag, Panel pnlIcerik, int bolgeId, string bolgeAdi, string aciklama)
        {
            SafeClearFlow(flowPanel);

            var genelBtn = new BolgeGenelButonu
            {
                BolgeId = bolgeId,
                BolgeAdi = $"Bölge {bolgeId} – {bolgeAdi}",
                Aciklama = aciklama,
                Name = $"btnBolgeGenel{bolgeId}",
                Width = flowPanel.Width - 40,
                Height = 120,
                Margin = new Padding(5)
            };
            genelBtn.GenelButonTiklandi += (s2, e2) =>
            {
                pnlIcerik.Controls.Clear();
                var uc = new ucBolgeDetay
                {
                    BolgeId = bolgeId,
                    BolgeAdi = genelBtn.BolgeAdi,
                    DbYolu = DbYolu,
                    Dock = DockStyle.Fill
                };
                pnlIcerik.Controls.Add(uc);
                uc.Yukle();
            };
            flowPanel.Controls.Add(genelBtn);
            flowPanel.Controls.SetChildIndex(genelBtn, 0);

            int no = 1;
            foreach (var risk in RiskRepository.Listele(DbYolu, bolgeId))
            {
                var uc = new ucRiskMaddesi
                {
                    RiskAdi = risk.Baslik,
                    RiskId = risk.Id,
                    DbYolu = DbYolu,
                    Width = flowPanel.Width - 40,
                    EskiRiskNo = no // Sıra ile eşleşiyor!
                };
                flowPanel.Controls.Add(uc);
                no++;
            }

            UpdateRiskSira(flowPanel);
            UpdateRiskAdlari(flowPanel);
            AddBolgeButtonEvents(flowPanel, tblSag, pnlIcerik, bolgeId);
        }

        private void AddBolgeButtonEvents(FlowLayoutPanel flowPanel, TableLayoutPanel tblSag, Panel pnlIcerik, int bolgeId)
        {
            var btnEkle = new Button { Text = "➕ Risk Ekle", Width = 250, Height = 60 };
            var btnSil = new Button { Text = "❌ Riski Sil", Width = 250, Height = 60 };
            var btnYukari = new Button { Text = "⬆️ Yukarı", Width = 250, Height = 60 };
            var btnAsagi = new Button { Text = "⬇️ Aşağı", Width = 250, Height = 60 };
            var btnKaydet = new Button { Text = "💾 Tümünü Kaydet", Width = 350, Height = 60 };

            var panelButton = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                WrapContents = false,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(5)
            };

            panelButton.Controls.AddRange(new Control[] { btnEkle, btnSil, btnYukari, btnAsagi, btnKaydet });
            tblSag.Controls.Add(panelButton, 0, 0);

            btnEkle.Click += (s, e) =>
            {
                string baslik = $"Risk {flowPanel.Controls.OfType<ucRiskMaddesi>().Count() + 1}";
                int yeniId = RiskRepository.Ekle(DbYolu, bolgeId, flowPanel.Controls.OfType<ucRiskMaddesi>().Count(), baslik);

                var yeniRisk = new ucRiskMaddesi
                {
                    RiskAdi = baslik,
                    RiskId = yeniId,
                    DbYolu = DbYolu,
                    Width = flowPanel.Width - 40,
                    EskiRiskNo = flowPanel.Controls.OfType<ucRiskMaddesi>().Count() + 1
                };

                flowPanel.Controls.Add(yeniRisk);
                yeniRisk.SelectRisk();
                UpdateRiskSira(flowPanel);
                UpdateRiskAdlari(flowPanel);
                UpdateRiskDosyaKlasorleri(flowPanel, bolgeId);
            };

            btnSil.Click += (s, e) =>
            {
                var secili = GetSelectedRisk(flowPanel);
                if (secili != null)
                {
                    int riskIndex = flowPanel.Controls.GetChildIndex(secili) - 1; // 0: genel bilgi butonu
                    RiskRepository.Sil(DbYolu, secili.RiskId);

                    // Risk silinince klasör ve dosyaları SİL ve kalanları GERİ KAYDIR!
                    DeleteRiskFoldersAndShift(DbYolu, bolgeId, riskIndex + 1, flowPanel.Controls.OfType<ucRiskMaddesi>().Count());
                    

                    flowPanel.Controls.Remove(secili);
                    secili.Dispose();
                    UpdateRiskSira(flowPanel);
                    UpdateRiskAdlari(flowPanel);
                    UpdateRiskDosyaKlasorleri(flowPanel, bolgeId);
                    // --- Silinince ilk risk seçili olsun:
                    var yeniSecili = flowPanel.Controls.OfType<ucRiskMaddesi>().FirstOrDefault();
                    if (yeniSecili != null) yeniSecili.SelectRisk();
                }
            };

            btnKaydet.Click += (s, e) =>
            {
                Panel aktifPanel = pnlIcerik;
                foreach (ucRiskMaddesi risk in flowPanel.Controls.OfType<ucRiskMaddesi>())
                {
                    foreach (Control alt in aktifPanel.Controls)
                    {
                        if (alt is ucGenelBilgilendirme g) g.Kaydet();
                        if (alt is ucRiskAzaltimi a) a.Kaydet();
                        if (alt is ucMevcutDurum m) m.Kaydet();
                        if (alt is ucModifikasyon mo) mo.Kaydet();
                    }
                }
                MessageBox.Show("Tüm içerikler kaydedildi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            btnYukari.Click += (s, e) =>
            {
                var secili = GetSelectedRisk(flowPanel);
                if (secili != null)
                {
                    int index = flowPanel.Controls.GetChildIndex(secili);
                    if (index > 1) // 0: genel bilgi butonu
                    {
                        // Swap önce iki riskin klasörlerini değiştir!
                        var riskler = flowPanel.Controls.OfType<ucRiskMaddesi>().ToList();
                        var oncekiRisk = riskler[index - 2]; // index-1: bu risk, index-2: yukarıdaki risk
                        SwapRiskFolders(DbYolu, bolgeId, secili.EskiRiskNo, oncekiRisk.EskiRiskNo);

                        flowPanel.Controls.SetChildIndex(secili, index - 1);
                        UpdateRiskSira(flowPanel);
                        UpdateRiskAdlari(flowPanel);
                        UpdateRiskDosyaKlasorleri(flowPanel, bolgeId);

                        // ... Taşıma ve sıralama işlemlerinden sonra:
                        secili.SelectRisk();
                        //secili.SimuleClick(); // Toggle ve ilk başlığı (Genel Bilgilendirme) açar
                        secili.GosterAltIcerik("Genel Bilgilendirme");

                    }
                }
            };

            btnAsagi.Click += (s, e) =>
            {
                var secili = GetSelectedRisk(flowPanel);
                if (secili != null)
                {
                    int index = flowPanel.Controls.GetChildIndex(secili);
                    if (index < flowPanel.Controls.Count - 1)
                    {
                        // Swap önce iki riskin klasörlerini değiştir!
                        var riskler = flowPanel.Controls.OfType<ucRiskMaddesi>().ToList();
                        var sonrakiRisk = riskler[index]; // index: bu risk, index+1: aşağıdaki risk
                        SwapRiskFolders(DbYolu, bolgeId, secili.EskiRiskNo, sonrakiRisk.EskiRiskNo);

                        flowPanel.Controls.SetChildIndex(secili, index + 1);
                        UpdateRiskSira(flowPanel);
                        UpdateRiskAdlari(flowPanel);
                        UpdateRiskDosyaKlasorleri(flowPanel, bolgeId);

                        // ... Taşıma ve sıralama işlemlerinden sonra:
                        secili.SelectRisk();
                        //secili.SimuleClick(); // Toggle ve ilk başlığı (Genel Bilgilendirme) açar
                        secili.GosterAltIcerik("Genel Bilgilendirme");
                    }
                }
            };

        }

        // --- Sadece silinen riskin klasörlerini silip, kalan tüm risklerin klasörlerini 1 geri kaydır ---
        private void DeleteRiskFoldersAndShift(string dbYolu, int bolgeNo, int silinenRiskNo, int toplamRiskSayisi)
        {
            string baseDir = Path.GetDirectoryName(dbYolu);
            string[] anaKlasorler = { "Gorseller/GenelBilgi", "Gorseller/Modifikasyon", "Gorseller/MevcutDurum" };

            foreach (var anaKlasor in anaKlasorler)
            {
                string silinecekKlasor = Path.Combine(baseDir, anaKlasor, $"Risk_{bolgeNo}.{silinenRiskNo}");
                if (Directory.Exists(silinecekKlasor))
                    Directory.Delete(silinecekKlasor, true);

                // Sonraki risklerin klasörlerini bir geri kaydır
                for (int i = silinenRiskNo + 1; i <= toplamRiskSayisi; i++)
                {
                    string eski = Path.Combine(baseDir, anaKlasor, $"Risk_{bolgeNo}.{i}");
                    string yeni = Path.Combine(baseDir, anaKlasor, $"Risk_{bolgeNo}.{i - 1}");
                    if (Directory.Exists(eski))
                    {
                        if (Directory.Exists(yeni)) Directory.Delete(yeni, true);
                        Directory.Move(eski, yeni);
                    }
                }
            }
        }

        // --- Sadece iki riskin klasör adlarını birbirleriyle SWAP eder ---
        private void SwapRiskFolders(string dbYolu, int bolgeNo, int riskNo1, int riskNo2)
        {
            string baseDir = Path.GetDirectoryName(dbYolu);
            string[] anaKlasorler = { "Gorseller/GenelBilgi", "Gorseller/Modifikasyon", "Gorseller/MevcutDurum" };

            foreach (var anaKlasor in anaKlasorler)
            {
                string klasor1 = Path.Combine(baseDir, anaKlasor, $"Risk_{bolgeNo}.{riskNo1}");
                string klasor2 = Path.Combine(baseDir, anaKlasor, $"Risk_{bolgeNo}.{riskNo2}");
                string tmpKlasor = Path.Combine(baseDir, anaKlasor, $"Risk_tmp_{Guid.NewGuid()}");

                if (Directory.Exists(klasor1) && Directory.Exists(klasor2))
                {
                    Directory.Move(klasor1, tmpKlasor);
                    Directory.Move(klasor2, klasor1);
                    Directory.Move(tmpKlasor, klasor2);
                }
                else if (Directory.Exists(klasor1))
                {
                    Directory.Move(klasor1, klasor2);
                }
                else if (Directory.Exists(klasor2))
                {
                    Directory.Move(klasor2, klasor1);
                }
            }
        }

        private void UpdateRiskDosyaKlasorleri(FlowLayoutPanel flowPanel, int bolgeNo)
        {
            string baseDir = Path.GetDirectoryName(DbYolu);

            int no = 1;
            foreach (ucRiskMaddesi risk in flowPanel.Controls.OfType<ucRiskMaddesi>())
            {
                risk.EskiRiskNo = no; // Yeni sırasını set et
                no++;
            }
        }

        private void UpdateRiskSira(FlowLayoutPanel flow)
        {
            var siralar = flow.Controls
                .OfType<ucRiskMaddesi>()
                .Select((r, i) => (r.RiskId, i))
                .ToList();
            RiskRepository.GuncelleSiralar(DbYolu, siralar);
        }
        private void UpdateRiskAdlari(FlowLayoutPanel flow)
        {
            int no = 1;
            foreach (ucRiskMaddesi risk in flow.Controls.OfType<ucRiskMaddesi>())
            {
                risk.RiskAdi = $"Risk {no++}";
            }
        }
        public void GosterAltBaslikIcerigi(object sender, string baslik)
        {
            if (sender is not ucRiskMaddesi risk) return;
            var flowPanel = risk.Parent as FlowLayoutPanel;
            if (flowPanel == null) return;

            Panel panel = null;
            if (flowPanel == flowRiskList1) panel = pnlIcerik1;
            else if (flowPanel == flowRiskList2) panel = pnlIcerik2;
            else if (flowPanel == flowRiskList3) panel = pnlIcerik3;
            else if (flowPanel == flowRiskList4) panel = pnlIcerik4;
            if (panel == null) return;

            SafeClearPanel(panel);

            int bolgeNo = GetBolgeNumarasi(flowPanel);
            int riskIndex = flowPanel.Controls.OfType<ucRiskMaddesi>().ToList().FindIndex(r => r.RiskId == risk.RiskId);
            int riskNo = riskIndex + 1;

            UserControl uc = baslik switch
            {
                "Genel Bilgilendirme" => new ucGenelBilgilendirme
                {
                    RiskId = risk.RiskId,
                    DbYolu = DbYolu,
                    BolgeNo = bolgeNo,
                    RiskNo = riskNo
                },
                "Risk Azaltımı" => new ucRiskAzaltimi
                {
                    RiskId = risk.RiskId,
                    DbYolu = DbYolu,
                    BolgeNo = bolgeNo,
                    RiskNo = riskNo,
                    BolgeNumarasi = bolgeNo
                },
                "Mevcut Durum" => new ucMevcutDurum
                {
                    RiskId = risk.RiskId,
                    DbYolu = DbYolu,
                    BolgeNo = bolgeNo,
                    RiskNo = riskNo,
                    ProjeKodu = this.ProjeKodu,
                    MakineAdi = this.MakineAdi,
                    RaporTuru = this.RaporTuru
                },
                "Modifikasyon Önerileri" => new ucModifikasyon
                {
                    RiskId = risk.RiskId,
                    DbYolu = DbYolu,
                    BolgeNo = bolgeNo,
                    RiskNo = riskNo,
                    ProjeKodu = this.ProjeKodu,
                    MakineAdi = this.MakineAdi,
                    RaporTuru = this.RaporTuru
                },
                _ => null
            };

            if (uc == null)
            {
                panel.Controls.Add(new Label { Text = "İçerik bulunamadı", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter });
                return;
            }

            uc.Dock = DockStyle.Fill;
            panel.Controls.Add(uc);

            switch (uc)
            {
                case ucGenelBilgilendirme g:
                    g.SetTehlikeKonum(bolgeNo, riskNo);
                    g.Yukle();
                    break;

                case ucRiskAzaltimi a:
                    a.Yukle();
                    break;

                case ucMevcutDurum m:
                    m.SetTehlikeKonum(bolgeNo, riskNo);
                    m.Yukle();
                    break;

                case ucModifikasyon mo:
                    mo.Yukle();
                    break;
            }
        }
        // --- Form tamamen kapanırken tüm disposable'lar temizleniyor ---
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            foreach (var panel in new[] { pnlIcerik1, pnlIcerik2, pnlIcerik3, pnlIcerik4 })
            {
                SafeClearPanel(panel);
            }
            foreach (var flow in new[] { flowRiskList1, flowRiskList2, flowRiskList3, flowRiskList4 })
            {
                SafeClearFlow(flow);
            }
            base.OnFormClosing(e);
        }
        private int GetBolgeNumarasi(FlowLayoutPanel panel)
        {
            if (panel == flowRiskList1) return 1;
            if (panel == flowRiskList2) return 2;
            if (panel == flowRiskList3) return 3;
            if (panel == flowRiskList4) return 4;
            return 0;
        }
    }
}

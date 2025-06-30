using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using EMAR.Models;
using EMAR.Repository;
using EMAR.UControls.Buton;

namespace EMAR
{
    public partial class ucModifikasyon : UserControl
    {
        public int RiskId { get; set; }
        public string DbYolu { get; set; }
        public string ProjeKodu { get; set; }
        public string MakineAdi { get; set; }
        public string RaporTuru { get; set; }
        public int BolgeNo { get; set; }
        public int RiskNo { get; set; }  // 👈 mutlaka eklenecek

        private ModifikasyonIcerikRepository repository;

        public ucModifikasyon()
        {
            InitializeComponent();
        }

        private void btnMetinEkle_Click(object sender, EventArgs e)
        {
            EkleYeniAlan("text", null);
        }

        private void btnGorselEkle_Click(object sender, EventArgs e)
        {
            EkleYeniAlan("gorsel", null);
        }

        public void Yukle()
        {
            if (!File.Exists(DbYolu)) return;
            repository = new ModifikasyonIcerikRepository(DbYolu);
            repository.EnsureTable();

            flwAlanlar.Controls.Clear();

            var icerikler = repository.GetByRiskId(RiskId);
            foreach (var item in icerikler)
            {
                EkleYeniAlan(item.Tip, item.Icerik);
            }
        }

        public void Kaydet()
        {
            if (!File.Exists(DbYolu)) return;
            if (repository == null)
                repository = new ModifikasyonIcerikRepository(DbYolu);

            repository.EnsureTable();
            repository.DeleteByRiskId(RiskId);

            int sira = 0;

            foreach (Control panel in flwAlanlar.Controls)
            {
                if (panel is not Panel pnl) continue;

                foreach (Control ctrl in pnl.Controls)
                {
                    string tip = null;
                    string veri = null;

                    if (ctrl is ucTextEditor txt)
                    {
                        tip = "text";
                        veri = txt.GetRtfText();
                    }
                    else if (ctrl is ucGorselYerlesim gorsel)
                    {
                        tip = "gorsel";
                        var liste = gorsel.GetCurrentList();
                        veri = System.Text.Json.JsonSerializer.Serialize(liste);
                    }

                    if (tip != null)
                    {
                        repository.Insert(new ModifikasyonIcerik
                        {
                            RiskId = RiskId,
                            Tip = tip,
                            Icerik = veri,
                            Siralama = sira++
                        });
                    }
                }
            }
        }
        private void EkleYeniAlan(string tip, string veri)
        {
            var panel = new Panel
            {
                Width = flwAlanlar.Width - 30,
                Height = 500,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
            };

            Control icerik;

            if (tip == "text")
            {
                var txt = new ucTextEditor { Dock = DockStyle.Fill };
                if (!string.IsNullOrEmpty(veri)) txt.SetRtfText(veri);
                icerik = txt;
            }
            else // gorsel
            {
                var gorsel = new ucGorselYerlesim
                {
                    Dock = DockStyle.Fill,
                    ProjeKodu = ProjeKodu,
                    RaporTuru = RaporTuru,
                    MakineAdi = MakineAdi,
                    BolgeNo = BolgeNo,
                    RiskNo = RiskNo,
                    GorselTip = "Modifikasyon",
                    DbYolu = DbYolu
                };

                if (!string.IsNullOrEmpty(veri))
                {
                    var liste = System.Text.Json.JsonSerializer.Deserialize<List<GorselYerlesimModel>>(veri);
                    if (liste != null)
                        gorsel.LoadGorselListesiFromJson(System.Text.Json.JsonSerializer.Serialize(liste));
                }

                icerik = gorsel;
                panel.AutoSize = true;
            }

            var btnSil = new Button
            {
                Text = "❌ Sil",
                Width = 60,
                Height = 50,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter
            };

            btnSil.Click += (s, e) =>
            {
                flwAlanlar.Controls.Remove(panel);
                panel.Dispose();
            };

            panel.Controls.Add(icerik);
            panel.Controls.Add(btnSil);
            flwAlanlar.Controls.Add(panel);
        }


    }
}

using EMAR.Models;
using EMAR.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EMAR.UControls
{
    public partial class ucRiskAzaltimi : UserControl
    {
        public int RiskId { get; set; }
        public int BolgeNo { get; set; }
        public int RiskNo { get; set; }
        public int BolgeNumarasi { get; set; }
        public string DbYolu { get; set; }

        private bool yukleniyor = false;
        private RiskAzaltimiRepository repository;

        public ucRiskAzaltimi()
        {
            InitializeComponent();
            YukleComboVerileri();
            OlaylariAyarla();
        }

        private void YukleComboVerileri()
        {
            cmbOlasıHasar.DataSource = new List<KeyValuePair<double, string>> {
                new(0.25, "0.25 - Çizik veya çürük"),
                new(0.5, "0.5 - Yırtılma, hafif sağlık etkisi veya hafif yanık"),
                new(3, "3 - Küçük bir kemiğin kırılması veya küçük geçici bir hastalık durumu"),
                new(5, "5 - Büyük bir kemiğin kırılması"),
                new(8, "8 - 1 veya 2 parmak/ayak parmağı kaybı, büyük yanıklar, hafif hastalık"),
                new(11, "11 - 1 el, kol veya bacak, kısmi körlük veya işitme kaybı amputasyonu"),
                new(15, "15 - 2 el/bacak amputasyonu, toplam körlük veya işitme kaybı"),
                new(25, "25 - Kritik yaralanmalar veya büyük kalıcı hastalıklar"),
                new(40, "40 - Tek ölüm"),
                new(65, "65 - Çoklu ölüm")
            };
            cmbOlasıHasar.DisplayMember = "Value";
            cmbOlasıHasar.ValueMember = "Key";

            cmbKazaOlma.DataSource = new List<KeyValuePair<double, string>> {
                new(0.05, "0.05 - Neredeyse imkânsız"),
                new(1.25, "1.25 - Aşırı koşullarda olası veya mümkün değil"),
                new(2.5, "2.5 - Mümkün ama olağandışı"),
                new(4, "4 - Şans bile olsa olabilir"),
                new(5, "5 - Muhtemelen, sonunda olacak"),
                new(6, "6 - Muhtemelen, makul olarak öngörülebilir"),
                new(7, "7 - Kesinlikle, yakın zamanda gerçekleşecek")
            };
            cmbKazaOlma.DisplayMember = "Value";
            cmbKazaOlma.ValueMember = "Key";

            cmbKacinma.DataSource = new List<KeyValuePair<double, string>> {
                new(0.75, "0.75 - Tamamen mümkün"),
                new(2.5, "2.5 - Mümkün ancak sadece kontrollü koşullar altında"),
                new(5, "5 - Mümkün değil")
            };
            cmbKacinma.DisplayMember = "Value";
            cmbKacinma.ValueMember = "Key";

            cmbMaruzKalma.DataSource = new List<KeyValuePair<double, string>> {
                new(0.5, "0.5 - Yıllık"),
                new(1, "1 - Aylık"),
                new(2, "2 - Haftalık"),
                new(3, "3 - Günlük"),
                new(4, "4 - Saatlik"),
                new(5, "5 - Sürekli")
            };
            cmbMaruzKalma.DisplayMember = "Value";
            cmbMaruzKalma.ValueMember = "Key";

            AyarlaComboBoxGenisligi(cmbOlasıHasar);
            AyarlaComboBoxGenisligi(cmbKazaOlma);
            AyarlaComboBoxGenisligi(cmbKacinma);
            AyarlaComboBoxGenisligi(cmbMaruzKalma);
        }

        private void AyarlaComboBoxGenisligi(ComboBox comboBox)
        {
            int maxWidth = 0;
            using (Graphics g = comboBox.CreateGraphics())
            {
                foreach (var item in comboBox.Items)
                {
                    string text = comboBox.GetItemText(item);
                    int itemWidth = (int)g.MeasureString(text, comboBox.Font).Width;
                    if (itemWidth > maxWidth) maxWidth = itemWidth;
                }
            }
            comboBox.DropDownWidth = maxWidth + 30;
        }

        private void OlaylariAyarla()
        {
            cmbOlasıHasar.SelectedIndexChanged += (s, e) => { if (!yukleniyor) { HesaplaHRN(); Kaydet(); } };
            cmbKazaOlma.SelectedIndexChanged += (s, e) => { if (!yukleniyor) { HesaplaHRN(); Kaydet(); } };
            cmbKacinma.SelectedIndexChanged += (s, e) => { if (!yukleniyor) { HesaplaHRN(); Kaydet(); } };
            cmbMaruzKalma.SelectedIndexChanged += (s, e) => { if (!yukleniyor) { HesaplaHRN(); Kaydet(); } };
        }

        private void HesaplaHRN()
        {
            if (cmbOlasıHasar.SelectedValue == null || cmbKazaOlma.SelectedValue == null || cmbKacinma.SelectedValue == null || cmbMaruzKalma.SelectedValue == null)
            {
                lblDegerRiskSkoru.Text = "-";
                lblDegerSeviye.Text = "-";
                lblDegerRiskSkoru.BackColor = SystemColors.Control;
                lblDegerSeviye.BackColor = SystemColors.Control;
                return;
            }

            double dph = (double)cmbOlasıHasar.SelectedValue;
            double lo = (double)cmbKazaOlma.SelectedValue;
            double pa = (double)cmbKacinma.SelectedValue;
            double fe = (double)cmbMaruzKalma.SelectedValue;

            if (BolgeNumarasi == 4)
            {
                lblDegerRiskSkoru.Text = "N/A";
                lblDegerSeviye.Text = "Kabul Edilebilir";
                lblDegerRiskSkoru.BackColor = Color.Transparent;
                lblDegerSeviye.BackColor = Color.Transparent;
                return;
            }

            double hrn = dph * lo * pa * fe;
            double skor = RoundUpDown(hrn);
            string seviye = RiskSeviyesi(skor);
            Color renk = RenkBelirle(skor);

            lblDegerRiskSkoru.Text = skor.ToString(CultureInfo.InvariantCulture);
            lblDegerSeviye.Text = seviye;
            lblDegerRiskSkoru.BackColor = renk;
            lblDegerSeviye.BackColor = renk;
        }

        private double RoundUpDown(double sayi)
        {
            if (sayi < 1) return 1;
            return (sayi - Math.Floor(sayi)) >= 0.5 ? Math.Ceiling(sayi) : Math.Floor(sayi);
        }

        private string RiskSeviyesi(double skor)
        {
            if (skor <= 10) return "İhmal Edilebilir Risk";
            else if (skor <= 20) return "Çok Düşük Risk";
            else if (skor <= 45) return "Düşük Risk";
            else if (skor <= 160) return "Önemli Risk";
            else return "Yüksek Risk";
        }

        private Color RenkBelirle(double skor)
        {
            if (skor <= 10) return Color.FromArgb(146, 208, 80);
            else if (skor <= 45) return Color.Orange;
            else return Color.Red;
        }

        public void Kaydet()
        {
            if (!File.Exists(DbYolu)) return;

            if (repository == null)
                repository = new RiskAzaltimiRepository(DbYolu);

            repository.EnsureTable();

            var model = new RiskAzaltimi
            {
                RiskId = RiskId,
                Olasilik = BolgeNumarasi == 4 ? "N/A" : ((double)cmbOlasıHasar.SelectedValue).ToString(CultureInfo.InvariantCulture),
                KazaOlma = BolgeNumarasi == 4 ? "N/A" : ((double)cmbKazaOlma.SelectedValue).ToString(CultureInfo.InvariantCulture),
                Kacinma = BolgeNumarasi == 4 ? "N/A" : ((double)cmbKacinma.SelectedValue).ToString(CultureInfo.InvariantCulture),
                MaruzKalma = BolgeNumarasi == 4 ? "N/A" : ((double)cmbMaruzKalma.SelectedValue).ToString(CultureInfo.InvariantCulture),
                HRN = BolgeNumarasi == 4 ? "N/A" :
                    RoundUpDown((double)cmbOlasıHasar.SelectedValue *
                                (double)cmbKazaOlma.SelectedValue *
                                (double)cmbKacinma.SelectedValue *
                                (double)cmbMaruzKalma.SelectedValue).ToString(CultureInfo.InvariantCulture),
                OnlemlerRTF = ucTextEditor1?.GetRtfText(),
                ArtikRiskRTF = ucTextEditor2?.GetRtfText(),
                HRNSeviye = lblDegerSeviye.Text,
            };

            repository.Save(model);
        }

        public void Yukle()
        {
            if (!File.Exists(DbYolu)) return;

            yukleniyor = true;

            repository = new RiskAzaltimiRepository(DbYolu);
            repository.EnsureTable();

            var model = repository.GetByRiskId(RiskId);
            if (model == null)
            {
                yukleniyor = false;
                return;
            }

            if (model.Olasilik == "N/A")
            {
                cmbOlasıHasar.SelectedIndex = 0;
                cmbKazaOlma.SelectedIndex = 0;
                cmbKacinma.SelectedIndex = 0;
                cmbMaruzKalma.SelectedIndex = 0;
            }
            else
            {
                cmbOlasıHasar.SelectedValue = double.Parse(model.Olasilik, CultureInfo.InvariantCulture);
                cmbKazaOlma.SelectedValue = double.Parse(model.KazaOlma, CultureInfo.InvariantCulture);
                cmbKacinma.SelectedValue = double.Parse(model.Kacinma, CultureInfo.InvariantCulture);
                cmbMaruzKalma.SelectedValue = double.Parse(model.MaruzKalma, CultureInfo.InvariantCulture);
            }

            ucTextEditor1.DbYolu = this.DbYolu;
            ucTextEditor1.BagliId = this.RiskId;
            ucTextEditor1.Alan = "Onlemler";
            ucTextEditor1.Yukle();

            ucTextEditor2.DbYolu = this.DbYolu;
            ucTextEditor2.BagliId = this.RiskId;
            ucTextEditor2.Alan = "ArtikRisk";
            ucTextEditor2.Yukle();

            ucTextEditor1.SetRtfText(model.OnlemlerRTF ?? "");
            ucTextEditor2.SetRtfText(model.ArtikRiskRTF ?? "");
            HesaplaHRN();
            yukleniyor = false;
        }
    }
}

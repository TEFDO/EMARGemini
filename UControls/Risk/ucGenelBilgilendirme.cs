// Güncellenmiş ucGenelBilgilendirme.cs - HRN hesaplaması + combobox veri açıklamaları + eksik metodlar tamamlandı
using EMAR.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EMAR.UControls
{
    public partial class ucGenelBilgilendirme : UserControl
    {
        public int BolgeNo { get; set; }
        public int RiskNo { get; set; }

        public int BolgeNumarasi { get; set; } = 1;
        public int RiskNumarasi { get; set; } = 1;
        public int RiskId { get; set; }
        public string DbYolu { get; set; }
        public string GorselYolu { get; set; }
        public string PiktogramYolu { get; set; }
        public ucGenelBilgilendirme()
        {
            InitializeComponent();
            YukleComboVerileri();
            YuklePLgComboVerileri();
            OlaylariAyarla();
            //ucTextEditor1.DbYolu = DbYolu; // Bunu yapmadan önce dbYolu'nun dolu olduğundan emin ol!
            this.Load += (s, e) =>
            {
                ucTextEditor1.DbYolu = this.DbYolu;
                ucTextEditor1.BagliId = this.RiskId;
                ucTextEditor1.Alan = "TehlikeTanim";
                ucTextEditor1.Yukle(); // otomatik içeri yükleme
            };


            this.btnPicSil.Click += new System.EventHandler(this.BtnPiktogramSil_Click);
            this.btnGorselSil.Click += new System.EventHandler(this.BtnGorselSil_Click);
            this.picPiktogram.Click += new System.EventHandler(this.BtnPiktogramSec_Click);
            this.picGorsel.Click += new System.EventHandler(this.BtnGorselYukle_Click);
            lblPLg.ContextMenuStrip = contextMenuPLg;
            txtPLg.Visible = false;
            txtPLg.Leave += txtPLg_Leave;
            txtPLg.KeyDown += txtPLg_KeyDown;
            düzenleToolStripMenuItem.Click += düzenleToolStripMenuItem_Click;
            lblTehlikeNo.Text = $"Tehlike No: {BolgeNumarasi}.{RiskNumarasi}";
        }
        // Sağ tık menü ile düzenle
        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtPLg.Text = lblPLg.Text;
            txtPLg.Visible = true;
            txtPLg.Focus();
            txtPLg.SelectAll();
            lblPLg.Visible = false;
        }

        // TextBox focus out
        private void txtPLg_Leave(object sender, EventArgs e)
        {
            lblPLg.Text = txtPLg.Text;
            lblPLg.Visible = true;
            txtPLg.Visible = false;
        }

        // TextBox enter tuşu
        private void txtPLg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblPLg.Text = txtPLg.Text;
                lblPLg.Visible = true;
                txtPLg.Visible = false;
            }
        }

        public void GuncelleTehlikeNo(int bolgeNo, int riskNo)
        {
            BolgeNumarasi = bolgeNo;
            RiskNumarasi = riskNo;
            lblTehlikeNo.Text = $"Tehlike No: {BolgeNumarasi}.{RiskNumarasi}";
            YuklePLgComboVerileri();
        }
        private void BtnPiktogramSec_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Görsel Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string hedefKlasor = Path.Combine(
                        Path.GetDirectoryName(DbYolu), "Gorseller", "GenelBilgi", $"Risk_{BolgeNumarasi}.{RiskNumarasi}"
                    );
                    Directory.CreateDirectory(hedefKlasor);

                    string hedef = Path.Combine(hedefKlasor, "Piktogram.png");

                    // PictureBox'taki mevcut resmi Dispose et!
                    if (picPiktogram.Image != null)
                    {
                        picPiktogram.Image.Dispose();
                        picPiktogram.Image = null;
                    }

                    // Eğer eski dosya varsa ve yeni seçilen dosya farklıysa eskiyi sil
                    if (File.Exists(hedef))
                    {
                        // Eğer tamamen aynı dosyaysa tekrar kopyalama!
                        if (!FilesAreEqual(ofd.FileName, hedef))
                        {
                            File.Delete(hedef);
                            File.Copy(ofd.FileName, hedef, true);
                        }
                        // Eğer aynı dosyaysa hiç işlem yapma, direkt aşağıdan yükle
                    }
                    else
                    {
                        File.Copy(ofd.FileName, hedef, true);
                    }

                    // Dosya kilidi bırakmamak için MemoryStream ile yükle!
                    using (var fs = new FileStream(hedef, FileMode.Open, FileAccess.Read))
                    using (var ms = new MemoryStream())
                    {
                        fs.CopyTo(ms);
                        ms.Position = 0;
                        picPiktogram.Image = Image.FromStream(ms);
                    }

                    // Property'de güncel yolu tut!
                    this.PiktogramYolu = Path.Combine("Gorseller", "GenelBilgi", $"Risk_{BolgeNumarasi}.{RiskNumarasi}", "Piktogram.png").Replace("\\", "/");
                }
            }
        }

        /// <summary>
        /// İki dosyanın birebir aynı olup olmadığını byte-by-byte karşılaştırır
        /// </summary>
        public static bool FilesAreEqual(string path1, string path2)
        {
            if (!File.Exists(path1) || !File.Exists(path2)) return false;
            FileInfo fi1 = new FileInfo(path1);
            FileInfo fi2 = new FileInfo(path2);
            if (fi1.Length != fi2.Length)
                return false;
            using (var fs1 = File.OpenRead(path1))
            using (var fs2 = File.OpenRead(path2))
            {
                int byte1, byte2;
                do
                {
                    byte1 = fs1.ReadByte();
                    byte2 = fs2.ReadByte();
                } while ((byte1 == byte2) && (byte1 != -1));
                return byte1 == -1;
            }
        }
        private void YukleComboVerileri()
        {
            INIHelper.YukleCommaSeparated(cmbTehlikeTipi, "TehlikeTipleri");
            INIHelper.YukleCommaSeparated(cmbGorevAsamasi, "GorevAsamalari");
            INIHelper.YukleCommaSeparated(cmbTehlikeHedefi, "TehlikeHedefleri");


            cmbDPH.DataSource = new List<KeyValuePair<double, string>> {
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
            cmbDPH.DisplayMember = "Value";
            cmbDPH.ValueMember = "Key";

            cmbLO.DataSource = new List<KeyValuePair<double, string>> {
        new(0.05, "0.05 - Neredeyse imkânsız"),
        new(1.25, "1.25 - Aşırı koşullarda olası veya mümkün değil"),
        new(2.5, "2.5 - Mümkün ama olağandışı"),
        new(4, "4 - Şans bile olsa olabilir"),
        new(5, "5 - Muhtemelen, sonunda olacak"),
        new(6, "6 - Muhtemelen, makul olarak öngörülebilir"),
        new(7, "7 - Kesinlikle, yakın zamanda gerçekleşecek")
    };
            cmbLO.DisplayMember = "Value";
            cmbLO.ValueMember = "Key";

            cmbPA.DataSource = new List<KeyValuePair<double, string>> {
        new(0.75, "0.75 - Tamamen mümkün"),
        new(2.5, "2.5 - Mümkün ancak sadece kontrollü koşullar altında"),
        new(5, "5 - Mümkün değil")
    };
            cmbPA.DisplayMember = "Value";
            cmbPA.ValueMember = "Key";

            cmbFE.DataSource = new List<KeyValuePair<double, string>> {
        new(0.5, "0.5 - Yıllık"),
        new(1, "1 - Aylık"),
        new(2, "2 - Haftalık"),
        new(3, "3 - Günlük"),
        new(4, "4 - Saatlik"),
        new(5, "5 - Sürekli")
    };
            cmbFE.DisplayMember = "Value";
            cmbFE.ValueMember = "Key";

            AyarlaComboBoxGenisligi(cmbDPH);
            AyarlaComboBoxGenisligi(cmbLO);
            AyarlaComboBoxGenisligi(cmbPA);
            AyarlaComboBoxGenisligi(cmbFE);
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

            comboBox.DropDownWidth = maxWidth + 30; // +30 padding
        }
        private void YuklePLgComboVerileri()
        {
            if (BolgeNumarasi == 1)
            {
                cmbS.Items.Clear();
                cmbS.Items.AddRange(new[] {
                    "S1 - HAFİF YARALANMA",
                    "S2 - CİDDİ YARALANMA",
                    "N/A"
                });
                cmbS.Enabled = true;

                cmbF.Items.Clear();
                cmbF.Items.AddRange(new[] {
                    "F1 - NADİREN",
                    "F2 - SÜREKLİ VE/VEYA UZUN SÜRELİ ",
                    "N/A"
                });
                cmbF.Enabled = true;

                cmbP.Items.Clear();
                cmbP.Items.AddRange(new[] {
                    "P1 - BELİRLİ ŞARTLAR ALTINDA MÜMKÜN",
                    "P2 - NADİREN MÜMKÜN",
                    "N/A"
                });
                cmbP.Enabled = true;

                //lblPLg.Text = "-";
            }
            else
            {
                cmbS.Items.Clear();
                cmbS.Items.Add("N/A");
                cmbS.SelectedIndex = 0;
                cmbS.Enabled = false;

                cmbF.Items.Clear();
                cmbF.Items.Add("N/A");
                cmbF.SelectedIndex = 0;
                cmbF.Enabled = false;

                cmbP.Items.Clear();
                cmbP.Items.Add("N/A");
                cmbP.SelectedIndex = 0;
                cmbP.Enabled = false;

                lblPLg.Text = "N/A";
            }
        }
        void SetSelectedItem(ComboBox cmb, string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return;
            foreach (var item in cmb.Items)
            {
                var itemStr = item.ToString().Trim();
                if (itemStr.Equals(value.Trim(), StringComparison.OrdinalIgnoreCase)
                    || itemStr.StartsWith(value.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    cmb.SelectedItem = item;
                    return;
                }
            }
            cmb.Items.Add(value);
            cmb.SelectedItem = value;
        }

        // Yinelenen tanım kaldırıldı
        private void OlaylariAyarla()
        {
            cmbLO.SelectedIndexChanged += HesaplaHRN;
            cmbPA.SelectedIndexChanged += HesaplaHRN;
            cmbFE.SelectedIndexChanged += HesaplaHRN;
            cmbDPH.SelectedIndexChanged += HesaplaHRN;

            cmbF.SelectedIndexChanged += HesaplaPLg;
            cmbS.SelectedIndexChanged += HesaplaPLg;
            cmbP.SelectedIndexChanged += HesaplaPLg;
        }
        private void HesaplaHRN(object sender, EventArgs e)
        {
            if (cmbDPH.SelectedValue == null || cmbLO.SelectedValue == null || cmbPA.SelectedValue == null || cmbFE.SelectedValue == null)
            {
                lblRiskSkoru.Text = "-";
                lblSeviye.Text = "-";
                lblRiskSkoru.BackColor = Color.Transparent;
                lblSeviye.BackColor = Color.Transparent;
                return;
            }

            // 🔴 4. bölge özel durumu
            if (BolgeNumarasi == 4)
            {
                lblRiskSkoru.Text = "N/A";
                lblSeviye.Text = "Kabul Edilemez";
                lblRiskSkoru.BackColor = Color.Transparent;
                lblSeviye.BackColor = Color.Transparent;
                return;
            }

            double dph = (double)cmbDPH.SelectedValue;
            double lo = (double)cmbLO.SelectedValue;
            double pa = (double)cmbPA.SelectedValue;
            double fe = (double)cmbFE.SelectedValue;

            double skorHam = dph * lo * pa * fe;
            double skor = RoundUpDown(skorHam);
            string seviye = RiskSeviyesi(skor);
            Color renk = RenkBelirle(skor);

            lblRiskSkoru.Text = skor.ToString(CultureInfo.InvariantCulture);
            lblSeviye.Text = seviye;
            lblRiskSkoru.BackColor = renk;
            lblSeviye.BackColor = renk;
        }
        private double RoundUpDown(double sayi)
        {
            if (sayi < 1) return 1;
            return (sayi - Math.Floor(sayi)) >= 0.5 ? Math.Ceiling(sayi) : Math.Floor(sayi);
        }
        private Color RenkBelirle(double skor)
        {
            if (skor <= 10) return Color.FromArgb(146, 208, 80);      // Açık yeşil
            else if (skor <= 45) return Color.Orange;                 // Turuncu
            else return Color.Red;                                    // Kırmızı
        }
        private string RiskSeviyesi(double skor)
        {
            if (skor <= 10) return "İhmal Edilebilir Risk";
            else if (skor <= 20) return "Çok Düşük Risk";
            else if (skor <= 45) return "Düşük Risk";
            else if (skor <= 160) return "Önemli Risk";
            else return "Yüksek Risk";
        }
        private void BtnGorselYukle_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Görsel Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string hedefKlasor = Path.Combine(
                        Path.GetDirectoryName(DbYolu), "Gorseller", "GenelBilgi", $"Risk_{BolgeNumarasi}.{RiskNumarasi}"
                    );
                    Directory.CreateDirectory(hedefKlasor);

                    string hedef = Path.Combine(hedefKlasor, "Gorsel.png");

                    // PictureBox kilidini kaldır!
                    if (picGorsel.Image != null)
                    {
                        picGorsel.Image.Dispose();
                        picGorsel.Image = null;
                    }

                    if (File.Exists(hedef))
                        File.Delete(hedef);

                    File.Copy(ofd.FileName, hedef, true);

                    // Dosya kilitlenmesin diye MemoryStream ile yükle!
                    using (var fs = new FileStream(hedef, FileMode.Open, FileAccess.Read))
                    using (var ms = new MemoryStream())
                    {
                        fs.CopyTo(ms);
                        ms.Position = 0;
                        picGorsel.Image = Image.FromStream(ms);
                    }
                    this.GorselYolu = Path.Combine("Gorseller", "GenelBilgi", $"Risk_{BolgeNumarasi}.{RiskNumarasi}", "Gorsel.png").Replace("\\", "/");
                }
            }
        }
        private void HesaplaPLg(object sender, EventArgs e)
        {
            if (BolgeNumarasi != 1)
            {
                // 2-3-4. bölgede zorunlu olarak N/A uygula
                cmbS.SelectedItem = "N/A";
                cmbF.SelectedItem = "N/A";
                cmbP.SelectedItem = "N/A";

                cmbS.Enabled = false;
                cmbF.Enabled = false;
                cmbP.Enabled = false;

                lblPLg.Text = "N/A";
                return;
            }

            // 1. bölge: Her birinde N/A seçilebilsin!
            cmbS.Enabled = true;
            cmbF.Enabled = true;
            cmbP.Enabled = true;

            string s = cmbS.SelectedItem?.ToString();
            string f = cmbF.SelectedItem?.ToString();
            string p = cmbP.SelectedItem?.ToString();

            if (s == "N/A" && f == "N/A" && p == "N/A")
            {
                lblPLg.Text = "N/A";
                return;
            }
            if (s == "N/A" || f == "N/A" || p == "N/A")
            {
                lblPLg.Text = "-";
                return;
            }

            // Hepsi seçili olmalı, aksi durumda -
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(f) || string.IsNullOrEmpty(p))
            {
                lblPLg.Text = "-";
                return;
            }

            string sonuc = "-";

            if (s.StartsWith("S1"))
            {
                if (f.StartsWith("F1")) sonuc = p.StartsWith("P1") ? "PL a" : "PL b";
                else sonuc = p.StartsWith("P1") ? "PL b" : "PL c";
            }
            else if (s.StartsWith("S2"))
            {
                if (f.StartsWith("F1")) sonuc = p.StartsWith("P1") ? "PL b" : "PL c";
                else sonuc = p.StartsWith("P1") ? "PL c" : "PL d";
            }

            lblPLg.Text = sonuc;
        }
        public void Kaydet(bool gorseliZorlaSil = false, bool piktogramiZorlaSil = false)
        {
            if (!File.Exists(DbYolu)) return;

            var repo = new GenelBilgilendirmeRepository(DbYolu);
            repo.EnsureTable();

            var eskiVeri = repo.GetByRiskId(RiskId);

            // Eğer silme talebi varsa, eski veriyi de null yap!
            string gorselYolu = gorseliZorlaSil ? null : (!string.IsNullOrWhiteSpace(this.GorselYolu) ? this.GorselYolu : (eskiVeri?.Gorsel ?? null));
            string piktogramYolu = piktogramiZorlaSil ? null : (!string.IsNullOrWhiteSpace(this.PiktogramYolu) ? this.PiktogramYolu : (eskiVeri?.Piktogram ?? null));

            var veri = new GenelBilgilendirme
            {
                RiskId = RiskId,
                TehlikeTipi = cmbTehlikeTipi.Text,
                GorevAsamasi = cmbGorevAsamasi.Text,
                TehlikeHedefi = cmbTehlikeHedefi.Text,
                S = cmbS.Text,
                F = cmbF.Text,
                P = cmbP.Text,
                DPH = cmbDPH.SelectedValue is double dph ? dph : 0,
                LO = cmbLO.SelectedValue is double lo ? lo : 0,
                PA = cmbPA.SelectedValue is double pa ? pa : 0,
                FE = cmbFE.SelectedValue is double fe ? fe : 0,
                Gorsel = gorselYolu,
                Piktogram = piktogramYolu,
                TehlikeTanim = ucTextEditor1?.RtfText ?? "",
                Bakim = chkBakim.Checked,
                Temizlik = chkTemizlik.Checked,
                Operator = chkOperator.Checked,
                Ziyaretci = chkZiyaretci.Checked,

                // EKLE!
                HRN = lblRiskSkoru.Text,      // veya hesaplanan skor değeri
                HRNSeviye = lblSeviye.Text,   // veya hesaplanan seviye
                PLg = lblPLg.Text,            // veya hesaplanan PLg
            };
            repo.Save(veri);
        }
        public void Yukle()
        {
            if (!File.Exists(DbYolu)) return;

            var repo = new GenelBilgilendirmeRepository(DbYolu);
            repo.EnsureTable();
            var veri = repo.GetByRiskId(RiskId);
            if (veri == null) return;

            // --- OLAYLARI KALDIR ---
            cmbS.SelectedIndexChanged -= HesaplaPLg;
            cmbF.SelectedIndexChanged -= HesaplaPLg;
            cmbP.SelectedIndexChanged -= HesaplaPLg;

            cmbLO.SelectedIndexChanged -= HesaplaHRN;
            cmbPA.SelectedIndexChanged -= HesaplaHRN;
            cmbFE.SelectedIndexChanged -= HesaplaHRN;
            cmbDPH.SelectedIndexChanged -= HesaplaHRN;

            // --- ComboBox içeriklerini YENİDEN yükle ---
            YukleComboVerileri();
            YuklePLgComboVerileri(); // Burada Clear+AddRange olmalı!

            // --- Değerleri ata ---
            SetSelectedItem(cmbS, veri.S);
            SetSelectedItem(cmbF, veri.F);
            SetSelectedItem(cmbP, veri.P);

            SetSelectedItem(cmbTehlikeTipi, veri.TehlikeTipi);
            SetSelectedItem(cmbGorevAsamasi, veri.GorevAsamasi);
            SetSelectedItem(cmbTehlikeHedefi, veri.TehlikeHedefi);

            cmbDPH.SelectedValue = veri.DPH;
            cmbLO.SelectedValue = veri.LO;
            cmbPA.SelectedValue = veri.PA;
            cmbFE.SelectedValue = veri.FE;

            ucTextEditor1.RtfText = veri.TehlikeTanim ?? "";

            chkBakim.Checked = veri.Bakim;
            chkTemizlik.Checked = veri.Temizlik;
            chkOperator.Checked = veri.Operator;
            chkZiyaretci.Checked = veri.Ziyaretci;

            lblRiskSkoru.Text = veri.HRN;
            lblSeviye.Text = veri.HRNSeviye;
            lblPLg.Text = veri.PLg;

            // --- OLAYLARI GERİ TAK ---
            OlaylariAyarla();

            // --- Hesaplamaları MANUEL çağır ---
            if (BolgeNumarasi == 1)
                HesaplaPLg(null, null);

            HesaplaHRN(null, null);

            string basePath = Path.GetDirectoryName(DbYolu);

            // Görsel yüklemede:
            if (!string.IsNullOrWhiteSpace(veri.Gorsel))
            {
                string tamYol = Path.Combine(basePath, veri.Gorsel);
                if (File.Exists(tamYol))
                {
                    GorselYukle(picGorsel, tamYol);
                    this.GorselYolu = veri.Gorsel;
                }
                else
                {
                    // Dosya yoksa UI ve property'yi temizle
                    if (picGorsel.Image != null) picGorsel.Image.Dispose();
                    picGorsel.Image = null;
                    this.GorselYolu = null;
                }
            }
            else
            {
                if (picGorsel.Image != null) picGorsel.Image.Dispose();
                picGorsel.Image = null;
                this.GorselYolu = null;
            }

            // Piktogram yüklemede:
            if (!string.IsNullOrWhiteSpace(veri.Piktogram))
            {
                string tamPiktogram = Path.Combine(basePath, veri.Piktogram);
                if (File.Exists(tamPiktogram))
                {
                    GorselYukle(picPiktogram, tamPiktogram);
                    this.PiktogramYolu = veri.Piktogram;
                }
                else
                {
                    if (picPiktogram.Image != null) picPiktogram.Image.Dispose();
                    picPiktogram.Image = null;
                    this.PiktogramYolu = null;
                }
            }
            else
            {
                if (picPiktogram.Image != null) picPiktogram.Image.Dispose();
                picPiktogram.Image = null;
                this.PiktogramYolu = null;
            }

            HesaplaPLg(null, null);
        }
        private void GorselYukle(PictureBox pic, string dosyaYolu)
        {
            // Eski resmi temizle
            if (pic.Image != null)
            {
                pic.Image.Dispose();
                pic.Image = null;
            }
            if (File.Exists(dosyaYolu))
            {
                using (var fs = new FileStream(dosyaYolu, FileMode.Open, FileAccess.Read))
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    ms.Position = 0;
                    using (var original = Image.FromStream(ms))
                    {
                        var thumb = new Bitmap(original, new Size(128, 128)); // veya uygun boyut
                        pic.Image = new Bitmap(thumb);
                        thumb.Dispose();
                    }
                }
            }
        }

        public void SetTehlikeKonum(int bolgeNo, int riskNo)
        {
            this.BolgeNumarasi = bolgeNo;
            this.RiskNumarasi = riskNo;
            lblTehlikeNo.Text = $"Tehlike No: {bolgeNo}.{riskNo}";
        }

        private void BtnGorselSil_Click(object sender, EventArgs e)
        {
            // PictureBox ve property'yi kesin null yap
            if (picGorsel.Image != null)
            {
                picGorsel.Image.Dispose();
                picGorsel.Image = null;
            }

            if (!string.IsNullOrWhiteSpace(this.GorselYolu))
            {
                string tamYol = Path.Combine(Path.GetDirectoryName(DbYolu), this.GorselYolu);
                if (File.Exists(tamYol))
                {
                    try { File.Delete(tamYol); }
                    catch (Exception ex) { MessageBox.Show("Görsel silinemedi:\n" + ex.Message); }
                }
                this.GorselYolu = null;
                // Kaydet fonksiyonunu silme modunda çağır (DB'den de gitsin)
                Kaydet(gorseliZorlaSil: true);
            }
        }
        private void BtnPiktogramSil_Click(object sender, EventArgs e)
        {
            if (picPiktogram.Image != null)
            {
                picPiktogram.Image.Dispose();
                picPiktogram.Image = null;
            }
            if (!string.IsNullOrWhiteSpace(this.PiktogramYolu))
            {
                string tamYol = Path.Combine(Path.GetDirectoryName(DbYolu), this.PiktogramYolu);
                if (File.Exists(tamYol))
                {
                    try { File.Delete(tamYol); }
                    catch (Exception ex) { MessageBox.Show("Piktogram silinemedi:\n" + ex.Message); }
                }
                this.PiktogramYolu = null;
                Kaydet(piktogramiZorlaSil: true);
            }
        }
        
    }
}

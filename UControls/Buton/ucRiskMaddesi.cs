using EMAR.UControls.Risk;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMAR.UControls
{
    public partial class ucRiskMaddesi : UserControl
    {
        private const int KapaliYukseklik = 60;
        private const int AcikYukseklik = 270;
        public int BolgeNo { get; set; }
        public int RiskNo { get; set; }
        public string ProjeKodu { get; set; }
        public string MakineAdi { get; set; }
        public string RaporTuru { get; set; }

        public int RiskId { get; set; }
        public int EskiRiskNo { get; set; } // Dosya/klasör taşıma için
        public string DbYolu { get; set; }
        public bool IsSelected { get; set; } = false;

        public ucRiskMaddesi()
        {
            InitializeComponent();
            this.Click += (s, e) => SelectRisk();
            this.Margin = new Padding(0);
            this.Height = KapaliYukseklik;
            LoadAltBaslikButonlari();
        }

        public void SelectRisk()
        {
            if (this.Parent is FlowLayoutPanel parentFlow)
            {
                foreach (Control c in parentFlow.Controls)
                {
                    if (c is ucRiskMaddesi risk)
                    {
                        risk.IsSelected = false;
                        risk.BorderStyle = BorderStyle.None;
                        risk.BackColor = SystemColors.Control;
                    }
                }
            }
            this.IsSelected = true;
            this.BorderStyle = BorderStyle.Fixed3D;
            this.BackColor = Color.LightSteelBlue;
        }

        public string RiskAdi
        {
            get => btnRiskBaslik.Text;
            set => btnRiskBaslik.Text = value;
        }

        private void LoadAltBaslikButonlari()
        {
            btnGenelBilgilendirme.Visible = false;
            btnRiskAzaltimi.Visible = false;
            btnMevcutDurum.Visible = false;
            btnModifikasyon.Visible = false;

            btnRiskBaslik.Click -= BtnRiskBaslik_Click;
            btnRiskBaslik.Click += BtnRiskBaslik_Click;
            btnGenelBilgilendirme.Click -= BtnAltBaslik_Click;
            btnGenelBilgilendirme.Click += BtnAltBaslik_Click;
            btnRiskAzaltimi.Click -= BtnAltBaslik_Click;
            btnRiskAzaltimi.Click += BtnAltBaslik_Click;
            btnMevcutDurum.Click -= BtnAltBaslik_Click;
            btnMevcutDurum.Click += BtnAltBaslik_Click;
            btnModifikasyon.Click -= BtnAltBaslik_Click;
            btnModifikasyon.Click += BtnAltBaslik_Click;
        }

        private async void BtnRiskBaslik_Click(object s, EventArgs e)
        {
            SelectRisk();
            await ToggleAltBasliklarAsync();
        }

        private void BtnAltBaslik_Click(object s, EventArgs e)
        {
            SelectRisk();
            string baslik = (s == btnGenelBilgilendirme) ? "Genel Bilgilendirme"
                         : (s == btnRiskAzaltimi) ? "Risk Azaltımı"
                         : (s == btnMevcutDurum) ? "Mevcut Durum"
                         : (s == btnModifikasyon) ? "Modifikasyon Önerileri"
                         : "";
            if (!string.IsNullOrEmpty(baslik))
                GosterAltIcerik(baslik);
        }

        private async Task ToggleAltBasliklarAsync()
        {
            bool yeniDurum = !btnGenelBilgilendirme.Visible;

            if (yeniDurum)
            {
                if (this.Parent is FlowLayoutPanel parentFlow)
                {
                    foreach (var other in parentFlow.Controls.OfType<ucRiskMaddesi>())
                    {
                        if (other != this)
                            other.KapatAltBasliklar();
                    }
                }
            }

            btnGenelBilgilendirme.Visible = yeniDurum;
            btnRiskAzaltimi.Visible = yeniDurum;
            btnMevcutDurum.Visible = yeniDurum;
            btnModifikasyon.Visible = yeniDurum;

            int hedefYukseklik = yeniDurum ? AcikYukseklik : KapaliYukseklik;
            await AnimateHeightAsync(this, hedefYukseklik, 120);

            if (yeniDurum)
                GosterAltIcerik("Genel Bilgilendirme");
        }

        public void KapatAltBasliklar()
        {
            btnGenelBilgilendirme.Visible = false;
            btnRiskAzaltimi.Visible = false;
            btnMevcutDurum.Visible = false;
            btnModifikasyon.Visible = false;
            this.Height = KapaliYukseklik;
        }

        public void GosterAltIcerik(string baslik)
        {
            Form anaForm = this.FindForm();
            if (anaForm is EMAR.frmRASCDetay frm)
            {
                frm.ProjeKodu = this.ProjeKodu;
                frm.MakineAdi = this.MakineAdi;
                frm.RaporTuru = this.RaporTuru;
                frm.GosterAltBaslikIcerigi(this, baslik);
            }
        }

        public void SimuleClick()
        {
            _ = ToggleAltBasliklarAsync();
        }

        private Task AnimateHeightAsync(Control control, int hedefYukseklik, int sureMs)
        {
            control.Height = hedefYukseklik;
            return Task.CompletedTask;
        }

        //private async Task AnimateHeightAsync(Control control, int hedefYukseklik, int sureMs)
        //{
        //    int baslangic = control.Height;
        //    int fark = hedefYukseklik - baslangic;
        //    int adimSayisi = 10;
        //    int gecikme = sureMs / adimSayisi;

        //    for (int i = 1; i <= adimSayisi; i++)
        //    {
        //        int yeniYukseklik = baslangic + (fark * i / adimSayisi);
        //        control.Height = yeniYukseklik;
        //        await Task.Delay(gecikme);
        //    }
        //}

    }
}

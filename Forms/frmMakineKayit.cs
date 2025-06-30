using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using EMAR.Models;
using EMAR.Repository;
using EMAR.Helpers;
using System.Linq;

namespace EMAR
{
    public partial class frmMakineKayit : Form
    {
        public Makine Makine { get; set; } = new Makine();
        public bool DuzenlemeModu { get; set; } = false;
        public int kaydedilenMakineId { get; set; } = 0;
        public bool KopyalamaModu { get; set; } = false;

        private string originalMakineJson = "";

        public frmMakineKayit() => InitializeComponent();

        private void frmMakineKayit_Load(object sender, EventArgs e)
        {
            Text = DuzenlemeModu ? "Makineyi Düzenle" : KopyalamaModu ? "Makineyi Kopyala" : "Yeni Makine Ekle";

            INIHelper.YukleCommaSeparated(cmbTipi, "MakineTipleri");
            INIHelper.YukleCommaSeparated(cmbSertifikasyon, "Sertifikasyonlar");

            INIHelper.YukleCommaSeparated(clbElektrik, "ElektrikKaynaklari");
            INIHelper.YukleCommaSeparated(clbPnomatik, "PnomatikKaynaklari");
            INIHelper.YukleCommaSeparated(clbHidrolik, "HidrolikKaynaklari");

            YukleMusteriler();

            if (KopyalamaModu || DuzenlemeModu)
                ModeliFormaAktar();
        }

        private void YukleMusteriler()
        {
            var dt = VeritabaniHelper.TabloGetir("SELECT Id, Ad FROM Musteriler");
            cmbMusteri.DataSource = dt;
            cmbMusteri.DisplayMember = "Ad";
            cmbMusteri.ValueMember = "Id";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!FormValidator.ZorunluAlanlariKontrolEt(
                ("Makine Adı", txtAd.Text),
                ("İmalatçı", txtImalatci.Text),
                ("Seri No", txtSeriNo.Text)))
                return;

            FormuModeleAktar();

            if (KopyalamaModu && SerializeMakine(Makine) == originalMakineJson)
            {
                MessageBox.Show("Kopyalanan kayıt üzerinde değişiklik yapılmadı.");
                return;
            }

            KaydetMakine();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnMakineLimitleri_Click(object sender, EventArgs e)
        {
            if (!DuzenlemeModu || Makine is null || Makine.Id <= 0)
            {
                MessageBox.Show("Makine limitlerini görüntüleyebilmek için önce makineyi kaydedin veya düzenleme modunda açın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var limitForm = new frmMakineLimitleri { SeciliMakineId = Makine.Id })
            {
                limitForm.ShowDialog();
            }
        }

        private void FormuModeleAktar()
        {
            Makine.Ad = txtAd.Text.Trim();
            Makine.Name = txtName.Text.Trim(); // İngilizce adı al
            Makine.Imalatci = txtImalatci.Text.Trim();
            Makine.SeriNo = txtSeriNo.Text.Trim();
            Makine.UretimYili = (int)numYil.Value;
            Makine.Tipi = cmbTipi.Text;
            Makine.Sertifikasyon = cmbSertifikasyon.Text;
            Makine.MusteriId = cmbMusteri.SelectedValue is not null ? Conversions.ToInteger(cmbMusteri.SelectedValue) : 0;
            Makine.Elektrik = SecimleriAl(clbElektrik);
            Makine.Pnomatik = SecimleriAl(clbPnomatik);
            Makine.Hidrolik = SecimleriAl(clbHidrolik);
            Makine.DigerEnerjiKaynaklari = txtDiger.Text.Trim(); // Diğer enerji kaynaklarını al
        }


        private void ModeliFormaAktar()
        {
            txtAd.Text = Makine.Ad;
            txtName.Text = Makine.Name ?? ""; // İngilizce adı forma yaz
            txtImalatci.Text = Makine.Imalatci;
            txtSeriNo.Text = Makine.SeriNo;
            numYil.Value = Makine.UretimYili > 0 ? Makine.UretimYili : numYil.Minimum;
            cmbTipi.Text = Makine.Tipi;
            cmbSertifikasyon.Text = Makine.Sertifikasyon;
            cmbMusteri.SelectedValue = Makine.MusteriId;
            CheckDegerler(clbElektrik, Makine.Elektrik);
            CheckDegerler(clbPnomatik, Makine.Pnomatik);
            CheckDegerler(clbHidrolik, Makine.Hidrolik);
            txtDiger.Text = Makine.DigerEnerjiKaynaklari ?? ""; // Diğer enerji kaynaklarını forma yaz
        }


        private void KaydetMakine()
        {
            try
            {
                kaydedilenMakineId = DuzenlemeModu
                    ? MakineRepository.Kaydet(Makine, guncelle: true)
                    : MakineRepository.Kaydet(Makine);

                MessageBox.Show("Makine başarıyla " + (DuzenlemeModu ? "güncellendi." : "kaydedildi."), "Tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SerializeMakine(Makine m) =>
            $"{m.Ad}|{m.Name}|{m.Imalatci}|{m.SeriNo}|{m.Tipi}|{m.UretimYili}|{m.Sertifikasyon}|{m.MusteriId}|{m.Elektrik}|{m.Pnomatik}|{m.Hidrolik}|{m.DigerEnerjiKaynaklari}";


        private string SecimleriAl(CheckedListBox clb)
        {
            var secilenler = new List<string>();
            foreach (var item in clb.CheckedItems)
                secilenler.Add(item.ToString());
            return string.Join(",", secilenler);
        }

        private void CheckDegerler(CheckedListBox clb, string degerler)
        {
            if (string.IsNullOrWhiteSpace(degerler)) return;

            var secilecekler = degerler.Split(',');
            for (int i = 0; i < clb.Items.Count; i++)
            {
                if (secilecekler.Contains(clb.Items[i].ToString()))
                    clb.SetItemChecked(i, true);
            }
        }

        /// <summary>
        /// Form kapanırken tüm kontrolleri ve Disposable nesneleri temizle (RAM leak önlemi)
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is IDisposable disposable)
                    disposable.Dispose();
            }
            base.OnFormClosing(e);
        }
    }
}

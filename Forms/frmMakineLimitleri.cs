using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using EMAR.Helpers;
using EMAR.Models;
using EMAR.Repository;
using System.IO;

namespace EMAR
{
    public partial class frmMakineLimitleri : Form
    {
        public int SeciliMakineId { get; set; } = 0;

        public frmMakineLimitleri() => InitializeComponent();

        public frmMakineLimitleri(int makineId) : this() => SeciliMakineId = makineId;

        private void frmMakineLimitleri_Load(object sender, EventArgs e)
        {
            if (!File.Exists("ayarlar.ini"))
            {
                MessageBox.Show("INI dosyası bulunamadı!");
                return;
            }

            YukleMakineler();
            INIHelper.YukleCommaSeparated(clbKullaniciSeviyeleri, "KullaniciSeviyeleri");

            if (SeciliMakineId > 0)
            {
                cmbMakine.SelectedValue = SeciliMakineId;
                cmbMakine_SelectedIndexChanged(null, null);
            }
        }

        private void YukleMakineler()
        {
            var dt = VeritabaniHelper.TabloGetir("SELECT Id, Ad FROM Makineler");
            cmbMakine.DataSource = dt;
            cmbMakine.DisplayMember = "Ad";
            cmbMakine.ValueMember = "Id";
        }

        private void cmbMakine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMakine.SelectedItem is not DataRowView row) return;
            int makineId = Convert.ToInt32(row["Id"]);

            var dt = VeritabaniHelper.TabloGetir("SELECT * FROM Makineler WHERE Id = @id", new() { ["@id"] = makineId });
            if (dt.Rows.Count == 0) return;
            var r = dt.Rows[0];

            txtKullanimAmaci.Text = r["KullanimAmaci"].ToString();
            txtPersonelTipi.Text = r["PersonelTipi"].ToString();
            txtBakimSikligi.Text = r["BakimSikligi"].ToString();
            txtOlculer.Text = r["MakineOlculeri"].ToString();
            txtZamanLimitleri.Text = r["ZamanLimitleri"].ToString();

            string[] secimler = (r["KullaniciSeviyesi"]?.ToString() ?? "").Split(';');
            for (int i = 0; i < clbKullaniciSeviyeleri.Items.Count; i++)
                clbKullaniciSeviyeleri.SetItemChecked(i, false);

            foreach (var secim in secimler)
            {
                int index = clbKullaniciSeviyeleri.Items.IndexOf(secim.Trim());
                if (index >= 0)
                    clbKullaniciSeviyeleri.SetItemChecked(index, true);
            }
        }

        private void btnSeviyeEkle_Click(object sender, EventArgs e)
        {
            string yeni = txtSeviyeYeni.Text.Trim();
            if (!string.IsNullOrEmpty(yeni) && !clbKullaniciSeviyeleri.Items.Contains(yeni))
            {
                clbKullaniciSeviyeleri.Items.Add(yeni, true);
                txtSeviyeYeni.Clear();
            }
        }

        private void btnTumunuSec_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbKullaniciSeviyeleri.Items.Count; i++)
                clbKullaniciSeviyeleri.SetItemChecked(i, true);
        }

        private void btnIptalSecim_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbKullaniciSeviyeleri.Items.Count; i++)
                clbKullaniciSeviyeleri.SetItemChecked(i, false);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbMakine.SelectedValue is null)
            {
                MessageBox.Show("Lütfen bir makine seçiniz.");
                return;
            }

            var makine = new Makine
            {
                Id = Convert.ToInt32(cmbMakine.SelectedValue),
                KullanimAmaci = txtKullanimAmaci.Text,
                PersonelTipi = txtPersonelTipi.Text,
                BakimSikligi = txtBakimSikligi.Text,
                MakineOlculeri = txtOlculer.Text,
                ZamanLimitleri = txtZamanLimitleri.Text,
                KullaniciSeviyesi = string.Join(";", clbKullaniciSeviyeleri.CheckedItems.Cast<string>())
            };

            MakineRepository.GuncelleLimitler(makine);

            MessageBox.Show("Makine limit bilgileri kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Form kapanırken tüm disposable kontrolleri ve kaynakları temizle (RAM leak önlemi)
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

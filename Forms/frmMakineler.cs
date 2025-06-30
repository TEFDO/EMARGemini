using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EMAR.Models;
using EMAR.Repository;

namespace EMAR
{
    public partial class frmMakineler : Form
    {
        private string aramaKelimesi = "";

        public frmMakineler()
        {
            InitializeComponent();
        }

        private void frmMakineler_Load(object sender, EventArgs e)
        {
            ProjeListesiniYukle();
            YukleMakineler();
            txtArama.KeyDown += txtArama_KeyDown;
        }

        private void ProjeListesiniYukle()
        {
            cmbProjeler.Items.Clear();
            cmbProjeler.Items.Add(new { Id = 0, ProjeKodu = "Tüm Makineler" });

            var dt = Helpers.VeritabaniHelper.TabloGetir("SELECT Id, ProjeKodu FROM Projeler");
            foreach (System.Data.DataRow row in dt.Rows)
            {
                cmbProjeler.Items.Add(new
                {
                    Id = row["Id"],
                    ProjeKodu = row["ProjeKodu"].ToString()
                });
            }
            cmbProjeler.DisplayMember = "ProjeKodu";
            cmbProjeler.SelectedIndex = 0;
        }

        private void YukleMakineler()
        {
            var secilenProje = cmbProjeler.SelectedItem;
            var projeId = ((dynamic)secilenProje).Id;
            var makineler = MakineRepository.Listele(Convert.ToInt32(projeId), aramaKelimesi);

            // Önce eski satırları dispose et
            dgvMakineler.Rows.Clear();

            foreach (var m in makineler)
                dgvMakineler.Rows.Add(m.Id, m.Ad, m.MusteriAd, m.Tipi, m.SeriNo);

            dgvMakineler.EnableHeadersVisualStyles = false;
            dgvMakineler.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        private void cmbProjeler_SelectedIndexChanged(object sender, EventArgs e) => YukleMakineler();

        private void btnEkle_Click(object sender, EventArgs e)
        {
            using (var frm = new frmMakineKayit())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int yeniMakineId = frm.kaydedilenMakineId;
                    var secilenProje = cmbProjeler.SelectedItem;

                    if (((dynamic)secilenProje).Id is int pid && pid != 0)
                    {
                        Helpers.VeritabaniHelper.KomutCalistir(
                            "INSERT OR IGNORE INTO ProjeMakineleri (ProjeId, MakineId) VALUES (@pid, @mid)",
                            new Dictionary<string, object> { ["@pid"] = pid, ["@mid"] = yeniMakineId }
                        );
                    }
                    YukleMakineler();
                }
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (dgvMakineler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen düzenlemek için bir makine seçin.");
                return;
            }

            int seciliId = Convert.ToInt32(dgvMakineler.SelectedRows[0].Cells[0].Value);
            var makine = MakineRepository.Getir(seciliId);
            if (makine is null) return;

            using (var frm = new frmMakineKayit()
            {
                Makine = makine,
                DuzenlemeModu = true
            })
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    YukleMakineler();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvMakineler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir makine seçin.");
                return;
            }

            int seciliId = Convert.ToInt32(dgvMakineler.SelectedRows[0].Cells[0].Value);

            if (Helpers.VeritabaniHelper.MakineBaskaProjeyeBagliMi(seciliId))
            {
                if (MessageBox.Show("Bu makine başka projelere de bağlı. Tüm ilişkileri kaldırıp silmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;

                Helpers.VeritabaniHelper.MakineyiProjelerdenSil(seciliId);
            }

            MakineRepository.Sil(seciliId);
            YukleMakineler();
        }

        private void btnMakineLimitleri_Click(object sender, EventArgs e)
        {
            if (dgvMakineler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir makine seçin.");
                return;
            }

            int seciliId = Convert.ToInt32(dgvMakineler.SelectedRows[0].Cells[0].Value);
            using (var frm = new frmMakineLimitleri() { SeciliMakineId = seciliId })
            {
                frm.ShowDialog();
            }
            YukleMakineler();
        }

        private void btnGeri_Click(object sender, EventArgs e) => Close();

        private void dgvMakineler_CellContentClick(object sender, DataGridViewCellEventArgs e) => btnDuzenle.PerformClick();

        private void btnKopyala_Click(object sender, EventArgs e)
        {
            if (dgvMakineler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen kopyalamak için bir makine seçin.");
                return;
            }

            int seciliId = Convert.ToInt32(dgvMakineler.SelectedRows[0].Cells[0].Value);
            var orijinal = MakineRepository.Getir(seciliId);
            if (orijinal is null) return;

            var kopya = new Makine()
            {
                Ad = orijinal.Ad + " (Kopya)",
                Imalatci = orijinal.Imalatci,
                SeriNo = orijinal.SeriNo,
                Tipi = orijinal.Tipi,
                UretimYili = orijinal.UretimYili,
                Sertifikasyon = orijinal.Sertifikasyon,
                MusteriId = orijinal.MusteriId,
                Elektrik = orijinal.Elektrik,
                Pnomatik = orijinal.Pnomatik,
                Hidrolik = orijinal.Hidrolik
            };

            using (var frm = new frmMakineKayit()
            {
                Makine = kopya,
                DuzenlemeModu = false,
                KopyalamaModu = true
            })
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    YukleMakineler();
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            aramaKelimesi = txtArama.Text.Trim();
            YukleMakineler();
        }

        private void txtArama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnAra.PerformClick();
            }
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

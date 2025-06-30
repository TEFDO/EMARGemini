// EMAR - Projeler Listesi (Repository Entegrasyonu + Filtreleme)

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EMAR.Models;
using EMAR.Repository;

namespace EMAR
{
    public partial class frmProjeler : Form
    {
        private string aramaKelimesi = "";

        public frmProjeler() => InitializeComponent();

        private void frmProjeler_Load(object sender, EventArgs e)
        {
            TopLevel = false;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;

            dgvProjeler.AutoGenerateColumns = false;
            dgvProjeler.Columns.Clear();

            dgvProjeler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvProjeler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Ad", HeaderText = "Proje Adı", DataPropertyName = "Ad", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 30f, MinimumWidth = 280 });
            dgvProjeler.Columns.Add(new DataGridViewTextBoxColumn { Name = "ProjeKodu", HeaderText = "Proje Kodu", DataPropertyName = "ProjeKodu", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 10f, MinimumWidth = 180 });
            dgvProjeler.Columns.Add(new DataGridViewTextBoxColumn { Name = "HizmetKodu", HeaderText = "Hizmet Kodu", DataPropertyName = "HizmetKodu", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 10f, MinimumWidth = 180 });
            dgvProjeler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Tarih", HeaderText = "Tarih", DataPropertyName = "Tarih", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 10f, MinimumWidth = 160 });
            dgvProjeler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Aciklama", HeaderText = "Açıklama", DataPropertyName = "Aciklama", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 25f });
            dgvProjeler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Musteri", HeaderText = "Müşteri", DataPropertyName = "MusteriAd", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 25f });

            dgvProjeler.DataSource = ProjeRepository.Listele(aramaKelimesi);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            var frm = new frmProjeKayit();
            if (frm.ShowDialog() == DialogResult.OK)
                dgvProjeler.DataSource = ProjeRepository.Listele(aramaKelimesi);
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (dgvProjeler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir proje seçin.");
                return;
            }

            int seciliId = Convert.ToInt32(dgvProjeler.SelectedRows[0].Cells["Id"].Value);
            var proje = ProjeRepository.Getir(seciliId);
            if (proje == null)
            {
                MessageBox.Show("Proje bulunamadı.");
                return;
            }

            var frm = new frmProjeKayit { DuzenlemeModu = true, SeciliProjeId = seciliId, Proje = proje };
            if (frm.ShowDialog() == DialogResult.OK)
                dgvProjeler.DataSource = ProjeRepository.Listele(aramaKelimesi);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvProjeler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir proje seçin.");
                return;
            }

            int seciliId = Convert.ToInt32(dgvProjeler.SelectedRows[0].Cells["Id"].Value);
            var onay = MessageBox.Show("Bu projeyi silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (onay == DialogResult.Yes)
            {
                ProjeRepository.Sil(seciliId);
                dgvProjeler.DataSource = ProjeRepository.Listele(aramaKelimesi);
            }
        }

        private void btnMakineEkle_Click(object sender, EventArgs e)
        {
            if (dgvProjeler.SelectedRows.Count == 0) return;
            int projeId = Convert.ToInt32(dgvProjeler.SelectedRows[0].Cells["Id"].Value);

            var frm = new frmProjeyeMakineEkle { aktifProjeId = projeId };
            frm.ShowDialog();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            aramaKelimesi = txtArama.Text.Trim();
            dgvProjeler.DataSource = ProjeRepository.Listele(aramaKelimesi);
        }

        private void btnGeri_Click(object sender, EventArgs e) => Close();

        private void dgvProjeler_CellContentClick(object sender, DataGridViewCellEventArgs e) => btnDuzenle.PerformClick();

        private void txtArama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnAra.PerformClick();
            }
        }
    }
}
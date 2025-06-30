// frmMusteriler.cs – Repository yapısına geçirilmiş versiyon
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EMAR.Models;
using EMAR.Repository;

namespace EMAR
{
    public partial class frmMusteriler : Form
    {
        public frmMusteriler()
        {
            InitializeComponent();
        }

        private void frmMusteriler_Load(object sender, EventArgs e)
        {
            TopLevel = false;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;

            dgvMusteriler.Columns.Clear();
            dgvMusteriler.Columns.Add("Id", "Id");
            dgvMusteriler.Columns.Add("Ad", "Ad");
            dgvMusteriler.Columns.Add("Adres", "Adres");
            dgvMusteriler.Columns["Id"].Visible = false;

            dgvMusteriler.EnableHeadersVisualStyles = false;
            dgvMusteriler.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvMusteriler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            YukleMusteriler();
        }

        private void YukleMusteriler()
        {
            var musteriler = MusteriRepository.Listele();

            dgvMusteriler.Rows.Clear();
            foreach (var m in musteriler)
                dgvMusteriler.Rows.Add(m.Id, m.Ad, m.Adres);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            var frm = new frmMusteriKayit();
            if (frm.ShowDialog() == DialogResult.OK)
                YukleMusteriler();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (dgvMusteriler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen düzenlemek için bir müşteri seçin.");
                return;
            }

            int seciliId = Convert.ToInt32(dgvMusteriler.SelectedRows[0].Cells[0].Value);
            var musteri = MusteriRepository.Getir(seciliId);
            if (musteri == null) return;

            var frm = new frmMusteriKayit(musteri);
            if (frm.ShowDialog() == DialogResult.OK)
                YukleMusteriler();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvMusteriler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir müşteri seçin.");
                return;
            }

            int seciliId = Convert.ToInt32(dgvMusteriler.SelectedRows[0].Cells[0].Value);
            if (MessageBox.Show("Bu müşteriyi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MusteriRepository.Sil(seciliId);
                YukleMusteriler();
            }
        }

        private void dgvMusteriler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDuzenle.PerformClick();
        }

        private void dgvMusteriler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDuzenle.PerformClick();
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yazdırma özelliği henüz uygulanmadı.");
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

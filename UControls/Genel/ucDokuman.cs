using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using EMAR.Models;
using EMAR.Repositories;

namespace EMAR
{
    public partial class ucDokuman : UserControl
    {
        public string DbYolu { get; set; }

        private DokumanRepository repository;

        public ucDokuman()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void ucDokuman_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DbYolu))
                return;

            repository = new DokumanRepository(DbYolu);
            repository.EnsureTables();

            cmbTip.DropDownStyle = ComboBoxStyle.DropDown;
            DokumanTipleriniYukle();
            DokumanlariYukle();

            dgvDokumanlar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }

        private void DokumanTipleriniYukle()
        {
            cmbTip.Items.Clear();
            INIHelper.YukleCommaSeparated(cmbTip, "DokumanTipleri");
        }



        private void DokumanlariYukle()
        {
            dgvDokumanlar.Rows.Clear();

            if (dgvDokumanlar.Columns.Count == 0)
            {
                dgvDokumanlar.Columns.Add("Id", "#");
                dgvDokumanlar.Columns.Add("Ad", "Döküman Adı");
                dgvDokumanlar.Columns.Add("Tip", "Döküman Tipi");
                dgvDokumanlar.Columns.Add("IletilmeTarihi", "İletilme Tarihi");
                dgvDokumanlar.Columns["Id"].Visible = false;
            }

            var dokumanlar = repository.GetAll();
            foreach (var d in dokumanlar)
            {
                dgvDokumanlar.Rows.Add(d.Id, d.Ad, d.Tip, d.IletilmeTarihi);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text.Trim();
            string tip = cmbTip.Text.Trim();
            string tarih = dtpIletilme.Value.ToString("yyyy-MM-dd");

            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(tip))
            {
                MessageBox.Show("Lütfen doküman adı ve tipi girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var yeni = new Dokuman
                {
                    Ad = ad,
                    Tip = tip,
                    IletilmeTarihi = tarih
                };

                repository.Insert(yeni);

                DokumanlariYukle();
                txtAd.Clear();
                cmbTip.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt işlemi başarısız:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvDokumanlar.SelectedRows.Count == 0)
                return;

            int id = Convert.ToInt32(dgvDokumanlar.SelectedRows[0].Cells["Id"].Value);

            if (MessageBox.Show("Bu dokümanı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                repository.Delete(id);
                DokumanlariYukle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi başarısız:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

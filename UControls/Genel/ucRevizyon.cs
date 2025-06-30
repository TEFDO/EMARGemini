using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EMAR.Helpers;
using EMAR.Models;
using EMAR.Repositories;

namespace EMAR.UControls
{
    public partial class ucRevizyon : UserControl
    {
        public string DbYolu { get; set; }

        private RevizyonRepository repository;
        private DateTimePicker dtPicker = new();
        private bool dtPickerVisible = false;
        private List<string> aciklamaListesi = new();
        private List<string> danismanListesi = new();

        public ucRevizyon()
        {
            InitializeComponent();
        }

        private void ucRevizyon_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DbYolu) || !File.Exists(DbYolu)) return;

            repository = new RevizyonRepository(DbYolu);
            repository.EnsureTable();

            dtPicker.Format = DateTimePickerFormat.Short;
            dtPicker.Visible = false;
            dtPicker.ValueChanged += DatePicker_ValueChanged;
            dtPicker.Leave += (_, _) => dtPicker.Visible = false;
            dgvRevizyonlar.Controls.Add(dtPicker);
            dgvRevizyonlar.LostFocus += (_, _) => dtPicker.Visible = false;

            SütunlariOlustur();
            YukleRevizyonlar();
        }

        private void SütunlariOlustur()
        {
            if (dgvRevizyonlar.Columns.Count > 0) return;

            // ✅ INI'den danışmanlar virgül ayrılmış şekilde okunuyor
            danismanListesi = INIHelper
                .Oku("Danismanlar", "Degerler")?
                .Split(',')
                .Select(x => x.Trim())
                .ToList() ?? new();

            var danismanKolon = new DataGridViewComboBoxColumn
            {
                HeaderText = "Değişiklik Yapan",
                Name = "Duzenleyen",
                FlatStyle = FlatStyle.Flat,
                DataSource = danismanListesi
            };

            dgvRevizyonlar.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { HeaderText = "Revizyon", Name = "Revizyon", ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "Tarih", Name = "Tarih" },
                danismanKolon,
                new DataGridViewTextBoxColumn
                {
                    HeaderText = "Açıklama",
                    Name = "Aciklama",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                }
            });

            dgvRevizyonlar.EditingControlShowing += dgvRevizyonlar_EditingControlShowing;
            dgvRevizyonlar.CellClick += dgvRevizyonlar_CellClick;
        }

        private void dgvRevizyonlar_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvRevizyonlar.CurrentCell.ColumnIndex == dgvRevizyonlar.Columns["Aciklama"].Index && e.Control is TextBox tb)
            {
                tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                tb.AutoCompleteSource = AutoCompleteSource.CustomSource;

                aciklamaListesi = INIHelper.GetValues("RevizyonAciklamalari");
                var source = new AutoCompleteStringCollection();
                source.AddRange(aciklamaListesi.ToArray());
                tb.AutoCompleteCustomSource = source;
            }
        }

        private void dgvRevizyonlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvRevizyonlar.Columns["Tarih"].Index)
            {
                dtPicker.Visible = false;
                return;
            }

            var cellRect = dgvRevizyonlar.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            dtPicker.Size = cellRect.Size;
            dtPicker.Location = cellRect.Location;

            var cellVal = dgvRevizyonlar.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            dtPicker.Value = DateTime.TryParse(Convert.ToString(cellVal), out var parsed) ? parsed : DateTime.Today;

            dtPicker.Tag = e;
            dtPicker.Visible = true;
            dtPicker.BringToFront();
            dtPicker.Focus();
            dtPickerVisible = true;
        }

        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (!dtPickerVisible || dtPicker.Tag is not DataGridViewCellEventArgs ev) return;

            dgvRevizyonlar.Rows[ev.RowIndex].Cells[ev.ColumnIndex].Value = dtPicker.Value.ToShortDateString();
            dtPicker.Visible = false;
            dtPickerVisible = false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int nextNo = dgvRevizyonlar.Rows.Count + 1;
            dgvRevizyonlar.Rows.Add($"V{nextNo}", DateTime.Today.ToShortDateString(), "", "Rapor Oluşturuldu");
            dgvRevizyonlar.ClearSelection();
            dgvRevizyonlar.Rows[^1].Selected = true;
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (dgvRevizyonlar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen düzenlenecek satırı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvRevizyonlar.BeginEdit(true);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvRevizyonlar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek satırı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dgvRevizyonlar.Rows.Remove(dgvRevizyonlar.SelectedRows[0]);
                YenidenNumaralandir();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DbYolu))
            {
                MessageBox.Show("Veritabanı yolu tanımlı değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var list = new List<RevizyonItem>();
            foreach (DataGridViewRow row in dgvRevizyonlar.Rows)
            {
                if (!row.IsNewRow)
                {
                    list.Add(new RevizyonItem
                    {
                        Revizyon = row.Cells["Revizyon"].Value?.ToString(),
                        Tarih = row.Cells["Tarih"].Value?.ToString(),
                        Duzenleyen = row.Cells["Duzenleyen"].Value?.ToString(),
                        Aciklama = row.Cells["Aciklama"].Value?.ToString()
                    });
                }
            }

            try
            {
                repository.SaveAll(list);
                MessageBox.Show("Revizyonlar başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                YukleRevizyonlar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void YukleRevizyonlar()
        {
            dgvRevizyonlar.Rows.Clear();
            var list = repository.GetAll();

            foreach (var item in list)
            {
                if (!danismanListesi.Contains(item.Duzenleyen))
                    danismanListesi.Add(item.Duzenleyen); // 🔄 INI'de yoksa bile listeye al

                dgvRevizyonlar.Rows.Add(item.Revizyon, item.Tarih, item.Duzenleyen, item.Aciklama);
            }
        }

        private void YenidenNumaralandir()
        {
            for (int i = 0; i < dgvRevizyonlar.Rows.Count; i++)
            {
                dgvRevizyonlar.Rows[i].Cells["Revizyon"].Value = $"V{i + 1}";
            }
        }
    }
}

using EMAR.Models;
using EMAR.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace EMAR
{
    public partial class ucTemsilci : UserControl
    {
        public string DbYolu { get; set; }
        private List<Temsilci> temsilciListesi = new();
        private int editingIndex = -1;
        private TemsilciRepository repository;

        public ucTemsilci()
        {
            InitializeComponent();
        }

        private void ucTemsilci_Load(object sender, EventArgs e)
        {
            var gorevler = INIHelper.GetValues("GorevTanimlari");
            cmbGorev.Items.Clear();
            cmbGorev.Items.AddRange(gorevler.ToArray());

            if (!string.IsNullOrWhiteSpace(DbYolu) && File.Exists(DbYolu))
            {
                repository = new TemsilciRepository(DbYolu);
                repository.EnsureTable();
                YukleVeritabani();
            }
        }


        private void YukleVeritabani()
        {
            temsilciListesi = repository?.GetAll() ?? new List<Temsilci>();
            GosterTemsilciler();
        }

        private void GosterTemsilciler()
        {
            DataGridView1.Rows.Clear();
            DataGridView1.Columns.Clear();

            DataGridView1.AutoGenerateColumns = false;
            DataGridView1.AllowUserToAddRows = false;
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridView1.MultiSelect = false;
            DataGridView1.ReadOnly = true;
            DataGridView1.RowHeadersVisible = false;

            DataGridView1.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { HeaderText = "İsim", Name = "Isim", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
                new DataGridViewTextBoxColumn { HeaderText = "Firma", Name = "Firma", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
                new DataGridViewTextBoxColumn { HeaderText = "Görev Tanımı", Name = "Gorev", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill }
            });

            foreach (var t in temsilciListesi)
            {
                DataGridView1.Rows.Add(t.Isim, t.Firma, t.Gorev);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var yeni = new Temsilci
            {
                Isim = txtIsim.Text.Trim(),
                Firma = txtFirma.Text.Trim(),
                Gorev = cmbGorev.Text.Trim()
            };

            if (editingIndex >= 0)
            {
                temsilciListesi.Insert(editingIndex, yeni);
                editingIndex = -1;
            }
            else
            {
                temsilciListesi.Add(yeni);
            }

            GosterTemsilciler();
            Temizle();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (DataGridView1.CurrentRow is null) return;
            int index = DataGridView1.CurrentRow.Index;
            if (index >= 0 && index < temsilciListesi.Count)
            {
                var secilen = temsilciListesi[index];
                txtIsim.Text = secilen.Isim;
                txtFirma.Text = secilen.Firma;
                cmbGorev.Text = secilen.Gorev;
                editingIndex = index;
                temsilciListesi.RemoveAt(index);
                GosterTemsilciler();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (DataGridView1.CurrentRow is null) return;
            int index = DataGridView1.CurrentRow.Index;
            if (index >= 0 && index < temsilciListesi.Count)
            {
                temsilciListesi.RemoveAt(index);
                GosterTemsilciler();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DbYolu) || !File.Exists(DbYolu))
            {
                MessageBox.Show("Veritabanı yolu tanımlı değil veya dosya mevcut değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (temsilciListesi.Count == 0)
            {
                MessageBox.Show("Kaydedilecek temsilci bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                repository.SaveAll(temsilciListesi);
                MessageBox.Show("Temsilciler başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                YukleVeritabani();
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Temizle()
        {
            txtIsim.Clear();
            txtFirma.Clear();
            cmbGorev.SelectedIndex = -1;
            editingIndex = -1;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtIsim.Text) ||
                string.IsNullOrWhiteSpace(txtFirma.Text) ||
                string.IsNullOrWhiteSpace(cmbGorev.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}

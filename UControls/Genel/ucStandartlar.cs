using EMAR.Helpers;
using EMAR.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace EMAR.UControls
{
    public partial class ucStandartlar : UserControl
    {
        private Dictionary<string, string> _standartlar = new();
        private List<string> _varsayilanStandartlar = new();
        private ComboBox _activeCombo;
        private bool _comboboxWasGreen;

        public ucStandartlar()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                _standartlar = INIHelper.OkuBolum("Standartlar")
                    .ToDictionary(kv => kv.Key.Trim(), kv => kv.Value.Trim());

                string varsayilan = INIHelper.Oku("VarsayilanStandartlar", "Satirlar") ?? "";
                _varsayilanStandartlar = varsayilan.Split(',')
                    .Select(s => s.Trim())
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .ToList();

                ((DataGridViewComboBoxColumn)dgvStandartlar.Columns["StandartNo"])
                    .Items.AddRange(_standartlar.Keys.ToArray());

                InitRows();

                dgvStandartlar.CellEndEdit += dgvStandartlar_CellEndEdit;
                dgvStandartlar.CellClick += dgvStandartlar_CellClick;
                dgvStandartlar.CellValueChanged += dgvStandartlar_CellValueChanged;
                dgvStandartlar.EditingControlShowing += dgvStandartlar_EditingControlShowing;
                dgvStandartlar.CurrentCellDirtyStateChanged += dgvStandartlar_CurrentCellDirtyStateChanged;

                dgvStandartlar.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                dgvStandartlar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                dgvStandartlar.CellFormatting += dgvStandartlar_CellFormatting;
                dgvStandartlar.CellPainting += dgvStandartlar_CellPainting;



            }
        }

        private void dgvStandartlar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvStandartlar.Rows[e.RowIndex];
            bool secili = Convert.ToBoolean(row.Cells["Secili"].Value);
            Color renk = secili ? ColorTranslator.FromHtml("#92D050") : Color.White;

            if (dgvStandartlar.Columns[e.ColumnIndex].Name == "StandartNo")
            {
                e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                e.CellStyle.ForeColor = Color.Black;
            }
            e.CellStyle.BackColor = renk;
            e.CellStyle.ForeColor = Color.Black;
        }

        private void InitRows()
        {
            dgvStandartlar.Rows.Clear();

            for (int i = 0; i < 12; i++)
            {
                string kod = _varsayilanStandartlar.Count > i ? _varsayilanStandartlar[i] : "";
                string baslik = _standartlar.TryGetValue(kod, out var aciklama) ? aciklama : "";
                dgvStandartlar.Rows.Add(false, kod, baslik);
            }
            for (int i = 0; i < dgvStandartlar.Rows.Count; i++)
            {
                dgvStandartlar.Rows[i].Height = 60;
            }

        }

        private void dgvStandartlar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvStandartlar.Columns[e.ColumnIndex].Name != "StandartNo") return;

            var row = dgvStandartlar.Rows[e.RowIndex];
            string kod = row.Cells["StandartNo"].Value?.ToString()?.Trim() ?? "";

            if (string.IsNullOrEmpty(kod) || !_standartlar.ContainsKey(kod))
            {
                MessageBox.Show("Geçerli bir standart kodu seçmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                row.Cells["StandartNo"].Value = null;
                row.Cells["Baslik"].Value = "";
                return;
            }

            for (int i = 0; i < dgvStandartlar.Rows.Count; i++)
            {
                if (i == e.RowIndex) continue;
                string digerKod = dgvStandartlar.Rows[i].Cells["StandartNo"].Value?.ToString()?.Trim();
                if (string.Equals(digerKod, kod, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Bu standart zaten başka bir satırda kullanılmış.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.Cells["StandartNo"].Value = null;
                    row.Cells["Baslik"].Value = "";
                    return;
                }
            }

            row.Cells["Baslik"].Value = _standartlar[kod];
        }

        private void dgvStandartlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvStandartlar.Rows[e.RowIndex];
            bool mevcut = Convert.ToBoolean(row.Cells["Secili"].Value);
            row.Cells["Secili"].Value = !mevcut;
            GuncelleSatirRengi(row, !mevcut);
        }

        private void dgvStandartlar_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvStandartlar.CurrentCell.ColumnIndex == dgvStandartlar.Columns["StandartNo"].Index &&
                e.Control is ComboBox cmb)
            {
                cmb.DropDownStyle = ComboBoxStyle.DropDownList;
                cmb.Items.Clear();

                var kullanilanKodlar = dgvStandartlar.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Index != dgvStandartlar.CurrentCell.RowIndex)
                    .Select(r => r.Cells["StandartNo"].Value?.ToString()?.Trim())
                    .Where(k => !string.IsNullOrEmpty(k))
                    .ToHashSet();

                var kullanilmamislar = _standartlar.Keys
                    .Where(k => !kullanilanKodlar.Contains(k))
                    .ToArray();

                cmb.Items.AddRange(kullanilmamislar);

                var mevcutDeger = dgvStandartlar.CurrentCell.Value?.ToString();
                if (!string.IsNullOrEmpty(mevcutDeger) && !cmb.Items.Contains(mevcutDeger))
                {
                    cmb.Items.Add(mevcutDeger);
                }

                // DropDown açılmadan önce arka planı satır seçiliyse yeşil yap
                var row = dgvStandartlar.Rows[dgvStandartlar.CurrentCell.RowIndex];
                bool secili = Convert.ToBoolean(row.Cells["Secili"].Value);
                cmb.BackColor = secili ? ColorTranslator.FromHtml("#92D050") : Color.White;
                cmb.ForeColor = Color.Black;

                // --- Önemli: DropDown açıldığında arka planı her zaman beyaz yap ---
                // Önce eski event handler kaldır:
                cmb.DropDown -= ComboBox_DropDown;
                cmb.DropDownClosed -= ComboBox_DropDownClosed;
                // Sonra ekle:
                cmb.DropDown += ComboBox_DropDown;
                cmb.DropDownClosed += ComboBox_DropDownClosed;

                _activeCombo = cmb;
                _comboboxWasGreen = secili;
            }
        }
        private void ComboBox_DropDown(object sender, EventArgs e)
        {
            if (sender is ComboBox cmb)
            {
                // DropDown açılınca her zaman beyaz yap
                cmb.BackColor = Color.White;
                cmb.ForeColor = Color.Black;
            }
        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (sender is ComboBox cmb)
            {
                // DropDown kapanınca tekrar satır seçiliyse yeşil, değilse beyaz yap
                cmb.BackColor = _comboboxWasGreen ? ColorTranslator.FromHtml("#92D050") : Color.White;
                cmb.ForeColor = Color.Black;
            }
        }


        private void dgvStandartlar_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvStandartlar.IsCurrentCellDirty)
                dgvStandartlar.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvStandartlar_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvStandartlar.Rows[e.RowIndex];

            if (dgvStandartlar.Columns[e.ColumnIndex].Name == "Secili")
            {
                bool secili = Convert.ToBoolean(row.Cells["Secili"].Value);
                GuncelleSatirRengi(row, secili);
            }

            if (dgvStandartlar.Columns[e.ColumnIndex].Name == "StandartNo")
            {
                string kod = row.Cells["StandartNo"].Value?.ToString()?.Trim();
                if (!string.IsNullOrEmpty(kod) && _standartlar.TryGetValue(kod, out var baslik))
                    row.Cells["Baslik"].Value = baslik;
                else
                    row.Cells["Baslik"].Value = "";
            }
        }

        private void GuncelleSatirRengi(DataGridViewRow row, bool secili)
        {
            Color backColor = secili ? ColorTranslator.FromHtml("#92D050") : Color.White;
            Color foreColor = Color.Black;

            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.Style.BackColor = backColor;
                cell.Style.SelectionBackColor = backColor;
                cell.Style.ForeColor = foreColor;
                cell.Style.SelectionForeColor = foreColor;
            }

            // Standart No sütunu daima kalın, siyah yazı!
            row.Cells["StandartNo"].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            row.Cells["StandartNo"].Style.ForeColor = Color.Black;
            row.Cells["StandartNo"].Style.SelectionForeColor = Color.Black;

            row.Height = 60;
        }
        private void dgvStandartlar_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvStandartlar.Columns[e.ColumnIndex].Name != "Secili")
                return;

            e.Handled = true;
            e.PaintBackground(e.CellBounds, true);

            bool secili = Convert.ToBoolean(dgvStandartlar.Rows[e.RowIndex].Cells["Secili"].Value);
            CheckBoxState state = secili ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal;

            Size checkBoxSize = CheckBoxRenderer.GetGlyphSize(e.Graphics, state);
            Point center = new Point(
                e.CellBounds.Left + (e.CellBounds.Width - checkBoxSize.Width) / 2,
                e.CellBounds.Top + (e.CellBounds.Height - checkBoxSize.Height) / 2
            );
            CheckBoxRenderer.DrawCheckBox(e.Graphics, center, state);

            // Kendi içeriğini çizme (e.PaintContent yok)
        }

        public List<StandartItem> GetSelectedList()
        {
            var list = new List<StandartItem>();
            foreach (DataGridViewRow row in dgvStandartlar.Rows)
            {
                if (row.Cells["StandartNo"].Value == null) continue;
                bool secili = false;
                if (row.Cells["Secili"].Value != null)
                    bool.TryParse(row.Cells["Secili"].Value.ToString(), out secili);

                list.Add(new StandartItem
                {
                    Kodu = row.Cells["StandartNo"].Value?.ToString(),
                    Aciklama = row.Cells["Baslik"].Value?.ToString(),
                    Secili = secili
                });
            }
            return list;
        }
        public void SetRowsFromList(List<StandartItem> list)
        {
            foreach (DataGridViewRow row in dgvStandartlar.Rows)
            {
                string kod = row.Cells["StandartNo"].Value?.ToString();
                var found = list?.FirstOrDefault(x => x.Kodu == kod);
                if (found != null)
                {
                    row.Cells["Baslik"].Value = found.Aciklama;
                    row.Cells["Secili"].Value = found.Secili;
                    GuncelleSatirRengi(row, found.Secili);
                }
                else
                {
                    row.Cells["Secili"].Value = false;
                    GuncelleSatirRengi(row, false);
                }
            }
        }


        public DataGridView GetGrid() => dgvStandartlar;
    }
}

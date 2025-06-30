using System;
using System.IO;
using System.Windows.Forms;
using EMAR.Helpers;

namespace EMAR.UControls
{
    public partial class ucAyarListesi : UserControl
    {
        public string AyarBasligi { get; private set; }

        public ucAyarListesi(string iniKey)
        {
            InitializeComponent();
            this.AyarBasligi = iniKey;
            grp.Text = iniKey;
        }

        private void ucAyarListesi_Load(object sender, EventArgs e)
        {
            INIHelper.YukleCommaSeparated(lst, AyarBasligi);
        }

        public void Kaydet()
        {
            INIHelper.GuncelleCommaSeparated(AyarBasligi, lst);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string deger = txt.Text.Trim();
            if (!string.IsNullOrWhiteSpace(deger) && !lst.Items.Contains(deger))
            {
                lst.Items.Add(deger);
                txt.Clear();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lst.SelectedItem != null)
                lst.Items.Remove(lst.SelectedItem);
        }
    }
}
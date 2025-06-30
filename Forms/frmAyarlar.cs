using System;
using System.IO;
using System.Windows.Forms;
using EMAR.UControls;


namespace EMAR
{
    public partial class frmAyarlar : Form
    {
        string iniYolu = Path.Combine(Application.StartupPath, "ayarlar.ini");

        public frmAyarlar()
        {
            InitializeComponent();
        }

        private void frmAyarlar_Load(object sender, EventArgs e)
        {
            string[] gruplar = new[]
            {
                "MakineTipleri",
                "Sertifikasyonlar",
                "KullaniciSeviyeleri",
                "HizmetKodlari",
                "RevizyonAciklamalari",
                "Danismanlar",
                "DokumanTipleri",
                "TehlikeTipleri",
                "GorevAsamalari",
                "TehlikeHedefleri",
                "PLg_S",
                "PLg_F",
                "PLg_P"
            };

            foreach (string grup in gruplar)
            {
                var control = new ucAyarListesi(grup);
                control.Dock = DockStyle.Top;
                flowPanel.Controls.Add(control);
                flowPanel.Controls.SetChildIndex(control, 0);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            foreach (ucAyarListesi ctrl in flowPanel.Controls)
                ctrl.Kaydet();

            MessageBox.Show("Tüm ayarlar kaydedildi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
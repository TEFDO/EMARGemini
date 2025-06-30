using System;
using System.Windows.Forms;
using EMAR.Helpers;

namespace EMAR
{
    public partial class frmMain : Form
    {
        public frmMain() => InitializeComponent();

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Text = "TEFDO - EMAR";
            
            // İlk yüklemede veritabanı temizlenmesin
            // Veritabanı sıfırlama isteğe bağlı olmalı
        }

        /// <summary>
        /// Panelde gösterilen formları temizlerken RAM tüketimini azaltmak için
        /// eski formu hem Remove hem Dispose ile hafızadan atar.
        /// </summary>
        private void FormuPaneldeGoster(Form frm)
        {
            foreach (Control ctrl in panelContent.Controls)
            {
                if (ctrl is IDisposable disposable)
                    disposable.Dispose();
            }
            panelContent.Controls.Clear();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(frm);
            frm.Show();
        }

        private void BtnMusteriler_Click(object sender, EventArgs e) => FormuPaneldeGoster(new frmMusteriler());
        private void BtnMakineler_Click(object sender, EventArgs e) => FormuPaneldeGoster(new frmMakineler());
        private void BtnProjeler_Click(object sender, EventArgs e) => FormuPaneldeGoster(new frmProjeler());
        private void btnRaporlar_Click(object sender, EventArgs e) => FormuPaneldeGoster(new frmRaporlar());
        private void btnAyarlar_Click(object sender, EventArgs e) => FormuPaneldeGoster(new frmAyarlar());

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Programdan çıkmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnVeritabaniSifirla_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tüm veriler silinecek. Devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                VeritabaniHelper.Sifirla();
                MessageBox.Show("Veritabanı sıfırlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Ana form kapanırken tüm formları ve nesneleri güvenli şekilde Dispose eder.
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            foreach (Control ctrl in panelContent.Controls)
            {
                if (ctrl is IDisposable disposable)
                    disposable.Dispose();
            }
            panelContent.Controls.Clear();
            base.OnFormClosing(e);
        }
    }
}

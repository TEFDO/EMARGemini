using System;
using System.Linq;
using System.Windows.Forms;
using EMAR.Models;
using EMAR.Repository;

namespace EMAR
{
    public partial class frmProjeyeMakineEkle : Form
    {
        public int aktifProjeId { get; set; }

        public frmProjeyeMakineEkle()
        {
            InitializeComponent();
        }

        private void frmProjeyeMakineEkle_Load(object sender, EventArgs e)
        {
            YukleMakineler();
        }

        private void YukleMakineler()
        {
            lstTumMakineler.DataSource = ProjeMakineRepository.GetirTumMakineler();
            lstTumMakineler.DisplayMember = "Ad";
            lstTumMakineler.ValueMember = "Id";

            lstProjedeMakineler.DataSource = ProjeMakineRepository.GetirProjeyeAitMakineler(aktifProjeId);
            lstProjedeMakineler.DisplayMember = "Ad";
            lstProjedeMakineler.ValueMember = "Id";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (lstTumMakineler.SelectedItem is not Makine secilen)
                return;

            ProjeMakineRepository.Ekle(aktifProjeId, secilen.Id);
            YukleMakineler();
        }

        private void btnCikar_Click(object sender, EventArgs e)
        {
            if (lstProjedeMakineler.SelectedItem is not Makine secilen)
                return;

            ProjeMakineRepository.Cikar(aktifProjeId, secilen.Id);
            YukleMakineler();
        }
    }
}
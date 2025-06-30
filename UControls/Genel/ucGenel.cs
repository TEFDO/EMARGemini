using System;

namespace EMAR
{
    public partial class ucGenel
    {
        // Bu değerler üst formdan set edilecek (frmRapor'dan)
        public string MusteriAdi { get; set; }
        public string ProjeAdi { get; set; }
        public string MakineAdi { get; set; }
        public DateTime RaporTarihi { get; set; }
        public string RaporAciklama { get; set; }

        public ucGenel()
        {
            InitializeComponent();
        }

        private void ucGenel_Load(object sender, EventArgs e)
        {
            lblMusteri.Text = MusteriAdi;
            lblProje.Text = ProjeAdi;
            lblMakine.Text = MakineAdi;
            dtTarih.Value = RaporTarihi != DateTime.MinValue ? RaporTarihi : DateTime.Today;
            txtAciklama.Text = RaporAciklama;
        }


        // frmRapor formu, bu property'leri doldurmalı
    }
}
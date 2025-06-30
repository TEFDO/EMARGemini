using System;
using System.Windows.Forms;

namespace EMAR.UControls
{
    public partial class BolgeGenelButonu : UserControl
    {
        public int BolgeId { get; set; }

        public string BolgeAdi
        {
            get => lblBaslik.Text;
            set => lblBaslik.Text = value;
        }

        public string Aciklama
        {
            get => lblAciklama.Text;
            set => lblAciklama.Text = value;
        }

        public event EventHandler GenelButonTiklandi;

        public BolgeGenelButonu()
        {
            InitializeComponent();

            // Tüm kontrol alanlarını tek bir tıklama eventiyle birleştiriyoruz
            //this.Click += Buton_Click;
            //lblBaslik.Click += Buton_Click;
            //lblAciklama.Click += Buton_Click;
            //pictureBoxIcon.Click += Buton_Click;
        }

        private void Buton_Click(object sender, EventArgs e)
        {
            GenelButonTiklandi?.Invoke(this, e);
        }

        
    }
}
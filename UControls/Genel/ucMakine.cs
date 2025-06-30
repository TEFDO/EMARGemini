using System;
using System.Data.SQLite;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EMAR
{

    public partial class ucMakine
    {

        // Sadece MakineId atanacak, diğer bilgiler veritabanından okunacak
        public int MakineId { get; set; }

        public ucMakine()
        {
            InitializeComponent();
        }

        private void ucMakine_Load(object sender, EventArgs e)
        {
            if (MakineId <= 0)
                return;

            try
            {
                var makine = Repository.MakineRepository.Getir(MakineId);

                if (makine == null)
                {
                    MessageBox.Show("Makine bilgisi bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                lblMakineAdi.Text = "Makine Adı: " + BosIseTire(makine.Ad);
                lblImalatci.Text = "İmalatçı: " + BosIseTire(makine.Imalatci);
                lblSeriNo.Text = "Seri No: " + BosIseTire(makine.SeriNo);
                lblTip.Text = "Tip: " + BosIseTire(makine.Tipi);
                lblYil.Text = "Üretim Yılı: " + (makine.UretimYili > 0 ? makine.UretimYili.ToString() : "-");
                txtSertifikasyon.Text = BosIseTire(makine.Sertifikasyon);
                lblElektrik.Text = "Elektrik: " + BosIseTire(makine.Elektrik);
                lblPnomatik.Text = "Pnomatik: " + BosIseTire(makine.Pnomatik);
                lblHidrolik.Text = "Hidrolik: " + BosIseTire(makine.Hidrolik);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Makine bilgileri yüklenirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Yardımcı fonksiyon: Null veya boşsa "-"
        private string BosIseTire(object obj)
        {
            string str = Convert.ToString(obj);
            return string.IsNullOrWhiteSpace(str) ? "-" : str;
        }



    }
}
using System;
using System.Data.SQLite;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EMAR
{

    public partial class ucKontrolSistemi
    {

        public string DbYolu { get; set; } // frmRapor üzerinden atanacak

        // Verileri temsil edecek DTO (data class)
        public class KontrolSistemiData
        {
            public string GenelAciklama { get; set; }
            public string GirisKati { get; set; }
            public string MantikKati { get; set; }
            public string CikisKati { get; set; }
        }

        public ucKontrolSistemi()
        {
            InitializeComponent();
        }

        // Formdan veriyi oku ve DTO olarak geri döndür
        public KontrolSistemiData Al()
        {
            return new KontrolSistemiData()
            {
                GenelAciklama = txtGenel.Text.Trim(),
                GirisKati = txtGiris.Text.Trim(),
                MantikKati = txtMantik.Text.Trim(),
                CikisKati = txtCikis.Text.Trim()
            };
        }

        // DTO içeriğini form alanlarına yükle
        public void Yukle(KontrolSistemiData data)
        {
            if (data is not null)
            {
                txtGenel.Text = data.GenelAciklama;
                txtGiris.Text = data.GirisKati;
                txtMantik.Text = data.MantikKati;
                txtCikis.Text = data.CikisKati;
            }
        }

        // Alanları temizle
        public void Temizle()
        {
            txtGenel.Clear();
            txtGiris.Clear();
            txtMantik.Clear();
            txtCikis.Clear();
        }

        // Alanları sadece okunur yap ya da eski haline getir
        public void Kilitle(bool kilitli)
        {
            txtGenel.ReadOnly = kilitli;
            txtGiris.ReadOnly = kilitli;
            txtMantik.ReadOnly = kilitli;
            txtCikis.ReadOnly = kilitli;
        }

        // Veritabanından veriyi oku ve alanlara yerleştir
        public void YukleVeritabani()
        {
            if (string.IsNullOrEmpty(DbYolu) || !System.IO.File.Exists(DbYolu))
                return;

            using (var con = new SQLiteConnection($"Data Source={DbYolu}"))
            {
                con.Open();

                // Gerekirse tabloyu oluştur
                var createTable = new SQLiteCommand(@"
                CREATE TABLE IF NOT EXISTS KontrolSistemi (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Genel TEXT,
                    Giris TEXT,
                    Mantik TEXT,
                    Cikis TEXT
                );", con);
                createTable.ExecuteNonQuery();

                // En son kaydı getir
                var cmd = new SQLiteCommand("SELECT * FROM KontrolSistemi ORDER BY Id DESC LIMIT 1", con);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var data = new KontrolSistemiData()
                        {
                            GenelAciklama = reader["Genel"].ToString(),
                            GirisKati = reader["Giris"].ToString(),
                            MantikKati = reader["Mantik"].ToString(),
                            CikisKati = reader["Cikis"].ToString()
                        };
                        Yukle(data);
                    }
                }
            }
        }

        // Alanlardaki veriyi veritabanına kaydet (eskiyi silip yenisini yaz)
        public void KaydetVeritabani()
        {
            if (string.IsNullOrEmpty(DbYolu) || !System.IO.File.Exists(DbYolu))
                return;

            var data = Al();

            using (var con = new SQLiteConnection($"Data Source={DbYolu}"))
            {
                con.Open();

                var createTable = new SQLiteCommand(@"
                CREATE TABLE IF NOT EXISTS KontrolSistemi (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Genel TEXT,
                    Giris TEXT,
                    Mantik TEXT,
                    Cikis TEXT
                );", con);
                createTable.ExecuteNonQuery();

                // Eski kayıtları sil (isteğe bağlı)
                var silCmd = new SQLiteCommand("DELETE FROM KontrolSistemi", con);
                silCmd.ExecuteNonQuery();

                // Yeni kaydı ekle
                var insert = new SQLiteCommand("INSERT INTO KontrolSistemi (Genel, Giris, Mantik, Cikis) VALUES (@Genel, @Giris, @Mantik, @Cikis)", con);
                insert.Parameters.AddWithValue("@Genel", data.GenelAciklama);
                insert.Parameters.AddWithValue("@Giris", data.GirisKati);
                insert.Parameters.AddWithValue("@Mantik", data.MantikKati);
                insert.Parameters.AddWithValue("@Cikis", data.CikisKati);
                insert.ExecuteNonQuery();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                KaydetVeritabani();
                MessageBox.Show("Kontrol sistemi bilgileri başarıyla kaydedildi.", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında bir hata oluştu:" + Constants.vbCrLf + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
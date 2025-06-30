using EMAR.Helpers;
using EMAR.Models;
using EMAR.Repository;
using EMAR.UControls;
using EMAR.Word;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EMAR
{
    public partial class frmRapor : Form
    {
        public string RaporKodu { get; set; }
        public int MakineId { get; set; }
        public string DbYolu { get; set; }

        public frmRapor() => InitializeComponent();

        private void frmRapor_Load(object sender, EventArgs e)
        {
            ShowGenelBilgiler();
        }

        private void btnGenel_Click(object sender, EventArgs e) => ShowGenelBilgiler();

        private void btnMakine_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            var makine = new ucMakine() { MakineId = MakineId };
            makine.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(makine);
        }

        private void btnRevizyon_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            var revizyonPanel = new ucRevizyon()
            {
                DbYolu = RaporKlasorYardimcisi.GetDbYoluFromRaporKodu(RaporKodu),
                Dock = DockStyle.Fill
            };
            pnlContent.Controls.Add(revizyonPanel);
        }

        private void btnDokuman_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            var dokuman = new ucDokuman() { DbYolu = DbYolu, Dock = DockStyle.Fill };
            pnlContent.Controls.Add(dokuman);
        }

        private void btnTemsilci_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            var temsilci = new ucTemsilci() { DbYolu = DbYolu, Dock = DockStyle.Fill };
            pnlContent.Controls.Add(temsilci);
        }

        private void btnKontrolSistemi_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            var kontrol = new ucKontrolSistemi() { DbYolu =  RaporKlasorYardimcisi.GetDbYoluFromRaporKodu(RaporKodu), Dock = DockStyle.Fill };
            pnlContent.Controls.Add(kontrol);
            kontrol.YukleVeritabani();
        }

        private void ShowGenelBilgiler()
{
    pnlContent.Controls.Clear();
    string dbYolu = RaporKlasorYardimcisi.GetDbYoluFromRaporKodu(RaporKodu);

    string proje = "(bilinmiyor)";
    string tur = "(bilinmiyor)";
    string makine = "(bilinmiyor)";
    string musteri = "(bilinmiyor)";
    var tarih = DateTime.Today;
    string aciklama = "(Açıklama girilmemiş)";

    try
    {
        var dt = VeritabaniHelper.TabloGetir(@"
            SELECT R.Tarih, R.RaporTuruKod, 
                   P.ProjeKodu, M.Ad AS MakineAdi, Mu.Ad AS MusteriAdi
            FROM Raporlar R
            JOIN Projeler P ON R.ProjeId = P.Id
            JOIN Makineler M ON R.MakineId = M.Id
            JOIN Musteriler Mu ON P.MusteriId = Mu.Id
            WHERE R.RaporKodu = @kod",
            new() { ["@kod"] = RaporKodu });

        if (dt.Rows.Count > 0)
        {
            var row = dt.Rows[0];
            proje = row["ProjeKodu"].ToString();
            tur = row["RaporTuruKod"].ToString();
            makine = row["MakineAdi"].ToString();
            musteri = row["MusteriAdi"].ToString();
            DateTime.TryParse(row["Tarih"]?.ToString(), out tarih);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Genel bilgiler okunamadı:" + Constants.vbCrLf + ex.Message);
    }

    var uc = new ucGenel()
    {
        ProjeAdi = proje,
        MakineAdi = makine,
        MusteriAdi = musteri,
        RaporTarihi = tarih,
        RaporAciklama = aciklama,
        Dock = DockStyle.Fill
    };
    pnlContent.Controls.Add(uc);
}


        private bool isSidebarExpanded = true;

        private void btnToggleMenu_Click(object sender, EventArgs e)
        {
            if (isSidebarExpanded)
            {
                pnlSidebar.Width = 60;
                btnGenel.Text = "";
                btnMakine.Text = "";
                btnRevizyon.Text = "";
                btnDokuman.Text = "";
            }
            else
            {
                pnlSidebar.Width = 404;
                btnGenel.Text = "Genel";
                btnMakine.Text = "Makine";
                btnRevizyon.Text = "Revizyon";
                btnDokuman.Text = "Doküman";
            }
            isSidebarExpanded = !isSidebarExpanded;
        }

        private void btnRiskler_Click(object sender, EventArgs e)
        {
            string dbYolu = RaporKlasorYardimcisi.GetDbYoluFromRaporKodu(RaporKodu);
            if (!File.Exists(dbYolu)) SQLiteConnection.CreateFile(dbYolu);

            string projeKodu = "(bilinmiyor)";
            string makineAdi = "(bilinmiyor)";
            string raporTuru = "(bilinmiyor)";

            try
            {
                var dt = VeritabaniHelper.TabloGetir(@"
        SELECT R.RaporTuruKod, P.ProjeKodu, M.Ad AS MakineAdi
        FROM Raporlar R
        JOIN Projeler P ON R.ProjeId = P.Id
        JOIN Makineler M ON R.MakineId = M.Id
        WHERE R.RaporKodu = @kod",
                    new() { ["@kod"] = RaporKodu });

                if (dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    projeKodu = row["ProjeKodu"].ToString();
                    makineAdi = row["MakineAdi"].ToString();
                    raporTuru = row["RaporTuruKod"].ToString();
                }
            }
            catch { }

            var detayForm = new frmRASCDetay
            {
                DbYolu = dbYolu,
                ProjeKodu = projeKodu,
                MakineAdi = makineAdi,
                RaporTuru = raporTuru
            };
            detayForm.ShowDialog();

        }

        private void btnGorseller_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            var gorseller = new ucMakineGorselleri()
            {
                DbYolu = RaporKlasorYardimcisi.GetDbYoluFromRaporKodu(RaporKodu),
                //DbYolu = $"{RaporKodu.Replace("-", "_")}.db",
                RaporKodu = RaporKodu,
                Dock = DockStyle.Fill
            };
            pnlContent.Controls.Add(gorseller);
        }
        private void btnYazdir_Click(object sender, EventArgs e)
        {
            // 1. SQL ve parametreler
            string sql = @"
SELECT R.RaporKodu, R.Tarih, R.RaporTuruKod, 
       P.ProjeKodu, M.Ad AS MakineAdi, Mu.Ad AS MusteriAdi,
       R.MakineId, R.SiraNo
FROM Raporlar R
JOIN Projeler P ON R.ProjeId = P.Id
JOIN Makineler M ON R.MakineId = M.Id
JOIN Musteriler Mu ON P.MusteriId = Mu.Id
WHERE R.RaporKodu = @kod";

            var prms = new Dictionary<string, object> { ["@kod"] = RaporKodu };

            // 2. DataTable al
            var dt = VeritabaniHelper.TabloGetir(sql, prms, "raporlar.db");

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Rapor bilgisi bulunamadı.");
                return;
            }

            var row = dt.Rows[0];
            var rapor = new Rapor
            {
                RaporKodu = row["RaporKodu"]?.ToString(),
                Tarih = row["Tarih"]?.ToString(),
                RaporTuruKod = row["RaporTuruKod"]?.ToString(),
                ProjeKodu = row["ProjeKodu"]?.ToString(),
                MakineAdi = row["MakineAdi"]?.ToString(),
                MusteriAdi = row["MusteriAdi"]?.ToString(),
                MakineId = row["MakineId"] != DBNull.Value ? Convert.ToInt32(row["MakineId"]) : 0,
                SiraNo = row["SiraNo"] != DBNull.Value ? Convert.ToInt32(row["SiraNo"]) : 0
            };

            using var sfd = new SaveFileDialog
            {
                Filter = "Word Belgesi (*.docx)|*.docx",
                FileName = $"{rapor.RaporKodu}.docx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Burada asıl Word çıktısını oluşturuyorsun
                    RaporYazici.Olustur(rapor, sfd.FileName);
                    MessageBox.Show("Word çıktısı başarıyla oluşturuldu.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Word çıktısı oluşturulurken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        //{
        //    // Kısa bir RTF (direkt düz metin de olabilir)
        //    string rtf = @"{\rtf1\ansi\deff0 {\fonttbl {\f0 Arial;}} \fs20 Merhaba \b Kalın \b0  Normal!}";

        //    // HTML çıktısı almak için
        //    string html = RtfPipe.Rtf.ToHtml(rtf);
        //    File.WriteAllText("debug_html_test.html", html);

        //    // XHTML çıktı almak için
        //    XElement xhtml = null;
        //    try
        //    {
        //        xhtml = XElement.Parse("<div>" + html + "</div>");
        //        File.WriteAllText("debug_xhtml_test.xml", xhtml.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("XHTML parse hatası: " + ex.Message);
        //        return;
        //    }

        //    // Settings oluştur
        //    var settings = OpenXmlPowerTools.HtmlToWmlConverter.GetDefaultSettings();

        //    // Dönüşüm dene
        //    try
        //    {
        //        var wmlDoc = OpenXmlPowerTools.HtmlToWmlConverter.ConvertHtmlToWml("", "", "", xhtml, settings);
        //        if (wmlDoc == null)
        //        {
        //            MessageBox.Show("WmlDocument null döndü!");
        //            return;
        //        }
        //        // Debug için dosya olarak yazabilirsin:
        //        File.WriteAllBytes("debug_doc.docx", wmlDoc.DocumentByteArray);

        //        MessageBox.Show("Başarılı! debug_doc.docx oluştu. Açıp kontrol edebilirsin.");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Dönüşümde hata: " + ex.Message);
        //    }
        //}





        //        {
        //            string sql = @"
        //SELECT R.RaporKodu, R.Tarih, R.RaporTuruKod, 
        //       P.ProjeKodu, M.Ad AS MakineAdi, Mu.Ad AS MusteriAdi,
        //       R.MakineId, R.SiraNo
        //FROM Raporlar R
        //JOIN Projeler P ON R.ProjeId = P.Id
        //JOIN Makineler M ON R.MakineId = M.Id
        //JOIN Musteriler Mu ON P.MusteriId = Mu.Id
        //WHERE R.RaporKodu = @kod";

        //            var prms = new Dictionary<string, object> { ["@kod"] = RaporKodu };
        //            var dt = VeritabaniHelper.TabloGetir(sql, prms, "raporlar.db");

        //            if (dt.Rows.Count == 0)
        //            {
        //                MessageBox.Show("Rapor bilgisi bulunamadı.");
        //                return;
        //            }

        //            var row = dt.Rows[0];
        //            var rapor = new Rapor
        //            {
        //                RaporKodu = row["RaporKodu"].ToString(),
        //                Tarih = row["Tarih"].ToString(),
        //                RaporTuruKod = row["RaporTuruKod"].ToString(),
        //                ProjeKodu = row["ProjeKodu"].ToString(),
        //                MakineAdi = row["MakineAdi"].ToString(),
        //                MusteriAdi = row["MusteriAdi"].ToString(),
        //                MakineId = Convert.ToInt32(row["MakineId"]),
        //                SiraNo = Convert.ToInt32(row["SiraNo"]) // Eğer SiraNo da kullanıyorsan!
        //            };

        //            using var sfd = new SaveFileDialog
        //            {
        //                Filter = "Word Belgesi (*.docx)|*.docx",
        //                FileName = $"{rapor.RaporKodu}.docx"
        //            };

        //            if (sfd.ShowDialog() == DialogResult.OK)
        //            {
        //                RaporYazici.Olustur(rapor, sfd.FileName);
        //                MessageBox.Show("Word çıktısı başarıyla oluşturuldu.");
        //            }
        //        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            foreach (Control ctrl in pnlContent.Controls)
            {
                if (ctrl is ucMakineGorselleri g) g.TemizleGorseller();
                if (ctrl is IDisposable d) d.Dispose();
            }
            pnlContent.Controls.Clear();
            base.OnFormClosing(e);
        }
    }
}

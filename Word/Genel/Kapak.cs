using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using EMAR.Helpers;
using EMAR.Models;
using EMAR.Repositories;
using EMAR.Repository;
using EMAR.Word.Helper;
using System;
using System.IO;
using System.Linq;

namespace EMAR.Word.Genel
{
    public static class Kapak
    {
        private static void SetSectionMargins(MainDocumentPart mainPart)
        {
            var sectionProps = mainPart.Document.Body.Elements<SectionProperties>().FirstOrDefault();
            if (sectionProps == null)
            {
                sectionProps = new SectionProperties();
                mainPart.Document.Body.Append(sectionProps);
            }

            sectionProps.RemoveAllChildren<PageMargin>();
            sectionProps.Append(new PageMargin
            {
                Top = 1418, // 2,5 cm
                Bottom = 1418,
                Left = 1418,
                Right = 1418,
                Header = 0,    // Üst Bilgi boşluğu 0
                Footer = 0     // Alt Bilgi boşluğu 0
            });
        }

        public static void Olustur(Rapor rapor, string hedefYol)
        {
            File.Copy("Sablonlar/Kapak.docx", hedefYol, true);

            using var doc = WordprocessingDocument.Open(hedefYol, true);
            var mainPart = doc.MainDocumentPart;

            string dbYolu = RaporKlasorYardimcisi.GetDbYoluFromRaporKodu(rapor.RaporKodu);
            if (string.IsNullOrEmpty(dbYolu) || !File.Exists(dbYolu))
                throw new FileNotFoundException("Raporun detay veritabanı dosyası bulunamadı!", dbYolu);

            EtiketDegistirici.Degistir(mainPart, "@@RaporKodu@@", rapor.RaporKodu);
            EtiketDegistirici.Degistir(mainPart, "@@Tarih@@", rapor.Tarih);
            EtiketDegistirici.Degistir(mainPart, "@@ProjeKodu@@", rapor.ProjeKodu);
            EtiketDegistirici.Degistir(mainPart, "@@MakineAdi@@", rapor.MakineAdi);
            EtiketDegistirici.Degistir(mainPart, "@@RaporTuruKod@@", rapor.RaporTuruKod);
            EtiketDegistirici.Degistir(mainPart, "@@MusteriAdi@@", rapor.MusteriAdi);

            var musteri = MusteriRepository.Listele().FirstOrDefault(m => m.Ad == rapor.MusteriAdi);
            if (musteri?.Logo != null)
                ResimEkleme.Yerlestir(mainPart, "@@Logo@@", musteri.Logo, "MusteriLogo");
            if (!string.IsNullOrWhiteSpace(musteri?.Adres))
                EtiketDegistirici.Degistir(mainPart, "@@MusteriAdresi@@", musteri.Adres);

            var makine = MakineRepository.Getir(rapor.MakineId);
            if (makine != null)
            {
                EtiketDegistirici.Degistir(mainPart, "@@MakineOzeti@@", $"{makine.Tipi} - {makine.SeriNo} - {makine.UretimYili} - {makine.Sertifikasyon}");
                EtiketDegistirici.Degistir(mainPart, "@@Tipi@@", makine.Tipi);
                EtiketDegistirici.Degistir(mainPart, "@@SeriNo@@", makine.SeriNo);
                EtiketDegistirici.Degistir(mainPart, "@@UretimYili@@", makine.UretimYili.ToString());
                EtiketDegistirici.Degistir(mainPart, "@@Sertifikasyon@@", makine.Sertifikasyon);
                EtiketDegistirici.Degistir(mainPart, "@@Elektrik@@", makine.Elektrik);
                EtiketDegistirici.Degistir(mainPart, "@@Pnomatik@@", makine.Pnomatik);
                EtiketDegistirici.Degistir(mainPart, "@@Hidrolik@@", makine.Hidrolik);
                EtiketDegistirici.Degistir(mainPart, "@@Imalatci@@", makine.Imalatci);
                EtiketDegistirici.Degistir(mainPart, "@@KullanimAmaci@@", makine.KullanimAmaci);
                EtiketDegistirici.Degistir(mainPart, "@@KullaniciSeviyesi@@", makine.KullaniciSeviyesi);
                EtiketDegistirici.Degistir(mainPart, "@@PersonelTipi@@", makine.PersonelTipi);
                EtiketDegistirici.Degistir(mainPart, "@@BakimSikligi@@", makine.BakimSikligi);
                EtiketDegistirici.Degistir(mainPart, "@@MakineOlculeri@@", makine.MakineOlculeri);
                EtiketDegistirici.Degistir(mainPart, "@@ZamanLimitleri@@", makine.ZamanLimitleri);
                EtiketDegistirici.Degistir(mainPart, "@@MachineName@@", makine.Name);
            }

            // Header ve Footer etiketlerini de değiştir:
            foreach (var headerPart in mainPart.HeaderParts)
            {
                foreach (var t in headerPart.Header.Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>())
                    if (t.Text.Contains("@@ProjeKodu@@"))
                        t.Text = t.Text.Replace("@@ProjeKodu@@", rapor.ProjeKodu);
                // başka etiketler de varsa onları da ekle
                headerPart.Header.Save();
            }
            foreach (var footerPart in mainPart.FooterParts)
            {
                foreach (var t in footerPart.Footer.Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>())
                    if (t.Text.Contains("@@ProjeKodu@@"))
                        t.Text = t.Text.Replace("@@ProjeKodu@@", rapor.ProjeKodu);
                // başka etiketler de varsa onları da ekle
                footerPart.Footer.Save();
            }
            SetSectionMargins(mainPart);
            mainPart.Document.Save();

        }
    }
}

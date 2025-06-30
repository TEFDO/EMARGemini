using EMAR.Repository;
using System;
using System.IO;
using System.Linq;

namespace EMAR.Helpers
{
    public static class RaporKlasorYardimcisi
    {
        // Temel kök klasör
        public static string RAPORLAR_ROOT = "Raporlar";

        // Klasör ve dosya adlarında kullanılmayan karakterleri temizle
        public static string Temizle(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            foreach (char c in Path.GetInvalidFileNameChars())
                text = text.Replace(c, '_');
            return text.Replace(" ", "_");
        }

        // Rapor ana klasörü: ProjeKodu/RaporTuru/SiraNo-MakineAdi/
        public static string RaporKlasoru(string projeKodu, string raporTuru, int siraNo, string makineAdi)
        {
            return Path.Combine(
                Temizle(RAPORLAR_ROOT ?? ""),
                Temizle(projeKodu ?? ""),
                Temizle(raporTuru ?? ""),
                $"{siraNo:D2}-{Temizle(makineAdi ?? "")}"
            );
        }

        // Rapor veritabanı dosya yolu
        public static string RaporDbYolu(string projeKodu, string raporTuru, int siraNo, string makineAdi)
        {
            string klasor = RaporKlasoru(projeKodu, raporTuru, siraNo, makineAdi);
            string dosyaAdi = $"{Temizle(projeKodu)}-{Temizle(raporTuru)}-{siraNo:D2}-{Temizle(makineAdi)}.db";
            return Path.Combine(klasor, dosyaAdi);
            }

        // Risk klasörü
        public static string RiskKlasoru(string projeKodu, string raporTuru, int siraNo, string makineAdi, int bolgeNo, int riskNo)
        {
            return Path.Combine(
                RaporKlasoru(projeKodu, raporTuru, siraNo, makineAdi),
                $"Risk{bolgeNo}.{riskNo}"
            );
        }

        // ... diğer kodlar aynı ...

        // Risk içindeki görsel tipi alt klasörü (örn: GenelBilgi, MevcutDurum, Modifikasyon, ...)
        public static string RiskGorselKlasoru(
            string projeKodu, string raporTuru, int siraNo, string makineAdi,
            int bolgeNo, int riskNo, string tip)
        {
            // Örn: .../Gorseller/MevcutDurum/Risk_1.2/
            return Path.Combine(
                RaporKlasoru(projeKodu, raporTuru, siraNo, makineAdi),
                "Gorseller",
                Temizle(tip ?? ""),
                $"Risk_{bolgeNo}.{riskNo}"
            );
        }

        // Risk görseli dosya yolu (örn: .../Gorseller/MevcutDurum/Risk_1.2/1.jpg)
        public static string RiskGorselDosyaYolu(
            string projeKodu, string raporTuru, int siraNo, string makineAdi,
            int bolgeNo, int riskNo, string tip, string dosyaAdi)
        {
            return Path.Combine(
                RiskGorselKlasoru(projeKodu, raporTuru, siraNo, makineAdi, bolgeNo, riskNo, tip),
                Temizle(dosyaAdi ?? "")
            );
        }



        // Klasörü varsa oluşturur
        public static void KlasorOlustur(string yol)
        {
            if (!Directory.Exists(yol))
                Directory.CreateDirectory(yol);
        }
        public static string GetDbYoluFromRaporKodu(string raporKodu)
        {
            var rapor = RaporRepository.Listele().FirstOrDefault(r => r.RaporKodu == raporKodu);
            if (rapor == null) return null;
            return RaporKlasorYardimcisi.RaporDbYolu(
                rapor.ProjeKodu, rapor.RaporTuruKod, rapor.SiraNo, rapor.MakineAdi
            );
        }


    }
}

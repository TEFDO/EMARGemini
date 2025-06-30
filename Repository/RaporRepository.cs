using System;
using System.Collections.Generic;
using System.Data;
using EMAR.Helpers;
using EMAR.Models;

namespace EMAR.Repository
{
    public static class RaporRepository
    {
        // Tek bir yerde ana db yolunu üretmek daha doğru
        private static string AnaDbYolu
        {
            get
            {
                // Uygulamanın çalıştığı klasörde tutuyorsan:
                // return Path.Combine(Application.StartupPath, "raporlar.db");
                // Veya sadece "raporlar.db" ise bu satırı kullan:
                return "raporlar.db";
            }
        }

        public static string KaydetVeKodUret(Rapor rapor, string anaDbYolu = null)
        {
            if (string.IsNullOrEmpty(anaDbYolu))
                anaDbYolu = AnaDbYolu;

            string raporKodu = $"{rapor.ProjeKodu}-{rapor.RaporTuruKod}-{rapor.SiraNo:D2}-{RaporKlasorYardimcisi.Temizle(rapor.MakineAdi)}";

            // PROJEKODU ve MAKINEADI tabloya YAZILMIYOR!
            string sql = @"INSERT INTO Raporlar (ProjeId, MakineId, RaporTuruKod, RaporKodu, Tarih, SiraNo)
                   VALUES (@pid, @mid, @kod, @raporKodu, @tarih, @sira);
                   SELECT last_insert_rowid();";

            var prms = new Dictionary<string, object>
            {
                ["@pid"] = rapor.ProjeId,
                ["@mid"] = rapor.MakineId,
                ["@kod"] = rapor.RaporTuruKod,
                ["@raporKodu"] = raporKodu,
                ["@tarih"] = rapor.Tarih,
                ["@sira"] = rapor.SiraNo
            };

            VeritabaniHelper.DegerGetir(sql, prms, anaDbYolu);
            return raporKodu;
        }


        public static List<Rapor> Listele(int? projeId = null, string raporTuruKod = null)
        {
            var raporlar = new List<Rapor>();

            string sql = @"SELECT R.Id, R.RaporKodu, R.ProjeId, R.MakineId, R.RaporTuruKod, R.Tarih,
                                  P.ProjeKodu, M.Ad AS MakineAdi, Mu.Ad AS MusteriAdi, R.SiraNo
                           FROM Raporlar R
                           JOIN Projeler P ON R.ProjeId = P.Id
                           JOIN Makineler M ON R.MakineId = M.Id
                           JOIN Musteriler Mu ON P.MusteriId = Mu.Id
                           WHERE 1 = 1";

            var prms = new Dictionary<string, object>();

            if (projeId.HasValue)
            {
                sql += " AND R.ProjeId = @pid";
                prms["@pid"] = projeId.Value;
            }

            if (!string.IsNullOrEmpty(raporTuruKod))
            {
                sql += " AND R.RaporTuruKod = @kod";
                prms["@kod"] = raporTuruKod;
            }

            var dt = VeritabaniHelper.TabloGetir(sql, prms, AnaDbYolu);

            foreach (DataRow row in dt.Rows)
            {
                raporlar.Add(new Rapor
                {
                    Id = Convert.ToInt32(row["Id"]),
                    RaporKodu = row["RaporKodu"].ToString(),
                    ProjeId = Convert.ToInt32(row["ProjeId"]),
                    MakineId = Convert.ToInt32(row["MakineId"]),
                    RaporTuruKod = row["RaporTuruKod"].ToString(),
                    Tarih = row["Tarih"].ToString(),
                    ProjeKodu = row["ProjeKodu"].ToString(),
                    MakineAdi = row["MakineAdi"].ToString(),
                    MusteriAdi = row["MusteriAdi"].ToString(),
                    SiraNo = row.Table.Columns.Contains("SiraNo") ? Convert.ToInt32(row["SiraNo"]) : 1 // Güvenlik için ekle!
                });
            }

            return raporlar;
        }

        public static int GetNextSiraNo(int projeId, int makineId, string raporTuru)
        {
            var sql = "SELECT IFNULL(MAX(SiraNo), 0) FROM Raporlar WHERE ProjeId = @pid AND MakineId = @mid AND RaporTuruKod = @tur";
            var prms = new Dictionary<string, object>
            {
                ["@pid"] = projeId,
                ["@mid"] = makineId,
                ["@tur"] = raporTuru
            };
            int mevcutMax = Convert.ToInt32(VeritabaniHelper.DegerGetir(sql, prms, AnaDbYolu));
            return mevcutMax + 1;
        }


        public static void Sil(string raporKodu)
        {
            VeritabaniHelper.KomutCalistir(
                "DELETE FROM Raporlar WHERE RaporKodu = @kod",
                new() { ["@kod"] = raporKodu }, AnaDbYolu);
        }
    }
}

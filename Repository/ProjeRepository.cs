using System;
using System.Collections.Generic;
using System.Data;
using EMAR.Helpers;
using EMAR.Models;

namespace EMAR.Repository
{
    public static class ProjeRepository
    {
        public static Proje Getir(int id)
        {
            var dt = VeritabaniHelper.TabloGetir("SELECT * FROM Projeler WHERE Id = @id", new() { ["@id"] = id });
            if (dt.Rows.Count == 0) return null;

            var row = dt.Rows[0];
            return new Proje
            {
                Id = id,
                Ad = row["Ad"].ToString(),
                ProjeKodu = row["ProjeKodu"].ToString(),
                MusteriId = row["MusteriId"] is DBNull ? -1 : Convert.ToInt32(row["MusteriId"]),
                Tarih = row["Tarih"].ToString(),
                HizmetKodu = row["HizmetKodu"].ToString(),
                Aciklama = row["Aciklama"].ToString()
            };
        }

        public static void Kaydet(Proje proje, bool guncelle)
        {
            string sql = guncelle
                ? @"UPDATE Projeler SET Ad=@ad, ProjeKodu=@kod, MusteriId=@musteri,
                    Tarih=@tarih, HizmetKodu=@hizmet, Aciklama=@aciklama WHERE Id=@id"
                : @"INSERT INTO Projeler (Ad, ProjeKodu, MusteriId, Tarih, HizmetKodu, Aciklama) 
                    VALUES (@ad, @kod, @musteri, @tarih, @hizmet, @aciklama)";

            var prms = new Dictionary<string, object>
            {
                ["@ad"] = proje.Ad,
                ["@kod"] = proje.ProjeKodu,
                ["@musteri"] = proje.MusteriId,
                ["@tarih"] = proje.Tarih,
                ["@hizmet"] = proje.HizmetKodu,
                ["@aciklama"] = proje.Aciklama
            };

            if (guncelle)
                prms["@id"] = proje.Id;

            VeritabaniHelper.KomutCalistir(sql, prms);
        }

        public static bool ProjeKoduZatenVar(string kod, int hariçId)
        {
            var sonuc = VeritabaniHelper.DegerGetir(
                "SELECT COUNT(*) FROM Projeler WHERE ProjeKodu = @kod AND Id <> @id",
                new() { ["@kod"] = kod, ["@id"] = hariçId });

            return Convert.ToInt32(sonuc) > 0;
        }

        public static List<Proje> Listele(string filtre = "")
        {
            string sql = @"SELECT P.*, M.Ad AS MusteriAd
                           FROM Projeler P
                           LEFT JOIN Musteriler M ON P.MusteriId = M.Id
                           WHERE LOWER(P.Ad) LIKE @filtre OR LOWER(P.ProjeKodu) LIKE @filtre";

            var prms = new Dictionary<string, object> { ["@filtre"] = $"%{filtre.ToLower()}%" };

            var dt = VeritabaniHelper.TabloGetir(sql, prms);
            var liste = new List<Proje>();

            foreach (DataRow r in dt.Rows)
            {
                liste.Add(new Proje
                {
                    Id = Convert.ToInt32(r["Id"]),
                    Ad = r["Ad"].ToString(),
                    ProjeKodu = r["ProjeKodu"].ToString(),
                    MusteriId = Convert.ToInt32(r["MusteriId"]),
                    Tarih = r["Tarih"].ToString(),
                    HizmetKodu = r["HizmetKodu"].ToString(),
                    Aciklama = r["Aciklama"].ToString(),
                    MusteriAd = r["MusteriAd"].ToString()
                });
            }

            return liste;
        }

        public static void Sil(int id)
        {
            VeritabaniHelper.KomutCalistir("DELETE FROM Projeler WHERE Id = @id", new() { ["@id"] = id });
        }
    }
}
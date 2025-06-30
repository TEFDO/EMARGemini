using System;
using System.Collections.Generic;
using System.Data;
using EMAR.Helpers;
using EMAR.Models;

namespace EMAR.Repository
{
    public static class MusteriRepository
    {
        public static int Kaydet(Musteri m, bool guncelle = false)
        {
            var prms = new Dictionary<string, object>
            {
                ["@ad"] = m.Ad,
                ["@adres"] = m.Adres,
                ["@logo"] = m.Logo ?? (object)DBNull.Value
            };

            if (guncelle)
            {
                prms["@id"] = m.Id;
                string sql = "UPDATE Musteriler SET Ad=@ad, Adres=@adres, Logo=@logo WHERE Id=@id";
                VeritabaniHelper.KomutCalistir(sql, prms);
                return m.Id;
            }
            else
            {
                string sql = "INSERT INTO Musteriler (Ad, Adres, Logo) VALUES (@ad, @adres, @logo); SELECT last_insert_rowid();";
                return Convert.ToInt32(VeritabaniHelper.DegerGetir(sql, prms));
            }
        }

        public static Musteri Getir(int id)
        {
            var dt = VeritabaniHelper.TabloGetir("SELECT * FROM Musteriler WHERE Id=@id", new() { ["@id"] = id });
            if (dt.Rows.Count == 0) return null;

            var r = dt.Rows[0];
            return new Musteri
            {
                Id = id,
                Ad = r["Ad"].ToString(),
                Adres = r["Adres"].ToString(),
                Logo = r["Logo"] is DBNull ? null : (byte[])r["Logo"]
            };
        }

        public static List<Musteri> Listele()
        {
            var dt = VeritabaniHelper.TabloGetir("SELECT * FROM Musteriler");
            var liste = new List<Musteri>();

            foreach (DataRow r in dt.Rows)
            {
                liste.Add(new Musteri
                {
                    Id = Convert.ToInt32(r["Id"]),
                    Ad = r["Ad"].ToString(),
                    Adres = r["Adres"].ToString(),
                    Logo = r["Logo"] is DBNull ? null : (byte[])r["Logo"]
                });
            }

            return liste;
        }

        public static void Sil(int id)
        {
            VeritabaniHelper.KomutCalistir("DELETE FROM Musteriler WHERE Id=@id", new() { ["@id"] = id });
        }
    }
}

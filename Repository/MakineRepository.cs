using System;
using System.Collections.Generic;
using System.Data;
using EMAR.Helpers;
using EMAR.Models;

namespace EMAR.Repository
{
    public static class MakineRepository
    {
        public static int Kaydet(Makine m, bool guncelle = false)
        {
            Dictionary<string, object> p = new()
            {
                ["@ad"] = m.Ad,
                ["@name"] = m.Name, // İngilizce adı ekle
                ["@imalatci"] = m.Imalatci,
                ["@seri"] = m.SeriNo,
                ["@tipi"] = m.Tipi,
                ["@yil"] = m.UretimYili,
                ["@sert"] = m.Sertifikasyon,
                ["@musteri"] = m.MusteriId,
                ["@elektrik"] = m.Elektrik,
                ["@pnomatik"] = m.Pnomatik,
                ["@hidrolik"] = m.Hidrolik,
                ["@diger"] = m.DigerEnerjiKaynaklari // Diğer enerji kaynakları
            };

            if (guncelle)
            {
                p["@id"] = m.Id;
                string sql = @"UPDATE Makineler SET 
                           Ad=@ad, 
                           Name=@name, 
                           Imalatci=@imalatci, 
                           SeriNo=@seri, 
                           Tipi=@tipi, 
                           UretimYili=@yil, 
                           Sertifikasyon=@sert, 
                           MusteriId=@musteri, 
                           Elektrik=@elektrik, 
                           Pnomatik=@pnomatik, 
                           Hidrolik=@hidrolik,
                           DigerEnerjiKaynaklari=@diger
                       WHERE Id=@id";
                VeritabaniHelper.KomutCalistir(sql, p);
                return m.Id;
            }
            else
            {
                string sql = @"INSERT INTO Makineler 
                        (Ad, Name, Imalatci, SeriNo, Tipi, UretimYili, Sertifikasyon, MusteriId, Elektrik, Pnomatik, Hidrolik, DigerEnerjiKaynaklari) 
                       VALUES 
                        (@ad, @name, @imalatci, @seri, @tipi, @yil, @sert, @musteri, @elektrik, @pnomatik, @hidrolik, @diger);
                       SELECT last_insert_rowid();";
                return Convert.ToInt32(VeritabaniHelper.DegerGetir(sql, p));
            }
        }

        public static Makine Getir(int id)
        {
            var dt = VeritabaniHelper.TabloGetir("SELECT * FROM Makineler WHERE Id=@id", new() { { "@id", id } });
            if (dt.Rows.Count == 0) return null;

            var r = dt.Rows[0];
            return new Makine
            {
                Id = id,
                Ad = r["Ad"].ToString(),
                Name = r.Table.Columns.Contains("Name") ? r["Name"].ToString() : "",
                Imalatci = r["Imalatci"].ToString(),
                SeriNo = r["SeriNo"].ToString(),
                Tipi = r["Tipi"].ToString(),
                UretimYili = Convert.ToInt32(r["UretimYili"]),
                Sertifikasyon = r["Sertifikasyon"].ToString(),
                MusteriId = Convert.ToInt32(r["MusteriId"]),
                Elektrik = r["Elektrik"].ToString(),
                Pnomatik = r["Pnomatik"].ToString(),
                Hidrolik = r["Hidrolik"].ToString(),
                DigerEnerjiKaynaklari = r.Table.Columns.Contains("DigerEnerjiKaynaklari") ? r["DigerEnerjiKaynaklari"].ToString() : "",

                // Limit property'leri
                KullanimAmaci = r.Table.Columns.Contains("KullanimAmaci") ? r["KullanimAmaci"].ToString() : "",
                KullaniciSeviyesi = r.Table.Columns.Contains("KullaniciSeviyesi") ? r["KullaniciSeviyesi"].ToString() : "",
                PersonelTipi = r.Table.Columns.Contains("PersonelTipi") ? r["PersonelTipi"].ToString() : "",
                BakimSikligi = r.Table.Columns.Contains("BakimSikligi") ? r["BakimSikligi"].ToString() : "",
                MakineOlculeri = r.Table.Columns.Contains("MakineOlculeri") ? r["MakineOlculeri"].ToString() : "",
                ZamanLimitleri = r.Table.Columns.Contains("ZamanLimitleri") ? r["ZamanLimitleri"].ToString() : ""
            };
        }

        public static List<Makine> Listele(int projeId = 0, string arama = "")
        {
            var liste = new List<Makine>();
            var prms = new Dictionary<string, object>();

            string filtre = "";
            if (!string.IsNullOrWhiteSpace(arama))
            {
                filtre = " AND (LOWER(M.Ad) LIKE @arama OR LOWER(M.SeriNo) LIKE @arama)";
                prms["@arama"] = $"%{arama.ToLower()}%";
            }

            string sql = projeId == 0
                ? $@"SELECT M.*, Mu.Ad AS MusteriAd 
             FROM Makineler M 
             LEFT JOIN Musteriler Mu ON M.MusteriId = Mu.Id 
             WHERE 1=1 {filtre}"
                : $@"SELECT M.*, Mu.Ad AS MusteriAd 
             FROM ProjeMakineleri PM 
             JOIN Makineler M ON M.Id = PM.MakineId 
             LEFT JOIN Musteriler Mu ON M.MusteriId = Mu.Id 
             WHERE PM.ProjeId = @ProjeId {filtre}";

            if (projeId != 0)
                prms["@ProjeId"] = projeId;

            var dt = VeritabaniHelper.TabloGetir(sql, prms);
            foreach (DataRow row in dt.Rows)
            {
                liste.Add(new Makine
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Ad = row["Ad"].ToString(),
                    Name = row.Table.Columns.Contains("Name") ? row["Name"].ToString() : "",
                    Imalatci = row["Imalatci"].ToString(),
                    SeriNo = row["SeriNo"].ToString(),
                    Tipi = row["Tipi"].ToString(),
                    UretimYili = row["UretimYili"] is DBNull ? 0 : Convert.ToInt32(row["UretimYili"]),
                    Sertifikasyon = row["Sertifikasyon"].ToString(),
                    MusteriId = row["MusteriId"] is DBNull ? 0 : Convert.ToInt32(row["MusteriId"]),
                    MusteriAd = row.Table.Columns.Contains("MusteriAd") ? row["MusteriAd"].ToString() : "",
                    Elektrik = row["Elektrik"].ToString(),
                    Pnomatik = row["Pnomatik"].ToString(),
                    Hidrolik = row["Hidrolik"].ToString(),
                    DigerEnerjiKaynaklari = row.Table.Columns.Contains("DigerEnerjiKaynaklari") ? row["DigerEnerjiKaynaklari"].ToString() : "",

                    // Limit property'leri
                    KullanimAmaci = row.Table.Columns.Contains("KullanimAmaci") ? row["KullanimAmaci"].ToString() : "",
                    KullaniciSeviyesi = row.Table.Columns.Contains("KullaniciSeviyesi") ? row["KullaniciSeviyesi"].ToString() : "",
                    PersonelTipi = row.Table.Columns.Contains("PersonelTipi") ? row["PersonelTipi"].ToString() : "",
                    BakimSikligi = row.Table.Columns.Contains("BakimSikligi") ? row["BakimSikligi"].ToString() : "",
                    MakineOlculeri = row.Table.Columns.Contains("MakineOlculeri") ? row["MakineOlculeri"].ToString() : "",
                    ZamanLimitleri = row.Table.Columns.Contains("ZamanLimitleri") ? row["ZamanLimitleri"].ToString() : ""
                });
            }

            return liste;
        }


        public static void Sil(int id)
        {
            VeritabaniHelper.KomutCalistir("DELETE FROM Makineler WHERE Id=@id", new() { ["@id"] = id });
        }

        public static void ProjedenSil(int makineId)
        {
            VeritabaniHelper.KomutCalistir("DELETE FROM ProjeMakineleri WHERE MakineId=@id", new() { ["@id"] = makineId });
        }

        public static void GuncelleLimitler(Makine m)
        {
            string sql = @"UPDATE Makineler SET 
                KullanimAmaci = @amac,
                KullaniciSeviyesi = @seviye,
                PersonelTipi = @personel,
                BakimSikligi = @bakim,
                MakineOlculeri = @olcu,
                ZamanLimitleri = @zaman
                WHERE Id = @id";

            var parametreler = new Dictionary<string, object>
            {
                ["@amac"] = m.KullanimAmaci,
                ["@seviye"] = m.KullaniciSeviyesi,
                ["@personel"] = m.PersonelTipi,
                ["@bakim"] = m.BakimSikligi,
                ["@olcu"] = m.MakineOlculeri,
                ["@zaman"] = m.ZamanLimitleri,
                ["@id"] = m.Id
            };

            VeritabaniHelper.KomutCalistir(sql, parametreler);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace EMAR.Helpers
{
    public static class VeritabaniHelper
    {
        private static readonly string DbYolu = "Data Source=raporlar.db;Version=3;";

        // --- TABLO GETİR ---
        public static DataTable TabloGetir(string sql, Dictionary<string, object> parametreler = null)
        {
            return TabloGetir(sql, parametreler, "raporlar.db");
        }

        public static DataTable TabloGetir(string sql, Dictionary<string, object> parametreler, string dbYolu)
        {
            using var con = new SQLiteConnection($"Data Source={dbYolu};Version=3;");
            using var da = new SQLiteDataAdapter(sql, con);
            if (parametreler != null)
            {
                da.SelectCommand.Parameters.Clear();
                foreach (var kvp in parametreler)
                    da.SelectCommand.Parameters.AddWithValue(kvp.Key, kvp.Value);
            }
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // --- KOMUT ÇALIŞTIR ---
        public static void KomutCalistir(string sql, Dictionary<string, object> parametreler = null)
        {
            KomutCalistir(sql, parametreler, "raporlar.db");
        }

        public static void KomutCalistir(string sql, Dictionary<string, object> parametreler, string dbYolu)
        {
            using var con = new SQLiteConnection($"Data Source={dbYolu};Version=3;");
            con.Open();
            using var cmd = new SQLiteCommand(sql, con);
            if (parametreler != null)
            {
                foreach (var kvp in parametreler)
                    cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
            }
            cmd.ExecuteNonQuery();
        }

        // --- DEĞER GETİR ---
        public static object DegerGetir(string sql, Dictionary<string, object> parametreler = null)
        {
            return DegerGetir(sql, parametreler, "raporlar.db");
        }

        public static object DegerGetir(string sql, Dictionary<string, object> parametreler, string dbYolu)
        {
            using var con = new SQLiteConnection($"Data Source={dbYolu};Version=3;");
            con.Open();
            using var cmd = new SQLiteCommand(sql, con);
            if (parametreler != null)
            {
                foreach (var kvp in parametreler)
                    cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
            }
            return cmd.ExecuteScalar();
        }

        // --- SIFIRLA ---
        public static void Sifirla()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            SQLiteConnection.ClearAllPools();

            foreach (var file in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.db"))
            {
                if (!file.EndsWith("raporlar.db", StringComparison.OrdinalIgnoreCase))
                {
                    try { File.Delete(file); } catch { }
                }
            }

            string[] gorselKlasorleri =
            {
                Path.Combine("Gorseller", "Makine"),
                Path.Combine("Gorseller", "Thumbs")
            };

            foreach (var klasor in gorselKlasorleri)
            {
                if (Directory.Exists(klasor))
                {
                    try { Directory.Delete(klasor, true); } catch { }
                }
            }

            string dbYolu = "raporlar.db";
            if (File.Exists(dbYolu)) File.Delete(dbYolu);
            SQLiteConnection.CreateFile(dbYolu);

            using var con = new SQLiteConnection($"Data Source={dbYolu};Version=3;");
            con.Open();

            string[] tabloKomutlari =
            {
                @"CREATE TABLE IF NOT EXISTS Musteriler (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Ad TEXT NOT NULL,
                    Adres TEXT,
                    Logo BLOB);",

                @"CREATE TABLE IF NOT EXISTS Projeler (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    MusteriId INTEGER,
                    Ad TEXT,
                    ProjeKodu TEXT NOT NULL,
                    HizmetKodu TEXT,
                    Tarih TEXT,
                    Aciklama TEXT,
                    FOREIGN KEY(MusteriId) REFERENCES Musteriler(Id));",

                @"CREATE TABLE IF NOT EXISTS Makineler (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    MusteriId INTEGER,
                    ProjeId INTEGER,
                    Ad TEXT NOT NULL,
                    Name TEXT,
                    Imalatci TEXT,
                    SeriNo TEXT,
                    Tipi TEXT,
                    UretimYili INTEGER,
                    Sertifikasyon TEXT,
                    Elektrik TEXT,
                    Pnomatik TEXT,
                    Hidrolik TEXT,
                    DigerEnerjiKaynaklari TEXT,
                    KullanimAmaci TEXT,
                    KullaniciSeviyesi TEXT,
                    PersonelTipi TEXT,
                    BakimSikligi TEXT,
                    MakineOlculeri TEXT,
                    ZamanLimitleri TEXT,
                    FOREIGN KEY(MusteriId) REFERENCES Musteriler(Id),
                    FOREIGN KEY(ProjeId) REFERENCES Projeler(Id));",

                @"CREATE TABLE IF NOT EXISTS ProjeMakineleri (
                    ProjeId INTEGER,
                    MakineId INTEGER,
                    PRIMARY KEY (ProjeId, MakineId),
                    FOREIGN KEY(ProjeId) REFERENCES Projeler(Id),
                    FOREIGN KEY(MakineId) REFERENCES Makineler(Id));",

                @"CREATE TABLE IF NOT EXISTS Raporlar (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    ProjeId INTEGER,
    MakineId INTEGER,
    RaporTuruKod TEXT,
    RaporKodu TEXT NOT NULL,
    Tarih TEXT,
    SiraNo INTEGER,       -- <<< YENİ
    MakineAdi TEXT,       -- <<< YENİ
    ProjeKodu TEXT,       -- <<< YENİ
    FOREIGN KEY(ProjeId) REFERENCES Projeler(Id),
    FOREIGN KEY(MakineId) REFERENCES Makineler(Id)
);
"
            };

            foreach (var sql in tabloKomutlari)
            {
                using var cmd = new SQLiteCommand(sql, con);
                cmd.ExecuteNonQuery();
            }

            // INI tabanlı tablolar kaldırıldı: RaporTurleri, MakineTipleri, Sertifikasyonlar, Kaynaklar...
        }

        // --- Yardımcılar ---
        public static bool MakineBaskaProjeyeBagliMi(int makineId)
        {
            var sql = "SELECT COUNT(*) FROM ProjeMakineleri WHERE MakineId = @id";
            var prms = new Dictionary<string, object> { ["@id"] = makineId };
            return Convert.ToInt32(DegerGetir(sql, prms)) > 0;
        }

        public static void MakineyiProjelerdenSil(int makineId)
        {
            var sql = "DELETE FROM ProjeMakineleri WHERE MakineId = @id";
            KomutCalistir(sql, new() { ["@id"] = makineId });
        }
    }
}



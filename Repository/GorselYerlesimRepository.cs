// Repository/GorselYerlesimRepository.cs

using System.Collections.Generic;
using System.Data.SQLite;
using EMAR.Models;
using Newtonsoft.Json;

namespace EMAR.Repository
{
    /// <summary>
    /// Her risk-altbaşlık için (örn: MevcutDurum, Modifikasyon) görselleri JSON olarak saklar.
    /// </summary>
    public static class GorselYerlesimRepository
    {
        // Tablo: Her risk ve başlık için bir satır.
        public static void EnsureSchema(string dbYolu)
        {
            using var con = new SQLiteConnection($"Data Source={dbYolu}");
            con.Open();
            var cmd = new SQLiteCommand(@"
                CREATE TABLE IF NOT EXISTS GorselYerlesimJson (
                    RiskId INTEGER,
                    Baslik TEXT, -- 'MevcutDurum', 'Modifikasyon' vb.
                    GorselListesiJson TEXT,
                    PRIMARY KEY (RiskId, Baslik)
                );", con);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Kaydet: İlgili risk ve başlıktaki tüm görselleri kaydeder (JSON tek satır).
        /// </summary>
        public static void Save(string dbYolu, int riskId, string baslik, List<GorselYerlesimModel> gorseller)
        {
            EnsureSchema(dbYolu);
            string json = JsonConvert.SerializeObject(gorseller ?? new List<GorselYerlesimModel>());
            using var con = new SQLiteConnection($"Data Source={dbYolu}");
            con.Open();
            var del = new SQLiteCommand("DELETE FROM GorselYerlesimJson WHERE RiskId = @id AND Baslik = @b", con);
            del.Parameters.AddWithValue("@id", riskId);
            del.Parameters.AddWithValue("@b", baslik);
            del.ExecuteNonQuery();

            var ins = new SQLiteCommand(
                "INSERT INTO GorselYerlesimJson (RiskId, Baslik, GorselListesiJson) VALUES (@id, @b, @json)", con);
            ins.Parameters.AddWithValue("@id", riskId);
            ins.Parameters.AddWithValue("@b", baslik);
            ins.Parameters.AddWithValue("@json", json);
            ins.ExecuteNonQuery();
        }

        /// <summary>
        /// Yükle: İlgili risk ve başlıktaki görselleri getirir.
        /// </summary>
        public static List<GorselYerlesimModel> Load(string dbYolu, int riskId, string baslik)
        {
            EnsureSchema(dbYolu);
            using var con = new SQLiteConnection($"Data Source={dbYolu}");
            con.Open();

            var cmd = new SQLiteCommand("SELECT GorselListesiJson FROM GorselYerlesimJson WHERE RiskId = @id AND Baslik = @b", con);
            cmd.Parameters.AddWithValue("@id", riskId);
            cmd.Parameters.AddWithValue("@b", baslik);
            using var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                string json = rdr["GorselListesiJson"]?.ToString();
                if (!string.IsNullOrWhiteSpace(json))
                    return JsonConvert.DeserializeObject<List<GorselYerlesimModel>>(json);
            }
            return new List<GorselYerlesimModel>();
        }

        /// <summary>
        /// Sil: İlgili risk ve başlıktaki görsel listesini siler.
        /// </summary>
        public static void Delete(string dbYolu, int riskId, string baslik)
        {
            using var con = new SQLiteConnection($"Data Source={dbYolu}");
            con.Open();
            var cmd = new SQLiteCommand("DELETE FROM GorselYerlesimJson WHERE RiskId = @id AND Baslik = @b", con);
            cmd.Parameters.AddWithValue("@id", riskId);
            cmd.Parameters.AddWithValue("@b", baslik);
            cmd.ExecuteNonQuery();
        }
    }
}

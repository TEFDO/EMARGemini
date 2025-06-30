using EMAR.Models;
using System;
using System.Data.SQLite;
using System.IO;

namespace EMAR.Repository
{
    public class RiskAzaltimiRepository
    {
        private readonly string _dbPath;

        public RiskAzaltimiRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void EnsureTable()
        {
            if (!File.Exists(_dbPath)) return;

            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();

            var cmd = new SQLiteCommand(@"
                CREATE TABLE IF NOT EXISTS RiskAzaltimi (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    RiskId INTEGER,
                    Olasilik TEXT,
                    KazaOlma TEXT,
                    Kacinma TEXT,
                    MaruzKalma TEXT,
                    HRN TEXT,
                    OnlemlerRTF TEXT,
                    ArtikRiskRTF TEXT,
                    HRNSeviye TEXT
                );", con);

            cmd.ExecuteNonQuery();
        }

        public RiskAzaltimi GetByRiskId(int riskId)
        {
            if (!File.Exists(_dbPath)) return null;

            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();

            var cmd = new SQLiteCommand("SELECT * FROM RiskAzaltimi WHERE RiskId = @r", con);
            cmd.Parameters.AddWithValue("@r", riskId);

            using var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                return new RiskAzaltimi
                {
                    Id = Convert.ToInt32(rdr["Id"]),
                    RiskId = Convert.ToInt32(rdr["RiskId"]),
                    Olasilik = rdr["Olasilik"].ToString(),
                    KazaOlma = rdr["KazaOlma"].ToString(),
                    Kacinma = rdr["Kacinma"].ToString(),
                    MaruzKalma = rdr["MaruzKalma"].ToString(),
                    HRN = rdr["HRN"].ToString(),
                    HRNSeviye = rdr["HRNSeviye"].ToString(),
                    OnlemlerRTF = rdr["OnlemlerRTF"].ToString(),
                    ArtikRiskRTF = rdr["ArtikRiskRTF"].ToString()
                };
            }

            return null;
        }

        public void Save(RiskAzaltimi model)
        {
            if (!File.Exists(_dbPath)) return;

            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();

            var cmd = new SQLiteCommand(@"
                INSERT OR REPLACE INTO RiskAzaltimi
                (Id, RiskId, Olasilik, KazaOlma, Kacinma, MaruzKalma, HRN, HRNSeviye ,OnlemlerRTF, ArtikRiskRTF)
                VALUES ((SELECT Id FROM RiskAzaltimi WHERE RiskId = @r), @r, @o, @k, @ka, @m, @h, @hrnSeviye, @on, @ar);", con);

            cmd.Parameters.AddWithValue("@r", model.RiskId);
            cmd.Parameters.AddWithValue("@o", model.Olasilik);
            cmd.Parameters.AddWithValue("@k", model.KazaOlma);
            cmd.Parameters.AddWithValue("@ka", model.Kacinma);
            cmd.Parameters.AddWithValue("@m", model.MaruzKalma);
            cmd.Parameters.AddWithValue("@h", model.HRN);
            cmd.Parameters.AddWithValue("@hrnSeviye", model.HRNSeviye);
            cmd.Parameters.AddWithValue("@on", model.OnlemlerRTF );
            cmd.Parameters.AddWithValue("@ar", model.ArtikRiskRTF);

            cmd.ExecuteNonQuery();
        }
    }
}

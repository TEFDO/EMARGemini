using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAR.Repository
{
    using EMAR.Models;
    using System;
    using System.Data.SQLite;

    public class MevcutDurumRepository
    {
        private readonly string _dbPath;

        public MevcutDurumRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void EnsureTable()
        {
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();
            var createCmd = new SQLiteCommand(@"
            CREATE TABLE IF NOT EXISTS MevcutDurum (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                RiskId INTEGER,
                Metin TEXT,
                Gorsel1 TEXT,
                Gorsel2 TEXT,
                StandartlarJson TEXT
            );", con);
            createCmd.ExecuteNonQuery();
            // Ek alan eklemesi (varsa yoksa)
            try
            {
                var alterCmd = new SQLiteCommand("ALTER TABLE MevcutDurum ADD COLUMN Gorsel2 TEXT;", con);
                alterCmd.ExecuteNonQuery();
            }
            catch { /* Zaten varsa hata verir, görmezden gel */ }
        }

        public MevcutDurum GetByRiskId(int riskId)
        {
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();
            var cmd = new SQLiteCommand("SELECT * FROM MevcutDurum WHERE RiskId = @r", con);
            cmd.Parameters.AddWithValue("@r", riskId);
            using var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                return new MevcutDurum
                {
                    Id = rdr.GetInt32(0),
                    RiskId = rdr.GetInt32(1),
                    Metin = rdr["Metin"]?.ToString(),
                    Gorsel1 = rdr["Gorsel1"]?.ToString(),
                    Gorsel2 = rdr["Gorsel2"]?.ToString(),
                    StandartlarJson = rdr["StandartlarJson"]?.ToString()
                };
            }

            return null;
        }
        public void DeleteByRiskId(int riskId)
        {
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();
            var cmd = new SQLiteCommand("DELETE FROM MevcutDurum WHERE RiskId = @r", con);
            cmd.Parameters.AddWithValue("@r", riskId);
            cmd.ExecuteNonQuery();
        }

        public void Save(MevcutDurum durum)
        {
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();
            var cmd = new SQLiteCommand(@"
            INSERT OR REPLACE INTO MevcutDurum
            (Id, RiskId, Metin, Gorsel1, Gorsel2, StandartlarJson)
            VALUES (
                (SELECT Id FROM MevcutDurum WHERE RiskId = @r),
                @r, @m, @g1, @g2, @s)", con);

            cmd.Parameters.AddWithValue("@r", durum.RiskId);
            cmd.Parameters.AddWithValue("@m", durum.Metin ?? "");
            cmd.Parameters.AddWithValue("@g1", (object)durum.Gorsel1 ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@g2", (object)durum.Gorsel2 ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@s", durum.StandartlarJson ?? "");
            cmd.ExecuteNonQuery();
        }
    }

}

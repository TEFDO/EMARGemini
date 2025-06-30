using System.Collections.Generic;
using System.Data.SQLite;
using EMAR.Models;

namespace EMAR.Repository
{
    public class ModifikasyonIcerikRepository
    {
        private readonly string _dbPath;

        public ModifikasyonIcerikRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void EnsureTable()
        {
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();
            string query = @"
                CREATE TABLE IF NOT EXISTS ModifikasyonIcerik (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    RiskId INTEGER,
                    Tip TEXT,
                    Icerik TEXT,
                    Siralama INTEGER
                );";
            new SQLiteCommand(query, con).ExecuteNonQuery();
        }

        public List<ModifikasyonIcerik> GetByRiskId(int riskId)
        {
            var list = new List<ModifikasyonIcerik>();
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();
            var cmd = new SQLiteCommand("SELECT * FROM ModifikasyonIcerik WHERE RiskId = @r ORDER BY Siralama", con);
            cmd.Parameters.AddWithValue("@r", riskId);
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(new ModifikasyonIcerik
                {
                    Id = rdr.GetInt32(0),
                    RiskId = rdr.GetInt32(1),
                    Tip = rdr.GetString(2),
                    Icerik = rdr.GetString(3),
                    Siralama = rdr.GetInt32(4)
                });
            }
            return list;
        }

        public void DeleteByRiskId(int riskId)
        {
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();
            var cmd = new SQLiteCommand("DELETE FROM ModifikasyonIcerik WHERE RiskId = @r", con);
            cmd.Parameters.AddWithValue("@r", riskId);
            cmd.ExecuteNonQuery();
        }

        public void Insert(ModifikasyonIcerik item)
        {
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();
            var cmd = new SQLiteCommand(@"
                INSERT INTO ModifikasyonIcerik (RiskId, Tip, Icerik, Siralama)
                VALUES (@r, @t, @i, @s)", con);
            cmd.Parameters.AddWithValue("@r", item.RiskId);
            cmd.Parameters.AddWithValue("@t", item.Tip);
            cmd.Parameters.AddWithValue("@i", item.Icerik);
            cmd.Parameters.AddWithValue("@s", item.Siralama);
            cmd.ExecuteNonQuery();
        }
    }
}

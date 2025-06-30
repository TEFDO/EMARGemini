using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using EMAR.Models;

namespace EMAR.Repository
{
    public static class RiskRepository
    {
        public static void EnsureSchema(string dbYolu)
        {
            using var con = new SQLiteConnection($"Data Source={dbYolu};Version=3;");
            con.Open();
            string sql = @"CREATE TABLE IF NOT EXISTS Riskler (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            BolgeId INTEGER,
                            RiskSira INTEGER,
                            Baslik TEXT);";
            using var cmd = new SQLiteCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static int Ekle(string dbYolu, int bolgeId, int sira, string baslik)
        {
            using var con = new SQLiteConnection($"Data Source={dbYolu};Version=3;");
            con.Open();
            string sql = "INSERT INTO Riskler (BolgeId, RiskSira, Baslik) VALUES (@b, @s, @t); SELECT last_insert_rowid();";
            using var cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@b", bolgeId);
            cmd.Parameters.AddWithValue("@s", sira);
            cmd.Parameters.AddWithValue("@t", baslik);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static void Sil(string dbYolu, int riskId)
        {
            using var con = new SQLiteConnection($"Data Source={dbYolu};Version=3;");
            con.Open();
            using var cmd = new SQLiteCommand("DELETE FROM Riskler WHERE Id = @id", con);
            cmd.Parameters.AddWithValue("@id", riskId);
            cmd.ExecuteNonQuery();
        }

        public static void GuncelleSiralar(string dbYolu, List<(int RiskId, int YeniSira)> siralar)
        {
            using var con = new SQLiteConnection($"Data Source={dbYolu};Version=3;");
            con.Open();
            foreach (var (riskId, yeniSira) in siralar)
            {
                using var cmd = new SQLiteCommand("UPDATE Riskler SET RiskSira = @s WHERE Id = @id", con);
                cmd.Parameters.AddWithValue("@s", yeniSira);
                cmd.Parameters.AddWithValue("@id", riskId);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<Risk> Listele(string dbYolu, int bolgeId)
        {
            var liste = new List<Risk>();
            using var con = new SQLiteConnection($"Data Source={dbYolu};Version=3;");
            con.Open();
            string sql = "SELECT * FROM Riskler WHERE BolgeId = @b ORDER BY RiskSira";
            using var cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@b", bolgeId);
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                liste.Add(new Risk
                {
                    Id = Convert.ToInt32(rdr["Id"]),
                    BolgeId = Convert.ToInt32(rdr["BolgeId"]),
                    RiskSira = Convert.ToInt32(rdr["RiskSira"]),
                    Baslik = rdr["Baslik"].ToString()
                });
            }
            return liste;
        }
    }
}

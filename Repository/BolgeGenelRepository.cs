using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMAR.Models;
using System.Data.SQLite;

namespace EMAR.Repository
{
      public class BolgeGenelRepository
    {
        private readonly string _dbPath;

        public BolgeGenelRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void EnsureTable()
        {
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();
            var cmd = new SQLiteCommand(@"
            CREATE TABLE IF NOT EXISTS BolgeGenel (
                BolgeId INTEGER PRIMARY KEY,
                Aciklama TEXT,
                Notlar TEXT,
                Gorsel TEXT
            );", con);
            cmd.ExecuteNonQuery();
        }

        public BolgeGenel GetById(int bolgeId)
        {
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();
            var cmd = new SQLiteCommand("SELECT * FROM BolgeGenel WHERE BolgeId = @id", con);
            cmd.Parameters.AddWithValue("@id", bolgeId);

            using var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                return new BolgeGenel
                {
                    BolgeId = bolgeId,
                    Aciklama = rdr["Aciklama"]?.ToString(),
                    Notlar = rdr["Notlar"]?.ToString(),
                    Gorsel = rdr["Gorsel"]?.ToString()
                };
            }

            return null;
        }

        public void Save(BolgeGenel veri)
        {
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();
            var cmd = new SQLiteCommand(@"
            INSERT OR REPLACE INTO BolgeGenel (BolgeId, Aciklama, Notlar, Gorsel)
            VALUES (@id, @a, @n, @g);", con);

            cmd.Parameters.AddWithValue("@id", veri.BolgeId);
            cmd.Parameters.AddWithValue("@a", veri.Aciklama);
            cmd.Parameters.AddWithValue("@n", veri.Notlar);
            cmd.Parameters.AddWithValue("@g", (object)veri.Gorsel ?? DBNull.Value);

            cmd.ExecuteNonQuery();
        }
    }

}

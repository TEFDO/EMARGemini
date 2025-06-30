using System.Collections.Generic;
using System.Data.SQLite;
using EMAR.Models;

namespace EMAR.Repositories
{
    public class RevizyonRepository
    {
        private readonly string _dbPath;

        public RevizyonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void EnsureTable()
        {
            using var conn = new SQLiteConnection($"Data Source={_dbPath}");
            conn.Open();
            var cmd = new SQLiteCommand(@"
                CREATE TABLE IF NOT EXISTS Revizyonlar (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Revizyon TEXT,
                    Tarih TEXT,
                    Duzenleyen TEXT,
                    Aciklama TEXT
                );", conn);
            cmd.ExecuteNonQuery();
        }

        public List<RevizyonItem> GetAll()
        {
            var list = new List<RevizyonItem>();
            using var conn = new SQLiteConnection($"Data Source={_dbPath}");
            conn.Open();
            var cmd = new SQLiteCommand("SELECT Revizyon, Tarih, Duzenleyen, Aciklama FROM Revizyonlar ORDER BY Id", conn);
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(new RevizyonItem
                {
                    Revizyon = rdr["Revizyon"].ToString(),
                    Tarih = rdr["Tarih"].ToString(),
                    Duzenleyen = rdr["Duzenleyen"].ToString(),
                    Aciklama = rdr["Aciklama"].ToString()
                });
            }

            return list;
        }

        public void SaveAll(List<RevizyonItem> items)
        {
            using var conn = new SQLiteConnection($"Data Source={_dbPath}");
            conn.Open();
            EnsureTable();

            using var tran = conn.BeginTransaction();
            new SQLiteCommand("DELETE FROM Revizyonlar", conn, tran).ExecuteNonQuery();

            foreach (var item in items)
            {
                var cmd = new SQLiteCommand(@"
                    INSERT INTO Revizyonlar (Revizyon, Tarih, Duzenleyen, Aciklama)
                    VALUES (@rev, @tarih, @kisi, @aciklama)", conn, tran);

                cmd.Parameters.AddWithValue("@rev", item.Revizyon);
                cmd.Parameters.AddWithValue("@tarih", item.Tarih);
                cmd.Parameters.AddWithValue("@kisi", item.Duzenleyen);
                cmd.Parameters.AddWithValue("@aciklama", item.Aciklama);
                cmd.ExecuteNonQuery();
            }

            tran.Commit();
        }
    }
}

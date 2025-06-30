using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using EMAR.Models;

namespace EMAR.Repository
{
    public class TemsilciRepository
    {
        private readonly string _dbPath;

        public TemsilciRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void EnsureTable()
        {
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();
            var cmd = new SQLiteCommand(@"
            CREATE TABLE IF NOT EXISTS Temsilciler (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Isim TEXT NOT NULL,
                Firma TEXT NOT NULL,
                Gorev TEXT NOT NULL
            );", con);
            cmd.ExecuteNonQuery();
        }

        public List<Temsilci> GetAll()
        {
            var list = new List<Temsilci>();
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();
            var cmd = new SQLiteCommand("SELECT * FROM Temsilciler", con);
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(new Temsilci
                {
                    Id = rdr.GetInt32(0),
                    Isim = rdr["Isim"].ToString(),
                    Firma = rdr["Firma"].ToString(),
                    Gorev = rdr["Gorev"].ToString()
                });
            }
            return list;
        }

        public void SaveAll(List<Temsilci> temsilciler)
        {
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();
            using var tran = con.BeginTransaction();

            new SQLiteCommand("DELETE FROM Temsilciler", con, tran).ExecuteNonQuery();

            foreach (var t in temsilciler)
            {
                var cmd = new SQLiteCommand(@"
                INSERT INTO Temsilciler (Isim, Firma, Gorev)
                VALUES (@i, @f, @g)", con, tran);
                cmd.Parameters.AddWithValue("@i", t.Isim);
                cmd.Parameters.AddWithValue("@f", t.Firma);
                cmd.Parameters.AddWithValue("@g", t.Gorev);
                cmd.ExecuteNonQuery();
            }

            tran.Commit();
        }
    }

}

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using EMAR.Models;

namespace EMAR.Repositories
{
    public class DokumanRepository
    {
        private readonly string _dbPath;

        public DokumanRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void EnsureTables()
        {
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();

            string sql = @"
                CREATE TABLE IF NOT EXISTS Dokumanlar (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Ad TEXT NOT NULL,
                    Tip TEXT NOT NULL,
                    IletilmeTarihi TEXT
                );";

            using var cmd = new SQLiteCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public List<Dokuman> GetAll()
        {
            var list = new List<Dokuman>();
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();
            var cmd = new SQLiteCommand("SELECT * FROM Dokumanlar ORDER BY Id DESC", con);
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(new Dokuman
                {
                    Id = Convert.ToInt32(rdr["Id"]),
                    Ad = rdr["Ad"].ToString(),
                    Tip = rdr["Tip"].ToString(),
                    IletilmeTarihi = rdr["IletilmeTarihi"].ToString()
                });
            }
            return list;
        }

        public void Insert(Dokuman dokuman)
        {
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();
            var cmd = new SQLiteCommand("INSERT INTO Dokumanlar (Ad, Tip, IletilmeTarihi) VALUES (@ad, @tip, @tarih)", con);
            cmd.Parameters.AddWithValue("@ad", dokuman.Ad);
            cmd.Parameters.AddWithValue("@tip", dokuman.Tip);
            cmd.Parameters.AddWithValue("@tarih", dokuman.IletilmeTarihi);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();
            var cmd = new SQLiteCommand("DELETE FROM Dokumanlar WHERE Id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}

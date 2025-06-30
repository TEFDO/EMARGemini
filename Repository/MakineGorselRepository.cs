using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using EMAR.Models;

namespace EMAR.Repositories
{
    public class MakineGorselRepository
    {
        private readonly string _dbPath;

        public MakineGorselRepository(string dbPath)
        {
            _dbPath = dbPath;
            string dir = System.IO.Path.GetDirectoryName(_dbPath);
            if (!System.IO.Directory.Exists(dir))
                System.IO.Directory.CreateDirectory(dir);

            // --- Dosya yoksa, oluştur! ---
            if (!System.IO.File.Exists(_dbPath))
            {
                System.Data.SQLite.SQLiteConnection.CreateFile(_dbPath);
                // Tabloları oluştur (ilk kez açarken)
                using var con = new SQLiteConnection($"Data Source={_dbPath}");
                con.Open();
                var cmd = new SQLiteCommand(@"
            CREATE TABLE IF NOT EXISTS MakineGorselleri (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                DosyaYolu TEXT
            );", con);
                cmd.ExecuteNonQuery();
            }
            else
            {
                // Varsa tabloyu kontrol et
                EnsureTable();
            }
        }

        public bool Exists(string relativePath)
        {
            using (var con = new SQLiteConnection($"Data Source={_dbPath}"))
            {
                con.Open();
                using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM MakineGorselleri WHERE DosyaYolu = @yol", con))
                {
                    cmd.Parameters.AddWithValue("@yol", relativePath);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public void EnsureTable()
        {
            string dir = System.IO.Path.GetDirectoryName(_dbPath);
            if (!System.IO.Directory.Exists(dir))
                System.IO.Directory.CreateDirectory(dir);

            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();
            var cmd = new SQLiteCommand(@"
        CREATE TABLE IF NOT EXISTS MakineGorselleri (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            DosyaYolu TEXT
        );", con);
            cmd.ExecuteNonQuery();
        }


        public List<MakineGorsel> GetAll()
        {
            var list = new List<MakineGorsel>();
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();
            var cmd = new SQLiteCommand("SELECT Id, DosyaYolu FROM MakineGorselleri ORDER BY Id", con);
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(new MakineGorsel
                {
                    Id = rdr.GetInt32(0),
                    DosyaYolu = rdr["DosyaYolu"].ToString()
                });
            }
            return list;
        }

        public void SaveAll(List<MakineGorsel> gorseller)
        {
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();

            using var tran = con.BeginTransaction();
            new SQLiteCommand("DELETE FROM MakineGorselleri", con, tran).ExecuteNonQuery();

            foreach (var g in gorseller)
            {
                var cmd = new SQLiteCommand("INSERT INTO MakineGorselleri (DosyaYolu) VALUES (@p)", con, tran);
                cmd.Parameters.AddWithValue("@p", g.DosyaYolu);
                cmd.ExecuteNonQuery();
            }

            tran.Commit();
        }

        public void DeleteByPath(string path)
        {
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();
            var cmd = new SQLiteCommand("DELETE FROM MakineGorselleri WHERE DosyaYolu = @path", con);
            cmd.Parameters.AddWithValue("@path", path);
            cmd.ExecuteNonQuery();
        }

        public void ClearAll()
        {
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();
            new SQLiteCommand("DELETE FROM MakineGorselleri", con).ExecuteNonQuery();
        }

        public void InsertBulk(List<MakineGorsel> gorseller)
        {
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();

            using var tran = con.BeginTransaction();

            foreach (var g in gorseller)
            {
                var cmd = new SQLiteCommand("INSERT INTO MakineGorselleri (DosyaYolu) VALUES (@path)", con, tran);
                cmd.Parameters.AddWithValue("@path", g.DosyaYolu);
                cmd.ExecuteNonQuery();
            }

            tran.Commit();
        }

        public void Add(MakineGorsel gorsel)
        {
            using var con = new SQLiteConnection($"Data Source={_dbPath}");
            con.Open();
            var cmd = new SQLiteCommand("INSERT INTO MakineGorselleri (DosyaYolu) VALUES (@p)", con);
            cmd.Parameters.AddWithValue("@p", gorsel.DosyaYolu);
            cmd.ExecuteNonQuery();
        }
    }
}

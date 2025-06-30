using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using EMAR.Models;
using System.IO;
namespace EMAR.Repository
{
    public static class TextEditorRepository
    {
        public static void Kaydet(string dbYolu, TextEditorData model)
        {
            if (string.IsNullOrWhiteSpace(dbYolu))
            {
                throw new ArgumentException("Veritabanı yolu boş! (Parameter 'dbYolu')", nameof(dbYolu));
            }
            if (!File.Exists(dbYolu))
                SQLiteConnection.CreateFile(dbYolu);
            using var con = new SQLiteConnection($"Data Source={dbYolu}");
            con.Open();

            // Tablonun olup olmadığını kontrol et
            var cmdCreate = new SQLiteCommand(@"
                CREATE TABLE IF NOT EXISTS TextEditorIcerikleri (
                    Id INTEGER,
                    Alan TEXT,
                    Icerik TEXT,
                    PRIMARY KEY (Id, Alan)
                );", con);
            cmdCreate.ExecuteNonQuery();

            var cmd = new SQLiteCommand(@"
                INSERT OR REPLACE INTO TextEditorIcerikleri (Id, Alan, Icerik) 
                VALUES (@id, @alan, @icerik);", con);

            cmd.Parameters.AddWithValue("@id", model.Id);
            cmd.Parameters.AddWithValue("@alan", model.Alan);
            cmd.Parameters.AddWithValue("@icerik", model.Icerik);
            cmd.ExecuteNonQuery();
        }

        public static string Getir(string dbYolu, int id, string alan)
        {
            using var con = new SQLiteConnection($"Data Source={dbYolu}");
            con.Open();

            var cmd = new SQLiteCommand("SELECT Icerik FROM TextEditorIcerikleri WHERE Id = @id AND Alan = @alan", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@alan", alan);
            var sonuc = cmd.ExecuteScalar();
            return sonuc?.ToString();
        }
    }
}
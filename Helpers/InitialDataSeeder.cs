using System;
using System.Data.SQLite;

public static class InitialDataSeeder
{
    //public static void SeedAllDefaults(string dbPath)
    //{
    //    using var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;");
    //    conn.Open();

    //    InsertIfNotExists(conn, "DokumanTipleri", "Tip", new[] {
    //        "Teknik Çizim", "CE Belgesi", "Kullanım Kılavuzu", "Elektrik Şeması", "Hidrolik Devre", "Pnömatik Devre"
    //    });

    //    InsertIfNotExists(conn, "ElektrikKaynaklari", "Deger", new[] {
    //        "AC 400V", "DC 24V", "AC 230V", "DC 12V"
    //    });

    //    InsertIfNotExists(conn, "PnomatikKaynaklari", "Deger", new[] {
    //        "6 bar", "8 bar"
    //    });

    //    InsertIfNotExists(conn, "HidrolikKaynaklari", "Deger", new[] {
    //        "150 bar", "200 bar"
    //    });

    //    InsertIfNotExists(conn, "MakineTipleri", "Tip", new[] {
    //        "Pres", "Konveyör", "Robot Kol", "Ambalaj Makinesi", "Test Cihazı"
    //    });

    //    InsertIfNotExists(conn, "Sertifikasyonlar", "Kod", new[] {
    //        "CE", "ISO 13849-1", "IEC 62061", "EN ISO 12100", "ISO 4413", "ISO 4414"
    //    });

    //    InsertIfNotExists(conn, "KullaniciSeviyeleri", "Seviye", new[] {
    //        "Operatör", "Bakımcı", "Mühendis", "Yönetici"
    //    });

    //    InsertIfNotExists(conn, "HizmetKodlari", "Kod", new[] {
    //        "RA-SC", "MRA", "Diğer"
    //    });

    //    InsertIfNotExists(conn, "RaporTurleri", "Kod", new[] {
    //        "RA-SC", "MRA"
    //    });

    //    InsertIfNotExists(conn, "Tehlikeler", "Kod", new[] {
    //        "T1", "T2", "T3", "T4", "T5"
    //    });
    //}

    private static void InsertIfNotExists(SQLiteConnection conn, string table, string column, string[] values)
    {
        foreach (var val in values)
        {
            var cmd = new SQLiteCommand($"INSERT OR IGNORE INTO {table} ({column}) VALUES (@value);", conn);
            cmd.Parameters.AddWithValue("@value", val);
            cmd.ExecuteNonQuery();
        }
    }
}

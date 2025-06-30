using EMAR.Models;
using System;
using System.Data.SQLite;

public class GenelBilgilendirmeRepository
{
    private readonly string _dbPath;

    public GenelBilgilendirmeRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    public void EnsureTable()
    {
        using var con = new SQLiteConnection($"Data Source={_dbPath}");
        con.Open();
        var sql = @"CREATE TABLE IF NOT EXISTS GenelBilgilendirme (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    RiskId INTEGER,
    TehlikeTipi TEXT,
    GorevAsamasi TEXT,
    TehlikeHedefi TEXT,
    S TEXT,
    F TEXT,
    P TEXT,
    DPH REAL,
    LO REAL,
    PA REAL,
    FE REAL,
    Gorsel TEXT,
    Piktogram TEXT,
    TehlikeTanim TEXT,
    Bakim INTEGER DEFAULT 0,
    Temizlik INTEGER DEFAULT 0,
    Operator INTEGER DEFAULT 0,
    Ziyaretci INTEGER DEFAULT 0,
    HRN TEXT,
    HRNSeviye TEXT,
    PLg TEXT
);";

        using var cmd = new SQLiteCommand(sql, con);
        cmd.ExecuteNonQuery();
        //// Alanlar yoksa ekle (eski tabloyu güncellemek için)
        //try
        //{
        //    using var alter1 = new SQLiteCommand("ALTER TABLE GenelBilgilendirme ADD COLUMN HRN TEXT;", con);
        //    alter1.ExecuteNonQuery();
        //}
        //catch { }

        //try
        //{
        //    using var alter2 = new SQLiteCommand("ALTER TABLE GenelBilgilendirme ADD COLUMN HRNSeviye TEXT;", con);
        //    alter2.ExecuteNonQuery();
        //}
        //catch { }

        //try
        //{
        //    using var alter3 = new SQLiteCommand("ALTER TABLE GenelBilgilendirme ADD COLUMN PLg TEXT;", con);
        //    alter3.ExecuteNonQuery();
        //}
        //catch { }

    }


    public GenelBilgilendirme GetByRiskId(int riskId)
    {
        using var con = new SQLiteConnection($"Data Source={_dbPath}");
        con.Open();
        var cmd = new SQLiteCommand("SELECT * FROM GenelBilgilendirme WHERE RiskId = @r", con);
        cmd.Parameters.AddWithValue("@r", riskId);

        using var rdr = cmd.ExecuteReader();
        if (rdr.Read())
        {
            return new GenelBilgilendirme
            {
                Id = rdr.GetInt32(0),
                RiskId = rdr.GetInt32(1),
                TehlikeTipi = rdr["TehlikeTipi"]?.ToString(),
                GorevAsamasi = rdr["GorevAsamasi"]?.ToString(),
                TehlikeHedefi = rdr["TehlikeHedefi"]?.ToString(),
                S = rdr["S"]?.ToString(),
                F = rdr["F"]?.ToString(),
                P = rdr["P"]?.ToString(),
                DPH = Convert.ToDouble(rdr["DPH"]),
                LO = Convert.ToDouble(rdr["LO"]),
                PA = Convert.ToDouble(rdr["PA"]),
                FE = Convert.ToDouble(rdr["FE"]),
                Gorsel = rdr["Gorsel"]?.ToString(),
                Piktogram = rdr["Piktogram"]?.ToString(),
                TehlikeTanim = rdr["TehlikeTanim"]?.ToString(),
                Bakim = Convert.ToInt32(rdr["Bakim"]) == 1,
                Temizlik = Convert.ToInt32(rdr["Temizlik"]) == 1,
                Operator = Convert.ToInt32(rdr["Operator"]) == 1,
                Ziyaretci = Convert.ToInt32(rdr["Ziyaretci"]) == 1,
                HRN = rdr["HRN"]?.ToString(),
                HRNSeviye = rdr["HRNSeviye"]?.ToString(),
                PLg = rdr["PLg"]?.ToString()
            };

        }

        return null;
    }

    public void Save(GenelBilgilendirme veri)
    {
        using var con = new SQLiteConnection($"Data Source={_dbPath}");
        con.Open();
        var cmd = new SQLiteCommand(@"
INSERT OR REPLACE INTO GenelBilgilendirme
(Id, RiskId, TehlikeTipi, GorevAsamasi, TehlikeHedefi, S, F, P, DPH, LO, PA, FE,
 Gorsel, Piktogram, TehlikeTanim, Bakim, Temizlik, Operator, Ziyaretci,
 HRN, HRNSeviye, PLg)
VALUES (
    (SELECT Id FROM GenelBilgilendirme WHERE RiskId = @r),
    @r, @tt, @ga, @th, @s, @f, @p, @dph, @lo, @pa, @fe,
    @g, @pk, @tanim, @bakim, @temizlik, @operator, @ziyaretci,
    @hrn, @hrnseviye, @plg);", con);

        cmd.Parameters.AddWithValue("@r", veri.RiskId);
        cmd.Parameters.AddWithValue("@tt", veri.TehlikeTipi ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@ga", veri.GorevAsamasi ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@th", veri.TehlikeHedefi ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@s", veri.S ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@f", veri.F ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@p", veri.P ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@dph", veri.DPH);
        cmd.Parameters.AddWithValue("@lo", veri.LO);
        cmd.Parameters.AddWithValue("@pa", veri.PA);
        cmd.Parameters.AddWithValue("@fe", veri.FE);
        cmd.Parameters.AddWithValue("@g", veri.Gorsel ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@pk", veri.Piktogram ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@tanim", veri.TehlikeTanim ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@bakim", veri.Bakim ? 1 : 0);
        cmd.Parameters.AddWithValue("@temizlik", veri.Temizlik ? 1 : 0);
        cmd.Parameters.AddWithValue("@operator", veri.Operator ? 1 : 0);
        cmd.Parameters.AddWithValue("@ziyaretci", veri.Ziyaretci ? 1 : 0);
        // EKLE
        cmd.Parameters.AddWithValue("@hrn", veri.HRN ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@hrnseviye", veri.HRNSeviye ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@plg", veri.PLg ?? (object)DBNull.Value);


        cmd.ExecuteNonQuery();
    }

}

using System;
using System.Data.SQLite;

public static class DatabaseSchemaCreator
{
    public static void InitializeRaporDatabase(string dbPath)
    {
        using (var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
        {
            connection.Open();

            var commands = new string[]
            {
                
                @"CREATE TABLE IF NOT EXISTS Musteriler (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Ad TEXT NOT NULL,
                Adres TEXT,
                Logo BLOB
                );",

            // ✅ Güncellenmiş Raporlar tablosu – yeni alanlar eklendi
            @"CREATE TABLE IF NOT EXISTS Raporlar (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ProjeId INTEGER,
                    MakineId INTEGER,
                    RaporTuruKod TEXT,
                    RaporKodu TEXT UNIQUE,
                    Tarih TEXT,
                    SiraNo INTEGER          -- <<< EKLENDİ
                    //MakineAdi TEXT,          -- <<< EKLENDİ
                   // ProjeKodu TEXT           -- <<< EKLENDİ
                );",

                // Projeler
                @"CREATE TABLE IF NOT EXISTS Projeler (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    MusteriId INTEGER,
                    Ad TEXT,
                    ProjeKodu TEXT UNIQUE,
                    HizmetKodu TEXT,
                    Tarih TEXT,
                    Aciklama TEXT
                );",

                // Proje-Makine bağlantı tablosu
                @"CREATE TABLE IF NOT EXISTS ProjeMakineleri (
                    ProjeId INTEGER,
                    MakineId INTEGER,
                    PRIMARY KEY (ProjeId, MakineId)
                );",

                // Makineler
                @"CREATE TABLE IF NOT EXISTS Makineler (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    MusteriId INTEGER,
                    ProjeId INTEGER,
                    Ad TEXT,
                    Name TEXT,
                    Imalatci TEXT,
                    SeriNo TEXT,
                    Tipi TEXT,
                    UretimYili TEXT,
                    Sertifikasyon TEXT,
                    Elektrik TEXT,
                    Pnomatik TEXT,
                    Hidrolik TEXT,
                    DigerEnerjiKaynaklari TEXT,
                    KullanimAmaci TEXT,
                    KullaniciSeviyesi TEXT,
                    PersonelTipi TEXT,
                    BakimSikligi TEXT,
                    MakineOlculeri TEXT,
                    ZamanLimitleri TEXT
                );",

                // Genel Bilgi Tabloları
                @"CREATE TABLE IF NOT EXISTS Genel (
                    Alan TEXT PRIMARY KEY,
                    Deger TEXT
                );",

                @"CREATE TABLE IF NOT EXISTS Metadata (
                    Alan TEXT PRIMARY KEY,
                    Deger TEXT
                );",

                // Görseller
                @"CREATE TABLE IF NOT EXISTS MakineGorselleri (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    DosyaYolu TEXT
                );",

                // Temsilciler
                @"CREATE TABLE IF NOT EXISTS Temsilciler (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Isim TEXT,
                    Firma TEXT,
                    Gorev TEXT
                );",

                // Revizyonlar
                @"CREATE TABLE IF NOT EXISTS Revizyonlar (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Revizyon TEXT,
                    Tarih TEXT,
                    Duzenleyen TEXT,
                    Aciklama TEXT
                );",

                // Dokümanlar
                @"CREATE TABLE IF NOT EXISTS Dokumanlar (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Ad TEXT,
                    Tip TEXT,
                    IletilmeTarihi TEXT
                );",

                // Kontrol Sistemi
                @"CREATE TABLE IF NOT EXISTS KontrolSistemi (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Genel TEXT,
                    Giris TEXT,
                    Mantik TEXT,
                    Cikis TEXT
                );",

                // Riskler
                @"CREATE TABLE IF NOT EXISTS Riskler (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    BolgeId INTEGER,
                    RiskSira INTEGER,
                    Baslik TEXT
                );",

                @"CREATE TABLE IF NOT EXISTS TextEditorIcerikleri (
                Id INTEGER,
                Alan TEXT,
                Icerik TEXT,
                PRIMARY KEY (Id, Alan)
                ); ",

                // Bölge Genel
                @"CREATE TABLE IF NOT EXISTS BolgeGenel (
                    BolgeId INTEGER PRIMARY KEY,
                    Aciklama TEXT,
                    Notlar TEXT,
                    Gorsel TEXT
                );",

                // Alt başlıklar
                @"CREATE TABLE IF NOT EXISTS GenelBilgilendirme (
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
);
",

                @"CREATE TABLE IF NOT EXISTS RiskAzaltimi (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    RiskId INTEGER,
    Olasilik TEXT,         -- Çoğunlukla DOUBLE, ama ""N/A"" olduğu için TEXT kullan
    KazaOlma TEXT,         -- Aynı şekilde
    Kacinma TEXT,          -- Aynı şekilde
    MaruzKalma TEXT,       -- Aynı şekilde
    HRN TEXT,              -- Aynı şekilde
    HRNSeviye TEXT,
    OnlemlerRTF TEXT,      -- RTF metni saklanacak
    ArtikRiskRTF TEXT      -- RTF metni saklanacak
);
",

                @"CREATE TABLE IF NOT EXISTS MevcutDurum (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    RiskId INTEGER,
    Metin TEXT,
    Gorsel1 TEXT,            -- Artık JSON formatında: Çoklu görselin path, başlık, vs. bilgisi
    StandartlarJson TEXT
);
",

                @"CREATE TABLE IF NOT EXISTS ModifikasyonIcerik (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    RiskId INTEGER NOT NULL,
                    Tip TEXT,
                    Icerik TEXT,
                    Siralama INTEGER
                );",

                @"CREATE TABLE IF NOT EXISTS Bolgeler (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    BolgeNo INTEGER NOT NULL,
                    Baslik TEXT NOT NULL,
                    Renk TEXT,
                    Sira INTEGER
                );",

                @"CREATE TABLE IF NOT EXISTS RiskAltBasliklar (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    RiskId INTEGER NOT NULL,
                    Baslik TEXT NOT NULL,
                    Turu TEXT,
                    Metin TEXT,
                    Gorsel1 TEXT,
                    Gorsel2 TEXT,
                    Sira INTEGER
                );",

                @"CREATE TABLE IF NOT EXISTS Tehlikeler (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Kod TEXT UNIQUE,
                    Tanimi TEXT
                );",

                @"CREATE TABLE IF NOT EXISTS Standartlar (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Kodu TEXT UNIQUE,
                    Adi TEXT,
                    Aciklama TEXT,
                    Kategori TEXT
                );",

                @"CREATE TABLE IF NOT EXISTS StandartReferanslar (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    RiskId INTEGER NOT NULL,
                    StandartId INTEGER NOT NULL
                );"
            };

            foreach (var sql in commands)
            {
                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

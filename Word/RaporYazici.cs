using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using EMAR.Helpers;
using EMAR.Models;
using EMAR.Repositories;
using EMAR.Repository;
using EMAR.Word.Genel;
using EMAR.Word.Tehlike;
using OpenXmlPowerTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using W = DocumentFormat.OpenXml.Wordprocessing;

namespace EMAR.Word
{
    public static class RaporYazici
    {
        public static void Olustur(Rapor rapor, string hedefYol)
        {
            string tempDir = "Temp";
            Directory.CreateDirectory(tempDir);

            LogRAM("Başlangıç");

            var bolumDosyalari = new List<string>();

            
            // 1. Kapak
            string kapakYol = Path.Combine(tempDir, "KapakDoldurulmus.docx");
            Kapak.Olustur(rapor, kapakYol); // Kendi içinde dosyayı açar/kapatır
            bolumDosyalari.Add(kapakYol);
            LogRAM("Kapak hazırlandı");

            // 2. Revizyon Tablosu
            string dbYolu = RaporKlasorYardimcisi.GetDbYoluFromRaporKodu(rapor.RaporKodu);
            if (string.IsNullOrEmpty(dbYolu) || !File.Exists(dbYolu))
                throw new FileNotFoundException("Raporun detay veritabanı dosyası bulunamadı!", dbYolu);

            string revizyonYol = Path.Combine(tempDir, "RevizyonTablosuDoldurulmus.docx");
            var revizyonlar = new RevizyonRepository(dbYolu).GetAll();
            RevizyonTablosu.Olustur(
                revizyonlar.OrderByDescending(r => r.Revizyon)
                    .Select(r => new[] { r.Revizyon, r.Tarih, r.Duzenleyen, r.Aciklama }).ToList(),
                revizyonYol,
                "Sablonlar/RevizyonTablosu.docx"
            );
            bolumDosyalari.Add(revizyonYol);
            LogRAM("Revizyon Tablosu hazırlandı");
            
            bolumDosyalari.Add("Sablonlar/Template.docx");

            // 5. Makine Görselleri
            string makineGorselYol = Path.Combine(tempDir, "MakineGorselleri.docx");
            CreateEmptyDocx(makineGorselYol);
            using (var doc = WordprocessingDocument.Open(makineGorselYol, true))
            {
                MakineGorselleriWordGridExporter.ExportMakineGorselleriToWord(doc, dbYolu, Path.GetDirectoryName(dbYolu));
                doc.MainDocumentPart.Document.Save();
            }
            bolumDosyalari.Add(makineGorselYol);
            LogRAM("Makine görselleri eklendi");

            // 3. İncelenen Dökümanlar
            string dokumanlarYol = Path.Combine(tempDir, "IncelenenDokumanlarDoldurulmus.docx");
            IncelenenDokumanlarTablosu.Olustur(
                dbYolu,
                "Sablonlar/IncelenenDokumanlar.docx",
                dokumanlarYol,
                new Dictionary<string, string>
                {
                    { "@@Tarih@@", rapor.Tarih },
                    { "@@Firma@@", rapor.MusteriAdi },
                    { "@@MakineAdi@@", rapor.MakineAdi }
                }
            );
            bolumDosyalari.Add(dokumanlarYol);
            LogRAM("İncelenen Dökümanlar hazırlandı");


           // 6. Otomatik tablolar (temsilci, makine bilgileri, limitler, vs.)
            string otomatikTablolarYol = Path.Combine(tempDir, "OtomatikTablolar.docx");
            CreateEmptyDocx(otomatikTablolarYol);
            using (var doc = WordprocessingDocument.Open(otomatikTablolarYol, true))
            {
                var body = doc.MainDocumentPart.Document.Body;
                var makine = MakineRepository.Getir(rapor.MakineId);

                var temsilciler = new TemsilciRepository(dbYolu).GetAll();
                if (temsilciler.Count > 0)
                {
                    body.AppendChild(TemsilciTablosu.Olustur(temsilciler));
                    body.AppendChild(new W.Paragraph());
                }
                if (makine != null)
                {
                    body.AppendChild(MakineBilgileriTablosu.Olustur(makine));
                    body.AppendChild(new W.Paragraph());
                    body.AppendChild(MakineLimitleriTablosu.Olustur(makine, 5000, 144, 120));
                    body.AppendChild(new W.Paragraph());
                    body.AppendChild(EnerjiKaynaklariTablosu.Olustur(makine));
                    body.AppendChild(new W.Paragraph());
                }
                body.AppendChild(MakineKontrolSistemiTablosu.Olustur(dbYolu));
                body.AppendChild(new W.Paragraph());
                //body.AppendChild(new W.Paragraph(
                //    new W.Run(new W.Break() { Type = W.BreakValues.Page })));
                doc.MainDocumentPart.Document.Save();
            }
            bolumDosyalari.Add(otomatikTablolarYol);
            LogRAM("Otomatik tablolar eklendi");

            bolumDosyalari.Add("Sablonlar/Metod.docx");
            // 7. Bölge ve Riskler
            string[] bolgeSablonYollari = {
                "Sablonlar/Bolge1.docx",
                "Sablonlar/Bolge2.docx",
                "Sablonlar/Bolge3.docx",
                "Sablonlar/Bolge4.docx"
            };
            for (int bolgeId = 1; bolgeId <= 4; bolgeId++)
            {
                string bolgePath = bolgeSablonYollari[bolgeId - 1];
                bolumDosyalari.Add(bolgePath);

                var riskListesi = RiskRepository.Listele(dbYolu, bolgeId);
                foreach (var risk in riskListesi)
                {
                    var riskDocPaths = GetRiskDocPaths(risk, dbYolu, tempDir);
                    bolumDosyalari.AddRange(riskDocPaths);
                    LogRAM($"Bölge {bolgeId} - Risk {risk.Id} ({risk.Baslik}) eklendi");
                }
            }
            bolumDosyalari.Add("Sablonlar/SonSayfa.docx");
            // 8. RAM dostu AltChunk birleştirme (asıl final çıktı!)
            LogRAM("AltChunk ile birleştirme başlıyor");
            AltChunkIleBirleştir(bolumDosyalari, hedefYol, true);
            LogRAM("AltChunk ile birleştirme bitti (Rapor tamamlandı)");

            // 9. Temizlik
            //foreach (var f in Directory.GetFiles(tempDir)) TryDelete(f);
            LogRAM("Temp dosyalar silindi (İşlem bitti)");
        }

        private static void AltChunkIleBirleştir(IEnumerable<string> bolumDosyalari, string hedefDosya, bool herParcaSonraSayfaSonu)
        {
            if (File.Exists(hedefDosya))
                File.Delete(hedefDosya);

            using (var mainDoc = WordprocessingDocument.Create(hedefDosya, WordprocessingDocumentType.Document))
            {
                var mainPart = mainDoc.AddMainDocumentPart();
                mainPart.Document = new W.Document(new W.Body());
                int chunkId = 1;
                foreach (string partFile in bolumDosyalari)
                {
                    if (!File.Exists(partFile))
                        continue; // Hata verme, geçici dosya eksikse atla

                    string altChunkId = $"AltChunkId{chunkId++}";
                    var altPart = mainPart.AddAlternativeFormatImportPart(
                        AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                    using (FileStream fs = File.OpenRead(partFile))
                    {
                        altPart.FeedData(fs);
                    }
                    mainPart.Document.Body.AppendChild(new W.AltChunk { Id = altChunkId });

                    if (herParcaSonraSayfaSonu)
                    {
                        mainPart.Document.Body.AppendChild(
                            new W.Paragraph(
                                new W.Run(
                                    new W.Break() { Type = W.BreakValues.Page }
                                )));
                    }
                }
                // ===> BURADA SECTIONPROPERTIES EKLE <===
                // Bu ayarlar senin şablonunda neyse orada da aynı olsun
                var sectionProps = new SectionProperties(
                    new PageMargin
                    {
                        Top = 1418,      // 2,5 cm
                        Bottom = 1418,
                        Left = 1418,
                        Right = 1418,
                        Header = 0,      // üst bilgi boşluğu 0
                        Footer = 0       // alt bilgi boşluğu 0
                    }
                );
                mainPart.Document.Body.Append(sectionProps);

                mainPart.Document.Save();
            }
        }

        private static void CreateEmptyDocx(string filePath)
        {
            using (var doc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            {
                var mainPart = doc.AddMainDocumentPart();
                mainPart.Document = new W.Document(new W.Body());
                mainPart.Document.Save();
            }
        }

        private static void TryDelete(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return;
            var tempDir = Path.GetFullPath("Temp");
            var fullPath = Path.GetFullPath(filePath);
            if (fullPath.StartsWith(tempDir, StringComparison.OrdinalIgnoreCase))
            {
                try { if (File.Exists(fullPath)) File.Delete(fullPath); } catch { }
            }
        }

        private static void LogRAM(string message)
        {
            long managed = GC.GetTotalMemory(forceFullCollection: true);
            long process = System.Diagnostics.Process.GetCurrentProcess().WorkingSet64;
            string log = $"{DateTime.Now:HH:mm:ss} [{message}] Managed: {managed / (1024 * 1024)} MB | Process: {process / (1024 * 1024)} MB";
            Console.WriteLine(log);
            File.AppendAllText("ram_log.txt", log + Environment.NewLine);
        }

        private static List<string> GetRiskDocPaths(Risk risk, string dbYolu, string tempDir)
        {
            var riskDocPaths = new List<string>();
            var genel = new GenelBilgilendirmeRepository(dbYolu).GetByRiskId(risk.Id);
            var azaltim = new RiskAzaltimiRepository(dbYolu).GetByRiskId(risk.Id);
            string genelSablonYol = "Sablonlar/TehlikeTanimi.docx";
            string riskGenelYol = Path.Combine(tempDir, $"GenelBilgilendirme_{risk.BolgeId}_{risk.RiskSira}.docx");
            string pictogramPath = null, makineGorselPath = null;
            if (genel != null && !string.IsNullOrWhiteSpace(genel.Piktogram))
                pictogramPath = Path.Combine(Path.GetDirectoryName(dbYolu), genel.Piktogram.Replace("/", "\\"));
            if (genel != null && !string.IsNullOrWhiteSpace(genel.Gorsel))
                makineGorselPath = Path.Combine(Path.GetDirectoryName(dbYolu), genel.Gorsel.Replace("/", "\\"));

            GenelBilgilendirmeWordExporter.Olustur(
                risk, genel, azaltim, genelSablonYol, riskGenelYol,
                pictogramPath: pictogramPath, makineGorselPath: makineGorselPath
            );
            riskDocPaths.Add(riskGenelYol);

            var mevcutDurum = new MevcutDurumRepository(dbYolu).GetByRiskId(risk.Id);
            if (mevcutDurum != null)
            {
                string mevcutDurumSablonYol = "Sablonlar/MevcutDurum.docx";
                string mevcutDurumYol = Path.Combine(tempDir, $"MevcutDurum_{risk.BolgeId}_{risk.RiskSira}.docx");
                MevcutDurumWordExporter.Olustur(risk, mevcutDurum, mevcutDurumSablonYol, mevcutDurumYol);
                riskDocPaths.Add(mevcutDurumYol);
            }

            var gorselList = GorselYerlesimRepository.Load(dbYolu, risk.Id, "MevcutDurum");
            if (gorselList != null && gorselList.Count > 0)
            {
                string gorselCiktiYolu = Path.Combine(tempDir, $"MevcutDurumGorselleri_{risk.BolgeId}_{risk.RiskSira}.docx");
                MevcutDurumGorselWordExporter.Olustur(gorselCiktiYolu, gorselList, Path.GetDirectoryName(dbYolu));
                riskDocPaths.Add(gorselCiktiYolu);
            }

            var gorselList2 = GorselYerlesimRepository.Load(dbYolu, risk.Id, "MevcutDurum2");
            if (gorselList2 != null && gorselList2.Count > 0)
            {
                string gorselCiktiYolu2 = Path.Combine(tempDir, $"MevcutDurumEkGorselleri_{risk.BolgeId}_{risk.RiskSira}.docx");
                MevcutDurumGorselWordExporter.Olustur(gorselCiktiYolu2, gorselList2, Path.GetDirectoryName(dbYolu));
                riskDocPaths.Add(gorselCiktiYolu2);
            }

            if (mevcutDurum != null && !string.IsNullOrWhiteSpace(mevcutDurum.StandartlarJson))
            {
                string pageBreakPath = "Sablonlar/PageBreak.docx";
                riskDocPaths.Add(pageBreakPath);

                var seciliStandartlar = StandartlarSerializer.Deserialize(mevcutDurum.StandartlarJson);
                string referansStandartlarPath = Path.Combine(tempDir, $"ReferansAlinanStandartlar_{risk.BolgeId}_{risk.RiskSira}.docx");
                ReferansAlinanStandartlarWordExporter.Olustur(referansStandartlarPath, seciliStandartlar);
                riskDocPaths.Add(referansStandartlarPath);
            }

            var modifikasyonlar = new ModifikasyonIcerikRepository(dbYolu).GetByRiskId(risk.Id);
            if (modifikasyonlar != null && modifikasyonlar.Count > 0)
            {
                string pageBreakPath = "Sablonlar/PageBreak.docx";
                riskDocPaths.Add(pageBreakPath);
                string modifikasyonCiktiYolu = Path.Combine(tempDir, $"Modifikasyon_{risk.BolgeId}_{risk.RiskSira}.docx");
                ModifikasyonAlanWordExporter.Olustur(
                    modifikasyonCiktiYolu, modifikasyonlar, Path.GetDirectoryName(dbYolu), "Modifikasyon Önerisi");
                riskDocPaths.Add(modifikasyonCiktiYolu);
            }

            return riskDocPaths;
        }
    }
}

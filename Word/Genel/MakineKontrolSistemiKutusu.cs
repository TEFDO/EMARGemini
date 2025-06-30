using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using System.Data.SQLite;
using System.Collections.Generic;

namespace EMAR.Word.Genel
{
    internal static class MakineKontrolSistemiTablosu
    {
        public static Table Olustur(string dbYolu, int tabloGenislik = 5000, int padding = 144)
        {
            var data = GetKontrolSistemiData(dbYolu);
            var table = new Table();

            table.AppendChild(new TableProperties(
                new TableWidth { Width = tabloGenislik.ToString(), Type = TableWidthUnitValues.Pct },
                new TableBorders(
                    new TopBorder { Val = BorderValues.Single, Size = 6 },
                    new BottomBorder { Val = BorderValues.Single, Size = 6 },
                    new LeftBorder { Val = BorderValues.Single, Size = 6 },
                    new RightBorder { Val = BorderValues.Single, Size = 6 },
                    new InsideHorizontalBorder { Val = BorderValues.Single, Size = 6 },
                    new InsideVerticalBorder { Val = BorderValues.Single, Size = 6 }
                ),
                new TableCellMarginDefault(
                    new TopMargin { Width = padding.ToString(), Type = TableWidthUnitValues.Dxa },
                    new BottomMargin { Width = padding.ToString(), Type = TableWidthUnitValues.Dxa },
                    new LeftMargin { Width = padding.ToString(), Type = TableWidthUnitValues.Dxa },
                    new RightMargin { Width = padding.ToString(), Type = TableWidthUnitValues.Dxa }
                )
            ));

            // Başlık
            table.AppendChild(new TableRow(
                new TableCell(new Paragraph(
                    new ParagraphProperties(new Justification { Val = JustificationValues.Center }, new SpacingBetweenLines { Before = 120.ToString(), After = 120.ToString() }),
                    new Run(new RunProperties(new Bold(), new FontSize { Val = "28" }), new Text("MAKİNE KONTROL SİSTEMİ"))
                ))
                {
                    TableCellProperties = new TableCellProperties(
                        new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = tabloGenislik.ToString() },
                        new Shading { Fill = "B4C6E7" }
                    )
                }
            ));

            // Alt satırlar
            table.AppendChild(new TableRow(
                new TableCell(
                    CreateParagraphs(data)
                )
                {
                    TableCellProperties = new TableCellProperties(
                        new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = tabloGenislik.ToString() }
                    )
                }
            ));

            return table;
        }

        private static OpenXmlElement[] CreateParagraphs(KontrolSistemiData data)
        {
            var list = new List<OpenXmlElement>();

            if (!string.IsNullOrWhiteSpace(data?.GenelAciklama))
            {
                list.Add(new Paragraph(
                    new Run(new RunProperties(new FontSize { Val = "24" }), new Text(data.GenelAciklama))
                ));
            }

            if (!string.IsNullOrWhiteSpace(data?.GirisKati))
            {
                list.Add(new Paragraph(
                    new Run(new RunProperties(new Bold(), new FontSize { Val = "24" }), new Text("Giriş katı; ") { Space = SpaceProcessingModeValues.Preserve }),
                    new Run(new RunProperties(new FontSize { Val = "24" }), new Text(data.GirisKati))
                ));
            }

            if (!string.IsNullOrWhiteSpace(data?.MantikKati))
            {
                list.Add(new Paragraph(
                    new Run(new RunProperties(new Bold(), new FontSize { Val = "24" }), new Text("Mantık katı; ") { Space = SpaceProcessingModeValues.Preserve }),
                    new Run(new RunProperties(new FontSize { Val = "24" }), new Text(data.MantikKati))
                ));
            }

            if (!string.IsNullOrWhiteSpace(data?.CikisKati))
            {
                list.Add(new Paragraph(
                    new Run(new RunProperties(new Bold(), new FontSize { Val = "24" }), new Text("Çıkış katı; ") { Space = SpaceProcessingModeValues.Preserve }),
                    new Run(new RunProperties(new FontSize { Val = "24" }), new Text(data.CikisKati))
                ));
            }

            // En az bir boş paragraf ekle (hiç veri yoksa)
            if (list.Count == 0)
            {
                list.Add(new Paragraph());
            }

            return list.ToArray();
        }


        private static KontrolSistemiData GetKontrolSistemiData(string dbYolu)
        {
            using (var con = new SQLiteConnection($"Data Source={dbYolu}"))
            {
                con.Open();
                using (var cmd = new SQLiteCommand("SELECT * FROM KontrolSistemi ORDER BY Id DESC LIMIT 1", con))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new KontrolSistemiData()
                        {
                            GenelAciklama = reader["Genel"].ToString(),
                            GirisKati = reader["Giris"].ToString(),
                            MantikKati = reader["Mantik"].ToString(),
                            CikisKati = reader["Cikis"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        private class KontrolSistemiData
        {
            public string GenelAciklama { get; set; }
            public string GirisKati { get; set; }
            public string MantikKati { get; set; }
            public string CikisKati { get; set; }
        }
    }
}

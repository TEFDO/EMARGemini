using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using EMAR.Models;

namespace EMAR.Word.Genel
{
    internal static class MakineBilgileriTablosu
    {
        public static Table Olustur(Makine makine, int tabloGenislik = 5000, int padding = 0, int satirBosluk = 0)
        {
            var table = new Table();

            // Tablo stil ve kenarlık ayarları
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

            // Başlık satırı
            var headerRow = new TableRow(
                new TableCell(new Paragraph(
                    new ParagraphProperties(new Justification { Val = JustificationValues.Center },
                        new SpacingBetweenLines { Before = 120.ToString(), After = 120.ToString() }),
                    new Run(
                        new RunProperties(new Bold(), new FontSize { Val = "28" }),
                        new Text("MAKİNE BİLGİLERİ")
                    )
                ))
                {
                    TableCellProperties = new TableCellProperties(
                        new GridSpan { Val = 2 },
                        new Shading { Fill = "B4C6E7" },
                        new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = tabloGenislik.ToString() }
                    )
                }
            );
            table.AppendChild(headerRow);

            // Satırlar
            table.AppendChild(CreateRow("Makinenin Adı", makine.Ad, tabloGenislik, satirBosluk));
            table.AppendChild(CreateRow("Üretici Adı", makine.Imalatci, tabloGenislik, satirBosluk));
            table.AppendChild(CreateRow("Seri No", makine.SeriNo, tabloGenislik, satirBosluk));
            table.AppendChild(CreateRow("Makine Tipi", makine.Tipi, tabloGenislik, satirBosluk));
            table.AppendChild(CreateRow("Üretim Yılı", makine.UretimYili.ToString(), tabloGenislik, satirBosluk));
            table.AppendChild(CreateRow("Makine Sertifikasyonu", makine.Sertifikasyon, tabloGenislik, satirBosluk));

            return table;
        }

        private static TableRow CreateRow(string sol, string sag, int tabloGenislik, int satirBosluk)
        {
            var solCell = new TableCell(new Paragraph(
                new ParagraphProperties(
                    new SpacingBetweenLines { Before = satirBosluk.ToString(), After = satirBosluk.ToString() }
                ),
                new Run(new RunProperties(new Bold(), new FontSize { Val = "26" }), new Text(sol))
            ))
            {
                TableCellProperties = new TableCellProperties(
                    new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = (tabloGenislik / 3).ToString() },
                    new Shading { Fill = "B4C6E7" }
                )
            };

            var sagCell = new TableCell(new Paragraph(
                new ParagraphProperties(
                    new SpacingBetweenLines { Before = satirBosluk.ToString(), After = satirBosluk.ToString() }
                ),
                new Run(new RunProperties(new FontSize { Val = "26" }), new Text(sag ?? ""))
            ))
            {
                TableCellProperties = new TableCellProperties(
                    new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = (tabloGenislik * 2 / 3).ToString() }
                )
            };

            return new TableRow(solCell, sagCell);
        }
    }
}

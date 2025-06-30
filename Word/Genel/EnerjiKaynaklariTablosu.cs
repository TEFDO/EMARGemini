using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using EMAR.Models;

namespace EMAR.Word.Genel
{
    internal static class EnerjiKaynaklariTablosu
    {
        public static Table Olustur(Makine makine, int tabloGenislik = 5000, int padding = 0)
        {
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
            var headerRow = new TableRow(
                new TableCell(new Paragraph(
                    new ParagraphProperties(new Justification { Val = JustificationValues.Center }, new SpacingBetweenLines { Before = 120.ToString(), After = 120.ToString() }),
                    new Run(new RunProperties(new Bold(), new FontSize { Val = "28" }), new Text("MAKİNENİN / HATTIN ENERJİ KAYNAKLARI"))
                ))
                {
                    TableCellProperties = new TableCellProperties(
                        new GridSpan { Val = 4 },
                        new Shading { Fill = "B4C6E7" },
                        new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = tabloGenislik.ToString() }
                    )
                }
            );
            table.AppendChild(headerRow);

            // Sütun başlıkları
            var columnRow = new TableRow(
                CreateHeaderCell("Elektriksel Enerji Kaynağı", tabloGenislik),
                CreateHeaderCell("Pnömatik Enerji Kaynağı", tabloGenislik),
                CreateHeaderCell("Hidrolik Enerji Kaynağı", tabloGenislik),
                CreateHeaderCell("Diğer Enerji Kaynakları", tabloGenislik)
            );
            table.AppendChild(columnRow);

            // Veri satırı
            var veriRow = new TableRow(
                CreateDataCell(makine.Elektrik, tabloGenislik),
                CreateDataCell(makine.Pnomatik, tabloGenislik),
                CreateDataCell(makine.Hidrolik, tabloGenislik),
                CreateDataCell(makine.DigerEnerjiKaynaklari, tabloGenislik)
            );
            table.AppendChild(veriRow);

            return table;
        }

        private static TableCell CreateHeaderCell(string text, int tabloGenislik)
        {
            return new TableCell(new Paragraph(
                new ParagraphProperties(new Justification { Val = JustificationValues.Center }),
                new Run(new RunProperties(new Bold(), new FontSize { Val = "24" }), new Text(text))
            ))
            {
                TableCellProperties = new TableCellProperties(
                    new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = (tabloGenislik / 4).ToString() }
                )
            };
        }

        private static TableCell CreateDataCell(string text, int tabloGenislik)
        {
            return new TableCell(new Paragraph(
                new ParagraphProperties(new Justification { Val = JustificationValues.Center }),
                new Run(new RunProperties(new FontSize { Val = "24" }),
                    new Text(string.IsNullOrWhiteSpace(text) ? "N/A" : text))
            ))
            {
                TableCellProperties = new TableCellProperties(
                    new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = (tabloGenislik / 4).ToString() }
                )
            };
        }
    }
}

using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using System.Collections.Generic;
using EMAR.Models;

namespace EMAR.Word.Genel
{
    internal static class TemsilciTablosu
    {
        /// <summary>
        /// Temsilci tablosu: İsim, Firma, Görev. Satır başına otomatik yükseklik ve uyumlu kenarlıklar.
        /// </summary>
        public static Table Olustur(List<Temsilci> temsilciler, int tabloGenislik = 5000, int padding = 0, int satirBosluk = 80)
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

            // --- Başlık satırı ---
            var headerRow = new TableRow(
                new TableCell(new Paragraph(
                    new ParagraphProperties(
                        new Justification { Val = JustificationValues.Center },
                        new SpacingBetweenLines { Before = "120", After = "120" }
                    ),
                    new Run(
                        new RunProperties(new Bold(), new FontSize { Val = "28" }),
                        new Text("MÜŞTERİ TEMSİLCİLERİ")
                    )
                ))
                {
                    TableCellProperties = new TableCellProperties(
                        new GridSpan { Val = 3 },
                        new Shading { Fill = "B4C6E7" },
                        new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = tabloGenislik.ToString() }
                    )
                }
            );
            table.AppendChild(headerRow);

            // --- Kolon başlıkları ---
            var colWidth = (tabloGenislik / 3).ToString();
            var columnRow = new TableRow(
                CreateHeaderCell("İsim", colWidth),
                CreateHeaderCell("Firma", colWidth),
                CreateHeaderCell("Görev Tanımı", colWidth)
            );
            table.AppendChild(columnRow);

            // --- Veri satırları ---
            foreach (var t in temsilciler ?? new List<Temsilci>())
            {
                table.AppendChild(new TableRow(
                    CreateValueCell(t.Isim, colWidth, satirBosluk),
                    CreateValueCell(t.Firma, colWidth, satirBosluk),
                    CreateValueCell(t.Gorev, colWidth, satirBosluk)
                ));
            }

            return table;
        }

        private static TableCell CreateHeaderCell(string text, string width)
        {
            return new TableCell(new Paragraph(
                new ParagraphProperties(
                    new Justification { Val = JustificationValues.Center },
                    new SpacingBetweenLines { Before = "60", After = "60" }
                ),
                new Run(new RunProperties(new Bold(), new FontSize { Val = "26" }), new Text(text))
            ))
            {
                TableCellProperties = new TableCellProperties(
                    new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = width }
                )
            };
        }

        private static TableCell CreateValueCell(string text, string width, int bosluk)
        {
            return new TableCell(new Paragraph(
                new ParagraphProperties(
                    new SpacingBetweenLines { Before = bosluk.ToString(), After = bosluk.ToString() },
                    new Justification { Val = JustificationValues.Center }
                ),
                new Run(new Text(text ?? ""))
            ))
            {
                TableCellProperties = new TableCellProperties(
                    new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = width }
                )
            };
        }
    }
}

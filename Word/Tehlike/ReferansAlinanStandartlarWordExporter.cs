using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using W14 = DocumentFormat.OpenXml.Office2010.Word;
using EMAR.Models;
using System.Collections.Generic;

namespace EMAR.Word.Genel
{
    public static class ReferansAlinanStandartlarWordExporter
    {
        public static void Olustur(string hedefDosyaYolu, List<StandartItem> seciliStandartlar)
        {
            using var wordDoc = WordprocessingDocument.Create(hedefDosyaYolu, WordprocessingDocumentType.Document);
            var mainPart = wordDoc.AddMainDocumentPart();
            mainPart.Document = new Document(new Body());
            var body = mainPart.Document.Body;

            // Tablo başlatılıyor (çerçeve + genişlikler)
            var table = new Table(
                new TableProperties(
                    new TableWidth { Width = "5000", Type = TableWidthUnitValues.Pct },
                    new TableBorders(
                        new TopBorder { Val = BorderValues.Single, Size = 6 },
                        new BottomBorder { Val = BorderValues.Single, Size = 6 },
                        new LeftBorder { Val = BorderValues.Single, Size = 6 },
                        new RightBorder { Val = BorderValues.Single, Size = 6 },
                        new InsideHorizontalBorder { Val = BorderValues.Single, Size = 6 },
                        new InsideVerticalBorder { Val = BorderValues.Single, Size = 6 }
                    )
                )
            );

            // Başlık satırı
            var headerRow = new TableRow(
                new TableRowProperties(new TableRowHeight
                {
                    Val = (UInt32Value)CmToTwip(1.4),
                    HeightType = HeightRuleValues.Exact
                }));
            var headerCell = new TableCell(
                new TableCellProperties(
                    new GridSpan { Val = 2 },
                    new Shading { Val = ShadingPatternValues.Clear, Fill = "B4C6E7" },
                    new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center }
                ),
                new Paragraph(
                    new ParagraphProperties(
                        new Justification { Val = JustificationValues.Center },
                        new SpacingBetweenLines { After = "0" }
                    ),
                    new Run(
                        new RunProperties(new FontSize { Val = "22" }, new Bold()),
                        new Text("Referans Alınan Standartlar")
                    )
                )
            );
            headerRow.Append(headerCell);
            table.Append(headerRow);

            // Veri satırları
            foreach (var item in seciliStandartlar)
            {
                var fillColor = item.Secili ? "92D050" : "FFFFFF"; // Seçili satırlar yeşil

                var row = new TableRow(
                    new TableRowProperties(new TableRowHeight
                    {
                        Val = (UInt32Value)CmToTwip(1.4),
                        HeightType = HeightRuleValues.Exact
                    }));

                // 1. Hücre: Checkbox ve kod
                var sdtCheck = new SdtRun(
                    new SdtProperties(
                        new SdtAlias { Val = "OnayKutusu" },
                        new Tag { Val = "OnayKutusu" },
                        new W14.SdtContentCheckBox(
                            new W14.Checked { Val = item.Secili ? W14.OnOffValues.One : W14.OnOffValues.Zero },
                            new W14.CheckedState { Font = "MS Gothic", Val = "2612" },
                            new W14.UncheckedState { Font = "MS Gothic", Val = "2610" }
                        )
                    ),
                    new SdtContentRun(
                        new Run(new RunProperties(new FontSize { Val = "24" }, new Bold()),
                            new Text(item.Secili ? "☒" : "☐")),
                        new Run(new Text("  "))
                    )
                );
                var cell1 = new TableCell(
                    new TableCellProperties(
                        new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center },
                        new TableCellWidth { Type = TableWidthUnitValues.Dxa, Width = "3000" },
                        new Shading { Val = ShadingPatternValues.Clear, Fill = fillColor }
                    ),
                    new Paragraph(
                        new ParagraphProperties(new Justification { Val = JustificationValues.Center }),
                        sdtCheck,
                        new Run(new Text("\u00A0")), // NBSP
                        new Run(new RunProperties(new FontSize { Val = "24" }, new Bold()), new Text(item.Kodu))
                    )
                );

                // 2. Hücre: Açıklama
                var cell2 = new TableCell(
                    new TableCellProperties(
                        new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center },
                        new TableCellWidth { Type = TableWidthUnitValues.Dxa, Width = "9000" },
                        new Shading { Val = ShadingPatternValues.Clear, Fill = fillColor }
                    ),
                    new Paragraph(
                        new ParagraphProperties(
                            new Justification { Val = JustificationValues.Left },
                            new SpacingBetweenLines { After = "0" }
                        ),
                        new Run(new RunProperties(new FontSize { Val = "24" }),
                            new Text(item.Aciklama ?? ""))
                    )
                );

                row.Append(cell1, cell2);
                table.Append(row);
            }

            body.Append(table);
            mainPart.Document.Save();
        }

        private static uint CmToTwip(double cm) => (uint)(cm * 567); // 1 cm ≈ 567 twip
    }
}

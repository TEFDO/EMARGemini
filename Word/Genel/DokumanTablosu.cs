using System;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;
using System.Linq;
using EMAR.Repositories;
using System.IO;
using DocumentFormat.OpenXml;

namespace EMAR.Word.Genel
{
    public static class IncelenenDokumanlarTablosu
    {
        public static void Olustur(string dbYolu, string sablonYolu, string hedefYol,
            Dictionary<string, string> etiketler)
        {
            File.Copy(sablonYolu, hedefYol, true);
            using (var doc = WordprocessingDocument.Open(hedefYol, true))
            {
                var mainPart = doc.MainDocumentPart;

                // Etiketleri değiştir
                foreach (var kvp in etiketler)
                {
                    ReplaceInAllParts(mainPart, kvp.Key, kvp.Value);
                }

                // Dokumanları veritabanından oku
                var repo = new DokumanRepository(dbYolu);
                var dokumanlar = repo.GetAll().OrderBy(d => d.Id).ToList();
                // Tabloyu doldur
                DoldurTablo(mainPart, dokumanlar);

                mainPart.Document.Save();
            }
        }

        private static void ReplaceInAllParts(MainDocumentPart mainPart, string placeholder, string value)
        {
            ReplaceInText(mainPart.Document.Body, placeholder, value);

            foreach (var header in mainPart.HeaderParts)
                ReplaceInText(header.Header, placeholder, value);

            foreach (var footer in mainPart.FooterParts)
                ReplaceInText(footer.Footer, placeholder, value);
        }

        private static void ReplaceInText(OpenXmlElement element, string placeholder, string value)
        {
            foreach (var text in element.Descendants<Text>())
            {
                if (text.Text.Contains(placeholder))
                    text.Text = text.Text.Replace(placeholder, value ?? "-");
            }
        }

        private static void DoldurTablo(MainDocumentPart mainPart, List<Models.Dokuman> dokumanlar)
        {
            var text = mainPart.Document.Body.Descendants<Text>()
                .FirstOrDefault(t => t.Text.Contains("@@DokumanSatir@@"));
            if (text == null) return;

            var table = text.Ancestors<Table>().FirstOrDefault();
            var currentRow = text.Ancestors<TableRow>().FirstOrDefault();
            if (table == null || currentRow == null) return;

            // Tablo kenarlıkları ekle (ekli değilse)
            var tblProps = table.GetFirstChild<TableProperties>();
            if (tblProps == null)
            {
                tblProps = new TableProperties();
                table.PrependChild(tblProps);
            }

            if (tblProps.TableBorders == null)
            {
                tblProps.TableBorders = new TableBorders(
                    new TopBorder { Val = BorderValues.Single, Size = 4 },
                    new BottomBorder { Val = BorderValues.Single, Size = 4 },
                    new LeftBorder { Val = BorderValues.Single, Size = 4 },
                    new RightBorder { Val = BorderValues.Single, Size = 4 },
                    new InsideHorizontalBorder { Val = BorderValues.Single, Size = 4 },
                    new InsideVerticalBorder { Val = BorderValues.Single, Size = 4 }
                );
            }

            text.Text = string.Empty;

            int no = 1;
            if (dokumanlar != null && dokumanlar.Count > 0)
            {
                foreach (var d in dokumanlar)
                {
                    try
                    {
                        var tr = new TableRow();

                        // NO sütunu
                        var noCell = new TableCell(
                            new Paragraph(
                                new ParagraphProperties(
                                    new Justification { Val = JustificationValues.Center },
                                    new SpacingBetweenLines { Before = "120", After = "120" }
                                ),
                                new Run(
                                    new RunProperties(
                                        new FontSize { Val = "24" }
                                    ),
                                    new Text(no.ToString()))
                            ),
                            new TableCellProperties(
                                new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center }
                            )
                        );
                        tr.Append(noCell);

                        // Diğer hücreler
                        var cellAd = new TableCell(
                            new Paragraph(
                                new ParagraphProperties(
                                    new Justification { Val = JustificationValues.Center },
                                    new SpacingBetweenLines { Before = "120", After = "120" }
                                ),
                                new Run(
                                    new RunProperties(
                                        new FontSize { Val = "24" }
                                    ),
                                    new Text(d.Ad ?? "-"))
                            ),
                            new TableCellProperties(
                                new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center }
                            )
                        );
                        var cellTip = new TableCell(
                            new Paragraph(
                                new ParagraphProperties(
                                    new Justification { Val = JustificationValues.Center },
                                    new SpacingBetweenLines { Before = "120", After = "120" }
                                ),
                                new Run(
                                    new RunProperties(
                                        new FontSize { Val = "24" }
                                    ),
                                    new Text(d.Tip ?? "-"))
                            ),
                            new TableCellProperties(
                                new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center }
                            )
                        );
                        var cellTarih = new TableCell(
                            new Paragraph(
                                new ParagraphProperties(
                                    new Justification { Val = JustificationValues.Center },
                                    new SpacingBetweenLines { Before = "120", After = "120" }
                                ),
                                new Run(
                                    new RunProperties(
                                        new FontSize { Val = "24" }
                                    ),
                                    new Text(d.IletilmeTarihi ?? "-"))
                            ),
                            new TableCellProperties(
                                new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center }
                            )
                        );
                        tr.Append(cellAd);
                        tr.Append(cellTip);
                        tr.Append(cellTarih);

                        table.InsertBefore(tr, currentRow);
                        no++;
                    }
                    catch (Exception ex)
                    {
                        // Logla veya atla
                    }
                }
            }
            else
            {
                // HİÇ KAYIT YOKSA → tabloya bir bilgilendirme satırı ekle!
                var tr = new TableRow();
                tr.Append(
                    new TableCell(
                        new Paragraph(
                            new ParagraphProperties(
                                new Justification { Val = JustificationValues.Center },
                                new SpacingBetweenLines { Before = "120", After = "120" }
                            ),
                            new Run(
                                new RunProperties(new FontSize { Val = "24" }, new Bold()),
                                new Text("Kayıt bulunmamaktadır.")
                            )
                        ),
                        new TableCellProperties(
                            new GridSpan { Val = 4 },
                            new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center }
                        )
                    )
                );
                table.InsertBefore(tr, currentRow);
            }

            currentRow.Remove();
        }
    }
}
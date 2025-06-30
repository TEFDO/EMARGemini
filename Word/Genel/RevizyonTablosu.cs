using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EMAR.Word.Genel
{
    public static class RevizyonTablosu
    {
        public static void Olustur(List<string[]> rows, string hedefYol, string sablonYolu)
        {
            File.Copy(sablonYolu, hedefYol, true);

            using (var doc = WordprocessingDocument.Open(hedefYol, true))
            {
                var mainPart = doc.MainDocumentPart;

                var text = mainPart.Document.Body.Descendants<Text>().FirstOrDefault(t => t.Text.Contains("@@RevizyonSatir@@"));
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

                foreach (var rowData in rows)
                {
                    var tr = new TableRow();

                    foreach (var value in rowData)
                    {
                        var cell = new TableCell(
                            new Paragraph(
                                new ParagraphProperties(
                                    new Justification { Val = JustificationValues.Center },
                                    new SpacingBetweenLines { Before = "120", After = "120" }
                                ),
                                new Run(new Text(value ?? ""))
                            ),
                            new TableCellProperties(
                                new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center }
                            )
                        );
                        tr.Append(cell);
                    }
                    table.InsertAfter(tr, currentRow);

                    // Çok büyük tabloda her 500 satırda bir GC çağırmak istersen:
                    // if (rows.IndexOf(rowData) % 500 == 0) GC.Collect();
                }
                currentRow.Remove();

                mainPart.Document.Save();
            }
        }
    }
}

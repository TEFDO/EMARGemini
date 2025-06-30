using DocumentFormat.OpenXml.Packaging;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System;
using DocumentFormat.OpenXml;
using W = DocumentFormat.OpenXml.Wordprocessing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
// Sadece aşağıdaki tipler için Drawing alias'ı açıldı:
using D = DocumentFormat.OpenXml.Drawing;
// Drawing namespace'ini asla toplu olarak ekleme!
using System.Linq;

public static class MakineGorselleriWordGridExporter
{
    public static void ExportMakineGorselleriToWord(WordprocessingDocument wordDoc, string dbYolu, string raporKlasor)
    {
        var gorselRepo = new EMAR.Repositories.MakineGorselRepository(dbYolu);
        var gorseller = gorselRepo.GetAll();

        var fullPaths = new List<string>();
        foreach (var g in gorseller)
        {
            string relPath = g.DosyaYolu.Replace("/", Path.DirectorySeparatorChar.ToString());
            string fullPath = Path.Combine(raporKlasor, relPath);
            if (File.Exists(fullPath))
                fullPaths.Add(fullPath);
        }

        if (fullPaths.Count == 0)
            return;

        var mainPart = wordDoc.MainDocumentPart;
        var body = mainPart.Document.Body;

        var table = new W.Table();
        var tblProps = new W.TableProperties(
            new W.TableBorders(
                new W.TopBorder { Val = W.BorderValues.Single, Size = 4 },
                new W.BottomBorder { Val = W.BorderValues.Single, Size = 4 },
                new W.LeftBorder { Val = W.BorderValues.Single, Size = 4 },
                new W.RightBorder { Val = W.BorderValues.Single, Size = 4 },
                new W.InsideHorizontalBorder { Val = W.BorderValues.Single, Size = 4 },
                new W.InsideVerticalBorder { Val = W.BorderValues.Single, Size = 4 }
            )
        );
        table.AppendChild(tblProps);

        int colCount = 2;

        var headingRow = new W.TableRow(
            new W.TableRowProperties(new W.TableHeader()),
            new W.TableCell(
                new W.Paragraph(
                    new W.ParagraphProperties(
                        new W.Justification { Val = W.JustificationValues.Center }
                    ),
                    new W.Run(
                        new W.RunProperties(
                            new W.Bold(),
                            new W.FontSize { Val = "28" }
                        ),
                        new W.Text("MAKİNE GÖRSELLERİ")
                    )
                ),
                new W.TableCellProperties(
                    new W.GridSpan { Val = colCount },
                    new W.TableCellVerticalAlignment { Val = W.TableVerticalAlignmentValues.Center },
                    new W.Shading() { Val = W.ShadingPatternValues.Clear, Color = "auto", Fill = "B4C6E7" }
                )
            )
        );
        table.AppendChild(headingRow);

        int imgIndex = 1;
        W.TableRow currentRow = null;
        for (int i = 0; i < fullPaths.Count; i++)
        {
            if (i % colCount == 0)
                currentRow = new W.TableRow();

            var imgPath = fullPaths[i];
            try
            {
                var extension = Path.GetExtension(imgPath).ToLower();
                var imageType = ImagePartType.Png;
                if (extension == ".jpg" || extension == ".jpeg")
                    imageType = ImagePartType.Jpeg;
                else if (extension == ".bmp")
                    imageType = ImagePartType.Bmp;
                else if (extension == ".png")
                    imageType = ImagePartType.Png;
                else
                    continue;

                var imagePart = mainPart.AddImagePart(imageType);

                using (FileStream stream = new FileStream(imgPath, FileMode.Open, FileAccess.Read))
                {
                    imagePart.FeedData(stream);
                }
                string relationshipId = mainPart.GetIdOfPart(imagePart);

                long widthEmu = 260 * 9525;
                long heightEmu = 180 * 9525;
                try
                {
                    using (var img = Image.FromFile(imgPath))
                    {
                        widthEmu = img.Width * 9525;
                        heightEmu = img.Height * 9525;
                        if (widthEmu > 260 * 9525)
                        {
                            double oran = (260.0 * 9525) / widthEmu;
                            widthEmu = (long)(widthEmu * oran);
                            heightEmu = (long)(heightEmu * oran);
                        }
                        if (heightEmu > 180 * 9525)
                        {
                            double oran = (180.0 * 9525) / heightEmu;
                            widthEmu = (long)(widthEmu * oran);
                            heightEmu = (long)(heightEmu * oran);
                        }
                    }
                }
                catch { /* resmin boyutu okunamıyorsa, varsayılan kullanılır */ }

                var drawing = CreateImageElement(relationshipId, widthEmu, heightEmu, imgIndex++);

                var para = new W.Paragraph(
                    new W.Run(drawing)
                )
                {
                    ParagraphProperties = new W.ParagraphProperties(
                        new W.Justification() { Val = W.JustificationValues.Center },
                        new W.SpacingBetweenLines() { After = "200" }
                    )
                };

                var cell = new W.TableCell(para)
                {
                    TableCellProperties = new W.TableCellProperties(
                        new W.TableCellVerticalAlignment() { Val = W.TableVerticalAlignmentValues.Center },
                        new W.TableCellWidth() { Type = W.TableWidthUnitValues.Dxa, Width = "5000" }
                    )
                };

                currentRow.Append(cell);

                if ((i % colCount == colCount - 1) || (i == fullPaths.Count - 1))
                {
                    while (currentRow.ChildElements.Count < colCount)
                        currentRow.Append(new W.TableCell(new W.Paragraph(new W.Run())));

                    table.Append(currentRow);
                }

                // Çok büyük projelerde 100-200 resimde bir GC.Collect() tetiklenebilir (isteğe bağlı!)
                // if ((i + 1) % 100 == 0) GC.Collect();
            }
            catch
            {
                // Hatalı görseli atla, işlemi kesme
            }
        }

        body.AppendChild(table);
        mainPart.Document.Save();
    }


    // Drawing (görsel) fonksiyonu aynı kalabilir
    private static W.Drawing CreateImageElement(
        string relationshipId, long widthEmu, long heightEmu, int imageId)
    {
        return new W.Drawing(
            new DW.Inline(
                new DW.Extent() { Cx = widthEmu, Cy = heightEmu },
                new DW.EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L },
                new DW.DocProperties() { Id = (UInt32Value)(uint)imageId, Name = "MakineGorseli" + imageId },
                new DW.NonVisualGraphicFrameDrawingProperties(
                    new D.GraphicFrameLocks() { NoChangeAspect = true }
                ),
                new D.Graphic(
                    new D.GraphicData(
                        new PIC.Picture(
                            new PIC.NonVisualPictureProperties(
                                new PIC.NonVisualDrawingProperties()
                                {
                                    Id = (UInt32Value)(uint)imageId,
                                    Name = "MakineGorseli" + imageId
                                },
                                new PIC.NonVisualPictureDrawingProperties()
                            ),
                            new PIC.BlipFill(
                                new D.Blip()
                                {
                                    Embed = relationshipId,
                                    CompressionState = D.BlipCompressionValues.Print
                                },
                                new D.Stretch(
                                    new D.FillRectangle()
                                )
                            ),
                            new PIC.ShapeProperties(
                                new D.Transform2D(
                                    new D.Offset() { X = 0L, Y = 0L },
                                    new D.Extents() { Cx = widthEmu, Cy = heightEmu }
                                ),
                                new D.PresetGeometry(
                                    new D.AdjustValueList()
                                )
                                { Preset = D.ShapeTypeValues.Rectangle }
                            )
                        )
                    )
                    { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" }
                )
            )
            {
                DistanceFromTop = 0U,
                DistanceFromBottom = 0U,
                DistanceFromLeft = 0U,
                DistanceFromRight = 0U
            }
        );
    }
}

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using EMAR.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using W = DocumentFormat.OpenXml.Wordprocessing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;

namespace EMAR.Word.Tehlike
{
    public static class MevcutDurumGorselWordExporter
    {
        public static void Olustur(string hedefDosyaYolu, List<GorselYerlesimModel> gorseller, string baseFolder, string tabloBasligi = "Mevcut Durum Görselleri")
        {
            using var doc = WordprocessingDocument.Create(hedefDosyaYolu, WordprocessingDocumentType.Document);
            var mainPart = doc.AddMainDocumentPart();
            mainPart.Document = new W.Document(new Body());
            var body = mainPart.Document.Body;

            // --- ARAYA BOŞLUK EKLE (İlk satır olarak) ---
            body.AppendChild(new W.Paragraph(
                new W.ParagraphProperties(
                    new W.SpacingBetweenLines { After = "200" }
                ),
                new W.Run(new W.Text(""))
            ));

            // Tablo ve grid
            var tableProps = new TableProperties(
                new TableWidth { Width = "5000", Type = TableWidthUnitValues.Pct },
                new TableLook { Val = "04A0" },
                new TableBorders(
                    new TopBorder { Val = BorderValues.Single, Size = 6 },
                    new BottomBorder { Val = BorderValues.Single, Size = 6 },
                    new LeftBorder { Val = BorderValues.Single, Size = 6 },
                    new RightBorder { Val = BorderValues.Single, Size = 6 },
                    new InsideHorizontalBorder { Val = BorderValues.Single, Size = 6 },
                    new InsideVerticalBorder { Val = BorderValues.Single, Size = 6 }
                ));
            var tablo = new Table();
            tablo.AppendChild(tableProps);
            tablo.AppendChild(new TableGrid(
                new GridColumn { Width = "2500" },
                new GridColumn { Width = "2500" }
            ));

            // Başlık satırı
            var headerCell = new TableCell(new Paragraph(
                new ParagraphProperties(
                    new Justification { Val = JustificationValues.Center },
                    new SpacingBetweenLines { Before = "0", After = "0" }),
                new Run(new RunProperties(new Bold()), new Text(tabloBasligi))
            ));
            headerCell.TableCellProperties = new TableCellProperties(
                new GridSpan { Val = 2 },
                new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = "5000" },
                new Shading { Val = ShadingPatternValues.Clear, Fill = "B4C6E7" },
                new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center }
            );
            var headerRow = new TableRow(headerCell);
            headerRow.TableRowProperties = new TableRowProperties(new TableHeader());
            tablo.AppendChild(headerRow);

            int columns = 2;
            int i = 0;
            while (i < gorseller.Count)
            {
                var g = gorseller[i];

                // Tekli mod
                if (g.LayoutType == 1)
                {
                    if (!string.IsNullOrWhiteSpace(g.Title))
                        tablo.AppendChild(CreateTitleRow(g.Title, columns));
                    tablo.AppendChild(CreateImageRow(mainPart, g, baseFolder, columns, 15, 10.2, true));
                    i++;
                    continue;
                }

                bool isLast = (i == gorseller.Count - 1);
                if (isLast)
                {
                    if (g.IsFill)
                    {
                        if (!string.IsNullOrWhiteSpace(g.Title))
                            tablo.AppendChild(CreateTitleRow(g.Title, columns));
                        tablo.AppendChild(CreateImageRow(mainPart, g, baseFolder, columns, 15, 10.2, true));
                    }
                    else if (g.IsCenter)
                    {
                        if (!string.IsNullOrWhiteSpace(g.Title))
                            tablo.AppendChild(CreateTitleRow(g.Title, columns));
                        var cell = CreateImageCell(mainPart, g, baseFolder, 8, 6);
                        cell.TableCellProperties = cell.TableCellProperties ?? new TableCellProperties();
                        cell.TableCellProperties.GridSpan = new GridSpan { Val = columns };
                        var row = new TableRow(cell);
                        tablo.AppendChild(row);
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(g.Title))
                        {
                            var titleCell = new TableCell(new Paragraph(
                                new ParagraphProperties(
                                    new Justification { Val = JustificationValues.Center },
                                    new SpacingBetweenLines { Before = "0", After = "0" }),
                                new Run(new Text(g.Title ?? ""))));
                            titleCell.TableCellProperties = new TableCellProperties(
                                new TableCellWidth { Width = "2500", Type = TableWidthUnitValues.Pct },
                                new Shading { Val = ShadingPatternValues.Clear, Fill = "F2F2F2" },
                                new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center },
                                new TableCellBorders(
                                    new TopBorder { Val = BorderValues.Single, Size = 6 },
                                    new BottomBorder { Val = BorderValues.None },
                                    new LeftBorder { Val = BorderValues.Single, Size = 6 },
                                    new RightBorder { Val = BorderValues.Single, Size = 6 }
                                )
                            );
                            var titleRow = new TableRow(titleCell);
                            tablo.AppendChild(titleRow);
                        }

                        var imageCell = CreateImageCell(mainPart, g, baseFolder, 7, 5);
                        imageCell.TableCellProperties = imageCell.TableCellProperties ?? new TableCellProperties();
                        imageCell.TableCellProperties.Append(new TableCellWidth { Width = "2500", Type = TableWidthUnitValues.Pct });
                        var rowImg = new TableRow(imageCell);
                        tablo.AppendChild(rowImg);
                    }

                    i++;
                    continue;
                }

                // Yan yana iki görsel
                var g2 = gorseller[i + 1];
                if (!string.IsNullOrWhiteSpace(g.Title) || !string.IsNullOrWhiteSpace(g2.Title))
                {
                    var titleRow = new TableRow();
                    titleRow.Append(CreateTitleCell(g.Title));
                    titleRow.Append(CreateTitleCell(g2.Title));
                    tablo.AppendChild(titleRow);
                }

                var imageRow = new TableRow();
                imageRow.Append(CreateImageCell(mainPart, g, baseFolder, 7, 5));
                imageRow.Append(CreateImageCell(mainPart, g2, baseFolder, 7, 5));
                tablo.AppendChild(imageRow);

                i += 2;
            }

            body.Append(tablo);
            mainPart.Document.Save();
        }

        // -- Yardımcı fonksiyonlar RAM dostu şekilde revize edildi --
        private static TableRow CreateTitleRow(string title, int columns)
        {
            var cell = new TableCell(new Paragraph(
                new ParagraphProperties(
                    new Justification { Val = JustificationValues.Center },
                    new SpacingBetweenLines { Before = "0", After = "0" }),
                new Run(new Text(title ?? ""))));
            cell.TableCellProperties = new TableCellProperties(
                new GridSpan { Val = columns },
                new Shading { Val = ShadingPatternValues.Clear, Fill = "F2F2F2" },
                new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center },
                new TableCellBorders(
                    new TopBorder { Val = BorderValues.Single, Size = 6 },
                    new BottomBorder { Val = BorderValues.None },
                    new LeftBorder { Val = BorderValues.Single, Size = 6 },
                    new RightBorder { Val = BorderValues.Single, Size = 6 }
                )
            );
            return new TableRow(cell);
        }

        private static TableRow CreateImageRow(MainDocumentPart mainPart, GorselYerlesimModel g, string baseFolder, int columns, double widthCm, double heightCm, bool isCenterOrFill)
        {
            var imagePath = Path.Combine(baseFolder, g.ImagePath.Replace("/", "\\"));
            if (!File.Exists(imagePath)) return new TableRow(new TableCell(new Paragraph(new Run())));
            var cell = CreateImageCell(mainPart, g, baseFolder, widthCm, heightCm);
            if (isCenterOrFill)
            {
                cell.TableCellProperties.GridSpan = new GridSpan { Val = columns };
                return new TableRow(cell);
            }
            else
            {
                var emptyCell = new TableCell(new Paragraph(new Run()));
                return new TableRow(cell, emptyCell);
            }
        }

        private static TableCell CreateTitleCell(string title)
        {
            var cell = new TableCell(new Paragraph(
                new ParagraphProperties(
                    new Justification { Val = JustificationValues.Center },
                    new SpacingBetweenLines { Before = "0", After = "0" }),
                new Run(new Text(title ?? ""))));
            cell.TableCellProperties = new TableCellProperties(
                new Shading { Val = ShadingPatternValues.Clear, Fill = "F2F2F2" },
                new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center },
                new TableCellBorders(
                    new TopBorder { Val = BorderValues.Single, Size = 6 },
                    new BottomBorder { Val = BorderValues.None },
                    new LeftBorder { Val = BorderValues.Single, Size = 6 },
                    new RightBorder { Val = BorderValues.Single, Size = 6 }
                )
            );
            return cell;
        }

        private static TableCell CreateImageCell(MainDocumentPart mainPart, GorselYerlesimModel g, string baseFolder, double widthCm, double heightCm)
        {
            var imagePath = Path.Combine(baseFolder, g.ImagePath.Replace("/", "\\"));
            if (!File.Exists(imagePath))
                return new TableCell(new Paragraph(new Run()));
            Drawing drawing = null;
            try
            {
                drawing = CreateDrawing(mainPart, imagePath, CmToEmu(widthCm), CmToEmu(heightCm));
            }
            catch
            {
                drawing = null;
            }
            var imagePara = new Paragraph(
                new ParagraphProperties(
                    new Justification { Val = JustificationValues.Center },
                    new SpacingBetweenLines { Before = "200", After = "200" }),
                drawing != null ? new Run(drawing) : new Run());
            var imageCell = new TableCell(imagePara);
            imageCell.TableCellProperties = new TableCellProperties(
                new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center }
            );
            return imageCell;
        }

        private static Drawing CreateDrawing(MainDocumentPart mainPart, string imagePath, long widthEmu, long heightEmu)
        {
            ImagePart imagePart = null;
            try
            {
                imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);
                using (var stream = File.OpenRead(imagePath))
                    imagePart.FeedData(stream);
            }
            catch
            {
                if (imagePart != null)
                    mainPart.DeletePart(imagePart);
                throw;
            }
            var imageId = mainPart.GetIdOfPart(imagePart);

            return new Drawing(
                new DW.Inline(
                    new DW.Extent { Cx = widthEmu, Cy = heightEmu },
                    new DW.EffectExtent { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L },
                    new DW.DocProperties { Id = (UInt32Value)1U, Name = Path.GetFileName(imagePath) },
                    new DW.NonVisualGraphicFrameDrawingProperties(new A.GraphicFrameLocks { NoChangeAspect = true }),
                    new A.Graphic(
                        new A.GraphicData(
                            new PIC.Picture(
                                new PIC.NonVisualPictureProperties(
                                    new PIC.NonVisualDrawingProperties { Id = (UInt32Value)0U, Name = Path.GetFileName(imagePath) },
                                    new PIC.NonVisualPictureDrawingProperties()),
                                new PIC.BlipFill(
                                    new A.Blip { Embed = imageId },
                                    new A.Stretch(new A.FillRectangle())),
                                new PIC.ShapeProperties(
                                    new A.Transform2D(
                                        new A.Offset { X = 0, Y = 0 },
                                        new A.Extents { Cx = widthEmu, Cy = heightEmu }),
                                    new A.PresetGeometry(new A.AdjustValueList()) { Preset = A.ShapeTypeValues.Rectangle })
                            )
                        )
                        { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                ));
        }

        private static long CmToEmu(double cm) => (long)(cm * 360000);
    }
}

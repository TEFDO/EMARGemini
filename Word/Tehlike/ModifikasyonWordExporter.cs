using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using EMAR.Models;
using EMAR.Word.Helper;
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
    public static class ModifikasyonAlanWordExporter
    {
        private static int PxToTwip(int px) => (int)(px * 15);

        public static void Olustur(
            string hedefDosyaYolu,
            List<ModifikasyonIcerik> alanlar,
            string baseFolder,
            string tabloBasligi = "Modifikasyon Alanı")
        {
            using var doc = WordprocessingDocument.Create(hedefDosyaYolu, WordprocessingDocumentType.Document);
            var mainPart = doc.AddMainDocumentPart();
            mainPart.Document = new W.Document(new W.Body());
            var body = mainPart.Document.Body;

            EnsureBulletNumbering(mainPart);

            foreach (var item in alanlar.OrderBy(x => x.Siralama))
            {
                if (item.Tip == "text")
                {
                    var converter = new RtfToOpenXmlConverter();
                    var docElements = converter.ConvertRtfToElements(item.Icerik)
                        .OfType<ParagraphElement>()
                        .ToList();
                    var tablo = CreateTextTable("Modifikasyon Önerisi", docElements);
                    body.Append(tablo);
                }
                else if (item.Tip == "gorsel")
                {
                    var gorselList = System.Text.Json.JsonSerializer.Deserialize<List<GorselYerlesimModel>>(item.Icerik);
                    if (gorselList != null && gorselList.Any())
                        body.Append(CreateTableForGorsel(mainPart, gorselList, baseFolder, "Modifikasyon Önerisi"));
                }
                body.AppendChild(new W.Paragraph(new W.Run())); // tablolar arası boşluk
            }

            mainPart.Document.Save();
        }

        private static W.Table CreateTableForGorsel(MainDocumentPart mainPart, List<GorselYerlesimModel> gorseller, string baseFolder, string tabloBasligi)
        {
            int columns = 2;
            var tablo = new W.Table();
            var tableProps = new W.TableProperties(
                new W.TableWidth { Width = "5000", Type = TableWidthUnitValues.Pct },
                new W.TableLook { Val = "04A0" },
                new W.TableBorders(
                    new W.TopBorder { Val = W.BorderValues.Single, Size = 6 },
                    new W.BottomBorder { Val = W.BorderValues.Single, Size = 6 },
                    new W.LeftBorder { Val = W.BorderValues.Single, Size = 6 },
                    new W.RightBorder { Val = W.BorderValues.Single, Size = 6 },
                    new W.InsideHorizontalBorder { Val = W.BorderValues.Single, Size = 6 },
                    new W.InsideVerticalBorder { Val = W.BorderValues.Single, Size = 6 }
                ));
            tablo.AppendChild(tableProps);
            tablo.AppendChild(new W.TableGrid(
                new W.GridColumn { Width = "2500" },
                new W.GridColumn { Width = "2500" }
            ));

            // Başlık satırı
            var headerCell = new W.TableCell(new W.Paragraph(
                new W.ParagraphProperties(
                    new W.Justification { Val = W.JustificationValues.Center },
                    new W.SpacingBetweenLines { Before = "0", After = "0" }),
                new W.Run(new W.RunProperties(new W.Bold()), new W.Text(tabloBasligi))
            ));
            headerCell.TableCellProperties = new W.TableCellProperties(
                new W.GridSpan { Val = 2 },
                new W.TableCellWidth { Type = TableWidthUnitValues.Pct, Width = "5000" },
                new W.Shading { Val = W.ShadingPatternValues.Clear, Fill = "B4C6E7" },
                new W.TableCellVerticalAlignment { Val = W.TableVerticalAlignmentValues.Center }
            );
            var headerRow = new W.TableRow(headerCell);
            headerRow.TableRowProperties = new W.TableRowProperties(new W.TableHeader());
            tablo.AppendChild(headerRow);

            int i = 0;
            while (i < gorseller.Count)
            {
                var g = gorseller[i];
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
                        cell.TableCellProperties = cell.TableCellProperties ?? new W.TableCellProperties();
                        cell.TableCellProperties.GridSpan = new W.GridSpan { Val = columns };
                        var row = new W.TableRow(cell);
                        tablo.AppendChild(row);
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(g.Title))
                        {
                            var cell = new W.TableCell(new W.Paragraph(
                                new W.ParagraphProperties(
                                    new W.Justification { Val = W.JustificationValues.Center },
                                    new W.SpacingBetweenLines { Before = "0", After = "0" }),
                                new W.Run(new W.Text(g.Title ?? ""))));
                            cell.TableCellProperties = new W.TableCellProperties(
                                new W.TableCellWidth { Width = "2500", Type = TableWidthUnitValues.Pct },
                                new W.Shading { Val = W.ShadingPatternValues.Clear, Fill = "F2F2F2" },
                                new W.TableCellVerticalAlignment { Val = W.TableVerticalAlignmentValues.Center },
                                new W.TableCellBorders(
                                    new W.TopBorder { Val = W.BorderValues.Single, Size = 6 },
                                    new W.BottomBorder { Val = W.BorderValues.None },
                                    new W.LeftBorder { Val = W.BorderValues.Single, Size = 6 },
                                    new W.RightBorder { Val = W.BorderValues.Single, Size = 6 }
                                )
                            );
                            var row = new W.TableRow(cell);
                            tablo.AppendChild(row);
                        }
                        {
                            var cell = CreateImageCell(mainPart, g, baseFolder, 7, 5);
                            cell.TableCellProperties = cell.TableCellProperties ?? new W.TableCellProperties();
                            cell.TableCellProperties.Append(new W.TableCellWidth { Width = "2500", Type = TableWidthUnitValues.Pct });
                            var row = new W.TableRow(cell);
                            tablo.AppendChild(row);
                        }
                    }
                    i++;
                    continue;
                }
                var g2 = gorseller[i + 1];
                if (!string.IsNullOrWhiteSpace(g.Title) || !string.IsNullOrWhiteSpace(g2.Title))
                {
                    var titleRow = new W.TableRow();
                    titleRow.Append(CreateTitleCell(g.Title));
                    titleRow.Append(CreateTitleCell(g2.Title));
                    tablo.AppendChild(titleRow);
                }
                var imageRow = new W.TableRow();
                imageRow.Append(CreateImageCell(mainPart, g, baseFolder, 7, 5));
                imageRow.Append(CreateImageCell(mainPart, g2, baseFolder, 7, 5));
                tablo.AppendChild(imageRow);
                i += 2;
            }
            return tablo;
        }

        private static W.TableRow CreateTitleRow(string title, int columns)
        {
            var cell = new W.TableCell(new W.Paragraph(
                new W.ParagraphProperties(
                    new W.Justification { Val = W.JustificationValues.Center },
                    new W.SpacingBetweenLines { Before = "0", After = "0" }),
                new W.Run(new W.Text(title ?? ""))));
            cell.TableCellProperties = new W.TableCellProperties(
                new W.GridSpan { Val = columns },
                new W.Shading { Val = W.ShadingPatternValues.Clear, Fill = "F2F2F2" },
                new W.TableCellVerticalAlignment { Val = W.TableVerticalAlignmentValues.Center },
                new W.TableCellBorders(
                    new W.TopBorder { Val = W.BorderValues.Single, Size = 6 },
                    new W.BottomBorder { Val = W.BorderValues.None },
                    new W.LeftBorder { Val = W.BorderValues.Single, Size = 6 },
                    new W.RightBorder { Val = W.BorderValues.Single, Size = 6 }
                )
            );
            return new W.TableRow(cell);
        }

        private static W.TableCell CreateTitleCell(string title)
        {
            var cell = new W.TableCell(new W.Paragraph(
                new W.ParagraphProperties(
                    new W.Justification { Val = W.JustificationValues.Center },
                    new W.SpacingBetweenLines { Before = "0", After = "0" }),
                new W.Run(new W.Text(title ?? ""))));
            cell.TableCellProperties = new W.TableCellProperties(
                new W.Shading { Val = W.ShadingPatternValues.Clear, Fill = "F2F2F2" },
                new W.TableCellVerticalAlignment { Val = W.TableVerticalAlignmentValues.Center },
                new W.TableCellBorders(
                    new W.TopBorder { Val = W.BorderValues.Single, Size = 6 },
                    new W.BottomBorder { Val = W.BorderValues.None },
                    new W.LeftBorder { Val = W.BorderValues.Single, Size = 6 },
                    new W.RightBorder { Val = W.BorderValues.Single, Size = 6 }
                )
            );
            return cell;
        }

        private static W.TableRow CreateImageRow(MainDocumentPart mainPart, GorselYerlesimModel g, string baseFolder, int columns, double widthCm, double heightCm, bool isCenterOrFill)
        {
            var imagePath = Path.Combine(baseFolder, g.ImagePath.Replace("/", "\\"));
            if (!File.Exists(imagePath)) return new W.TableRow(new W.TableCell(new W.Paragraph(new W.Run())));
            var cell = CreateImageCell(mainPart, g, baseFolder, widthCm, heightCm);
            if (isCenterOrFill)
            {
                cell.TableCellProperties.GridSpan = new W.GridSpan { Val = columns };
                return new W.TableRow(cell);
            }
            else
            {
                var emptyCell = new W.TableCell(new W.Paragraph(new W.Run()));
                return new W.TableRow(cell, emptyCell);
            }
        }

        private static W.TableCell CreateImageCell(MainDocumentPart mainPart, GorselYerlesimModel g, string baseFolder, double widthCm, double heightCm)
        {
            var imagePath = Path.Combine(baseFolder, g.ImagePath.Replace("/", "\\"));
            if (!File.Exists(imagePath))
                return new W.TableCell(new W.Paragraph(new W.Run()));
            Drawing drawing = null;
            try
            {
                drawing = CreateDrawing(mainPart, imagePath, CmToEmu(widthCm), CmToEmu(heightCm));
            }
            catch
            {
                drawing = null;
            }
            var imagePara = new W.Paragraph(
                new W.ParagraphProperties(
                    new W.Justification { Val = W.JustificationValues.Center },
                    new W.SpacingBetweenLines { Before = "200", After = "200" }),
                drawing != null ? new W.Run(drawing) : new W.Run());
            var imageCell = new W.TableCell(imagePara);
            imageCell.TableCellProperties = new W.TableCellProperties(
                new W.TableCellVerticalAlignment { Val = W.TableVerticalAlignmentValues.Center }
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

        private static void EnsureBulletNumbering(MainDocumentPart mainPart)
        {
            var numberingPart = mainPart.NumberingDefinitionsPart ?? mainPart.AddNewPart<NumberingDefinitionsPart>();
            if (numberingPart.Numbering == null)
            {
                numberingPart.Numbering = new Numbering(
                    new AbstractNum(
                            new Level(
                                    new NumberingFormat() { Val = NumberFormatValues.Bullet },
                                    new LevelText() { Val = "•" },
                                    new LevelJustification() { Val = LevelJustificationValues.Left },
                                    new W.ParagraphProperties(new W.Indentation() { Left = "340" })
                                )
                            { LevelIndex = 0 }
                        )
                    { AbstractNumberId = 1 },

                    new NumberingInstance(
                            new AbstractNumId() { Val = 1 }
                        )
                    { NumberID = 1 }
                );
            }
        }

        private static W.Table CreateTextTable(string textTitle, List<ParagraphElement> docElements)
        {
            var tablo = new W.Table();
            tablo.AppendChild(new W.TableProperties(
                new W.TableWidth { Type = W.TableWidthUnitValues.Pct, Width = "5000" },
                new W.TableBorders(
                    new W.TopBorder { Val = W.BorderValues.Single, Size = 12 },
                    new W.LeftBorder { Val = W.BorderValues.Single, Size = 12 },
                    new W.BottomBorder { Val = W.BorderValues.Single, Size = 12 },
                    new W.RightBorder { Val = W.BorderValues.Single, Size = 12 },
                    new W.InsideHorizontalBorder { Val = W.BorderValues.Single, Size = 8 },
                    new W.InsideVerticalBorder { Val = W.BorderValues.Single, Size = 8 }
                ),
                new W.TableLook { Val = "04A0", FirstRow = true }
            ));

            var headerCell = new W.TableCell(
                new W.Paragraph(
                    new W.ParagraphProperties(
                        new W.Justification { Val = W.JustificationValues.Center },
                        new W.SpacingBetweenLines { Before = "0", After = "0" }),
                    new W.Run(new W.RunProperties(new W.Bold()), new W.Text(textTitle ?? "Modifikasyon Önerisi"))
                ));
            headerCell.TableCellProperties = new W.TableCellProperties(
                new W.TableCellWidth { Type = W.TableWidthUnitValues.Pct, Width = "5000" },
                new W.Shading { Val = W.ShadingPatternValues.Clear, Fill = "B4C6E7" },
                new W.TableCellVerticalAlignment { Val = W.TableVerticalAlignmentValues.Center }
            );
            var headerRow = new W.TableRow(headerCell);
            headerRow.TableRowProperties = new W.TableRowProperties(new W.TableHeader());
            tablo.AppendChild(headerRow);

            var cell = new W.TableCell();
            cell.TableCellProperties = new W.TableCellProperties(
                new W.TableCellWidth { Type = W.TableWidthUnitValues.Pct, Width = "5000" }
            );

            W.Paragraph currentParagraph = null;
            bool hasContent = false;

            foreach (var el in docElements)
            {
                if (currentParagraph == null)
                    currentParagraph = new W.Paragraph();

                var runProps = new W.RunProperties();
                if (el.IsBold) runProps.Append(new W.Bold());
                if (el.IsItalic) runProps.Append(new W.Italic());
                if (el.IsUnderline) runProps.Append(new W.Underline() { Val = W.UnderlineValues.Single });
                if (!string.IsNullOrWhiteSpace(el.FontFamily)) runProps.Append(new W.RunFonts() { Ascii = el.FontFamily });
                if (el.FontSize > 0) runProps.Append(new W.FontSize() { Val = ((int)(el.FontSize * 2)).ToString() });
                if (el.ForeColor != null) runProps.Append(new W.Color { Val = el.ForeColor.Replace("#", "") });
                if (el.BackColor != null) runProps.Append(new W.Shading { Val = W.ShadingPatternValues.Clear, Fill = el.BackColor.Replace("#", "") });

                var run = new W.Run(runProps, new W.Text(el.Text ?? "") { Space = SpaceProcessingModeValues.Preserve });

                var pProps = new W.ParagraphProperties();
                if (el.Alignment != null)
                {
                    var justify = el.Alignment switch
                    {
                        "center" => W.JustificationValues.Center,
                        "right" => W.JustificationValues.Right,
                        "justify" => W.JustificationValues.Both,
                        _ => W.JustificationValues.Left
                    };
                    pProps.Append(new W.Justification { Val = justify });
                }
                if (el.LeftIndent != 0 || el.RightIndent != 0)
                {
                    pProps.Append(new W.Indentation
                    {
                        Left = el.LeftIndent != 0 ? PxToTwip(el.LeftIndent).ToString() : null,
                        Right = el.RightIndent != 0 ? PxToTwip(el.RightIndent).ToString() : null
                    });
                }
                if (el.SpaceBefore != 0 || el.SpaceAfter != 0)
                {
                    pProps.Append(new W.SpacingBetweenLines
                    {
                        Before = el.SpaceBefore.ToString(),
                        After = el.SpaceAfter.ToString()
                    });
                }
                if (el.IsBullet)
                {
                    pProps.Append(
                        new W.NumberingProperties(
                            new W.NumberingLevelReference() { Val = 0 },
                            new W.NumberingId() { Val = 1 }
                        )
                    );
                }
                if (!currentParagraph.Elements<W.ParagraphProperties>().Any())
                    currentParagraph.PrependChild(pProps);

                currentParagraph.Append(run);
                hasContent = true;

                if (el.IsParagraphEnd && hasContent)
                {
                    cell.Append(currentParagraph);
                    currentParagraph = new W.Paragraph();
                    hasContent = false;
                }
            }
            if (hasContent && currentParagraph != null)
                cell.Append(currentParagraph);

            var row = new W.TableRow(cell);
            tablo.AppendChild(row);
            return tablo;
        }
    }
}

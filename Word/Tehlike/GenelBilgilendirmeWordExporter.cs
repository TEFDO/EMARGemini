using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using EMAR.Models;
using EMAR.Word.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using W = DocumentFormat.OpenXml.Wordprocessing;

namespace EMAR.Word.Tehlike
{
    public static class GenelBilgilendirmeWordExporter
    {
        public static void Olustur(
            Risk risk,
            GenelBilgilendirme genel,
            RiskAzaltimi azaltim,
            string sablonYol,
            string hedefYol,
            string pictogramPath = null,
            string makineGorselPath = null)
        {
            if (genel == null)
                throw new Exception("Genel bilgilendirme verisi bulunamadı!");

            File.Copy(sablonYol, hedefYol, true);

            using (var doc = WordprocessingDocument.Open(hedefYol, true))
            {
                var mainPart = doc.MainDocumentPart;

                EnsureBulletNumbering(mainPart);
                SetTag(mainPart, "TehlikeNo", $"{risk.BolgeId}.{risk.RiskSira + 1}");
                SetTag(mainPart, "TT", genel.TehlikeTipi);
                SetTag(mainPart, "GA", genel.GorevAsamasi);
                SetTag(mainPart, "TH", genel.TehlikeHedefi);

                SetCheck(mainPart, "BP", genel.Bakim);
                SetCheck(mainPart, "O", genel.Operator);
                SetCheck(mainPart, "TG", genel.Temizlik);
                SetCheck(mainPart, "Z", genel.Ziyaretci);

                SetTag(mainPart, "YS", genel.S);
                SetTag(mainPart, "TMKS", genel.F);
                SetTag(mainPart, "TKI", genel.P);

                SetTag(mainPart, "OHD", genel.DPH.ToString());
                SetTag(mainPart, "KOO", genel.LO.ToString());
                SetTag(mainPart, "KO", genel.PA.ToString());
                SetTag(mainPart, "MKS", genel.FE.ToString());

                var converter = new RtfToOpenXmlConverter();
                var docElements = converter.ConvertRtfToElements(genel.TehlikeTanim);

                ReplacePlaceholderWithFormattedContent(mainPart, "{{TehlikeTanimlamasi}}", docElements);

                SetTag(mainPart, "RiskSkoru", genel.HRN);
                SetTag(mainPart, "LVL", genel.HRNSeviye);
                SetTag(mainPart, "PLG", genel.PLg);

                // Risk azaltım alanları
                if (azaltim != null)
                {
                    var alt = new RtfToOpenXmlConverter();
                    var azaltimonlem = alt.ConvertRtfToElements(azaltim.OnlemlerRTF);
                    ReplacePlaceholderWithFormattedContent(mainPart, "{{RİSKAZALTİM}}", azaltimonlem);

                    var asd = new RtfToOpenXmlConverter();
                    var artik = asd.ConvertRtfToElements(azaltim.ArtikRiskRTF);
                    ReplacePlaceholderWithFormattedContent(mainPart, "{{ARTİKRİSK}}", artik);

                    SetTag(mainPart, "ROHD", azaltim.Olasilik);
                    SetTag(mainPart, "RKOO", azaltim.KazaOlma);
                    SetTag(mainPart, "RKO", azaltim.Kacinma);
                    SetTag(mainPart, "RMKS", azaltim.MaruzKalma);
                    SetTag(mainPart, "AzaltilmisRiskSkoru", azaltim.HRN);
                    SetTag(mainPart, "RLVL", azaltim.HRNSeviye);
                    SetTag(mainPart, "ArtikRisk", azaltim.ArtikRiskRTF);
                }
                // Risk Skoru ve Seviyesi
                if (double.TryParse(genel.HRN, out double anaSkor))
                {
                    SetCellBackgroundColor(mainPart, "RiskSkoru", anaSkor);
                    SetCellBackgroundColor(mainPart, "LVL", anaSkor);
                }

                // Azaltılmış Risk Skoru ve Seviyesi
                if (azaltim != null && double.TryParse(azaltim.HRN, out double azaltimSkor))
                {
                    SetCellBackgroundColor(mainPart, "AzaltilmisRiskSkoru", azaltimSkor);
                    SetCellBackgroundColor(mainPart, "RLVL", azaltimSkor);
                }
                // --- Görseller (Thumbnail RAM optimizasyonu için stream'li load) ---
                if (!string.IsNullOrEmpty(pictogramPath) && File.Exists(pictogramPath))
                    AddImageToContentControl(mainPart, "pictogram", pictogramPath, emuWidth: 777600, emuHeight: 615600);

                if (!string.IsNullOrEmpty(makineGorselPath) && File.Exists(makineGorselPath))
                    AddImageToContentControl(mainPart, "makinegorseli", makineGorselPath, emuWidth: 2880000, emuHeight: 2160000);

                mainPart.Document.Save();
            }
        }
        // Word tablosunda ilgili Tag'e sahip alanın arka planını değiştirir
        private static void SetCellBackgroundColor(MainDocumentPart part, string tag, double skor)
        {
            var sdt = part.Document.Descendants<SdtElement>()
                .FirstOrDefault(x => x.SdtProperties.GetFirstChild<Tag>()?.Val == tag);

            if (sdt == null) return;

            var cell = sdt.Ancestors<W.TableCell>().FirstOrDefault();
            if (cell == null)
            {
                cell = sdt.Descendants<W.TableCell>().FirstOrDefault();
            }

            if (cell != null)
            {
                string colorHex = GetColorHex(skor);

                var props = cell.TableCellProperties ?? new W.TableCellProperties();
                // Önceki shading’i sil
                var oldShading = props.Elements<Shading>().FirstOrDefault();
                if (oldShading != null) props.RemoveChild(oldShading);

                // Yeni shading ekle
                props.Append(new Shading
                {
                    Val = ShadingPatternValues.Clear,
                    Color = "auto",
                    Fill = colorHex
                });
                cell.TableCellProperties = props;
            }
        }

        private static string GetColorHex(double skor)
        {
            if (skor <= 10) return "92D050";      // Açık yeşil
            else if (skor <= 45) return "FFC000"; // Turuncu
            else return "FF0000";                 // Kırmızı
        }

        private static void SetTag(MainDocumentPart part, string tag, string value)
        {
            var sdt = part.Document.Descendants<SdtElement>()
                .FirstOrDefault(x => x.SdtProperties.GetFirstChild<Tag>()?.Val == tag);
            if (sdt != null)
            {
                var txt = sdt.Descendants<W.Text>().FirstOrDefault();
                if (txt != null)
                    txt.Text = value ?? ""; // null veya "" ise boş bırakır (Word bozulmaz)
            }
        }


        private static void SetCheck(MainDocumentPart part, string tag, bool? value)
        {
            var sdt = part.Document.Descendants<SdtElement>()
                .FirstOrDefault(x => x.SdtProperties.GetFirstChild<Tag>()?.Val == tag);

            if (sdt != null)
            {
                var chk = sdt.Descendants<CheckBox>().FirstOrDefault();
                if (chk != null)
                {
                    var checkedProp = chk.Parent.Descendants<Checked>().FirstOrDefault();
                    if (checkedProp != null)
                        checkedProp.Val = value == true ? OnOffValue.FromBoolean(true) : OnOffValue.FromBoolean(false);
                }
                var txt = sdt.Descendants<W.Text>().FirstOrDefault();
                if (txt != null)
                    txt.Text = value == true ? "☒" : "☐";
            }
        }


        private static void AddImageToContentControl(MainDocumentPart part, string tag, string imagePath, long emuWidth, long emuHeight)
        {
            var sdt = part.Document.Descendants<SdtElement>()
                .FirstOrDefault(x => x.SdtProperties.GetFirstChild<Tag>()?.Val == tag);
            if (sdt == null) return;

            var oldDrawing = sdt.Descendants<Drawing>().FirstOrDefault();
            oldDrawing?.Remove();

            ImagePart imagePart = null;
            try
            {
                imagePart = part.AddImagePart(ImagePartType.Jpeg);
                using (var stream = File.OpenRead(imagePath))
                {
                    imagePart.FeedData(stream);
                }
            }
            catch
            {
                if (imagePart != null)
                {
                    // imagePart eklenmişse, dokümandan kaldır:
                    part.DeletePart(imagePart);
                }
                return;
            }

            var imageId = part.GetIdOfPart(imagePart);

            var element = new Drawing(
                new Inline(
                    new Extent() { Cx = emuWidth, Cy = emuHeight },
                    new EffectExtent { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L },
                    new DocProperties { Id = (UInt32Value)1U, Name = "Resim" },
                    new DocumentFormat.OpenXml.Drawing.Wordprocessing.NonVisualGraphicFrameDrawingProperties(new GraphicFrameLocks { NoChangeAspect = true }),
                    new Graphic(
                        new GraphicData(
                            new DocumentFormat.OpenXml.Drawing.Pictures.Picture(
                                new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties(
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties { Id = (UInt32Value)0U, Name = "Resim" },
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureDrawingProperties()),
                                new DocumentFormat.OpenXml.Drawing.Pictures.BlipFill(
                                    new Blip { Embed = imageId, CompressionState = BlipCompressionValues.Print },
                                    new Stretch(new FillRectangle())),
                                new DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties(
                                    new Transform2D(
                                        new Offset { X = 0, Y = 0 },
                                        new Extents { Cx = emuWidth, Cy = emuHeight }
                                    ),
                                    new PresetGeometry(new AdjustValueList()) { Preset = ShapeTypeValues.Rectangle }
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

            var para = sdt.Descendants<W.Paragraph>().FirstOrDefault();
            if (para != null)
            {
                para.RemoveAllChildren<W.Run>();
                para.AppendChild(new W.Run(element));
            }
            else
            {
                sdt.AppendChild(new W.Paragraph(new W.Run(element)));
            }
        }

        private static int PxToTwip(int px) => (int)(px * 15.0);

        public static void ReplacePlaceholderWithFormattedContent(MainDocumentPart mainPart, string placeholder, List<DocumentElement> elements)
        {
            var textNode = mainPart.Document.Descendants<W.Text>()
                .FirstOrDefault(t => t.Text.Contains(placeholder));
            if (textNode == null) return;

            var run = textNode.Parent as W.Run;
            var paragraph = run?.Parent as W.Paragraph;

            // Eğer paragraph yoksa (çok nadir), sadece run'ı sil ve boş bırak
            if (paragraph == null)
            {
                run?.Remove();
                return;
            }

            var parentElement = paragraph.Parent as OpenXmlCompositeElement;
            if (parentElement == null)
            {
                paragraph.Remove();
                return;
            }

            var paragraphList = parentElement.Elements<W.Paragraph>().ToList();
            int index = paragraphList.IndexOf(paragraph);

            // Eğer hiç veri yoksa veya elements boşsa:
            if (elements == null || elements.Count == 0)
            {
                // Silip, yerine boş paragraf ekle (Word hatası oluşmaz!)
                paragraph.Remove();
                parentElement.InsertAt(new W.Paragraph(), index);
                return;
            }

            // DEVAMI: (Sadece elements doluysa)
            var newParagraphs = new List<W.Paragraph>();
            W.Paragraph currentParagraph = new W.Paragraph();
            bool hasContent = false;

            foreach (var el in elements.OfType<ParagraphElement>())
            {
                if (el.IsParagraphEnd && hasContent)
                {
                    newParagraphs.Add(currentParagraph);
                    currentParagraph = new W.Paragraph();
                    hasContent = false;
                    continue;
                }

                var props = new W.RunProperties();
                if (el.IsBold) props.Append(new W.Bold());
                if (el.IsItalic) props.Append(new W.Italic());
                if (el.IsUnderline) props.Append(new W.Underline() { Val = W.UnderlineValues.Single });
                if (!string.IsNullOrWhiteSpace(el.FontFamily)) props.Append(new W.RunFonts() { Ascii = el.FontFamily });
                if (el.FontSize > 0) props.Append(new W.FontSize() { Val = ((int)(el.FontSize * 2)).ToString() });
                if (el.ForeColor != null) props.Append(new W.Color { Val = el.ForeColor.Replace("#", "") });
                if (el.BackColor != null) props.Append(new W.Shading { Val = W.ShadingPatternValues.Clear, Fill = el.BackColor.Replace("#", "") });

                var runNew = new W.Run(props, new W.Text(el.Text ?? "") { Space = SpaceProcessingModeValues.Preserve });

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

                currentParagraph.PrependChild(pProps);
                currentParagraph.Append(runNew);
                hasContent = true;
            }
            if (hasContent)
                newParagraphs.Add(currentParagraph);

            // Sil, yenileri ekle
            paragraph.Remove();
            for (int i = newParagraphs.Count - 1; i >= 0; i--)
                parentElement.InsertAt(newParagraphs[i], index);
        }
        public static void EnsureBulletNumbering(MainDocumentPart mainPart)
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
                                    new W.ParagraphProperties(new Indentation() { Left = "340" })
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
    }
}

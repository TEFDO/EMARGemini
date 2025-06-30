using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using EMAR.Models;
using EMAR.Repository;
using EMAR.Word.Helper;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using W = DocumentFormat.OpenXml.Wordprocessing;

namespace EMAR.Word.Tehlike
{
    public static class MevcutDurumWordExporter
    {
        public static void Olustur(Risk risk, MevcutDurum mevcut, string sablonYol, string hedefYol)
        {
            if (mevcut == null)
                throw new System.Exception("Mevcut Durum verisi bulunamadı!");

            File.Copy(sablonYol, hedefYol, true);

            using (var doc = WordprocessingDocument.Open(hedefYol, true))
            {
                var mainPart = doc.MainDocumentPart;

                SetTag(mainPart, "TehlikeNo", $"{risk.BolgeId}.{risk.RiskSira + 1}");

                var converter = new RtfToOpenXmlConverter();
                var docElements = converter.ConvertRtfToElements(mevcut.Metin);

                ReplacePlaceholderWithFormattedContent(mainPart, "{{MEVCUTDURUM}}", docElements);

                mainPart.Document.Save();
            }
        }

        private static void SetTag(MainDocumentPart part, string tag, string value)
        {
            var sdt = part.Document.Descendants<SdtElement>()
                .FirstOrDefault(x => x.SdtProperties.GetFirstChild<Tag>()?.Val == tag);
            if (sdt != null)
            {
                var txt = sdt.Descendants<W.Text>().FirstOrDefault();
                if (txt != null)
                    txt.Text = value ?? "";
            }
        }
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
        private static int PxToTwip(int px) => (int)(px * 15.0);
    }
}

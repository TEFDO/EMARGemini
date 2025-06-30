using EMAR.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EMAR.Word.Helper
{
    public class RtfToOpenXmlConverter
    {
        public List<DocumentElement> ConvertRtfToElements(string rtf)
        {
            var elements = new List<DocumentElement>();

            using (RichTextBox rtb = new RichTextBox())
            {
                rtb.Rtf = rtf ?? "";

                int charIndex = 0;
                int length = rtb.TextLength;
                int lineIndex = 0;

                while (charIndex < length)
                {
                    int lineStart = charIndex;
                    int lineLen = rtb.Lines.Length > lineIndex ? rtb.Lines[lineIndex].Length : 0;
                    int lineEnd = lineStart + lineLen;

                    while (charIndex < lineEnd)
                    {
                        rtb.Select(charIndex, 1);
                        var baseFont = rtb.SelectionFont;
                        var baseColor = rtb.SelectionColor;
                        var baseBackColor = rtb.SelectionBackColor;
                        var baseAlign = rtb.SelectionAlignment;
                        bool isBullet = rtb.SelectionBullet;

                        int segStart = charIndex;
                        while (charIndex < lineEnd)
                        {
                            rtb.Select(charIndex, 1);
                            if (!FontEqual(baseFont, rtb.SelectionFont) ||
                                baseColor != rtb.SelectionColor ||
                                baseBackColor != rtb.SelectionBackColor ||
                                baseAlign != rtb.SelectionAlignment)
                                break;
                            charIndex++;
                        }

                        int segLen = charIndex - segStart;
                        if (segLen > 0)
                        {
                            rtb.Select(segStart, segLen);
                            string selectedText = rtb.SelectedText;

                            if (!string.IsNullOrWhiteSpace(selectedText))
                            {
                                elements.Add(new ParagraphElement
                                {
                                    Text = RemoveInvalidXmlChars(selectedText),
                                    IsBold = baseFont?.Bold ?? false,
                                    IsItalic = baseFont?.Italic ?? false,
                                    IsUnderline = baseFont?.Underline ?? false,
                                    FontFamily = baseFont?.FontFamily?.Name ?? "Segoe UI",
                                    FontSize = baseFont?.Size ?? 11,
                                    ForeColor = ColorToHex(baseColor),
                                    BackColor = ColorToHex(baseBackColor),
                                    Alignment = AlignmentToString(baseAlign),
                                    LeftIndent = rtb.SelectionIndent,
                                    RightIndent = rtb.SelectionRightIndent,
                                    SpaceBefore = 0,
                                    SpaceAfter = 0,
                                    IsBullet = isBullet
                                });
                            }
                        }
                    }
                    // Paragraf sonu
                    elements.Add(new ParagraphElement { Text = "", IsParagraphEnd = true });

                    charIndex = lineEnd + 1; // +1 for newline
                    lineIndex++;
                }
            }
            return elements;
        }

        private string AlignmentToString(HorizontalAlignment align)
        {
            return align switch
            {
                HorizontalAlignment.Center => "center",
                HorizontalAlignment.Right => "right",
                _ => "left"
            };
        }

        public static string RemoveInvalidXmlChars(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            return new string(text.Where(
                ch => (ch == 0x9 || ch == 0xA || ch == 0xD ||
                       (ch >= 0x20 && ch <= 0xD7FF) ||
                       (ch >= 0xE000 && ch <= 0xFFFD) ||
                       (ch >= 0x10000 && ch <= 0x10FFFF))
            ).ToArray());
        }

        private bool FontEqual(Font a, Font b)
        {
            if (a == null || b == null) return false;
            return a.Bold == b.Bold &&
                   a.Italic == b.Italic &&
                   a.Underline == b.Underline &&
                   a.FontFamily.Name == b.FontFamily.Name &&
                   a.Size == b.Size;
        }

        private string ColorToHex(Color color)
        {
            if (color.IsEmpty) return null;
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }
    }
}

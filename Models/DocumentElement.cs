using System.Drawing;

namespace EMAR.Models
{
    public abstract class DocumentElement { }

    public class ParagraphElement : DocumentElement
    {
        public string Text { get; set; }
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
        public bool IsUnderline { get; set; }
        public string FontFamily { get; set; }
        public float FontSize { get; set; }
        public bool IsParagraphEnd { get; set; }

        // EKLEDİKLERİN:
        public string ForeColor { get; set; }    // "#RRGGBB"
        public string BackColor { get; set; }    // "#RRGGBB"
        public string Alignment { get; set; }    // "left" | "center" | "right" | "justify"
        public int LeftIndent { get; set; }      // twip cinsinden
        public int RightIndent { get; set; }     // twip cinsinden
        public int SpaceBefore { get; set; }     // twip cinsinden
        public int SpaceAfter { get; set; }      // twip cinsinden
        public bool IsBullet { get; set; } = false;

    }


    // Diğer sınıflar aynı kalacak...
}
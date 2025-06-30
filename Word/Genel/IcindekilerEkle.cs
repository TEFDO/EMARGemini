using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;

public static class IcindekilerEkle
{
    public static void Ekle(MainDocumentPart mainPart)
    {
        var body = mainPart.Document.Body;

        // Kapaktan sonra eklemek için ilk sayfa sonrasına ekle (veya başa ekle)
        // Burada en başa ekliyor, istersen body.Elements<Paragraph>().Skip(1).First() önüne de ekleyebilirsin

        // Sayfa sonu ile ayır
        body.AppendChild(new Paragraph(
            new Run(new Break() { Type = BreakValues.Page })
        ));

        // "İçindekiler" başlığını Heading 1 olarak ekle
        body.AppendChild(
            new Paragraph(
                new ParagraphProperties(
                    new ParagraphStyleId { Val = "Heading1" },
                    new Justification { Val = JustificationValues.Center },
                    new SpacingBetweenLines { After = "200" }
                ),
                new Run(
                    new RunProperties(
                        new Bold(),
                        new FontSize { Val = "32" } // 16 pt
                    ),
                    new Text("İÇİNDEKİLER")
                )
            )
        );

        // Asıl TOC (Table of Contents) alanı
        var tocPara = new Paragraph(
            new ParagraphProperties(
                new Justification { Val = JustificationValues.Left }
            ),
            new SimpleField() // Word’de alan kodu
            {
                Instruction = "TOC \\o \"1-3\" \\h \\z \\u",
                Dirty = true
            }
        );
        body.AppendChild(tocPara);

        // Sonra Word'de "İçindekiler Tablosunu Güncelle" dediğinde otomatik oluşur!
    }
}
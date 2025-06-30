using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Linq;

namespace EMAR.Word.Helper
{
    public static class EtiketDegistirici
    {
        /// <summary>
        /// Belge, header ve footer’da tüm placeholder’ları verilen değer ile değiştirir.
        /// </summary>
        public static void Degistir(MainDocumentPart mainPart, string placeholder, string value)
        {
            ReplaceInText(mainPart.Document.Body, placeholder, value);

            if (mainPart.HeaderParts != null)
            {
                foreach (var header in mainPart.HeaderParts)
                    if (header?.Header != null)
                        ReplaceInText(header.Header, placeholder, value);
            }

            if (mainPart.FooterParts != null)
            {
                foreach (var footer in mainPart.FooterParts)
                    if (footer?.Footer != null)
                        ReplaceInText(footer.Footer, placeholder, value);
            }
        }

        private static void ReplaceInText(OpenXmlElement element, string placeholder, string value)
        {
            if (string.IsNullOrEmpty(placeholder)) return;

            foreach (var text in element.Descendants<Text>())
            {
                if (string.IsNullOrEmpty(text.Text)) continue;
                if (text.Text.Contains(placeholder))
                    text.Text = text.Text.Replace(placeholder, value ?? "-");
            }
        }
    }
}
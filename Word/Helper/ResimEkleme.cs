using DocumentFormat.OpenXml.Packaging;
using A = DocumentFormat.OpenXml.Drawing;
using AP = DocumentFormat.OpenXml.Drawing.Pictures;
using WP = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using W = DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;

namespace EMAR.Word.Helper
{
    public static class ResimEkleme
    {
        public static void Yerlestir(MainDocumentPart mainPart, string placeholder, byte[] imageBytes, string imageName)
        {
            if (imageBytes == null || imageBytes.Length == 0) return;

            var body = mainPart.Document.Body;
            var text = body.Descendants<W.Text>().FirstOrDefault(t => t.Text.Contains(placeholder));
            if (text == null) return;

            var paragraph = text.Ancestors<W.Paragraph>().FirstOrDefault();
            if (paragraph == null) return;

            text.Text = string.Empty; // Placeholder'ı temizle

            ImagePart imagePart = null;
            string relationshipId = null;
            try
            {
                imagePart = mainPart.AddImagePart(ImagePartType.Png);
                using (var stream = new MemoryStream(imageBytes))
                    imagePart.FeedData(stream);

                relationshipId = mainPart.GetIdOfPart(imagePart);
            }
            catch
            {
                if (imagePart != null)
                    mainPart.DeletePart(imagePart);
                return;
            }

            // Standart çıktı boyutu (EMU)
            long cx = 990000L, cy = 792000L;

            var drawing = new W.Drawing(
                new WP.Inline(
                    new WP.Extent { Cx = cx, Cy = cy },
                    new WP.EffectExtent { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L },
                    new WP.DocProperties { Id = (UInt32Value)1U, Name = imageName },
                    new A.Graphic(
                        new A.GraphicData(
                            new AP.Picture(
                                new AP.NonVisualPictureProperties(
                                    new AP.NonVisualDrawingProperties { Id = (UInt32Value)0U, Name = imageName },
                                    new AP.NonVisualPictureDrawingProperties()
                                ),
                                new AP.BlipFill(
                                    new A.Blip { Embed = relationshipId },
                                    new A.Stretch(new A.FillRectangle())
                                ),
                                new AP.ShapeProperties(
                                    new A.Transform2D(
                                        new A.Offset { X = 0L, Y = 0L },
                                        new A.Extents { Cx = cx, Cy = cy }
                                    ),
                                    new A.PresetGeometry(new A.AdjustValueList())
                                    { Preset = A.ShapeTypeValues.Rectangle }
                                )
                            )
                        )
                        { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" }
                    )
                )
            );

            paragraph.Append(new W.Run(drawing));
        }
    }
}

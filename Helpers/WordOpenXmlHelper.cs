using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using System.Linq;
using EMAR.Models;
using EMAR.Repository;
using EMAR.Helpers;
using EMAR.Repositories;
using System.Collections.Generic;
using DocumentFormat.OpenXml;

public static class WordOpenXmlHelper
{
    private static void ReplacePlaceholderWithImage(MainDocumentPart mainPart, string placeholder, byte[] imageBytes, string imageName)
    {
        if (imageBytes == null || imageBytes.Length == 0) return;

        var body = mainPart.Document.Body;
        var text = body.Descendants<Text>().FirstOrDefault(t => t.Text.Contains(placeholder));
        if (text == null) return;

        var paragraph = text.Ancestors<Paragraph>().FirstOrDefault();
        if (paragraph == null) return;

        text.Text = string.Empty; // placeholder'ı temizle

        var imagePart = mainPart.AddImagePart(ImagePartType.Png);
        using (var stream = new MemoryStream(imageBytes))
        {
            imagePart.FeedData(stream);
        }

        string relationshipId = mainPart.GetIdOfPart(imagePart);

        var element = new Drawing(
            new DocumentFormat.OpenXml.Drawing.Wordprocessing.Inline(
                new DocumentFormat.OpenXml.Drawing.Wordprocessing.Extent
                {
                    Cx = 990000L, // genişlik (EMU)
                    Cy = 792000L  // yükseklik (EMU)
                },
                new DocumentFormat.OpenXml.Drawing.Wordprocessing.DocProperties
                {
                    Id = (UInt32Value)1U,
                    Name = imageName
                },
                new DocumentFormat.OpenXml.Drawing.Graphic(
                    new DocumentFormat.OpenXml.Drawing.GraphicData(
                        new DocumentFormat.OpenXml.Drawing.Pictures.Picture(
                            new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties(
                                new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties
                                {
                                    Id = (UInt32Value)0U,
                                    Name = imageName
                                },
                                new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureDrawingProperties()
                            ),
                            new DocumentFormat.OpenXml.Drawing.Pictures.BlipFill(
                                new DocumentFormat.OpenXml.Drawing.Blip
                                {
                                    Embed = relationshipId
                                },
                                new DocumentFormat.OpenXml.Drawing.Stretch(
                                    new DocumentFormat.OpenXml.Drawing.FillRectangle())
                            ),
                            new DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties(
                                new DocumentFormat.OpenXml.Drawing.Transform2D(
                                    new DocumentFormat.OpenXml.Drawing.Offset { X = 0L, Y = 0L },
                                    new DocumentFormat.OpenXml.Drawing.Extents { Cx = 990000L, Cy = 792000L }),
                                new DocumentFormat.OpenXml.Drawing.PresetGeometry(
                                    new DocumentFormat.OpenXml.Drawing.AdjustValueList()
                                )
                                { Preset = DocumentFormat.OpenXml.Drawing.ShapeTypeValues.Rectangle }
                            )
                        )
                    )
                    { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" }
                )
            )
        );

        var run = new Run(element);
        paragraph.Append(run);
    }

    public static void RaporuOlustur(Rapor rapor, string hedefYol)
    {
        File.Copy("Sablonlar/Kapak.docx", hedefYol, true);

        using var doc = WordprocessingDocument.Open(hedefYol, true);
        var mainPart = doc.MainDocumentPart;
        var body = mainPart.Document.Body;

        void AddFieldToAllParts(string placeholder, string value)
        {
            foreach (var text in body.Descendants<Text>())
                if (text.Text.Contains(placeholder))
                    text.Text = text.Text.Replace(placeholder, value ?? "-");

            foreach (var headerPart in mainPart.HeaderParts)
                foreach (var text in headerPart.Header.Descendants<Text>())
                    if (text.Text.Contains(placeholder))
                        text.Text = text.Text.Replace(placeholder, value ?? "-");

            foreach (var footerPart in mainPart.FooterParts)
                foreach (var text in footerPart.Footer.Descendants<Text>())
                    if (text.Text.Contains(placeholder))
                        text.Text = text.Text.Replace(placeholder, value ?? "-");
        }

        var dbYolu = $"{rapor.RaporKodu.Replace("-", "_")}.db";

        AddFieldToAllParts("@@RaporKodu@@", rapor.RaporKodu);
        AddFieldToAllParts("@@Tarih@@", rapor.Tarih);
        AddFieldToAllParts("@@ProjeKodu@@", rapor.ProjeKodu);
        AddFieldToAllParts("@@MakineAdi@@", rapor.MakineAdi);
        AddFieldToAllParts("@@RaporTuruKod@@", rapor.RaporTuruKod);
        AddFieldToAllParts("@@MusteriAdi@@", rapor.MusteriAdi);
        var musteri = MusteriRepository.Listele().FirstOrDefault(m => m.Ad == rapor.MusteriAdi);
        if (musteri?.Logo != null)
        {
            ReplacePlaceholderWithImage(mainPart, "@@Logo@@", musteri.Logo, "MusteriLogo");
        }


        var makine = MakineRepository.Getir(rapor.MakineId);
        if (makine != null)
        {
            AddFieldToAllParts("@@MakineOzeti@@", $"{makine.Tipi} - {makine.SeriNo} - {makine.UretimYili} - {makine.Sertifikasyon}");
            AddFieldToAllParts("@@Tipi@@", makine.Tipi);
            AddFieldToAllParts("@@SeriNo@@", makine.SeriNo);
            AddFieldToAllParts("@@UretimYili@@", makine.UretimYili.ToString());
            AddFieldToAllParts("@@Sertifikasyon@@", makine.Sertifikasyon);
            AddFieldToAllParts("@@Elektrik@@", makine.Elektrik);
            AddFieldToAllParts("@@Pnomatik@@", makine.Pnomatik);
            AddFieldToAllParts("@@Hidrolik@@", makine.Hidrolik);
            AddFieldToAllParts("@@Imalatci@@", makine.Imalatci);
            AddFieldToAllParts("@@KullanimAmaci@@", makine.KullanimAmaci);
            AddFieldToAllParts("@@KullaniciSeviyesi@@", makine.KullaniciSeviyesi);
            AddFieldToAllParts("@@PersonelTipi@@", makine.PersonelTipi);
            AddFieldToAllParts("@@BakimSikligi@@", makine.BakimSikligi);
            AddFieldToAllParts("@@MakineOlculeri@@", makine.MakineOlculeri);
            AddFieldToAllParts("@@ZamanLimitleri@@", makine.ZamanLimitleri);
            AddFieldToAllParts(placeholder: "@@MusteriAdresi@@", musteri.Adres);
        }

        void ReplacePlaceholderWithTable(string placeholder, string[] headers, List<string[]> rows)
        {
            var text = body.Descendants<Text>().FirstOrDefault(t => t.Text.Contains(placeholder));
            if (text == null) return;

            var parentPara = text.Ancestors<Paragraph>().FirstOrDefault();
            if (parentPara == null) return;

            var table = new Table(
                new TableProperties(
                    new TableBorders(
                        new TopBorder { Val = BorderValues.Single, Size = 6 },
                        new BottomBorder { Val = BorderValues.Single, Size = 6 },
                        new LeftBorder { Val = BorderValues.Single, Size = 6 },
                        new RightBorder { Val = BorderValues.Single, Size = 6 },
                        new InsideHorizontalBorder { Val = BorderValues.Single, Size = 6 },
                        new InsideVerticalBorder { Val = BorderValues.Single, Size = 6 }
                    ),
                    new TableWidth { Width = "100%", Type = TableWidthUnitValues.Pct }
                )
            );

            var headerRow = new TableRow();
            foreach (var h in headers)
                headerRow.Append(new TableCell(new Paragraph(new Run(new Text(h)))));
            table.Append(headerRow);

            foreach (var row in rows)
            {
                var tr = new TableRow();
                foreach (var cell in row)
                    tr.Append(new TableCell(new Paragraph(new Run(new Text(cell)))));
                table.Append(tr);
            }

            var parent = parentPara.Parent;
            parent.InsertAfter(table, parentPara);
            parentPara.Remove();
        }

        var revizyonlar = new RevizyonRepository(dbYolu).GetAll();
        if (revizyonlar.Any())
        {
            EkleRevizyonSatirlari(mainPart, revizyonlar
                .OrderByDescending(r => r.Revizyon) // En güncel en üste gelsin
                .Select(r => new[] { r.Revizyon, r.Tarih, r.Duzenleyen, r.Aciklama })
                .ToList());
        }

        var temsilciler = new TemsilciRepository(dbYolu).GetAll();
        if (temsilciler.Any())
        {
            ReplacePlaceholderWithTable("@@Temsilciler@@", new[] { "İsim", "Görev", "Firma" },
                temsilciler.Select(t => new[] { t.Isim, t.Gorev, t.Firma }).ToList());
        }

        var dokumanlar = new DokumanRepository(dbYolu).GetAll();
        if (dokumanlar.Any())
        {
            ReplacePlaceholderWithTable("@@DokumanListesi@@", new[] { "Ad", "Tarih", "Tip" },
                dokumanlar.Select(d => new[] { d.Ad, d.IletilmeTarihi, d.Tip }).ToList());
        }

        mainPart.Document.Save();
    }
    private static void EkleRevizyonSatirlari(MainDocumentPart part, List<string[]> rows)
    {
        var text = part.Document.Body.Descendants<Text>().FirstOrDefault(t => t.Text.Contains("@@RevizyonSatir@@"));
        if (text == null) return;

        var table = text.Ancestors<Table>().FirstOrDefault();
        var currentRow = text.Ancestors<TableRow>().FirstOrDefault();
        if (table == null || currentRow == null) return;

        text.Text = string.Empty;

        foreach (var rowData in rows)
        {
            var tr = new TableRow();
            foreach (var value in rowData)
            {
                var cell = new TableCell(
                    new Paragraph(
                        new ParagraphProperties(
                            new Justification { Val = JustificationValues.Center },
                            new SpacingBetweenLines
                            {
                                Before = "120",  // 6 pt boşluk önce
                                After = "120",   // 6 pt boşluk sonra
                                Line = "240",
                                LineRule = LineSpacingRuleValues.Auto
                            }
                        ),
                        new Run(new Text(value ?? ""))
                    ),
                    new TableCellProperties(
                        new TableCellBorders(
                            new TopBorder { Val = BorderValues.Single },
                            new BottomBorder { Val = BorderValues.Single },
                            new LeftBorder { Val = BorderValues.Single },
                            new RightBorder { Val = BorderValues.Single }
                        )
                    )
                );
                tr.Append(cell);
            }
            table.InsertAfter(tr, currentRow);
        }

        currentRow.Remove();
    }
}

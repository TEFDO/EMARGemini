using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Linq;

public static class INIHelper
{
    [DllImport("kernel32")]
    private static extern int GetPrivateProfileSection(string section, byte[] buffer, int size, string filePath);

    private static string iniPath = "ayarlar.ini";

    public static string Oku(string bolum, string anahtar)
    {
        if (!File.Exists(iniPath)) return null;

        var lines = File.ReadAllLines(iniPath);
        string aktifBolum = "";
        foreach (var line in lines)
        {
            var trimmed = line.Trim();
            if (string.IsNullOrWhiteSpace(trimmed) || trimmed.StartsWith(";"))
                continue;

            if (trimmed.StartsWith("[") && trimmed.EndsWith("]"))
            {
                aktifBolum = trimmed[1..^1];
                continue;
            }

            if (aktifBolum == bolum && trimmed.Contains('='))
            {
                var parca = trimmed.Split(new[] { '=' }, 2);
                if (parca[0].Trim() == anahtar)
                    return parca[1].Trim();
            }
        }

        return null;
    }

    public static List<(string Key, string Value)> OkuBolum(string bolum)
    {
        var sonuc = new List<(string, string)>();
        if (!File.Exists(iniPath)) return sonuc;

        var lines = File.ReadAllLines(iniPath);
        string aktifBolum = "";
        foreach (var line in lines)
        {
            var trimmed = line.Trim();
            if (string.IsNullOrWhiteSpace(trimmed) || trimmed.StartsWith(";"))
                continue;

            if (trimmed.StartsWith("[") && trimmed.EndsWith("]"))
            {
                aktifBolum = trimmed[1..^1];
                continue;
            }

            if (aktifBolum == bolum && trimmed.Contains('='))
            {
                var parca = trimmed.Split(new[] { '=' }, 2);
                sonuc.Add((parca[0].Trim(), parca[1].Trim()));
            }
        }

        return sonuc;
    }

    public static List<string> GetValues(string section)
    {
        byte[] buffer = new byte[4096];
        GetPrivateProfileSection(section, buffer, buffer.Length, iniPath);

        var entries = Encoding.ASCII.GetString(buffer)
            .Trim('\0')
            .Split('\0');

        List<string> result = new();
        foreach (var entry in entries)
        {
            var parts = entry.Split('=');
            if (parts.Length == 2)
                result.Add(parts[1]);
        }

        return result;
    }

    // ✅ CheckedListBox yüklemesi (virgüllü yapıdan)
    public static void YukleCommaSeparated(CheckedListBox clb, string bolum, string anahtar = "Degerler")
    {
        clb.Items.Clear();
        var raw = Oku(bolum, anahtar);
        if (!string.IsNullOrWhiteSpace(raw))
        {
            foreach (var deger in raw.Split(','))
                clb.Items.Add(deger.Trim());
        }
    }

    // ✅ ComboBox yüklemesi (virgüllü yapıdan)
    public static void YukleCommaSeparated(ComboBox cmb, string bolum, string anahtar = "Degerler")
    {
        cmb.Items.Clear();
        var raw = Oku(bolum, anahtar);
        if (!string.IsNullOrWhiteSpace(raw))
        {
            foreach (var deger in raw.Split(','))
                cmb.Items.Add(deger.Trim());
        }
    }

    // ✅ CheckedListBox yüklemesi (satır satır key=value yapıdan)
    public static void YukleKeyValue(CheckedListBox clb, string bolum)
    {
        clb.Items.Clear();
        var degerler = GetValues(bolum);
        foreach (var d in degerler)
            clb.Items.Add(d);
    }

    // ✅ ComboBox yüklemesi (satır satır key=value yapıdan)
    public static void YukleKeyValue(ComboBox cmb, string bolum)
    {
        cmb.Items.Clear();
        var degerler = GetValues(bolum);
        foreach (var d in degerler)
            cmb.Items.Add(d);
    }

    public static void GuncelleCommaSeparated(string baslik, ListBox lst)
    {
        string iniYolu = Path.Combine(Application.StartupPath, "ayarlar.ini");
        List<string> satirlar = new();

        foreach (string item in lst.Items)
            satirlar.Add(item.Trim());

        string icerik = string.Join(", ", satirlar);
        INIYaz(iniYolu, baslik, "Degerler", icerik);
    }

    public static void INIYaz(string iniYolu, string bolum, string anahtar, string deger)
    {
        var satirlar = File.Exists(iniYolu)
            ? new List<string>(File.ReadAllLines(iniYolu))
            : new List<string>();

        bool bolumVar = false;
        bool anahtarYazildi = false;
        for (int i = 0; i < satirlar.Count; i++)
        {
            if (satirlar[i].Trim().StartsWith("[") && satirlar[i].Trim().EndsWith("]"))
            {
                if (satirlar[i].Trim().Equals($"[{bolum}]", StringComparison.OrdinalIgnoreCase))
                {
                    bolumVar = true;
                    continue;
                }
                else if (bolumVar)
                {
                    // Bölüm bitti ama anahtar bulunamadı
                    satirlar.Insert(i, $"{anahtar} = {deger}");
                    anahtarYazildi = true;
                    break;
                }
            }

            if (bolumVar && satirlar[i].Contains("="))
            {
                var parca = satirlar[i].Split('=');
                if (parca[0].Trim().Equals(anahtar, StringComparison.OrdinalIgnoreCase))
                {
                    satirlar[i] = $"{anahtar} = {deger}";
                    anahtarYazildi = true;
                }
            }
        }
    }
    // ✅ ListBox versiyonu: ucAyarListesi için uyumlu
    public static void YukleCommaSeparated(ListBox lst, string bolum, string anahtar = "Degerler")
    {
        lst.Items.Clear();
        var raw = Oku(bolum, anahtar);
        if (!string.IsNullOrWhiteSpace(raw))
        {
            foreach (var deger in raw.Split(','))
                lst.Items.Add(deger.Trim());
        }
    }

}

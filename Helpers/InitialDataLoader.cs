using System.Collections.Generic;
using EMAR.Helpers;

public static class InitialDataLoader
{
    public static void Yukle()
    {
        YukleTablo("MakineTipleri", "Tip");
        YukleTablo("Sertifikasyonlar", "Kod");
        YukleTablo("ElektrikKaynaklari", "Ad");
        YukleTablo("PnomatikKaynaklari", "Ad");
        YukleTablo("HidrolikKaynaklari", "Ad");
    }

    private static void YukleTablo(string section, string kolon)
    {
        var entries = INIHelper.GetValues(section);
        VeritabaniHelper.KomutCalistir($"DELETE FROM {section}");

        foreach (var val in entries)
        {
            var prms = new Dictionary<string, object> { [$"@{kolon}"] = val };
            VeritabaniHelper.KomutCalistir(
                $"INSERT INTO {section} ({kolon}) VALUES (@{kolon})", prms
            );
        }
    }
}
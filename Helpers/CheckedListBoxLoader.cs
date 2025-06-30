using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EMAR.Helpers
{
    public static class CheckedListBoxLoader
    {
        public static void Yukle(CheckedListBox clb, string tablo)
        {
            clb.Items.Clear();
            var dt = VeritabaniHelper.TabloGetir($"SELECT Deger FROM {tablo}");
            foreach (DataRow row in dt.Rows)
                clb.Items.Add(row["Deger"].ToString());
        }
        public static void YukleINI(CheckedListBox clb, string bolumAdi)
        {
            clb.Items.Clear();
            var degerler = INIHelper.GetValues(bolumAdi); // sadece value listesi döner
            foreach (var deger in degerler)
                clb.Items.Add(deger);
        }

        public static void CheckDegerler(CheckedListBox clb, string degerler)
        {
            var dizi = (degerler ?? "").Split(';');
            for (int i = 0; i < clb.Items.Count; i++)
                clb.SetItemChecked(i, dizi.Contains(clb.Items[i].ToString()));
        }

        public static string SecimleriAl(CheckedListBox clb)
        {
            return string.Join(";", clb.CheckedItems.Cast<string>());
        }
    }
}
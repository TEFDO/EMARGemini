using System.Windows.Forms;

namespace EMAR.Helpers
{
    public static class FormValidator
    {
        public static bool ZorunluAlanlariKontrolEt(params (string ad, string deger)[] alanlar)
        {
            foreach (var (ad, deger) in alanlar)
            {
                if (string.IsNullOrWhiteSpace(deger))
                {
                    MessageBox.Show($"Lütfen {ad} alanını doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }
    }
}
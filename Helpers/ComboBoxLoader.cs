using System.Data;
using System.Windows.Forms;

namespace EMAR.Helpers
{
    public static class ComboBoxLoader
    {
        public static void Yukle(ComboBox cmb, string sql, string kolon)
        {
            cmb.Items.Clear();
            var dt = VeritabaniHelper.TabloGetir(sql);
            foreach (DataRow row in dt.Rows)
                cmb.Items.Add(row[kolon].ToString());
        }
    }
}
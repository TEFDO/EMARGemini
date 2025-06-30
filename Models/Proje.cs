using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAR.Models
{
    public class Proje
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string ProjeKodu { get; set; }
        public int MusteriId { get; set; }
        public string Tarih { get; set; } // SQLite uyumluluğu için string tutuluyor (yyyy-MM-dd)
        public string HizmetKodu { get; set; }
        public string Aciklama { get; set; }
        public string MusteriAd { get; set; } // Liste görünümü için

    }
}

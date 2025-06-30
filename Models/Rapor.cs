using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAR.Models
{
    public class Rapor
    {
        public int Id { get; set; }
        public int ProjeId { get; set; }
        public int MakineId { get; set; }
        public string RaporTuruKod { get; set; }  // ✅ artık string
        public string RaporKodu { get; set; }
        public string Tarih { get; set; }
        public int SiraNo { get; set; }

        // Görüntüleme için
        public string ProjeKodu { get; set; }
        public string MakineAdi { get; set; }
        public string MusteriAdi { get; set; }
    }

}


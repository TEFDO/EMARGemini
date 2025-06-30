using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAR.Models
{
    public class MevcutDurum
    {
        public int Id { get; set; }
        public int RiskId { get; set; }
        public string Metin { get; set; } // RTF metni
        public string Gorsel1 { get; set; } // Göreli yol
        public string Gorsel2 { get; set; }
        public string StandartlarJson { get; set; } // JSON metni
    }

}

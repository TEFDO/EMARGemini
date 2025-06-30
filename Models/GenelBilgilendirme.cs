using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAR.Models
{
    public class GenelBilgilendirme
    {
        public int Id { get; set; }
        public int RiskId { get; set; }
        public string TehlikeTipi { get; set; }
        public string GorevAsamasi { get; set; }
        public string TehlikeHedefi { get; set; }

        public string S { get; set; }
        public string F { get; set; }
        public string P { get; set; }

        public double DPH { get; set; }
        public double LO { get; set; }
        public double PA { get; set; }
        public double FE { get; set; }

        public string Gorsel { get; set; }
        public string Piktogram { get; set; }

        public string TehlikeTanim { get; set; }

        public bool Bakim { get; set; }
        public bool Temizlik { get; set; }
        public bool Operator { get; set; }
        public bool Ziyaretci { get; set; }
        public string HRNSeviye { get; set; }      // HRN Seviyesi
        public string HRN { get; set; }      // HRN Seviyesi
        public string PLg { get; set; }
    }

}

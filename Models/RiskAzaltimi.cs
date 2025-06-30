using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAR.Models
{
    public class RiskAzaltimi
    {
        public int Id { get; set; }
        public int RiskId { get; set; }
        public string Olasilik { get; set; }          // DPH
        public string KazaOlma { get; set; }          // LO
        public string Kacinma { get; set; }           // PA
        public string MaruzKalma { get; set; }        // FE
        public string HRN { get; set; }               // HRN
        public string OnlemlerRTF { get; set; }
        public string ArtikRiskRTF { get; set; }

        // Eksik olanları ekle (şablon için):
        
        public string HRNSeviye { get; set; }             // HRN Seviyesi
    }
}
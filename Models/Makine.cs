using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAR.Models
{
    public class Makine
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Imalatci { get; set; }
        public string SeriNo { get; set; }
        public string Tipi { get; set; }
        public int UretimYili { get; set; }
        public string Sertifikasyon { get; set; }
        public int MusteriId { get; set; }
        public string Elektrik { get; set; }
        public string Pnomatik { get; set; }
        public string Hidrolik { get; set; }
        public string MusteriAd { get; set; }
        public string KullanimAmaci { get; set; }
        public string KullaniciSeviyesi { get; set; }
        public string PersonelTipi { get; set; }
        public string BakimSikligi { get; set; }
        public string MakineOlculeri { get; set; }
        public string ZamanLimitleri { get; set; }
        public string Name { get; set; }
        public string DigerEnerjiKaynaklari { get; set; }
        public override string ToString() => Ad;
    }
}



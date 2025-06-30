// Models/RiskDetayViewModel.cs
namespace EMAR.Models
{
    public class RiskDetayViewModel
    {
        public int BolgeNo { get; set; }      // BölgeId'yi doğrudan taşı
        public int RiskNo { get; set; }       // Sıra veya custom no
        public Risk Risk { get; set; }
        public GenelBilgilendirme GenelBilgi { get; set; }
    }
}
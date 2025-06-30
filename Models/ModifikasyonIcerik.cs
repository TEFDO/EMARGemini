namespace EMAR.Models
{
    public class ModifikasyonIcerik
    {
        public int Id { get; set; }
        public int RiskId { get; set; }
        public string Tip { get; set; } // "text" veya "gorsel"
        public string Icerik { get; set; } // RTF veya JSON
        public int Siralama { get; set; }
    }

}
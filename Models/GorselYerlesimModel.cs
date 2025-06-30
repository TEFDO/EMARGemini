// Models/GorselYerlesimModel.cs

using System;

namespace EMAR.Models
{
    [Serializable]
    public class GorselYerlesimModel
    {
        public string ImagePath { get; set; }        // Rapor köküne göre RELATIVE path
        public string Title { get; set; }            // Görsel başlığı
        public bool IsFill { get; set; }             // Wordde tabloya yayılacak mı
        public bool IsCenter { get; set; }           // Ortalansın mı
        public int Row { get; set; }                 // Tablo satırı (Word)
        public int Column { get; set; }              // Tablo sütunu (Word)
        public int GridRows { get; set; }            // Tablo toplam satır sayısı (Word)
        public int GridColumns { get; set; }         // Tablo toplam sütun sayısı (Word)
        public int LayoutType { get; set; } = 0; // 0 = 2 sütun, 1 = tek sütun

    }
}
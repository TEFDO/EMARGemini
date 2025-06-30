// Word/OlcuHelper.cs

namespace EMAR.Word.Helper
{
    public static class OlcuHelper
    {
        public static long CmToEmu(double cm)
        {
            return (long)(cm * 360000);
        }
    }
}
﻿// ------------------------------------------------------------------------------
// <auto-generated>
// Bu kod araç tarafından oluşturuldu.
// Çalışma Zamanı Sürümü:4.0.30319.42000
// 
// Bu dosyada yapılacak değişiklikler yanlış davranışa neden olabilir ve
// kod yeniden oluşturulursa kaybolur.
// </auto-generated>
// ------------------------------------------------------------------------------


using System.Diagnostics;
using System.Drawing;
using Microsoft.VisualBasic;

namespace EMAR.My.Resources
{

    // Bu sınıf ResGen veya Visual Studio gibi bir araç kullanılarak StronglyTypedResourceBuilder
    // sınıfı tarafından otomatik olarak oluşturuldu.
    // Üye eklemek veya kaldırmak için .ResX dosyanızı düzenleyin ve sonra da ResGen
    // komutunu /str seçeneğiyle yeniden çalıştırın veya VS projenizi yeniden oluşturun.
    /// <summary>
    /// Yerelleştirilmiş dizeleri aramak gibi işlemler için, türü kesin olarak belirtilmiş kaynak sınıfı.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [DebuggerNonUserCode()]
    [System.Runtime.CompilerServices.CompilerGenerated()]
    [HideModuleName()]
    internal static class Resources
    {

        private static System.Resources.ResourceManager resourceMan;

        private static System.Globalization.CultureInfo resourceCulture;

        /// <summary>
        /// Bu sınıf tarafından kullanılan, önbelleğe alınmış ResourceManager örneğini döndürür.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (ReferenceEquals(resourceMan, null))
                {
                    var temp = new System.Resources.ResourceManager("EMAR.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        /// <summary>
        /// Tümü için geçerli iş parçacığının CurrentUICulture özelliğini geçersiz kular
        /// CurrentUICulture özelliğini tüm kaynak aramaları için geçersiz kılar.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        /// <summary>
        /// System.Drawing.Bitmap türünde yerelleştirilmiş bir kaynak arar.
        /// </summary>
        internal static Bitmap tefdo
        {
            get
            {
                var obj = ResourceManager.GetObject("tefdo", resourceCulture);
                return (Bitmap)obj;
            }
        }
    }
}
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace EMAR.My
{
    internal static partial class MyProject
    {
        internal partial class MyForms
        {

            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmAyarlar m_frmAyarlar;

            public frmAyarlar frmAyarlar
            {
                [DebuggerHidden]
                get
                {
                    m_frmAyarlar = Create__Instance__(m_frmAyarlar);
                    return m_frmAyarlar;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmAyarlar))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmAyarlar);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmMain m_frmMain;

            public frmMain frmMain
            {
                [DebuggerHidden]
                get
                {
                    m_frmMain = Create__Instance__(m_frmMain);
                    return m_frmMain;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmMain))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmMain);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmMakineKayit m_frmMakineKayit;

            public frmMakineKayit frmMakineKayit
            {
                [DebuggerHidden]
                get
                {
                    m_frmMakineKayit = Create__Instance__(m_frmMakineKayit);
                    return m_frmMakineKayit;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmMakineKayit))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmMakineKayit);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmMakineler m_frmMakineler;

            public frmMakineler frmMakineler
            {
                [DebuggerHidden]
                get
                {
                    m_frmMakineler = Create__Instance__(m_frmMakineler);
                    return m_frmMakineler;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmMakineler))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmMakineler);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmMakineLimitleri m_frmMakineLimitleri;

            public frmMakineLimitleri frmMakineLimitleri
            {
                [DebuggerHidden]
                get
                {
                    m_frmMakineLimitleri = Create__Instance__(m_frmMakineLimitleri);
                    return m_frmMakineLimitleri;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmMakineLimitleri))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmMakineLimitleri);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmMusteriKayit m_frmMusteriKayit;

            public frmMusteriKayit frmMusteriKayit
            {
                [DebuggerHidden]
                get
                {
                    m_frmMusteriKayit = Create__Instance__(m_frmMusteriKayit);
                    return m_frmMusteriKayit;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmMusteriKayit))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmMusteriKayit);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmMusteriler m_frmMusteriler;

            public frmMusteriler frmMusteriler
            {
                [DebuggerHidden]
                get
                {
                    m_frmMusteriler = Create__Instance__(m_frmMusteriler);
                    return m_frmMusteriler;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmMusteriler))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmMusteriler);
                }
            }


            //[EditorBrowsable(EditorBrowsableState.Never)]
            //public frmProje m_frmProje;

            //public frmProje frmProje
            //{
            //    [DebuggerHidden]
            //    get
            //    {
            //        m_frmProje = Create__Instance__(m_frmProje);
            //        return m_frmProje;
            //    }
            //    [DebuggerHidden]
            //    set
            //    {
            //        if (ReferenceEquals(value, m_frmProje))
            //    return;
            //if (value is not null)
            //    throw new ArgumentException("Property can only be set to Nothing");
            //        Dispose__Instance__(ref m_frmProje);
            //    }
            //}


            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmProjeKayit m_frmProjeKayit;

            public frmProjeKayit frmProjeKayit
            {
                [DebuggerHidden]
                get
                {
                    m_frmProjeKayit = Create__Instance__(m_frmProjeKayit);
                    return m_frmProjeKayit;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmProjeKayit))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmProjeKayit);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmProjeler m_frmProjeler;

            public frmProjeler frmProjeler
            {
                [DebuggerHidden]
                get
                {
                    m_frmProjeler = Create__Instance__(m_frmProjeler);
                    return m_frmProjeler;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmProjeler))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmProjeler);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmProjeyeMakineEkle m_frmProjeyeMakineEkle;

            public frmProjeyeMakineEkle frmProjeyeMakineEkle
            {
                [DebuggerHidden]
                get
                {
                    m_frmProjeyeMakineEkle = Create__Instance__(m_frmProjeyeMakineEkle);
                    return m_frmProjeyeMakineEkle;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmProjeyeMakineEkle))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmProjeyeMakineEkle);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmRapor m_frmRapor;

            public frmRapor frmRapor
            {
                [DebuggerHidden]
                get
                {
                    m_frmRapor = Create__Instance__(m_frmRapor);
                    return m_frmRapor;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmRapor))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmRapor);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmRaporKayit m_frmRaporKayit;

            public frmRaporKayit frmRaporKayit
            {
                [DebuggerHidden]
                get
                {
                    m_frmRaporKayit = Create__Instance__(m_frmRaporKayit);
                    return m_frmRaporKayit;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmRaporKayit))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmRaporKayit);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmRaporlar m_frmRaporlar;

            public frmRaporlar frmRaporlar
            {
                [DebuggerHidden]
                get
                {
                    m_frmRaporlar = Create__Instance__(m_frmRaporlar);
                    return m_frmRaporlar;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmRaporlar))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmRaporlar);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmRASCDetay m_frmRASCDetay;

            public frmRASCDetay frmRASCDetay
            {
                [DebuggerHidden]
                get
                {
                    m_frmRASCDetay = Create__Instance__(m_frmRASCDetay);
                    return m_frmRASCDetay;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmRASCDetay))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmRASCDetay);
                }
            }

        }


    }
}
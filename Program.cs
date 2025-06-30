using System;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EMAR
{
    static class Program
    {
        [STAThread()]
        public static void Main()
        {
            // 🟢 RtfPipe için encoding desteği
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            // 1) Global exception handlers
            Application.ThreadException += OnThreadException;
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

            // 3) High‑DPI / visual style setup
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 4) Run main form (wrapped in Using for disposal)
            using (var anaForm = new frmMain())
            {
                Application.Run(anaForm);
            }
        }

        /// <summary>
        /// Catches all exceptions thrown on the WinForms (UI) thread.
        /// </summary>
        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Beklenmeyen bir UI hatası oluştu:" + Constants.vbCrLf + e.Exception.Message, "Uygulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // TODO: log to file, remote server, etc.
        }

        /// <summary>
        /// Catches all non‑UI exceptions (background threads, etc.).
        /// </summary>
        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            string msg = ex is not null ? ex.Message : "Bilinmeyen bir hata";
            MessageBox.Show("Beklenmeyen bir arka‑plan hatası oluştu:" + Constants.vbCrLf + msg, "Uygulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // TODO: log to file, remote server, etc.
        }
    }
}

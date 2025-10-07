using snake_windows_forms.Models;

namespace snake_windows_forms
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Windows Forms alapbeállítások
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Alkalmazás indítása
            Application.Run(new Form1());
        }
    }
}
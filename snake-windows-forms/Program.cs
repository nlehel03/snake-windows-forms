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
            // Windows Forms alapbe�ll�t�sok
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Alkalmaz�s ind�t�sa
            Application.Run(new Form1());
        }
    }
}
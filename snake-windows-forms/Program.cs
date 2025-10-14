using snake_windows_forms.Models;
using snake_windows_forms.View;

namespace snake_windows_forms
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenuView());
        }
    }
}
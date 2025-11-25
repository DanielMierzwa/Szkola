global using DangerousFigure = System.Diagnostics.Process;

namespace OopPaint
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}

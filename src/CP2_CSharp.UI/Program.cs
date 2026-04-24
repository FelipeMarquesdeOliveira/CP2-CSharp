namespace CP2_CSharp.UI;

/// <summary>
/// Entry point - RM556319 Felipe Marques de Oliveira | RM556309 Gabriel Barros Cisoto
/// </summary>
internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}

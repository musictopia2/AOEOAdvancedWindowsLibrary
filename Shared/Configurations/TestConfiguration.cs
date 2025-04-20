using System.Windows;

namespace AOEOAdvancedWindowsLibrary.Shared.Configurations;
public static class TestConfiguration
{
    public static Window? Window { get; set; } = null!;
    public static string TestingProcess { get; set; } = "Testing Quest";
    public static bool CanGoBack { get; set; } = false;
    public static void MinimizeWindow()
    {
        if (Window is not null)
        {
            Window.WindowState = WindowState.Minimized;
        }
    }
}

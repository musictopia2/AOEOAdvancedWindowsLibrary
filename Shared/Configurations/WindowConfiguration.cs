using System.Windows;
namespace AOEOAdvancedWindowsLibrary.Shared.Configurations;
public static class WindowConfiguration
{
    public static Window? Window { get; set; } = null!;
    public static void MinimizeWindow()
    {
        if (Window is not null)
        {
            Window.WindowState = WindowState.Minimized;
        }
    }
    public static void RestoreWindow()
    {
        if (Window is not null && Window.WindowState == WindowState.Minimized)
        {
            Window.WindowState = WindowState.Normal;
            Window.Activate();
        }
    }
    public static bool IsMinimized => Window?.WindowState == WindowState.Minimized;

}

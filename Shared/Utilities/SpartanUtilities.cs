namespace AOEOAdvancedWindowsLibrary.Shared.Utilities;
public static class SpartanUtilities
{
    public static void ExitSpartan()
    {
        foreach (var process in Process.GetProcessesByName("Spartan"))
        {
            try
            {
                process.Kill();
                process.WaitForExit(); // Optional: ensures it's fully terminated
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not kill process: {ex.Message}");
            }
        }
    }
    public static bool IsSpartanRunning()
    {
        var process = Process.GetProcessesByName("Spartan").FirstOrDefault();
        if (process is null || process.HasExited)
        {
            return false;
        }
        return true;
    }
}
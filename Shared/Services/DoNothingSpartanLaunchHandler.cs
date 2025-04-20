namespace AOEOAdvancedWindowsLibrary.Shared.Services;
public class DoNothingSpartanLaunchHandler : ISpartanLaunchHandler
{
    void ISpartanLaunchHandler.OnSpartanLaunched()
    {
        //they chose to do nothing.  this means everything is manually done.
    }
}
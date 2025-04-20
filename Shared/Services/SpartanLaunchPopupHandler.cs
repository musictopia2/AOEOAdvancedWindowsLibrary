namespace AOEOAdvancedWindowsLibrary.Shared.Services;
public class SpartanLaunchPopupHandler(IOpenSimplePopup pop,
    ISpartanMonitor monitor
    ) : ISpartanLaunchHandler
{
    private CancellationToken _cts;
    void ISpartanLaunchHandler.OnSpartanLaunched()
    {
        if (_cts.CanBeCanceled)
        {
            monitor.StopWatching(); // clean up existing if any
        }
        _cts = monitor.RegisterWatcher(EnumSpartaExitStage.Open);
        pop.OpenPopup(SpartanPopupConfiguration.Key, SpartanPopupConfiguration.Message, _cts, Closed);
    }
    void Closed()
    {
        //this means the popup was closed.
        monitor.StopWatching();
    }
}
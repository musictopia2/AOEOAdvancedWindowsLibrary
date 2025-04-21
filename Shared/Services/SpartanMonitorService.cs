namespace AOEOAdvancedWindowsLibrary.Shared.Services;
public class SpartanMonitorService(ISpartanExitHandler exit) : ISpartanMonitor, IDisposable
{
    private CancellationTokenSource? _cts;
    //make protected so the editor would now show this as gray (not in use).
    protected Task? _watchTask;
    CancellationToken ISpartanMonitor.RegisterWatcher(EnumSpartaExitStage stage)
    {
        _cts?.Cancel();
        _cts?.Dispose();
        _cts = new CancellationTokenSource();
        _watchTask = MonitorAsync(stage, _cts.Token);
        return _cts.Token;
    }
    private async Task MonitorAsync(EnumSpartaExitStage stage, CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            if (SpartanUtilities.IsSpartanRunning() == false)
            {
                StopWatching();
                await exit.ExitSpartanAsync(stage);
                break;
            }
            //var process = Process.GetProcessesByName("Spartan").FirstOrDefault();
            //if (process is null || process.HasExited)
            //{
            //    StopWatching();
            //    await exit.ExitSpartanAsync(stage);
            //    break;
            //}
            await Task.Delay(1000, token);
        }
    }
    private void StopWatching()
    {
        _cts?.Cancel();
        _watchTask = null;
    }
    void ISpartanMonitor.StopWatching()
    {
        StopWatching();
    }
    public void Dispose()
    {
        _cts?.Cancel();
        _cts?.Dispose();
        GC.SuppressFinalize(this);
    }
}
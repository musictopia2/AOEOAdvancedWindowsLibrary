namespace AOEOAdvancedWindowsLibrary.Shared.Interfaces;
public interface ISpartanMonitor
{
    /// <summary>
    /// Starts watching Spartan and returns a token. Optional onExit action runs if it closes.
    /// </summary>
    CancellationToken RegisterWatcher(EnumSpartaExitStage stage);
    void StopWatching();
}
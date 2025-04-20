namespace AOEOAdvancedWindowsLibrary.Shared.Interfaces;
public interface ISpartanExitHandler
{
    Task ExitSpartanAsync(EnumSpartaExitStage stage);
}
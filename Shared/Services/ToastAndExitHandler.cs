namespace AOEOAdvancedWindowsLibrary.Shared.Services;
public class ToastAndExitHandler(IOpenTimedPopup pop, IExit exit) : ISpartanExitHandler
{
    async Task ISpartanExitHandler.ExitSpartanAsync(EnumSpartaExitStage stage)
    {
        string message;
        message = $"Spartan Exited At Stage {stage}";
        await pop.OpenPopupAsync(message, 500);
        exit.ExitApp();
    }
}
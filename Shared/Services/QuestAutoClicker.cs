namespace AOEOAdvancedWindowsLibrary.Shared.Services;
public class QuestAutoClicker(LocationContainer locationContainer
    , ISpartanMonitor monitor,
    ISpartanQuestRequested quest
    ) : ISpartanReady, IAfterCloseSimplePopup
{
    async void IAfterCloseSimplePopup.FinishProcess()
    {
        await LaunchAsync();
    }
    private async Task LaunchAsync()
    {
        if (locationContainer.Locations.Count == 0)
        {
            StartQuest();
            return; //just do nothing
        }
        CancellationToken token = monitor.RegisterWatcher(EnumSpartaExitStage.AutoClicking);
        await aa1.ClickSeveralLocationsAsync(locationContainer.Locations, 500, token);
        WindowConfiguration.MinimizeWindow();
        if (token.IsCancellationRequested)
        {
            //the monitor already handled this.
            return;
        }
        monitor.StopWatching();
        StartQuest();
    }
    async Task ISpartanReady.LoadQuestAsync()
    {
        await LaunchAsync();

    }
    private void StartQuest()
    {
        WindowConfiguration.MinimizeWindow();
        quest.Monitor();
    }
}
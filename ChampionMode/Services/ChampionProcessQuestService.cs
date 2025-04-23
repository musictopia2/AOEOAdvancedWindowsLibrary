namespace AOEOAdvancedWindowsLibrary.ChampionMode.Services;
public class ChampionProcessQuestService(
    ChampionSharedQuestProcessor processor,
    QuestFileContainer questFileContainer
    ) : IProcessQuestService
{
    async Task IProcessQuestService.ProcessQuestAsync()
    {
        if (ll1.MainLocation == "")
        {
            throw new CustomBasicException("Must set up ahead of time now.  Since locations can change");
        }
        if (dd1.NewGamePath == "")
        {
            throw new CustomBasicException("Must set the new game path ahead of time now");
        }
        if (string.IsNullOrWhiteSpace(questFileContainer.FileName))
        {
            throw new CustomBasicException("Must set the quest file ahead of time");
        }
        await processor.ProcessQuestAsync(questFileContainer.QuestPath);
    }
}
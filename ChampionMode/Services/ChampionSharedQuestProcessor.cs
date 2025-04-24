namespace AOEOAdvancedWindowsLibrary.ChampionMode.Services;
public class ChampionSharedQuestProcessor(
    IPlayQuestService playService,
    ICharacterBusinessService characterService,
    ITechBusinessService businessService,
    ITacticsBusinessService tactics,
    IUnitProcessor units,
    IQuestSettings questSettings,
    IQuestConfigurator configurator,
    IClickLocationProvider location,
    ISpartanLaunchHandler launch,
    IGlobalTechStrategy global,
    StatusContainer statusContainer
    )
{
    public async Task ProcessQuestAsync(string oldQuestPath)
    {
        if (ll1.MainLocation == "")
        {
            throw new CustomBasicException("Must set up ahead of time now.  Since locations can change");
        }
        if (dd1.NewGamePath == "")
        {
            throw new CustomBasicException("Must set the new game path ahead of time now");
        }
        ResetQuestSettingsClass.ResetQuests(questSettings);
        await configurator.ConfigureAsync(questSettings);
        await businessService.DoAllTechsAsync(); //i think
        await characterService.CopyCharacterFilesAsync();
        //comes from the quest service.
        XElement source = XElement.Load(oldQuestPath);
        source.MakeChampionMode();
        //something else needs to populate this.
        source.AddAccommodationQuestExtensions(questSettings, global);
        source.Save(dd1.NewQuestPath);
        string content = ff1.AllText(dd1.NewQuestPath);
        content = content.Replace("<onlycountelites>true</onlycountelites>", "<onlycountelites>false</onlycountelites>");
        ff1.WriteAllText(dd1.NewQuestPath, content); //i think i need this too.
        source = units.GetUnitXML();
        source.Save(dd1.NewUnitLocation);
        //await businessService.DoAllTechsAsync();
        await businessService.DoAllTechsAsync();
        tactics.DoAllTactics();
        SpartanUtilities.ExitSpartan(); //if there are any opened, must be closed.
        playService.OpenOfflineGame(dd1.SpartanDirectoryPath);
        location.PopulateClickLocations();
        statusContainer.StartPlaying();
        launch.OnSpartanLaunched();
    }
}
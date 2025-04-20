namespace AOEOAdvancedWindowsLibrary.ChampionMode.ViewModels;
public class ChampionTestSingleQuestViewModel(IChooseCivViewModel civVM,
    IQuestLocatorService questService,
    IPlayQuestService playService,
    ICharacterBusinessService characterService,
    ITechBusinessService businessService,
    ITacticsBusinessService tactics,
    IUnitProcessor units,
    IQuestSettings questSettings,
    IQuestConfigurator configurator,
    IClickLocationProvider location,
    ISpartanLaunchHandler launch,
    IGlobalTechStrategy global
    ) : IPlayQuestViewModel
{
    private string SpecialTitle() => $"{TestConfiguration.TestingProcess} For Civilization {civVM.CivilizationChosen!.FullName}";
    string IPlayQuestViewModel.Title => civVM.Title(SpecialTitle);
    bool IPlayQuestViewModel.CanGoBack => TestConfiguration.CanGoBack;
    async Task IPlayQuestViewModel.PlayCivAsync()
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
        configurator.Configure(questSettings);
        await businessService.DoAllTechsAsync(); //i think
        await characterService.CopyCharacterFilesAsync();

        //comes from the quest service.
        XElement source = XElement.Load(questService.OldQuestPath);
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
        playService.OpenOfflineGame(dd1.SpartanDirectoryPath);
        location.PopulateClickLocations();
        launch.OnSpartanLaunched();
    }
    void IPlayQuestViewModel.ResetCiv()
    {
        civVM.ResetCiv();
    }
}
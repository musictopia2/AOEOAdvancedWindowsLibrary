namespace AOEOAdvancedWindowsLibrary.Shared.Interfaces;
public interface IQuestConfigurator
{
    Task ConfigureAsync(IQuestSettings questSettings);
}
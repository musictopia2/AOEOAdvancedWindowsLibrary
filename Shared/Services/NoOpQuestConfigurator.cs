namespace AOEOAdvancedWindowsLibrary.Shared.Services;
public class NoOpQuestConfigurator : IQuestConfigurator
{
    Task IQuestConfigurator.ConfigureAsync(IQuestSettings questSettings)
    {
        //this is when a person will not change the settings at all.
        //if a person is playing around with quest settings for test purposes, create your own class for this.
        return Task.CompletedTask;
    }
}
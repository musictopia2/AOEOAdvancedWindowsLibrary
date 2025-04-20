namespace AOEOAdvancedWindowsLibrary.Shared.Services;
public class ToastQuestEnder(IOpenTimedPopup pop) : ISpartaQuestEnded
{
    async void ISpartaQuestEnded.EndQuest(EnumSpartaQuestResult result, string time)
    {
        string message;
        if (result == EnumSpartaQuestResult.Completed)
        {
            message = $"Quest completed in {time}";
        }
        else if (result == EnumSpartaQuestResult.Failed)
        {
            message = $"Quest failed in {time}";
        }
        else
        {
            throw new CustomBasicException("Invalid result");
        }
        await pop.OpenPopupAsync(message, 2000);
    }
}
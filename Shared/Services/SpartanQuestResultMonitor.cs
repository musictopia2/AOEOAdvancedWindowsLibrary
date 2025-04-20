namespace AOEOAdvancedWindowsLibrary.Shared.Services;
public partial class SpartanQuestResultMonitor(
    ICaptureGrayScaleMask capture
    , IOcrProcessor ocr,
    ISpartanMonitor monitor,
    ISpartaQuestEnded end
    ) : ISpartanQuestRequested
{
    async void ISpartanQuestRequested.Monitor()
    {
        CancellationToken token = monitor.RegisterWatcher(EnumSpartaExitStage.PlayingQuest);
        await RunCaptureLoopAsync(token);
    }
    private async Task RunCaptureLoopAsync(CancellationToken token)
    {
        EnumSpartaQuestResult result;
        while (!token.IsCancellationRequested)
        {
            result = GetResults();
            if (result != EnumSpartaQuestResult.Ongoing)
            {
                string time = GetTime();
                end.EndQuest(result, time);
                return;
            }
            await Task.Delay(5000, token); // optional: cancels delay if token is canceled
        }
    }
    private string GetTime()
    {
        Rectangle bounds = OcrConfiguration.TimerRegion;
        using Bitmap bitmap = capture.CaptureMaskedBitmap(bounds);
        string text = ocr.GetText(bitmap);
        var timeMatch = TimeMatch().Match(text);
        if (timeMatch.Success)
        {
            return timeMatch.Value;
        }
        return "";
    }
    private EnumSpartaQuestResult GetResults()
    {
        Rectangle bounds = OcrConfiguration.QuestStatusRegion;
        using Bitmap bitmap = capture.CaptureMaskedBitmap(bounds);
        string text = ocr.GetText(bitmap);
        if (text.Contains(OcrConfiguration.SuccessMessage))
        {
            return EnumSpartaQuestResult.Completed;
        }
        if (text.Contains(OcrConfiguration.FailureMessage))
        {
            return EnumSpartaQuestResult.Failed;
        }
        return EnumSpartaQuestResult.Ongoing;
    }
    [GeneratedRegex(@"\b\d{2}:\d{2}:\d{2}\b")]
    private static partial Regex TimeMatch();
}
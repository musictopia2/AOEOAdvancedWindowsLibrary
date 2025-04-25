namespace AOEOAdvancedWindowsLibrary.Shared.Services;
/// <summary>
/// Spartan launch handler that uses OCR to detect when a known UI element appears on screen.
/// Once the element is detected, it triggers the next step via an external handler.
/// This class does NOT perform the next steps (like autoclicking); it just waits for readiness.
/// </summary>
public class OcrDetectionSpartanLaunchHandler(ICaptureGrayScaleMask capture
    , IOcrProcessor ocr,
    ISpartanMonitor monitor,
    ISpartanReady ready
    ) : ISpartanLaunchHandler
{
    async void ISpartanLaunchHandler.OnSpartanLaunched()
    {
        OcrConfiguration.DoubleCheck();
        CancellationToken checkToken = monitor.RegisterWatcher(EnumSpartaExitStage.Open);
        await RunCaptureLoopAsync(checkToken);
    }
    private async Task RunCaptureLoopAsync(CancellationToken token)
    {

        while (!token.IsCancellationRequested)
        {
            if (await IsLoadedAsync(token))
            {
                break;
            }

            await Task.Delay(5000, token); // optional: cancels delay if token is canceled
        }
        if (token.IsCancellationRequested)
        {
            return;
        }
        await ready.LoadQuestAsync();
    }
    private async Task<bool> IsLoadedAsync(CancellationToken token)
    {
        // Offload capture and OCR to a background thread
        return await Task.Run(async () =>
        {
            Rectangle bounds = OcrConfiguration.IsLoadedRegion;
            using Bitmap bitmap = capture.CaptureMaskedBitmap(bounds);
            string text = await ocr.GetTextAsync(bitmap, token);
            return text.Contains(OcrConfiguration.LoadIdentifier);
        }, token);
    }
}
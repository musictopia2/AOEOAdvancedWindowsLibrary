namespace AOEOAdvancedWindowsLibrary.Shared.Services;
public static class ResetQuestSettingsClass
{
    public static void ResetQuests(IQuestSettings settings)
    {
        // Clear all list properties
        settings.Units.Clear();
        settings.HumanLimitedEffects.Clear();
        settings.HumanForeverEffects.Clear();
        settings.ComputerLimitedEffects.Clear();
        settings.ComputerForeverEffects.Clear();

        // Reset all integer properties to their default values
        settings.DelayedAttackTime = 0;
        settings.LimitedHumanEffectTime = 0;
        settings.LimitedComputerEffectTime = 0;
    }
}
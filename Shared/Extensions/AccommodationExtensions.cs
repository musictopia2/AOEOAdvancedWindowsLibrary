namespace AOEOAdvancedWindowsLibrary.Shared.Extensions;
public static class AccommodationExtensions
{
    public static void AddAccommodationQuestExtensions(this XElement source, IQuestSettings settings, IGlobalTechStrategy global)
    {
        //the source is the quest file.
        if (global.HasGlobalTech)
        {
            source.AddGlobalTech(); //will have global stuff always for this version.
        }
        if (settings.DelayedAttackTime > 0)
        {
            source.SetDelayedAttacksForAllComputerPlayers(settings.DelayedAttackTime);
        }
        if (settings.HumanForeverEffects.Count > 0)
        {
            source.AddHumanTechForever();
        }
        if (settings.HumanLimitedEffects.Count > 0)
        {
            source.AddHumanTechLimited(settings.LimitedHumanEffectTime);
        }
        if (settings.ComputerForeverEffects.Count > 0)
        {
            source.AddComputerTechForever();
        }
        if (settings.ComputerLimitedEffects.Count > 0)
        {
            source.AddComputerTechLimited(settings.LimitedComputerEffectTime);
        }
        if (settings.Units.Count > 0)
        {
            source.AddAutomationTownCenterTech();
        }
        if (settings.SeeAllMap)
        {
            source.AddMapBoolVariable("SeeAll", true);
        }
    }
}
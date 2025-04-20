namespace AOEOAdvancedWindowsLibrary.Shared.Services;
public class CustomTacticsClass(IQuestSettings settings) : ITacticsAutomation
{
    XElement ITacticsAutomation.GetAutomatedTactics(XElement source)
    {
        if (settings.Units.Count == 0)
        {
            return source;
        }
        settings.AddTownCenterTacticsForCustomUnits(source);
        return source;
    }
}
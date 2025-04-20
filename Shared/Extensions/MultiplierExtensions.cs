namespace AOEOAdvancedWindowsLibrary.Shared.Extensions;
public static class MultiplierExtensions
{
    public static bool HasMultipliers(this XElement source)
    {
        //has to report if this even has multipliers.
        XElement firsts = source.Element("randommap")!.Element("map")!;
        string loaderValue = firsts.Value;
        if (loaderValue.EndsWith("Celeste_Loader_NoBonusMultipliers"))
        {
            return false;
        }
        if (loaderValue.EndsWith("RhakotisLoader"))
        {
            return true;
        }
        if (loaderValue.EndsWith("Loader_Celtpack_quest4"))
        {
            return true; //even brennos attacks.
        }
        if (loaderValue.EndsWith("Celeste_Loader") == false)
        {
            return false;
        }
        firsts = source.Element("questgivers")!.Element("protounit")!;
        string questValue = firsts.Value;
        if (questValue == "ZabolTrader")
        {
            return false;
        }
        return true;
    }
}
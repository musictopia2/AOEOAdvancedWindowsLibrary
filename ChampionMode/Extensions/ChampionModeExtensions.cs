namespace AOEOAdvancedWindowsLibrary.ChampionMode.Extensions;
public static class ChampionModeExtensions
{
    public static void MakeChampionMode(this XElement source)
    {
        //this will not care where the file came from.
        source.Part1ChampionMode();
        source.RemoveOptionalChallenges();
    }
    private static void Part1ChampionMode(this XElement source)
    {
        //source.Element("displayname")!.Value = title;
        //has to figure out how to add another tag.
        string content = source.ToString();
        if (content.Contains("<failonexpire>true</failonexpire>"))
        {
            source.Element("timer")!.Element("hideonui")!.Value = "true";
        }
        XElement extras = new("championmode");
        extras.Value = "true";
        source.AddFirst(extras);
        source.Element("elitespawnchance")!.Value = "0";
        //everything requires xml manipulation i think.
        XElement starts = source.Element("randommap")!.Element("mapvariables")!;
        XElement legs = starts.Elements("variable").Single(x => x.Attribute("name")!.Value == "IsLEGENDARY");
        legs.Value = "false";
        XElement script = source.Element("randommap")!.Element("map")!;
        string newValue = @"Celeste\Event\Winter\Winter_LoaderFix";
        //trying with winterfix.  if that does not work. then refer to the older files of what i did.
        if (script.Value == @"Celeste\Event\Winter\Winter_Loader")
        {
            script.Value = newValue;
            return;
        }
        else if (script.Value == @"Celeste\Event\Winter\Winter_Cyprus_Loader")
        {
            script.Value = newValue;
            return;
        }
        else if (script.Value == @"Celeste\Event\Winter\Winter_ImpossibleCataclysm")
        {
            script.Value = newValue;
            return;
        }
        if (source.HasMultipliers())
        {
            newValue = @"Celeste\Celeste_LoaderFix";
            script.Value = newValue;
        }
    }
    private static void RemoveOptionalChallenges(this XElement source)
    {
        var list = source.Elements("secondaryobjectives");
        list.Remove();
    }
}
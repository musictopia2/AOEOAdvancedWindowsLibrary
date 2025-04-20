namespace AOEOAdvancedWindowsLibrary.Shared.Extensions;
public static class AdvancedQuestExtensions
{
    public static void AddAllAccommodationHumanTechs(this XElement source, int seconds)
    {
        source.AddHumanTechForever();
        source.AddAutomationTownCenterTech();
        source.AddHumanTechLimited(seconds);
    }
    public static void AddAllAccommodationComputerTechs(this XElement source, int seconds)
    {
        source.AddComputerTechForever();
        source.AddComputerTechLimited(seconds);
    }
    public static void AddAllAccommodationTechs(this XElement source, int humanSeconds, int computerSeconds)
    {
        source.AddAllAccommodationHumanTechs(humanSeconds);
        source.AddAllAccommodationComputerTechs(computerSeconds);
    }
    public static void SetDelayedAttacksForAllComputerPlayers(this XElement source, int time)
    {
        var list = source.GetAllComputerPlayerElements();
        BasicList<string> fins = [];
        foreach (var temp in list)
        {
            var id = temp.Attribute("id")!.Value;
            fins.Add($"P{id}AttackDelayMod");
        }
        foreach (var player in fins)
        {
            source.DeleteExistingMapVariable(player);
        }
        foreach (var player in fins)
        {
            source.AddMapIntegerVariable(player, time);
        }
    }
    public static void AddHumanTechForever(this XElement source)
    {
        int id = GetTechID();
        source.AddMapIntegerVariable("CustomHumanTechForever", id);
    }
    public static void AddHumanTechLimited(this XElement source, int seconds) //can now decide when this tech expires in seconds.
    {
        int id = GetTechID();
        id++;
        string toSend = $"{id},{seconds}";
        source.AddMapStringVariable("CustomHumanTechTemporarily", toSend);
    }
    public static void AddAutomationTownCenterTech(this XElement source)
    {
        int id = GetTechID();
        id += 2;
        source.AddMapIntegerVariable("TechForAutomation", id);
    }
    public static void AddComputerTechForever(this XElement source)
    {
        int id = GetTechID();
        id += 3;
        source.AddMapIntegerVariable("CustomComputerTechForever", id);
    }
    public static void AddComputerTechLimited(this XElement source, int seconds) //can now decide when this tech expires in seconds.
    {
        int id = GetTechID();
        id += 4;
        string toSend = $"{id},{seconds}";
        source.AddMapStringVariable("CustomComputerTechTemporarily", toSend);
    }
    public static void AddGlobalTech(this XElement source)
    {
        int id = GetTechID();
        id += 5;
        source.AddMapIntegerVariable("CustomGlobalTechForever", id);
    }
    private static int GetTechID()
    {
        string path = dd1.RawTechLocation;
        XElement source = XElement.Load(path);
        var list = source.Elements().ToBasicList();
        return list.Count; //for now.  evenually can decide to have placeholders for techs (since consistency is important.
    }
}
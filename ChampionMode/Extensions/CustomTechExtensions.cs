namespace AOEOAdvancedWindowsLibrary.ChampionMode.Extensions;
internal static class CustomTechExtensions
{
    private static void AddEmptyTech(this IAddTechsToTechTreeService techs, string name)
    {
        BasicList<BasicEffectModel> list = [];
        techs.AddMiscTech(list, name);
    }
    public static void AddCustomTechs(this IAddTechsToTechTreeService techs, IQuestSettings settings, ICivilizationContext civ, IGlobalTechStrategy global)
    {
        if (settings.HumanForeverEffects.Count > 0)
        {
            techs.AddMiscTech(settings.HumanForeverEffects, "ChampionHumanPermanentTechs");
        }
        else
        {
            techs.AddEmptyTech("Name1");
        }
        if (settings.HumanLimitedEffects.Count > 0)
        {
            techs.AddMiscTech(settings.HumanLimitedEffects, "ChampionHumanLimitedTechs");
        }
        else
        {
            techs.AddEmptyTech("Name2");
        }
        //here, will do the techs required for the units used.
        if (settings.Units.Count > 0)
        {
            techs.AddUnitTechs(settings, civ);
        }
        else
        {
            techs.AddEmptyTech("Name3"); //needs placeholders even for units because we now have computer techs.
        }
        if (settings.ComputerForeverEffects.Count > 0)
        {
            techs.AddMiscTech(settings.ComputerForeverEffects, "ChampionComputerPermanentTechs");
        }
        else
        {
            techs.AddEmptyTech("Name4");
        }
        if (settings.ComputerLimitedEffects.Count > 0)
        {
            techs.AddMiscTech(settings.ComputerLimitedEffects, "ChampionComputerLimitedTechs");
        }
        else
        {
            techs.AddEmptyTech("Name5"); //just in case there is something else i am missing.
        }
        //i guess my custom version can ask for something else to add to it (more flexible than before).
        var list = global.GetGlobalTechEffects();
        if (list.Count > 0)
        {
            techs.AddMiscTech(list, "GlobalTech");
        }
    }
    internal static IAddTechsToTechTreeService AddMiscTech(this IAddTechsToTechTreeService techs, BasicList<BasicEffectModel> effects, string name)
    {
        XElement ourTech = TechTreeServices.StartNewTech(name);
        BasicList<XElement> elements = EffectsServices.GetEffects(effects);
        XElement source = TechTreeServices.GetEffects(elements);
        ourTech.Add(source); //i think.
        techs!.Source!.Add(ourTech);
        return techs;
    }
}
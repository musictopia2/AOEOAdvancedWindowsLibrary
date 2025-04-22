namespace AOEOAdvancedWindowsLibrary.Shared.Extensions;
internal static class UnitTraitExtensions
{
    public static void AddUnitTechs(this IAddTechsToTechTreeService techs,  IQuestSettings settings,

        ICivilizationContext civ
        )
    {
        //was going to append to list but decided to not do this way.
        BasicEffectModel effect;
        BasicList<BasicEffectModel> list = [];
        foreach (var unit in settings.Units)
        {
            if (unit.ProtoName == "")
            {
                throw new CustomBasicException("Proto name is blank.  Cannot add unit techs");
            }
            string actionName = $"Spawn_{unit.ProtoName}";
            effect = new CustomTacticEffect()
            {
                CustomTacticName = actionName,
                ProtoUnit = $"{civ!.CivAbb}_bldg_TownCenter"
            };
            list.Add(effect);
        }
        techs.AddMiscTech(list, "MultipleUnitsTech");
    }

    public static void AddTownCenterTacticsForCustomUnits(this IQuestSettings settings, XElement source)
    {
        foreach (var unit in settings.Units)
        {
            AddItem(source, unit);
        }
        XElement tactic = source.Element("tactic")!;
        string text;
        foreach (var unit in settings.Units)
        {
            text = $"""
                <action>Spawn_{unit.ProtoName}</action>
                """;
            tactic.Add(XElement.Parse(text));
        }
    }
    private static void AddItem(XElement source, CustomUnitModel unit)
    {
        string text;
        text = $"""
            <action>
            	<name>Spawn_{unit.ProtoName}</name>
            	<type>Maintain</type>
            	<MaintainEntry>
            	  <TrainCount>{unit.HowMany}</TrainCount>
            	  <UnitsOwned>{unit.HowMany}</UnitsOwned>
            	  <RateMultiplier>1.0</RateMultiplier>
            	  <TrainProtoUnit>{unit.ProtoName}</TrainProtoUnit>
            	</MaintainEntry>
            	<active>0</active>
            	<singleuse>1</singleuse>
            	<persistent>1</persistent>
            </action>
            """;
        source.Add(XElement.Parse(text));
    }
}
namespace AOEOAdvancedWindowsLibrary.Shared.Extensions;
public static class CustomTechExtensions
{
    public static void AddQuickCompleteQuest(this IQuestSettings settings)
    {
        BasicList<BasicEffectModel> list = [];
        BasicEffectModel effect;
        //this will help with not only when a quest is completed but also showing quests that a human gets forever.
        effect = new HitPointsModel() //seem to be okay
        {
            ProtoUnit = "all",
            Value = "100.0000"
        };
        list.Add(effect);
        effect = new DamageModel() //seem to be okay
        {
            ProtoUnit = "all",
            Value = "1000.0000"
        };
        list.Add(effect);
        settings.HumanForeverEffects.AddRange(list);
        settings.SeeAllMap = true;
    }
}
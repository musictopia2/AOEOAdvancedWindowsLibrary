namespace AOEOAdvancedWindowsLibrary.Shared.Services;
public class ChampionCustomTechClass(IQuestSettings settings, 
    ICivilizationContext context, 
    IGlobalTechStrategy global) : BaseAddTechsService
{
    public override void AddTechs()
    {
        this.AddCustomTechs(settings, context, global);
    }
}
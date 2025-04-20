namespace AOEOAdvancedWindowsLibrary.Shared.Services;
public class NoGlobalTechStrategy : IGlobalTechStrategy
{
    public bool HasGlobalTech => false; //there is none.
    BasicList<BasicEffectModel> IGlobalTechStrategy.GetGlobalTechEffects()
    {
        return [];
    }
}
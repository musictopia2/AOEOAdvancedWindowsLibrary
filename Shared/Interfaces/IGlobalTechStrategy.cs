namespace AOEOAdvancedWindowsLibrary.Shared.Interfaces;
public interface IGlobalTechStrategy
{
    BasicList<BasicEffectModel> GetGlobalTechEffects();
    abstract bool HasGlobalTech { get; }
}
namespace AOEOAdvancedWindowsLibrary.Shared.Services;
public class SimpleQuestSettings : IQuestSettings
{
    public BasicList<CustomUnitModel> Units { get; set; } = [];
    public BasicList<BasicEffectModel> HumanLimitedEffects { get; set; } = [];
    public BasicList<BasicEffectModel> HumanForeverEffects { get; set; } = [];
    public BasicList<BasicEffectModel> ComputerLimitedEffects { get; set; } = [];
    public BasicList<BasicEffectModel> ComputerForeverEffects { get; set; } = [];
    public int DelayedAttackTime { get; set; }
    public int LimitedHumanEffectTime { get; set; }
    public int LimitedComputerEffectTime { get; set; }
}
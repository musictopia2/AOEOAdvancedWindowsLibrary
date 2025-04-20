namespace AOEOAdvancedWindowsLibrary.Shared.Interfaces;
public interface IQuestSettings
{
    BasicList<CustomUnitModel> Units { get; set; }
    BasicList<BasicEffectModel> HumanLimitedEffects { get; set; }
    BasicList<BasicEffectModel> HumanForeverEffects { get; set; }
    BasicList<BasicEffectModel> ComputerLimitedEffects { get; set; }
    BasicList<BasicEffectModel> ComputerForeverEffects { get; set; }
    int DelayedAttackTime { get; set; }
    int LimitedHumanEffectTime { get; set; }
    int LimitedComputerEffectTime { get; set; }
}

namespace AOEOAdvancedWindowsLibrary.Shared.Interfaces;
public interface IUnitHandler
{
    abstract static string SupportedProtoName { get; }
    void ProcessCustomUnit(XElement root, CustomUnitModel model);
}
namespace AOEOAdvancedWindowsLibrary.Shared.Interfaces;
public interface IUnitRegistry
{
    IUnitHandler? GetHandlerFor(string protoName);
}
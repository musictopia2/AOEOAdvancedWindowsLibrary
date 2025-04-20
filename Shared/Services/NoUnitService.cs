namespace AOEOAdvancedWindowsLibrary.Shared.Services;
public class NoUnitService : IUnitRegistry
{
    IUnitHandler? IUnitRegistry.GetHandlerFor(string protoName)
    {
        return null; //because this has no units.
    }
}
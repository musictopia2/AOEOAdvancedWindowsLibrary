namespace AOEOAdvancedWindowsLibrary.Shared.Services;
public class StandardUnitProcessor(IQuestSettings settings, IUnitRegistry register) : IUnitProcessor
{
    XElement IUnitProcessor.GetUnitXML()
    {
        XElement entire = XElement.Load(dd1.RawUnitLocation);
        foreach (var item in settings.Units)
        {
            IUnitHandler? unit = register.GetHandlerFor(item.ProtoName);
            unit?.ProcessCustomUnit(entire, item);
        }
        return entire;
    }
}
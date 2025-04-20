namespace AOEOAdvancedWindowsLibrary.Shared.Interfaces;
public interface IUnitProcessor
{
    //can't be just building anymore because could be dock or could be town center.  could even be both eventually.
    XElement GetUnitXML();
}
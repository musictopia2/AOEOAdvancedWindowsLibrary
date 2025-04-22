namespace AOEOAdvancedWindowsLibrary.Shared.Extensions;
public static class SimpleUnitExtensions
{
    //must be public now since its now possible to use outside for experimenting.
    public static void AddCustomUnitToEntireList(this XElement source, string details)
    {
        XElement extras = XElement.Parse(details);
        source.Add(extras);
    }
}
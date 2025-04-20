namespace AOEOAdvancedWindowsLibrary.Shared.Extensions;
internal static class MapVariablesExtensions
{
    public static void DeleteExistingMapVariable(this XElement source, string name)
    {
        var maps = source.Element("randommap")!.Element("mapvariables");
        foreach (var map in maps!.Elements())
        {
            if (map.Attribute("name")!.Value == name)
            {
                map.Remove();
                return;
            }
        }
    }
    public static void AddMapIntegerVariable(this XElement source, string name, int value)
    {
        source.AddMapVariable("Int", name, value);
    }
    public static void AddMapStringVariable(this XElement source, string name, string value)
    {
        source.AddMapVariable("String", name, value);
    }
    public static void AddMapBoolVariable(this XElement source, string name, bool value)
    {
        source.AddMapVariable("Bool", name, value);
    }
    private static void AddMapVariable(this XElement source, string type, string name, object value)
    {
        var maps = source.Element("randommap")!.Element("mapvariables");
        string input = $"""
            <variable name="{name}" type="{type}" >{value}</variable>
            """;
        XElement adds = XElement.Parse(input);
        maps!.Add(adds);
    }
}
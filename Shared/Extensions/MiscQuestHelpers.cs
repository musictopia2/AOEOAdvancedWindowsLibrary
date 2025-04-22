namespace AOEOAdvancedWindowsLibrary.Shared.Extensions;
public static class MiscQuestHelpers
{
    public static string GetQuestTitle(this XElement source) //this is for sure needed.
    {
        string parts = source.Element("displayname")!.Value;
        parts = parts.Replace("$$", "");
        int value = int.Parse(parts);
        string output = value.GetQuestStringValue();
        output = output.Replace(" (Archive)", "");
        output = output.Trim(); //we don't care if its archive or not.
        return output;
    }
}
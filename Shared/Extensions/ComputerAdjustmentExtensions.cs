namespace AOEOAdvancedWindowsLibrary.Shared.Extensions;
internal static class ComputerAdjustmentExtensions
{
    public static BasicList<XElement> GetAllComputerPlayerElements(this XElement source)
    {
        var output = source.GetComputerPlayers();
        return output;
    }
    private static BasicList<XElement> GetComputerPlayers(this XElement source)
    {
        var list = source.Elements("playersettings");
        BasicList<XElement> output = [];
        foreach (XElement player in list)
        {
            if (player.Element("color")!.Value == "1")
            {
                continue; //don't consider anymore.
            }
            if (player.Element("team")!.Value == "1")
            {
                continue; //because its an ally.
            }
            if (player.Element("playertype")!.Value != "Computer")
            {
                continue; //must be controlled by computer.
            }
            if (player.Element("script")!.Value == "")
            {
                continue; //because if there is no script, then no adjustments to be made to computer player.
            }
            output.Add(player);
        }
        return output;
    }
}
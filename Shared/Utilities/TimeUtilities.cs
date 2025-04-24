namespace AOEOAdvancedWindowsLibrary.Shared.Utilities;
public static class TimeUtilities
{
    //i was going to put into common but not common enough so its here.
    public static int GetMinutes(string completeTime)
    {
        var timeParts = completeTime.Split(':');

        int hours = int.Parse(timeParts[0]);
        int minutes = int.Parse(timeParts[1]);
        int seconds = int.Parse(timeParts[2]);

        int totalMinutes = (hours * 60) + minutes;

        // Round up if there are any seconds
        if (seconds > 0)
        {
            totalMinutes += 1;
        }

        return totalMinutes;
    }
}
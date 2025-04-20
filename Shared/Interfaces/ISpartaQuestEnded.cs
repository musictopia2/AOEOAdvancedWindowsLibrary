namespace AOEOAdvancedWindowsLibrary.Shared.Interfaces;
public interface ISpartaQuestEnded
{
    /// <summary>
    /// This method is called when the quest is finished.
    /// </summary>
    /// <param name="result">The result of the quest (success or failure).</param>
    /// <param name="time">The time the quest took, in the format HH:mm:ss.</param>
    void EndQuest(EnumSpartaQuestResult result, string time); //just return the string and whoever handles it can decide what to do from here.
}
namespace AOEOAdvancedWindowsLibrary.Shared.Containers;
public class QuestFileContainer
{
    public QuestFileModel? QuestFile { get; private set; }
    public void SetQuestFile(string title, string path)
    {
        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(path))
        {
            throw new CustomBasicException("Title or path cannot be empty.");
        }
        if (ff1.FileExists(path) == false)
        {
            throw new CustomBasicException($"File does not exist: {path}");
        }
        QuestFile = new QuestFileModel(title, path);
    } //i think needs to be done this way for now.
    public void ClearQuestFile()
    {
        QuestFile = null;
    }
    public string QuestTitle => QuestFile?.Title ?? string.Empty;
    public string QuestPath => QuestFile?.Path ?? string.Empty;
}
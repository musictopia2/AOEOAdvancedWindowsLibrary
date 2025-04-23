using System.IO;
namespace AOEOAdvancedWindowsLibrary.Shared.Containers;
public class QuestFileContainer
{
    private QuestFileModel? _questFile;
    //public QuestFileModel? QuestFile { get; private set; }
    public void SetQuestFile(string title, string fileName)
    {
        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(fileName))
        {
            throw new CustomBasicException("Title or path cannot be empty.");
        }
        _questFile = new QuestFileModel(title, fileName);
    } //i think needs to be done this way for now.
    public void ClearQuestFile()
    {
        _questFile = null;
    }
    public string QuestTitle => _questFile?.Title ?? string.Empty;
    public string FileName => _questFile?.FileName ?? string.Empty;
    public string QuestPath
    {
        get
        {
            if (_questFile is null)
            {
                return "";
            }
            string output = Path.Combine(dd1.NewQuestFileDirectory, $"{_questFile.Value.FileName}.quest");
            return output;
        }
    }
}
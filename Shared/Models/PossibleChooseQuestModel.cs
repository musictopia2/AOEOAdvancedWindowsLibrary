namespace AOEOAdvancedWindowsLibrary.Shared.Models;
public class PossibleChooseQuestModel : ISelectable
{
    public string Title { get; set; } = "";
    public string FileName { get; set; } = "";
    public bool IsSelected { get; set; } //since this can be modified
}
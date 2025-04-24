namespace AOEOAdvancedWindowsLibrary.Shared.Models;
public record struct PossbileChooseQuestModel(string Title, string FileName, bool IsSelected) : ISelectable;
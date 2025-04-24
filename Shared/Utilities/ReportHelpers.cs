namespace AOEOAdvancedWindowsLibrary.Shared.Utilities;
public static class ReportHelpers
{
    public static async Task<BasicList<PossibleChooseQuestModel>> ListAllQuestFilesAsync()
    {
        BasicList<PossibleChooseQuestModel> output = [];
        BasicList<string> files = await ff1.FileListAsync(dd1.NewQuestFileDirectory);
        foreach (var file in files)
        {
            string content = await ff1.AllTextAsync(file);
            XElement source = XElement.Parse(content);
            string title = source.GetQuestTitle();
            PossibleChooseQuestModel quest = new()
            {
                Title = title,
                FileName = ff1.FileName(file),
                IsSelected = false
            };
            output.Add(quest);
        }
        if (output.Count == 0)
        {
            throw new CustomBasicException("There has to be at least one quest that has required time limit");
        }
        return output;
    }
    public static async Task<BasicList<CivilizationBasicModel>> GetCivilizationsAsync()
    {
        ICivilizationDataService data = new InMemoryCivilizationDataService();
        var list = await data.GetCivilizationsAsync();
        return list;
    }
}
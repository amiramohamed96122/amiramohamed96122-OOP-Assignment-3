namespace RefactoringLab.Part02.Reports;

public abstract class ReportExporter
{
    public void Export(string path)
    {
        var rows = Load();

        if (!Validate(rows))
            throw new InvalidOperationException("Invalid data");

        var content = Format(rows);
        Save(path, content);
    }

    protected List<string[]> Load() =>
    [
        ["Id", "Name"],
        ["1", "Keyboard"],
        ["2", "Mouse"]
    ];

    protected bool Validate(List<string[]> rows) =>
        rows.Count > 1 && rows[0].Length > 0;
    protected void Save(string path, string content) =>
        File.WriteAllText(path, content);

    // Different → each exporter implements its own Format
    protected abstract string Format(List<string[]> rows);

    
}
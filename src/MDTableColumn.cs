using System.Collections.Immutable;

namespace MarkdownUtilities;

public class MDTableColumn
{
    public readonly string Header;
    public ImmutableArray<string> Rows => ImmutableArray.Create<string>(_rows.ToArray());
    public int MaxWidth { get; private set; }
    public int RowCount => _rows is null ? 0 : _rows.Count;
    private List<string> _rows = new();

    public MDTableColumn(string Header)
    {
        this.Header = string.IsNullOrWhiteSpace(Header) ? " " : Header;
        this.MaxWidth = this.Header.Length;
    }

    public void AddRow(string row)
    {
        var escaped = EscapeText(row);
        _rows.Add(escaped);
        UpdateMaxWidth(escaped);
    }

    private void UpdateMaxWidth(string row) =>
        MaxWidth = Math.Max(row.Length, MaxWidth);


    private string EscapeText(string text) =>
        string.IsNullOrWhiteSpace(text) ? " " :
            text.Replace("\\", "\\\\")
                .Replace("|", "\\|");
}
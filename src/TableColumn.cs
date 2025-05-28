using System.Collections.Immutable;

namespace MarkdownUtilities;

public class TableColumn
{
    public readonly string Header;
    public List<string> Rows => new(_rows);
    public int MaxWidth { get; private set; }
    public int RowCount => _rows is null ? 0 : _rows.Count;
    private List<string> _rows = new();

    public TableColumn(string Header)
    {
        this.Header = string.IsNullOrWhiteSpace(Header) ? " " : EscapeText(Header);
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
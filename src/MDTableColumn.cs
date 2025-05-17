using System.Collections.Immutable;

namespace MarkdownUtilities;

public class MDTableColumn
{
    public readonly string Header;
    public ImmutableList<string> Rows { get; private set; }
    public int MaxWidth { get; private set; }
    public int RowCount => Rows is null ? 0 : Rows.Count;

    public MDTableColumn(string Header)
    {
        this.Header = string.IsNullOrWhiteSpace(Header) ? " " : Header;
        this.MaxWidth = this.Header.Length;
        Rows = ImmutableList.Create<string>();
    }

    public void AddRow(string row)
    {
        var escaped = EscapeText(row);
        Rows = Rows.Add(escaped);
        UpdateMaxWidth(escaped);
    }

    private void UpdateMaxWidth(string row) =>
        MaxWidth = Math.Max(row.Length, MaxWidth);


    private string EscapeText(string text) =>
        string.IsNullOrWhiteSpace(text) ? " " :
            text.Replace("\\", "\\\\")
                .Replace("|", "\\|");
}
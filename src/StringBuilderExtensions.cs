using System.Text;

namespace MarkdownUtilities;

internal static class StringBuilderExtensions
{
    internal static StringBuilder AppendHeaderRow(this StringBuilder sb, TableBuilder TB) => sb.AppendHeaderRow(TB.Columns);
    internal static StringBuilder AppendHeaderRow(this StringBuilder sb, IEnumerable<TableColumn> Columns)
    {
        sb.Append('|');
        foreach (var column in Columns)
        {
            sb.Append(' ')
                .AppendPadded(column.Header, column.MaxWidth)
                .Append(" |");
        }
        sb.AppendLine();
        return sb;
    }

    internal static StringBuilder AppendSeparatorRow(this StringBuilder sb, TableBuilder TB, char SeparatorChar = '-') =>
        sb.AppendSeparatorRow(TB.Columns, SeparatorChar);
    internal static StringBuilder AppendSeparatorRow(this StringBuilder sb, IEnumerable<TableColumn> Columns, char SeparatorChar = '-')
    {
        sb.Append('|');
        foreach (var column in Columns)
        {
            sb.Append(' ')
                .Append(SeparatorChar, column.MaxWidth)
                .Append(" |");
        }
        sb.AppendLine();
        return sb;
    }

    internal static StringBuilder AppendRows(this StringBuilder sb, TableBuilder TB)
    {
        for (int i = 0; i < TB.RowCount; i++)
        {
            sb.Append('|');
            foreach (var column in TB.Columns)
            {
                sb.Append(' ')
                  .AppendPadded(column.Rows[i], column.MaxWidth)
                  .Append(" |");
            }
            sb.AppendLine();
        }
        return sb;
    }

    internal static StringBuilder AppendPadded(this StringBuilder sb, string Text, PositiveInt MaxWidth, char PaddingChar = ' ')
    {
        // null string to empty string
        var text = Text is null ? string.Empty : Text;
        // truncate to max width
        text = text.Length > MaxWidth ? text[..MaxWidth] : text;
        sb.Append(text)
            .Append(PaddingChar, MaxWidth - text.Length);
        return sb;
    }
}

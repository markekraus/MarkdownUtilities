using System.Collections.Immutable;
using System.Text;

namespace MarkdownUtilities;
public class TableBuilder
{
    public TableColumn[] Columns { get; private set; }
    public int RowCount { get; private set; }
    public int ColumnCount { get; private set; }
    private readonly StringBuilder sb;
    public TableBuilder() => sb = new();
    public TableBuilder(StringBuilder sb) => this.sb = sb;

    public TableBuilder WithHeaders(params string[] Headers)
    {

        var columns = Array.ConvertAll(Headers, h => new TableColumn(h));
        Columns = columns;
        RowCount = 0;
        ColumnCount = Columns.Length;
        return this;
    }

    public TableBuilder AddRow(params string[] row)
    {
        if (row.Length != ColumnCount)
            throw new ArgumentOutOfRangeException(nameof(row), row, $"Supplied row item count does not match the number of columns. Expected {ColumnCount} row items.");
        for (int i = 0; i < row.Length; i++)
                Columns[i].AddRow(row[i]);
        RowCount++;
        return this;
    }

    public StringBuilder BuildTable() =>
        sb
            .AppendHeaderRow(this)
            .AppendSeparatorRow(this)
            .AppendRows(this)
            .AppendLine("");

    public override string ToString() =>
         sb
            .AppendHeaderRow(this)
            .AppendSeparatorRow(this)
            .AppendRows(this)
            .AppendLine("")
            .ToString();
}
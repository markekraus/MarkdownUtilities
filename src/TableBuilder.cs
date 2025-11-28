using System.Collections.ObjectModel;
using System.Text;

namespace MarkdownUtilities;
public class TableBuilder
{
    public ReadOnlyCollection<TableColumn> Columns =>
        _columns is not null
            ? _columns.AsReadOnly()
            : new List<TableColumn>().AsReadOnly();
    public int RowCount { get; private set; }
    public int ColumnCount =>
        _columns is not null
            ? _columns.Count
            : 0;
    private List<TableColumn> _columns;
    private readonly StringBuilder sb;
    public TableBuilder() => sb = new();
    public TableBuilder(StringBuilder sb) => this.sb = sb;

    public TableBuilder WithHeaders(params string[] Headers)
    {

        var columns = Array.ConvertAll(Headers, h => new TableColumn(h));
        _columns = new(columns);
        RowCount = 0;
        return this;
    }

    public TableBuilder AddRow(params string[] row)
    {
        if (row.Length != ColumnCount)
            throw new ArgumentOutOfRangeException(nameof(row), row, $"Supplied row item count does not match the number of columns. Expected {ColumnCount} row items.");
        for (int i = 0; i < row.Length; i++)
                _columns[i].AddRow(row[i]);
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
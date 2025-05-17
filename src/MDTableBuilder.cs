using System.Collections.Immutable;
using System.Text;

namespace MarkdownUtilities;
public class MDTableBuilder
{
    public ImmutableArray<MDTableColumn> Columns { get; private set; }
    public int RowCount { get; private set; }
    public int ColumnCount { get; private set; }
    public MDTableBuilder() { }

    public MDTableBuilder WithHeaders(params string[] Headers)
    {

        var columns = Array.ConvertAll(Headers, h => new MDTableColumn(h));
        Columns = ImmutableArray.Create(columns);
        RowCount = 0;
        ColumnCount = Columns.Length;
        return this;
    }

    public MDTableBuilder AddRow(params string[] row)
    {
        if (row.Length != ColumnCount)
            throw new ArgumentOutOfRangeException(nameof(row), row, $"Supplied row item count does not match the number of columns. Expected {ColumnCount} row items.");
        for (int i = 0; i < row.Length; i++)
                Columns[i].AddRow(row[i]);
        RowCount++;
        return this;
    }

    public string Build() => ToString();

    public override string ToString()
    {
        var sb = new StringBuilder()
            .AppendHeaderRow(this)
            .AppendSeparatorRow(this)
            .AppendRows(this);
        return sb.ToString();
    }    
}
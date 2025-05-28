using MarkdownUtilities;

namespace tests;

public class TableBuilderTests
{
    public const string resultTable = """
    | a        | b           | c         |
    | -------- | ----------- | --------- |
    | 11111111 | 2           | 3         |
    | 4        | 55555555555 | 6         |
    | 7        | 8           | 999999999 |


    """;

    public const string resultEscapedTable = """
    | Escaped\| |
    | --------- |
    | \|        |
    | \\        |


    """;

    [Fact]
    public void TableBuilderNormalTable()
    {
        var tb = new TableBuilder();
        var testResult = tb
            .WithHeaders("a", "b", "c")
            .AddRow("11111111", "2", "3")
            .AddRow("4", "55555555555", "6")
            .AddRow("7", "8", "999999999")
            .ToString();
        Assert.Equal(resultTable, testResult);
    }

    [Fact]
    public void TableBuilderEscapedData()
    {
        var tb = new TableBuilder();
        var testResult = tb
            .WithHeaders("Escaped|")
            .AddRow("|")
            .AddRow("\\")
            .ToString();
        Assert.Equal(resultEscapedTable, testResult);
    }
}

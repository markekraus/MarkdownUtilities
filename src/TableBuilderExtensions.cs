using System.Text;

namespace MarkdownUtilities;

public static class TableBuilderExtensions
{
    public static TableBuilder NewTable(this StringBuilder sb) => new(sb);
    public static TableBuilder ForEachAddRow<T>(this TableBuilder tb, IEnumerable<T> enumerator, Func<T, IEnumerable<string>> forEach)
    {
        foreach (var item in enumerator)
        {
            tb.AddRow(forEach(item).ToArray());
        }
        return tb;
    }

    public static TableBuilder WithPropertyValueHeaders(this TableBuilder tb) => tb.WithHeaders("Property", "Value");
    public static TableBuilder WithNameValueHeaders(this TableBuilder tb) => tb.WithHeaders("Name", "Value");
    public static TableBuilder AddRowIfNotNull<T>(this TableBuilder tb, T nullCheckObject, Func<T, IEnumerable<string>> notNullAction) =>
        nullCheckObject is null
        ? tb
        : tb.AddRow(notNullAction(nullCheckObject).ToArray());
}
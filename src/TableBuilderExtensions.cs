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
    public static TableBuilder AddRow(this TableBuilder tb, string Property, bool Value) =>
        tb.AddRow(Property, Value.ToString());
    public static TableBuilder AddRow(this TableBuilder tb, string Property, int Value) =>
        tb.AddRow(Property, Value.ToString());
    public static TableBuilder AddRow(this TableBuilder tb, string Property, long Value) =>
        tb.AddRow(Property, Value.ToString());
    public static TableBuilder AddRow(this TableBuilder tb, string Property, uint Value) =>
        tb.AddRow(Property, Value.ToString());
    public static TableBuilder AddRow(this TableBuilder tb, string Property, ulong Value) =>
        tb.AddRow(Property, Value.ToString());
    public static TableBuilder AddRow(this TableBuilder tb, string Property, float Value) =>
        tb.AddRow(Property, Value.ToString());
    public static TableBuilder AddRow(this TableBuilder tb, string Property, double Value) =>
        tb.AddRow(Property, Value.ToString());
}
namespace MarkdownUtilities;

public record PositiveInt
{
    public readonly int Value;

    public PositiveInt(int Value)
    {
        if (Value < 0)
            throw new ArgumentOutOfRangeException(nameof(PositiveInt), "Value must be 0 or greater.");
        this.Value = Value;
    }
    public static implicit operator int(PositiveInt i) => i.Value;
    public static implicit operator Index(PositiveInt i) => i.Value;
    public static implicit operator PositiveInt(int i) => new(i);
}
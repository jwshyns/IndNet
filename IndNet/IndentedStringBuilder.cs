using System.Text;

namespace IndNet;

/// <summary>
/// A thin wrapper around <see cref="StringBuilder"/> to aid in indenting new lines when string building.
/// </summary>
/// <inheritdoc cref="IIndentedStringBuilder"/>
public class IndentedStringBuilder : IIndentedStringBuilder
{
    public int IndentationLevel { get; private set; }
    public char IndentationChar { get; }
    public int IndentSize { get; }
    public string IndentationString { get; private set; }

    /// <summary>
    /// Underlying string builder.
    /// </summary>
    private readonly StringBuilder _stringBuilder;

    /// <summary>
    /// Only constructor.
    /// </summary>
    /// <param name="indentationChar">The character used for indentation.</param>
    /// <param name="startingIndentationLevel">The starting indentation level.</param>
    /// <param name="indentSize">The size of each indentation level.</param>
    /// <param name="stringBuilder">An option to provide a configured <see cref="StringBuilder"/>.</param>
    /// <exception cref="ArgumentException">Thrown if <paramref name="startingIndentationLevel"/> is less than 0.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="indentSize"/> is less than 1.</exception>
    public IndentedStringBuilder
    (
        char indentationChar = '\t',
        int startingIndentationLevel = 0,
        int indentSize = 1,
        StringBuilder? stringBuilder = null
    )
    {
        if (startingIndentationLevel < 0)
        {
            throw new ArgumentException("Must be greater than or equal to 0.", nameof(startingIndentationLevel));
        }

        if (indentSize < 1)
        {
            throw new ArgumentException("Must be greater than or equal to 1.", nameof(indentSize));
        }

        _stringBuilder = stringBuilder ?? new StringBuilder();
        IndentationChar = indentationChar;
        IndentationLevel = startingIndentationLevel;
        IndentSize = indentSize;
        IndentationString = GenerateIndentationString();
    }

    public IIndentedStringBuilder IncrementIndentation(int amount = 1)
    {
        if (amount == 0)
        {
            return this;
        }

        IndentationLevel = Math.Max(0, IndentationLevel += amount);
        IndentationString = GenerateIndentationString();
        return this;
    }

    public IIndentedStringBuilder DecrementIndentation(int amount = 1)
    {
        if (amount == 0)
        {
            return this;
        }

        IndentationLevel = Math.Max(0, IndentationLevel -= amount);
        IndentationString = GenerateIndentationString();
        return this;
    }

    public IIndentedStringBuilder Append(bool value)
    {
        _stringBuilder.Append(value);
        return this;
    }

    public IIndentedStringBuilder Append(byte value)
    {
        _stringBuilder.Append(value);
        return this;
    }

    public IIndentedStringBuilder Append(char value)
    {
        _stringBuilder.Append(value);
        return this;
    }

    public IIndentedStringBuilder Append(char[]? value)
    {
        _stringBuilder.Append(value);
        return this;
    }

    public IIndentedStringBuilder Append(char[]? value, int startIndex, int charCount)
    {
        _stringBuilder.Append(value, startIndex, charCount);
        return this;
    }

    public IIndentedStringBuilder Append(decimal value)
    {
        _stringBuilder.Append(value);
        return this;
    }

    public IIndentedStringBuilder Append(double value)
    {
        _stringBuilder.Append(value);
        return this;
    }

    public IIndentedStringBuilder Append(short value)
    {
        _stringBuilder.Append(value);
        return this;
    }

    public IIndentedStringBuilder Append(int value)
    {
        _stringBuilder.Append(value);
        return this;
    }

    public IIndentedStringBuilder Append(long value)
    {
        _stringBuilder.Append(value);
        return this;
    }

    public IIndentedStringBuilder Append(object? value)
    {
        _stringBuilder.Append(value);
        return this;
    }

    public IIndentedStringBuilder Append(sbyte value)
    {
        _stringBuilder.Append(value);
        return this;
    }

    public IIndentedStringBuilder Append(float value)
    {
        _stringBuilder.Append(value);
        return this;
    }


    public IIndentedStringBuilder Append(string? value)
    {
        _stringBuilder.Append(value);
        return this;
    }

    public IIndentedStringBuilder Append(string? value, int startIndex, int charCount)
    {
        _stringBuilder.Append(value, startIndex, charCount);
        return this;
    }

    public IIndentedStringBuilder Append(IIndentedStringBuilder? value)
    {
        return value is { Length: > 0 } ? Append(value, 0, value.Length) : this;
    }

    public IIndentedStringBuilder Append(IIndentedStringBuilder? value, int startIndex, int charCount)
    {
        if (value is { Length: > 0 })
        {
            _stringBuilder.Append(value.ToString(startIndex, charCount));
        }

        return this;
    }

    public IIndentedStringBuilder Append(uint value)
    {
        _stringBuilder.Append(value);
        return this;
    }

    public IIndentedStringBuilder Append(ulong value)
    {
        _stringBuilder.Append(value);
        return this;
    }

    public IIndentedStringBuilder Append(ushort value)
    {
        _stringBuilder.Append(value);
        return this;
    }

    public IIndentedStringBuilder AppendFormat(string format, params object[] args)
    {
        _stringBuilder.AppendFormat(format, args);
        return this;
    }

    public IIndentedStringBuilder AppendFormat(IFormatProvider? provider, string format, params object[] args)
    {
        _stringBuilder.AppendFormat(provider, format, args);
        return this;
    }

    public IIndentedStringBuilder AppendLine()
    {
        _stringBuilder.AppendLine();
        return this;
    }

    public IIndentedStringBuilder AppendLine(string? value)
    {
        if (value is null)
        {
            return AppendLine();
        }

        _stringBuilder.Append(IndentationString).AppendLine(value);
        return this;
    }

    public IIndentedStringBuilder AppendLines(int amount = 1)
    {
        if (amount < 1)
        {
            return this;
        }

        for (var i = amount; i > 0; i--)
        {
            AppendLine();
        }

        return this;
    }

    public IIndentedStringBuilder AppendLines(IEnumerable<string> values)
    {
        foreach (var value in values)
        {
            AppendLine(value);
        }

        return this;
    }

    public IIndentedStringBuilder AppendBlock(Action<IIndentedStringBuilder> action)
    {
        action(this);
        return this;
    }

    public IIndentedStringBuilder IndentAndAppendLines(IEnumerable<string> values, int amount = 1)
    {
        return IncrementIndentation(amount).AppendLines(values).DecrementIndentation(amount);
    }

    public IIndentedStringBuilder AppendIndentedBlock(Action<IIndentedStringBuilder> action, int amount = 1)
    {
        action(IncrementIndentation(amount));
        return DecrementIndentation(amount);
    }

    public IIndentedStringBuilder Insert(int index, bool value)
    {
        _stringBuilder.Insert(index, value);
        return this;
    }

    public IIndentedStringBuilder Insert(int index, byte value)
    {
        _stringBuilder.Insert(index, value);
        return this;
    }

    public IIndentedStringBuilder Insert(int index, char value)
    {
        _stringBuilder.Insert(index, value);
        return this;
    }

    public IIndentedStringBuilder Insert(int index, char[]? value)
    {
        _stringBuilder.Insert(index, value);
        return this;
    }

    public IIndentedStringBuilder Insert(int index, char[]? value, int startIndex, int charCount)
    {
        _stringBuilder.Insert(index, value, startIndex, charCount);
        return this;
    }

    public IIndentedStringBuilder Insert(int index, decimal value)
    {
        _stringBuilder.Insert(index, value);
        return this;
    }

    public IIndentedStringBuilder Insert(int index, double value)
    {
        _stringBuilder.Insert(index, value);
        return this;
    }

    public IIndentedStringBuilder Insert(int index, short value)
    {
        _stringBuilder.Insert(index, value);
        return this;
    }

    public IIndentedStringBuilder Insert(int index, int value)
    {
        _stringBuilder.Insert(index, value);
        return this;
    }

    public IIndentedStringBuilder Insert(int index, long value)
    {
        _stringBuilder.Insert(index, value);
        return this;
    }

    public IIndentedStringBuilder Insert(int index, object? value)
    {
        _stringBuilder.Insert(index, value);
        return this;
    }

    public IIndentedStringBuilder Insert(int index, sbyte value)
    {
        _stringBuilder.Insert(index, value);
        return this;
    }

    public IIndentedStringBuilder Insert(int index, float value)
    {
        _stringBuilder.Insert(index, value);
        return this;
    }

    public IIndentedStringBuilder Insert(int index, string value)
    {
        _stringBuilder.Insert(index, value);
        return this;
    }

    public IIndentedStringBuilder Insert(int index, string? value, int count)
    {
        _stringBuilder.Insert(index, value, count);
        return this;
    }

    public IIndentedStringBuilder Insert(int index, uint value)
    {
        _stringBuilder.Insert(index, value);
        return this;
    }

    public IIndentedStringBuilder Insert(int index, ulong value)
    {
        _stringBuilder.Insert(index, value);
        return this;
    }

    public IIndentedStringBuilder Insert(int index, ushort value)
    {
        _stringBuilder.Insert(index, value);
        return this;
    }

    public IIndentedStringBuilder Remove(int startIndex, int length)
    {
        _stringBuilder.Remove(startIndex, length);
        return this;
    }

    public IIndentedStringBuilder Replace(char oldChar, char newChar)
    {
        _stringBuilder.Replace(oldChar, newChar);
        return this;
    }

    public IIndentedStringBuilder Replace(char oldChar, char newChar, int startIndex, int count)
    {
        _stringBuilder.Replace(oldChar, newChar, startIndex, count);
        return this;
    }

    public IIndentedStringBuilder Replace(string oldValue, string newValue)
    {
        _stringBuilder.Replace(oldValue, newValue);
        return this;
    }

    public IIndentedStringBuilder Replace(string oldValue, string? newValue, int startIndex, int count)
    {
        _stringBuilder.Replace(oldValue, newValue, startIndex, count);
        return this;
    }

    public IIndentedStringBuilder Clear()
    {
        return ClearBuilder().ClearIndentation();
    }

    public IIndentedStringBuilder ClearIndentation()
    {
        DecrementIndentation(IndentationLevel);
        return this;
    }

    public IIndentedStringBuilder ClearBuilder()
    {
        _stringBuilder.Clear();
        return this;
    }

    public int EnsureCapacity(int capacity)
    {
        return _stringBuilder.EnsureCapacity(capacity);
    }

    public int Capacity
    {
        get => _stringBuilder.Capacity;
        set => _stringBuilder.Capacity = value;
    }

    public char this[int index]
    {
        get => _stringBuilder[index];
        set => _stringBuilder[index] = value;
    }

    public int Length
    {
        get => _stringBuilder.Length;
        set => _stringBuilder.Length = value;
    }

    public int MaxCapacity => _stringBuilder.MaxCapacity;

    private string GenerateIndentationString()
    {
        return new string(IndentationChar, IndentationLevel * IndentSize);
    }

    public override string ToString()
    {
        return _stringBuilder.ToString();
    }

    public string ToString(int startIndex, int length)
    {
        return _stringBuilder.ToString(startIndex, length);
    }
}
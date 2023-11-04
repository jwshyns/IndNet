using System.Text;

namespace IndNet;

public interface IIndentedStringBuilder
{
    /// <summary>
    /// The current indentation level of indentation.
    /// </summary>
    public int IndentationLevel { get; }

    /// <summary>
    /// The character used for indentation.
    /// </summary>
    public char IndentationChar { get; }

    /// <summary>
    /// The size of each indentation (the amount of characters used to indent by).
    /// </summary>
    public int IndentSize { get; }

    /// <summary>
    /// The current string used for indentation - a <see cref="string"/> that's <see cref="IndentSize"/> * <see cref="IndentationLevel"/>
    /// in length of <see cref="IndentationChar"/>.
    /// </summary>
    public string IndentationString { get; }

    /// <summary>
    /// Increments the indentation level (<see cref="IndentationLevel"/>) by an optionally specified amount.
    /// </summary>
    /// <param name="amount">The amount to increment the indentation level by.</param>
    public IIndentedStringBuilder IncrementIndentation(int amount = 1);

    /// <summary>
    /// Decrements the indentation level (<see cref="IndentationLevel"/>) by an optionally specified amount.
    /// </summary>
    /// <param name="amount">The amount to decrement the indentation level by.</param>
    public IIndentedStringBuilder DecrementIndentation(int amount = 1);

    /// <inheritdoc cref="StringBuilder.Append(bool)"/>
    public IIndentedStringBuilder Append(bool value);

    /// <inheritdoc cref="StringBuilder.Append(byte)"/>
    public IIndentedStringBuilder Append(byte value);

    /// <inheritdoc cref="StringBuilder.Append(char)"/>
    public IIndentedStringBuilder Append(char value);

    /// <inheritdoc cref="StringBuilder.Append(char[])"/>
    public IIndentedStringBuilder Append(char[]? value);

    /// <inheritdoc cref="StringBuilder.Append(char[], int, int)"/>
    public IIndentedStringBuilder Append(char[]? value, int startIndex, int charCount);

    /// <inheritdoc cref="StringBuilder.Append(decimal)"/>
    public IIndentedStringBuilder Append(decimal value);

    /// <inheritdoc cref="StringBuilder.Append(double)"/>
    public IIndentedStringBuilder Append(double value);

    /// <inheritdoc cref="StringBuilder.Append(short)"/>
    public IIndentedStringBuilder Append(short value);

    /// <inheritdoc cref="StringBuilder.Append(int)"/>
    public IIndentedStringBuilder Append(int value);

    /// <inheritdoc cref="StringBuilder.Append(long)"/>
    public IIndentedStringBuilder Append(long value);

    /// <inheritdoc cref="StringBuilder.Append(object)"/>
    public IIndentedStringBuilder Append(object? value);

    /// <inheritdoc cref="StringBuilder.Append(sbyte)"/>
    public IIndentedStringBuilder Append(sbyte value);

    /// <inheritdoc cref="StringBuilder.Append(float)"/>
    public IIndentedStringBuilder Append(float value);

    /// <inheritdoc cref="StringBuilder.Append(string)"/>
    public IIndentedStringBuilder Append(string? value);

    /// <inheritdoc cref="StringBuilder.Append(string, int, int)"/>
    public IIndentedStringBuilder Append(string? value, int startIndex, int charCount);

    /// <summary>
    /// Appends the string representation of a specified string builder to this instance
    /// </summary>
    /// <param name="value">The value to be appended.</param>
    /// <returns>A reference to this <see cref="IIndentedStringBuilder"/>.</returns>
    public IIndentedStringBuilder Append(IIndentedStringBuilder? value);

    /// <summary>
    /// Appends a copy of a substring within a specified <see cref="IIndentedStringBuilder"/> to this instance.
    /// </summary>
    /// <param name="value">The string builder that contains the substring to append.</param>
    /// <param name="startIndex">The starting position of the substring within value.</param>
    /// <param name="charCount">The number of characters in value to append.</param>
    /// <returns>A reference to this instance after the append operation has completed.</returns>
    public IIndentedStringBuilder Append(IIndentedStringBuilder? value, int startIndex, int charCount);

    /// <inheritdoc cref="StringBuilder.Append(uint)"/>
    public IIndentedStringBuilder Append(uint value);

    /// <inheritdoc cref="StringBuilder.Append(ulong)"/>
    public IIndentedStringBuilder Append(ulong value);

    /// <inheritdoc cref="StringBuilder.Append(ushort)"/>
    public IIndentedStringBuilder Append(ushort value);

    /// <inheritdoc cref="StringBuilder.AppendFormat(string, object[])"/>
    public IIndentedStringBuilder AppendFormat(string format, params object[] args);

    /// <inheritdoc cref="StringBuilder.AppendFormat(IFormatProvider, string, object[])"/>
    public IIndentedStringBuilder AppendFormat(IFormatProvider? provider, string format, params object[] args);

    /// <inheritdoc cref="StringBuilder.AppendLine()"/>
    public IIndentedStringBuilder AppendLine();

    /// <summary>
    /// Appends a string to the end of this builder, preserving the current <see cref="IndentationLevel"/>.
    /// </summary>
    /// <param name="value">The string to append.</param>
    public IIndentedStringBuilder AppendLine(string? value);

    /// <summary>
    /// Appends a specified amount of empty lines to this builder.
    /// </summary>
    /// <param name="amount">The amount of empty lines to add.</param>
    public IIndentedStringBuilder AppendLines(int amount = 1);

    /// <summary>
    /// Appends multiple provided lines to this builder, preserving the current <see cref="IndentationLevel"/>.
    /// </summary>
    /// <param name="values">The lines to be appended.</param>
    public IIndentedStringBuilder AppendLines(IEnumerable<string> values);

    /// <summary>
    /// Appends multiple provided lines to this builder, preserving the current <see cref="IndentationLevel"/>.
    /// </summary>
    /// <param name="action">An action that allows for passing the current builder to another function whilst maintaining
    /// call chaining.</param>
    public IIndentedStringBuilder AppendLines(Action<IIndentedStringBuilder> action);

    /// <summary>
    /// Temporarily indents the builder to append lines, and then return to original <see cref="IndentationLevel"/>.
    /// </summary>
    /// <param name="values">The lines to append.</param>
    /// <param name="amount">The amount to temporarily increment/decrement <see cref="IndentationLevel"/>.</param>
    public IIndentedStringBuilder IndentAndAppendLines(IEnumerable<string> values, int amount = 1);

    /// <summary>
    /// Temporarily indents the builder to append lines, and then return to original <see cref="IndentationLevel"/>.
    /// </summary>
    /// <param name="action">An action that creates an indented 'scope' for appending lines within.</param>
    /// <param name="amount">The amount to temporarily increment/decrement <see cref="IndentationLevel"/>.</param>
    public IIndentedStringBuilder IndentAndAppendLines(Action<IIndentedStringBuilder> action, int amount = 1);

    /// <inheritdoc cref="StringBuilder.Insert(int, bool)"/>
    public IIndentedStringBuilder Insert(int index, bool value);

    /// <inheritdoc cref="StringBuilder.Insert(int, byte)"/>
    public IIndentedStringBuilder Insert(int index, byte value);

    /// <inheritdoc cref="StringBuilder.Insert(int, char)"/>
    public IIndentedStringBuilder Insert(int index, char value);

    /// <inheritdoc cref="StringBuilder.Insert(int, char[])"/>
    public IIndentedStringBuilder Insert(int index, char[]? value);

    /// <inheritdoc cref="StringBuilder.Insert(int, char[],int, int)"/>
    public IIndentedStringBuilder Insert(int index, char[]? value, int startIndex, int charCount);

    /// <inheritdoc cref="StringBuilder.Insert(int, decimal)"/>
    public IIndentedStringBuilder Insert(int index, decimal value);

    /// <inheritdoc cref="StringBuilder.Insert(int, double)"/>
    public IIndentedStringBuilder Insert(int index, double value);

    /// <inheritdoc cref="StringBuilder.Insert(int, short)"/>
    public IIndentedStringBuilder Insert(int index, short value);

    /// <inheritdoc cref="StringBuilder.Insert(int, int)"/>
    public IIndentedStringBuilder Insert(int index, int value);

    /// <inheritdoc cref="StringBuilder.Insert(int, long)"/>
    public IIndentedStringBuilder Insert(int index, long value);

    /// <inheritdoc cref="StringBuilder.Insert(int, object)"/>
    public IIndentedStringBuilder Insert(int index, object? value);

    /// <inheritdoc cref="StringBuilder.Insert(int, sbyte)"/>
    public IIndentedStringBuilder Insert(int index, sbyte value);

    /// <inheritdoc cref="StringBuilder.Insert(int, float)"/>
    public IIndentedStringBuilder Insert(int index, float value);

    /// <inheritdoc cref="StringBuilder.Insert(int, string)"/>
    public IIndentedStringBuilder Insert(int index, string value);

    /// <inheritdoc cref="StringBuilder.Insert(int, string, int)"/>
    public IIndentedStringBuilder Insert(int index, string? value, int count);

    /// <inheritdoc cref="StringBuilder.Insert(int, uint)"/>
    public IIndentedStringBuilder Insert(int index, uint value);

    /// <inheritdoc cref="StringBuilder.Insert(int, ulong)"/>
    public IIndentedStringBuilder Insert(int index, ulong value);

    /// <inheritdoc cref="StringBuilder.Insert(int, ushort)"/>
    public IIndentedStringBuilder Insert(int index, ushort value);

    /// <inheritdoc cref="StringBuilder.Insert(int, int)"/>
    public IIndentedStringBuilder Remove(int startIndex, int length);

    /// <inheritdoc cref="StringBuilder.Replace(char, char)"/>
    public IIndentedStringBuilder Replace(char oldChar, char newChar);

    /// <inheritdoc cref="StringBuilder.Replace(char, char, int, int)"/>
    public IIndentedStringBuilder Replace(char oldChar, char newChar, int startIndex, int count);

    /// <inheritdoc cref="StringBuilder.Replace(string, string)"/>
    public IIndentedStringBuilder Replace(string oldValue, string newValue);

    /// <inheritdoc cref="StringBuilder.Replace(string, string, int, int)"/>
    public IIndentedStringBuilder Replace(string oldValue, string? newValue, int startIndex, int count);

    /// <summary>
    /// Removes all characters from the instance, and resets <see cref="IIndentedStringBuilder.IndentationLevel"/> to 0.
    /// </summary>
    public IIndentedStringBuilder Clear();

    /// <summary>
    /// Resets <see cref="IIndentedStringBuilder.IndentationLevel"/> to 0.
    /// </summary>
    public IIndentedStringBuilder ClearIndentation();

    /// <summary>
    /// Removes all characters from the instance.
    /// </summary>
    public IIndentedStringBuilder ClearBuilder();

    /// <inheritdoc cref="StringBuilder.EnsureCapacity"/>
    public int EnsureCapacity(int capacity);

    /// <inheritdoc cref="StringBuilder.Capacity"/>
    public int Capacity { get; set; }

    /// <inheritdoc cref="StringBuilder.this[int]"/>
    public char this[int index] { get; set; }

    /// <inheritdoc cref="StringBuilder.Length"/>
    public int Length { get; set; }

    /// <inheritdoc cref="StringBuilder.MaxCapacity"/>
    public int MaxCapacity { get; }

    /// <inheritdoc cref="StringBuilder.ToString()"/>
    public string ToString();

    /// <inheritdoc cref="StringBuilder.ToString(int, int)"/>
    public string ToString(int startIndex, int length);
}
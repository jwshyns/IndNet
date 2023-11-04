using FluentAssertions;

namespace IndNet.Tests;

public class IndentedStringBuilderIncrementTests
{
    private readonly IIndentedStringBuilder _sut = new IndentedStringBuilder();

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void IncrementIndentation_ShouldNotChangeIndentationLevel_WhenProvidedAmountIsZero(int startingValue)
    {
        // Arrange
        _sut.IncrementIndentation(startingValue);

        // Act
        var result = _sut.IncrementIndentation(0);

        // Assert
        result.IndentationLevel.Should().Be(startingValue);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void IncrementIndentation_ShouldIncrementIndentationLevel_WhenAmountProvidedIsPositive(int amount)
    {
        // Act
        var result = _sut.IncrementIndentation(amount);

        // Assert
        result.IndentationLevel.Should().Be(amount);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    [InlineData(-3)]
    [InlineData(-25)]
    [InlineData(-50)]
    [InlineData(-100)]
    public void IncrementIndentation_ShouldDecrementIndentationLevel_WhenAmountProvidedIsNegative(int amount)
    {
        // Arrange
        _sut.IncrementIndentation(Math.Abs(amount));

        // Act
        var result = _sut.IncrementIndentation(amount);

        // Assert
        result.IndentationLevel.Should().Be(0);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    [InlineData(-3)]
    [InlineData(-25)]
    [InlineData(-50)]
    [InlineData(-100)]
    public void IncrementIndentation_ShouldDecrementIndentationLevelToLessThanZero_WhenAmountProvidedIsNegative
        (int amount)
    {
        // Act
        var result = _sut.IncrementIndentation(amount);

        // Assert
        result.IndentationLevel.Should().Be(0);
    }
}
using FluentAssertions;

namespace IndNet.Tests;

public class IndentedStringBuilderDecrementTests
{
    private readonly IIndentedStringBuilder _sut = new IndentedStringBuilder();

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void DecrementIndentation_ShouldNotChangeIndentationLevel_WhenProvidedAmountIsZero(int startingValue)
    {
        // Arrange
        _sut.IncrementIndentation(startingValue);

        // Act
        var result = _sut.DecrementIndentation(0);

        // Assert
        result.Should().Be(_sut);
        result.IndentationLevel.Should().Be(startingValue);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void DecrementIndentation_ShouldDecrementIndentationLevel_WhenAmountProvidedIsPositive(int amount)
    {
        // Arrange
        _sut.IncrementIndentation(amount);

        // Act
        var result = _sut.DecrementIndentation(amount);

        // Assert
        result.Should().Be(_sut);
        result.IndentationLevel.Should().Be(0);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    [InlineData(-3)]
    [InlineData(-25)]
    [InlineData(-50)]
    [InlineData(-100)]
    public void DecrementIndentation_ShouldIncrementIndentationLevel_WhenAmountProvidedIsNegative(int amount)
    {
        // Arrange

        // Act
        var result = _sut.DecrementIndentation(amount);

        // Assert
        result.Should().Be(_sut);
        result.IndentationLevel.Should().Be(Math.Abs(amount));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void DecrementIndentation_ShouldDecrementIndentationLevelToLessThanZero_WhenAmountProvidedIsPositive
        (int amount)
    {
        // Act
        var result = _sut.DecrementIndentation(amount);

        // Assert
        result.Should().Be(_sut);
        result.IndentationLevel.Should().Be(0);
    }
}
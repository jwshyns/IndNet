using FluentAssertions;

namespace IndNet.Tests;

public class IndentedStringBuilderTests
{
    [Fact]
    public void Ctor_ShouldCorrectlyInstantiate_WhenProvidedProperParameters()
    {
        // Arrange

        // Act
        var result = () => new IndentedStringBuilder();

        // Assert
        result.Should().NotThrow();
    }

    [Fact]
    public void Ctor_ShouldThrow_WhenStartingIndentationLevelIsLessThanZero()
    {
        // Arrange

        // Act
        var result = () => new IndentedStringBuilder(startingIndentationLevel: -1);

        // Assert
        result
            .Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage("Must be greater than or equal to 0. (Parameter 'startingIndentationLevel')");
    }

    [Fact]
    public void Ctor_ShouldThrow_WhenIndentSizeIsLessThanOne()
    {
        // Arrange

        // Act
        var result = () => new IndentedStringBuilder(indentSize: 0);

        // Assert
        result
            .Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage("Must be greater than or equal to 1. (Parameter 'indentSize')");
    }
}
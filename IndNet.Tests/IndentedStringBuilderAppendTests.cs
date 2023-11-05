using FluentAssertions;

namespace IndNet.Tests;

public class IndentedStringBuilderAppendTests
{
    private readonly IIndentedStringBuilder _sut = new IndentedStringBuilder(' ', indentSize: 4);

    [Fact]
    public void AppendLine_ShouldAppendLineAtCurrentIndentationLevel_WhenValueIsProvided()
    {
        // Arrange
        _sut.IncrementIndentation();

        var expectedResult = $"    test{Environment.NewLine}";

        // Act
        var result = _sut.AppendLine("test");

        // Assert
        result.Should().Be(_sut);
        result.ToString().Should().Be(expectedResult);
    }

    [Fact]
    public void AppendLine_ShouldAppendLineWithoutIndentation_WhenValueIsNull()
    {
        // Arrange
        _sut.IncrementIndentation();

        var expectedResult = Environment.NewLine;

        // Act
        var result = _sut.AppendLine(null);

        // Assert
        result.Should().Be(_sut);
        result.ToString().Should().Be(expectedResult);
    }

    [Fact]
    public void AppendLine_ShouldAppendEmptyLineAtCurrentIndentationLevel_WhenValueIsNotProvided()
    {
        // Arrange
        _sut.IncrementIndentation();

        // Act
        var result = _sut.AppendLine();

        // Assert
        result.Should().Be(_sut);
        result.ToString().Should().Be(Environment.NewLine);
    }

    [Fact]
    public void AppendLines_ShouldAppendLinesAtCurrentIndentationLevel_WhenAmountIsProvided()
    {
        // Arrange
        _sut.IncrementIndentation();

        var expectedResult = $"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}";

        // Act
        var result = _sut.AppendLines(3);

        // Assert
        result.Should().Be(_sut);
        result.ToString().Should().Be(expectedResult);
    }

    [Fact]
    public void AppendLines_ShouldNotAppendLines_WhenAmountIsZero()
    {
        // Arrange
        _sut.IncrementIndentation();

        var expectedResult = string.Empty;

        // Act
        var result = _sut.AppendLines(0);

        // Assert
        result.Should().Be(_sut);
        result.ToString().Should().Be(expectedResult);
    }

    [Fact]
    public void AppendLines_ShouldAppendLinesAtCurrentIndentationLevel_WhenValuesAreProvided()
    {
        // Arrange
        _sut.IncrementIndentation();

        var expectedResult = $"""
                                  1
                                  2
                                  3{Environment.NewLine}
                              """;

        // Act
        var result = _sut.AppendLines(new[] { "1", "2", "3" });

        // Assert
        result.Should().Be(_sut);
        result.ToString().Should().Be(expectedResult);
    }

    [Fact]
    public void AppendBlock_ShouldAppendLinesAtCurrentIndentationLevel_WhenActionIsProvided()
    {
        // Arrange
        var expectedResult = $"""
                              1
                              2
                              3{Environment.NewLine}
                              """;

        Action<IIndentedStringBuilder> action = builder => { builder.AppendLines(new[] { "1", "2", "3" }); };

        // Act
        var result = _sut.AppendBlock(action);

        // Assert
        result.Should().Be(_sut);
        result.ToString().Should().Be(expectedResult);
        result.IndentationLevel.Should().Be(0);
    }

    [Fact]
    public void
        IndentAndAppendLines_ShouldAppendLinesAtIncrementedIndentationLevelAndDecrementAfterwards_WhenValuesAreProvided()
    {
        // Arrange
        var expectedResult = $"""
                                  1
                                  2
                                  3{Environment.NewLine}
                              """;

        // Act
        var result = _sut.IndentAndAppendLines(new[] { "1", "2", "3" });

        // Assert
        result.Should().Be(_sut);
        result.ToString().Should().Be(expectedResult);
        result.IndentationLevel.Should().Be(0);
    }

    [Fact]
    public void AppendIndentedBlock_ShouldAutomaticallyIncrementedAndDecrementIndentationLevel_WhenActionIsProvided()
    {
        // Arrange
        var expectedResult = $"""
                                  1
                                  2
                                  3{Environment.NewLine}
                              """;

        Action<IIndentedStringBuilder> action = builder => { builder.AppendLines(new[] { "1", "2", "3" }); };

        // Act
        var result = _sut.AppendIndentedBlock(action);

        // Assert
        result.Should().Be(_sut);
        result.ToString().Should().Be(expectedResult);
        result.IndentationLevel.Should().Be(0);
    }
}
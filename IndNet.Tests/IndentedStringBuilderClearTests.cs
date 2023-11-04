using System.Text;
using FluentAssertions;
using NSubstitute;

namespace IndNet.Tests;

public class IndentedStringBuilderClearTests
{
    private readonly IIndentedStringBuilder _sut = new IndentedStringBuilder(' ');

    [Fact]
    public void Clear_ShouldClearBuilderAndIndentation_WhenCalled()
    {
        // Arrange
        const int indentSize = 1;
        const string contents = "test contents";
        _sut.Append(contents);
        _sut.IncrementIndentation(100);
        
        // Act
        var result = _sut.Clear();
        
        // Assert
        result.Should().Be(_sut);
        result.ToString().Should().Be(string.Empty);
        result.IndentationLevel.Should().Be(0);
        result.IndentSize.Should().Be(indentSize);
        result.IndentationString.Should().Be(new string(_sut.IndentationChar, 0));
    }
    
    [Fact]
    public void ClearIndentation_ShouldClearIndentation_WhenCalled()
    {
        // Arrange
        const int indentSize = 1;
        const string contents = "test contents";
        _sut.Append(contents);
        _sut.IncrementIndentation(100);

        // Act
        var result = _sut.ClearIndentation();

        // Assert
        result.Should().Be(_sut);
        result.ToString().Should().Be(contents);
        result.IndentationLevel.Should().Be(0);
        result.IndentSize.Should().Be(indentSize);
        result.IndentationString.Should().Be(new string(_sut.IndentationChar, 0));
    }
    
    [Fact]
    public void ClearBuilder_ShouldClearUnderlyingStringBuilder_WhenCalled()
    {
        // Arrange
        const int indentSize = 1;
        const int incrementAmount = 100;
        const string contents = "test contents";
        _sut.Append(contents);
        _sut.IncrementIndentation(incrementAmount);

        // Act
        var result = _sut.ClearBuilder();

        // Assert
        result.Should().Be(_sut);
        result.ToString().Should().Be(string.Empty);
        result.IndentationLevel.Should().Be(incrementAmount);
        result.IndentSize.Should().Be(indentSize);
        result.IndentationString.Should().Be(new string(_sut.IndentationChar, incrementAmount * indentSize));
    }
}
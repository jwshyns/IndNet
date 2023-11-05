# IndNet

A thin wrapper around StringBuilder to aid in indenting new lines when string building.
___

## Configuration
### Default constructor
```csharp
var isb = new IndentedStringBuilder(indentationChar: '\t', startingIndentationLevel: 0, indentSize: 1, stringBuilder: null);
```
#### indentationChar
- Defaults to `\t`
- Optionally change the character used for indentation
#### startingIndentationLevel
- Defaults to `0`
- Optionally change the starting indentation level
#### indentSize
- Defaults to `1`
- Optionally change how many characters are used for each indentation level
#### stringBuilder
- Defaults to `null`
- Optionally provide a pre-configured `StringBuilder`

## Example(s)

Using the `IndentedStringBuilder` is as easy as using the native `StringBuilder`, and exposes many of the same methods
with the addition of the following:

### IncrementIndentation(int amount = 1)
This method is used for incrementing the indentation of subsequently appended lines:
```csharp
var isb = new IndentedStringBuilder();

var s = isb.AppendLine("Line 1")
            .IncrementIndentation()
            .AppendLine("Line 2")
            .ToString();

Console.WriteLine(s);
```
which would write the following to console:
```text
Line 1
    Line 2
```

### DecrementIndentation(int amount = 1)
This method is used for incrementing the indentation of subsequently appended lines:
```csharp
var isb = new IndentedStringBuilder();

var s = isb.AppendLine("Line 1")
            .IncrementIndentation()
            .AppendLine("Line 2")
            .DecrementIndentation()
            .AppendLine("Line 3")
            .ToString();

Console.WriteLine(s);
```
which would write the following to console:
```text
Line 1
    Line 2
Line 3
```

### AppendLine(string? value)
Ok, `StringBuilder` has this too but in `IndentedStringBuilder` this behaves a bit differently. If you read the examples
for `IncrementIndentation` and `DecrementIndentation` you'll see that in addition to appending new lines, it does so
with respect to the current indentation of the `IndentedStringBuilder` (so have a look there for some usage examples).

### AppendLines(int amount = 1)
This method wraps `StringBuilder.AppendLine()` allowing for you to append multiple blank lines from a single method call.

### AppendLines(IEnumerable<string> values)
This method wraps `AppendLine(string? value)` allowing you to provide multiple strings and have them appended as new lines
with respect to the current indentation level:
```csharp
var isb = new IndentedStringBuilder();

var s = isb.AppendLine("Line 1")
            .IncrementIndentation()
            .AppendLines(new [] {"Line 2", "Line 3"})
            .ToString();

Console.WriteLine(s);
```
which would write the following to console:
```text
Line 1
    Line 2
    Line 3
```

### AppendBlock(Action<IIndentedStringBuilder> action)
This serves as a 'convenience' allowing another method to append to the builder whilst maintaining your call chaining:
```csharp
var isb = new IndentedStringBuilder();

// can be a anonymous method, local method, class method, or other - this is just an example
Action<IIndentedStringBuilder> action = builder => { builder.AppendLines(new[] { "1", "2", "3" }); };

var s = isb.AppendLine("Line 1")
            .IncrementIndentation()
            .AppendBlock(action)
            .AppendLines(new [] {"Line 2", "Line 3"})
            .ToString();

Console.WriteLine(s);
```
which would write the following to console:
```text
Line 1
    1
    2
    3
    Line 2
    Line 3
```

### AppendIndentedBlock(Action<IIndentedStringBuilder> action)
Similar to `AppendBlock(Action<IIndentedStringBuilder> action)`, this serves as a 'convenience' allowing another method 
to append to the builder whilst maintaining your call chaining, however this automatically increments and then decrements
around the lines appended by the provided action:
```csharp
var isb = new IndentedStringBuilder();

// can be a anonymous method, local method, class method, or other - this is just an example
Action<IIndentedStringBuilder> action = builder => { builder.AppendLines(new[] { "1", "2", "3" }); };

var s = isb.AppendLine("Line 1")
            .AppendIndentedBlock(action)
            .AppendLines(new [] {"Line 2", "Line 3"})
            .ToString();

Console.WriteLine(s);
```
which would write the following to console:
```text
Line 1
    1
    2
    3
Line 2
Line 3
```

### IndentAndAppendLines(IEnumerable<string> values)
Similar to `AppendBlock(Action<IIndentedStringBuilder> action)`, however this allows you to provide strings that you
wish to both indent and append as new lines:
```csharp
var isb = new IndentedStringBuilder();


var s = isb.AppendLine("Line 1")
            .IndentAndAppendLines(new[] { "1", "2", "3" }))
            .AppendLines(new [] {"Line 2", "Line 3"})
            .ToString();

Console.WriteLine(s);
```
which would write the following to console:
```text
Line 1
    1
    2
    3
Line 2
Line 3
```
using IndNet;

Console.WriteLine("==== Example Increment ====");

var exampleIncrement = new IndentedStringBuilder()
    .AppendLine("Line 1")
    .IncrementIndentation()
    .AppendLine("Line 2")
    .ToString();
Console.WriteLine(exampleIncrement);

Console.WriteLine("==== Example Decrement ====");

var exampleDecrement = new IndentedStringBuilder()
    .AppendLine("Line 1")
    .IncrementIndentation()
    .AppendLine("Line 2")
    .DecrementIndentation()
    .AppendLine("Line 3")
    .ToString();
Console.WriteLine(exampleDecrement);

Console.WriteLine("==== Example Append Block ====");

// can be a anonymous method, local method, class method, or other - this is just an example
Action<IIndentedStringBuilder> appendBlockAction = builder => { builder.AppendLines(new[] { "1", "2", "3" }); };

var exampleAppendBlock = new IndentedStringBuilder()
    .AppendLine("Line 1")
    .IncrementIndentation()
    .AppendBlock(appendBlockAction)
    .AppendLines(new[] { "Line 2", "Line 3" })
    .ToString();

Console.WriteLine(exampleAppendBlock);

Console.WriteLine("==== Append Indented Block ====");


// can be a anonymous method, local method, class method, or other - this is just an example
Action<IIndentedStringBuilder> indentedBlockAction = builder => { builder.AppendLines(new[] { "1", "2", "3" }); };

var exampleAppendIndentedBlock = new IndentedStringBuilder()
    .AppendLine("Line 1")
    .AppendIndentedBlock(indentedBlockAction)
    .AppendLines(new[] { "Line 2", "Line 3" })
    .ToString();

Console.WriteLine(exampleAppendIndentedBlock);
using MarkdownUtilities;

var table = new TableBuilder()
  .WithHeaders("First Name", "Last Name")
  .AddRow("Mark", "Kraus")
  .AddRow("Karl", "Marx")
  .AddRow("Friedrich", "Engels");
Console.WriteLine(table);
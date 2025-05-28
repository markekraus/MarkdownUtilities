# Markdown Utilities

This is a collection of markdown utilities.

## Table of Contents

- [Markdown Utilities](#markdown-utilities)
  - [Table of Contents](#table-of-contents)
  - [Building](#building)
  - [Usage](#usage)
    - [C-Sharp](#c-sharp)
    - [PowerShell](#powershell)
  - [Utilities](#utilities)
    - [Table Builder](#table-builder)

## Building

From PowerShell:

```powershell
& ./build.ps1
```

## Usage

### C-Sharp

Clone the repo and then Add a reference to the csproj.

```powershell
dotnet add reference .\path\to\MarkdownUtilities.csproj
```

Then you can use it un your code like so:

```csharp
using MarkdownUtilities;

var table = new TableBuilder()
  .WithHeaders("A", "B", "C")
  .AddRow("1", "2", "3")
  .AddRow("4", "5", "6")
  .AddRow("7", "8", "9");
Console.WriteLine(table);
```

### PowerShell

Download and extract the the last net21 release.

```powershell
Add-Type -Path .\path\to\MarkdownUtilities.dll
$builder = [MarkdownUtilities.TableBuilder]::New()
$builder.WithHeaders("A", "B", "C").
    AddRow("1", "2", "3").
    AddRow("4", "5", "6").
    AddRow("7", "8", "9").
    ToString()
```

## Utilities

### Table Builder

The table builder will build a markdown representation of data. It will automatically escape characters that may break the table. It also auto-sizes the columns so that they appear uniform in raw text.

```csharp
var table = new TableBuilder()
  .WithHeaders("First Name", "Last Name")
  .AddRow("Mark", "Kraus")
  .AddRow("Karl", "Marx")
  .AddRow("Friedrich", "Engels")
  .AddRow("Nestor", "Makhno");
Console.WriteLine(table);
```

Result:

```text
| First Name | Last Name |
| ---------- | --------- |
| Mark       | Kraus     |
| Karl       | Marx      |
| Friedrich  | Engels    |
| Nestor     | Makhno    |
```

When rendered:

| First Name | Last Name |
| ---------- | --------- |
| Mark       | Kraus     |
| Karl       | Marx      |
| Friedrich  | Engels    |
| Nestor     | Makhno    |

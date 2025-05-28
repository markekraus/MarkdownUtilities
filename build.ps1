# NetStandard 2.1
dotnet build .\MarkdownUtilities.slnx -c net21
Remove-Item $path/*.deps.json

# MelonLoader Il2Cpp
dotnet build .\MarkdownUtilities.slnx -c net6
Remove-Item $path/*.deps.json

Get-Date

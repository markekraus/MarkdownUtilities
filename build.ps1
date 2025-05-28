if (!(get-command ILRepack.exe)) {
    dotnet tool install -g dotnet-ilrepack
}

# NetStandard 2.1
dotnet build .\MarkdownUtilities.slnx -c net21
$Path = ".\Release\MarkdownUtilities.net21\"
$Name = "MarkdownUtilities.net21.dll"
ILRepack.exe /target:library /lib:$Path /internalize /out:$Path/$Name $Path/$Name
Remove-Item $path/*.deps.json

# MelonLoader Il2Cpp
dotnet build .\MarkdownUtilities.slnx -c net6
$Path = ".\Release\MarkdownUtilities.net6"
$Name = "MarkdownUtilities.net6.dll"
ILRepack.exe /target:library /lib:$Path /internalize /out:$Path/$Name $Path/$Name
Remove-Item $path/*.deps.json

Get-Date

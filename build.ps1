if (!(get-command ILRepack.exe)) {
    dotnet tool install -g dotnet-ilrepack
}

Push-Location src

# NetStandard 2.1
dotnet build -c net21
$Path = "..\Release\MarkdownUtilities.net21\"
ILRepack.exe /target:library /lib:$Path /internalize /out:$Path/MarkdownUtilities.dll $Path/MarkdownUtilities.dll
Remove-Item $path/MarkdownUtilities.deps.json

# MelonLoader Il2Cpp
dotnet build -c ML_Cpp_CoreCLR
$Path = "..\Release\MarkdownUtilities.MelonLoader.IL2CPP.CoreCLR"
ILRepack.exe /target:library /lib:$Path /internalize /out:$Path/MarkdownUtilities.ML.IL2CPP.CoreCLR.dll $Path/MarkdownUtilities.ML.IL2CPP.CoreCLR.dll
Remove-Item $path/MarkdownUtilities.ML.IL2CPP.CoreCLR.deps.json

Get-Date
Pop-Location
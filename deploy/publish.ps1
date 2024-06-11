$ErrorActionPreference = 'Stop'

$outPath = "$env:LOCALAPPDATA\DesktopInfoBar"

if(!(Test-Path -PathType container $outPath))
{
    New-Item -ItemType Directory -Path $outPath
}

dotnet publish `
    ..\src\DesktopInfoBar.App\DesktopInfoBar.App.csproj `
    -f net8.0-windows10.0.19041.0 `
    -c Release `
    -p:RuntimeIdentifierOverride=win10-x64 `
    -p:WindowsPackageType=None `
    -p:WindowsAppSDKSelfContained=true `
    --self-contained `
    --output $outPath

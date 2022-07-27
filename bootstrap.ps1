$p = $env:PATH

if($null -eq $Global:IsWindows) 
{
    # back compat variables for powershell 5.1 and below
    Set-Variable -Name "IsWindows" -Value ([Environment]::OSVersion.Platform.ToString().StartsWith("Win")) -Scope Global
    Set-Variable -Name "IsLinux" -Value (([Environment]::OSVersion.Platform -eq [PlatformId]::Unix)) -Scope Global
    Set-Variable -Name "IsMacOs" -Value ([Environment]::OSVersion.Platform -eq  [PlatformId]::MacOSX) -Scope Global
}

$bootDir = Join-Path $PSScriptRoot 'bootstrap'

if(!(Test-Path -Path $bootDir))
{
    Write-Host "Bootstrap directory not found or checked out: $bootDir" -ForegroundColor Red
    exit 1
}

# load scripts as a path, if it is not already prepended.
$paths = $p.Split([IO.Path]::PathSeparator)
$scripts = Join-Path $bootDir "scripts"
$hasScripts = $false;
foreach($p in $Paths) {
    if($p -eq $scripts) {
        $hasScripts = $true;
        break
    }
}

if(!$hasScripts) {
    $env:Path = "$($scripts)$([IO.Path]::PathSeparator)$($env:Path)"
}

$paths = $Env:PSModulePath.Split([IO.Path]::PathSeparator)
$modules = Join-Path $bootDir "modules"
$hasModules = $false;
foreach($p in $Paths) {
    if($p -eq $modules) {
        $hasModules = $true;
        break
    }
}

if(!$hasModules) {
    $env:PSModulePath = "$($modules)$([IO.Path]::PathSeparator)$($env:PSModulePath)"
}

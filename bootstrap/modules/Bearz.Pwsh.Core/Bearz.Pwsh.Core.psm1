

$functions = @();
$files = Get-Item "$PSScriptRoot\public\*.ps1" -EA SilentlyContinue
foreach($f in $files) {
    . "$($f.FullName)"

    $functions += $f.Name
}

Export-ModuleMember -Function @functions
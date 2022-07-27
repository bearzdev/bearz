function Test-Command() {
    [CmdletBinding()]
    param (
        [Parameter()]
        [TypeName("System.String")]
        $Command,

        [Parameter()]
        [Switch]
        $Throw
    )

    process {
        $result =  $null -ne (Get-Command $Command -EA SilentlyContinue)

        if($Throw -and $result -eq $false) {
            throw "Command not found on environment path: $Command"
        }
    }
}
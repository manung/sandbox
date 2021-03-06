<#
Modifies csproj files to turn on/off code analysis in Visual Studio
#>
param (
    $value = 'true',
    $exclude = '*Specs*'
)

$ns = @{msbuild="http://schemas.microsoft.com/developer/msbuild/2003"} 

function Set-CodeAnalysis {
    param (
        $path
    )
        
    $xml = [xml](Get-Content $path)
    $xml.Project | Select-Xml -XPath '//msbuild:RunCodeAnalysis' -Namespace $ns | % {$_.Node.'#text' = $value}
    $xml.Save($path)
}

gci -recurse -filter '*.csproj' | ? {$_.FullName -notlike $exclude} | % {Set-CodeAnalysis $_.FullName}



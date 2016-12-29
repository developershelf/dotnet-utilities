Param($a)

if($a ==) {
    Write-Host "API key required";
    exit;
}

Write-Host "Starting Nuget package publishing for DeveloperShelf Utilities"
nuget push DeveloperShelf.Utilities.1.0.0.nupkg $a -Source https://www.nuget.org/api/v2/package
Write-Host "Nuget publishing complete"
Param($a, $b)

if(!$a){
	Write-Host "Nuget package required"
	exit;
}

if(!$b) {
    Write-Host "API key required";
    exit;
}

Write-Host "Starting Nuget package publishing for DeveloperShelf Utilities"
nuget push $a $b -Source https://www.nuget.org/api/v2/package
Write-Host "Nuget publishing complete"
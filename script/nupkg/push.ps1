$apiKey = $args[0]

$rootPath = (Get-Item -Path "./" -Verbose).FullName
Write-Host ($rootPath)

Get-ChildItem ./src/**/*.nupkg -recurse | ForEach-Object -Process {
	if ($_ -is [System.IO.FileInfo]) {
		$nupkgPath = $_.Directory
		Write-Host ($nupkgPath)
		Set-Location $nupkgPath
		dotnet nuget push $_.Name -s https://api.nuget.org/v3/index.json --api-key "$apiKey"

		Set-Location $rootPath
	}
}

Set-Location $rootPath

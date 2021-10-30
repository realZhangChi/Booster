$apiKey = $args[0]
Write-Host ($apiKey)

$rootPath = (Get-Item -Path "./" -Verbose).FullName

Get-ChildItem ./src/**/bin/Release/*.nupkg -recurse | ForEach-Object -Process {
	if ($_ -is [System.IO.FileInfo]) {
		$nupkgPath = $_.Directory
		Set-Location $nupkgPath
		dotnet nuget push $_.Name -s https://api.nuget.org/v3/index.json --api-key "$apiKey"

		Set-Location $rootPath
	}
}

Set-Location $rootPath
Get-ChildItem ./binding/**/bin/Release/*.nupkg -recurse | ForEach-Object -Process {
	if ($_ -is [System.IO.FileInfo]) {
		$nupkgPath = $_.Directory
		Set-Location $nupkgPath
		dotnet nuget push $_.Name -s https://api.nuget.org/v3/index.json --api-key "$apiKey"

		Set-Location $rootPath
	}
}

Set-Location $rootPath

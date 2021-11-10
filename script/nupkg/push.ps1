$apiKey = $args[0]

$rootPath = (Get-Item -Path "./" -Verbose).FullName

Get-ChildItem ./src/**/*.nupkg -recurse | ForEach-Object -Process {
	if ($_ -is [System.IO.FileInfo]) {
		Set-Location $_.Directory
		dotnet nuget push $_.Name -s https://api.nuget.org/v3/index.json --api-key "$apiKey"
		dotnet nuget push $snupkg -s https://api.nuget.org/v3/index.json --api-key "$apiKey"

		Set-Location $rootPath
	}
}

Set-Location $rootPath

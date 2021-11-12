$rootPath = (Get-Item -Path "./" -Verbose).FullName

Get-ChildItem ./src/**/*.sln -recurse | ForEach-Object -Process{
	if($_ -is [System.IO.FileInfo])
	{
		$projectPath = $_.Directory
		Set-Location $projectPath
		dotnet clean
		& dotnet build
		if (-Not $?) {
			Write-Host ("Test failed for the project: " + $_.Name)
			Set-Location $rootPath
			exit $LASTEXITCODE
		}
	}
}

Set-Location $rootPath

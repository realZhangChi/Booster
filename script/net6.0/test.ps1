$rootPath = (Get-Item -Path "./" -Verbose).FullName

Get-ChildItem ./test/**/*.UnitTest.csproj -recurse | ForEach-Object -Process{
	if($_ -is [System.IO.FileInfo])
	{
		$unitTestAbsPath = $_.Directory
		Set-Location $unitTestAbsPath
		dotnet test
		if (-Not $?) {
			Write-Host ("Test failed for the project: " + $_.Name)
			Set-Location $rootPath
			exit $LASTEXITCODE
		}
	}
}

Set-Location $rootPath

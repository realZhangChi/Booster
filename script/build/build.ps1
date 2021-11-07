Get-ChildItem ./src/**/*.csproj -recurse | ForEach-Object -Process{
	if($_ -is [System.IO.FileInfo])
	{
		msbuild $_.FullName -restore -p:Configuration=Debug
		if (-Not $?) {
			Write-Host ("Build failed for the project: " + $_.Name)
			exit $LASTEXITCODE
		}
	}
}

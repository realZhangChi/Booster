$rootFolder = (Get-Item -Path "./" -Verbose).FullName

dotnet restore

Get-ChildItem ./src/**/*.csproj -recurse | ForEach-Object -Process {
	
	.\nuget\nuget.exe pack $_.FullName
    if (-Not $?) {
        Write-Host ("Packaging failed for the project: " + $_.Name)
        exit $LASTEXITCODE
    }
    Set-Location $rootFolder
}

Set-Location $rootFolder

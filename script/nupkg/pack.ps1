$rootFolder = (Get-Item -Path "./" -Verbose).FullName

Get-ChildItem ./src/**/*.csproj -recurse | ForEach-Object -Process {
    Set-Location $_.Directory

    dotnet pack -c Release
    if (-Not $?) {
        Write-Host ("Packaging failed for the project: " + $_.Name)
        exit $LASTEXITCODE
    }
    Set-Location $rootFolder
}

Set-Location $rootFolder

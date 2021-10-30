$rootFolder = (Get-Item -Path "./" -Verbose).FullName

dotnet restore

Get-ChildItem ./src/**/*.csproj -recurse | ForEach-Object -Process {
    $projectFolder = $_.Directory

    Set-Location $projectFolder
    Remove-Item -Recurse (Join-Path $projectFolder "bin/Release")
    & dotnet pack -c Release
    if (-Not $?) {
        Write-Host ("Packaging failed for the project: " + $_.Name)
        exit $LASTEXITCODE
    }
    Set-Location $rootFolder
}

Set-Location $rootFolder

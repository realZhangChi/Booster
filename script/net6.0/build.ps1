$rootFolder = (Get-Item -Path "./" -Verbose).FullName

Get-ChildItem ./src/**/*.csproj -recurse | ForEach-Object -Process {

    Set-Location $_.Directory
    dotnet build --configuration Release -f net6.0
    if (-Not $?) {
        Write-Host ("Build failed for the app: " + $_.Name)
        exit $LASTEXITCODE
    }
    Set-Location $rootFolder
}

Set-Location $rootFolder

$rootFolder = (Get-Item -Path "./" -Verbose).FullName

Get-ChildItem ./test/**/*.DeviceTest.csproj -recurse | ForEach-Object -Process {

    Set-Location $_.Directory
    dotnet build --configuration Release -f net6.0-ios -p:BuildIpa=true
    if (-Not $?) {
        Write-Host ("Build failed for the app: " + $_.Name)
        exit $LASTEXITCODE
    }
    Set-Location $rootFolder
}

Set-Location $rootFolder
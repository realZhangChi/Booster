$rootFolder = (Get-Item -Path "./" -Verbose).FullName

Get-ChildItem ./src/**/*.DeviceTest.csproj -recurse | ForEach-Object -Process {

    Set-Location $_.Directory
    dotnet clean
    & dotnet build --configuration Debug -f net6.0-android -p:EmbedAssembliesIntoApk=true
    if (-Not $?) {
        Write-Host ("Build failed for the app: " + $_.Name)
        Set-Location $rootFolder
        exit $LASTEXITCODE
    }
    Set-Location $rootFolder
}

Set-Location $rootFolder
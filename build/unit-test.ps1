$rootPath = (Get-Item -Path "./" -Verbose).FullName

$unitTestPaths = @(
		"../test/Maui.Toolkit.WeChat/Maui.Toolkit.WeChat.Abstraction.Test"
	)

foreach ($unitTestPath in $unitTestPaths) {    
    $unitTestAbsPath = (Join-Path $rootPath $unitTestPath)
    Set-Location $unitTestAbsPath
    dotnet test --no-build --no-restore
    if (-Not $?) {
        Write-Host ("Test failed for the project: " + $unitTestPath)
        Set-Location $rootPath
        exit $LASTEXITCODE
    }
}

Set-Location $rootPath
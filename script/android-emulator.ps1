$sdkRootPath = (Get-Item -Path $Env:ANDROID_SDK_ROOT -Verbose).FullName

$toolsPath = (Join-Path $sdkRootPath "tools/bin")
$emulatorPath = (Join-Path $sdkRootPath "emulator")

Set-Location $toolsPath
./sdkmanager --install "system-images;android-31;google_apis_playstore;x86_64" --verbose
yes | ./sdkmanager --licenses --verbose
if (-Not $?) {
    Write-Host ("Build failed for the solution")
    exit $LASTEXITCODE
}
else {
    Write-Host ("Success!")
    exit 0
}

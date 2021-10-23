$sdkRootPath = (Get-Item -Path $Env:ANDROID_SDK_ROOT -Verbose).FullName

$toolsPath = (Join-Path $sdkRootPath "tools/bin")
$emulatorPath = (Join-Path $sdkRootPath "emulator")

Set-Location $sdkRootPath
ls
Set-Location $emulatorPath
Write-Host("emulatorPath:" + $emulatorPath)
ls
Set-Location $toolsPath
Write-Host("toolsPath:" + $toolsPath)
ls
./avdmanager create avd -name android-31 --package "system-images;android-31;google_apis_playstore;x86_64"
if (-Not $?) {
    Write-Host ("Avd creation failed.")
    exit $LASTEXITCODE
}

Set-Location $emulatorPath
emulator -avd android-31 -no-window -gpu swiftshader_indirect -no-snapshot -noaudio -no-boot-anim
if (-Not $?) {
    Write-Host ("Android emulator failed to start.")
    exit $LASTEXITCODE
}
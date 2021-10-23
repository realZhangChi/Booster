$sdkRootPath = (Get-Item -Path $Env:ANDROID_SDK_ROOT -Verbose).FullName

$toolsPath = (Join-Path $sdkRootPath "tools/bin")
$emulatorPath = (Join-Path $sdkRootPath "emulator")

Write-Host("toolsPath:" + $toolsPath)
Write-Host("emulatorPath:" + $emulatorPath)
Set-Location $sdkRootPath
ls
Set-Location $emulatorPath
ls
Set-Location $toolsPath
ls
avdmanager create avd -name android-31 --package "system-images;android-31;google_apis_playstore;x86_64"
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
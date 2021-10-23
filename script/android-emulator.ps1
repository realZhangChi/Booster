$sdkRootPath = (Get-Item -Path $Env:ANDROID_SDK_ROOT -Verbose).FullName

$toolsPath = (Join-Path $sdkRootPath "tools/bin")
$emulatorPath = (Join-Path $sdkRootPath "emulator")

Set-Location $toolsPath
./sdkmanager --list
./avdmanager create avd --name android-30 --package "system-images;android-30;google_apis;x86_64"
if (-Not $?) {
    Write-Host ("Avd creation failed.")
    exit $LASTEXITCODE
}

Set-Location $emulatorPath
./emulator -avd android-31 -no-window -gpu swiftshader_indirect -no-snapshot -noaudio -no-boot-anim
if (-Not $?) {
    Write-Host ("Android emulator failed to start.")
    exit $LASTEXITCODE
}
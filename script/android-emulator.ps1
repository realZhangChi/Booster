$avdManagerPath = (Join-Path $Env:ANDROID_SDK_ROOT '/tools/bin').FullName
$emulatorPath = (Join-Path $Env:ANDROID_SDK_ROOT '/emulator').FullName
Write-Host($avdManagerPath)
Write-Host($emulatorPath)

Invoke-Expression -Command '$avdManagerPath/avdmanager create avd -name android-31 --package "system-images;android-31;google_apis_playstore;x86_64"'
if (-Not $?) {
    Write-Host ("Avd creation failed.")
    exit $LASTEXITCODE
}

Invoke-Expression -Command '$emulatorPath/emulator -avd android-31 -no-window -gpu swiftshader_indirect -no-snapshot -noaudio -no-boot-anim'
if (-Not $?) {
    Write-Host ("Android emulator failed to start.")
    exit $LASTEXITCODE
}
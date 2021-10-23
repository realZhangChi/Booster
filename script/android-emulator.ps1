Write-Host($Env:ANDROID_SDK_ROOT)
$avdManagerPath = (Join-Path $Env:ANDROID_SDK_ROOT './tools/bin/avdmanager').FullName
$emulatorPath = (Join-Path $Env:ANDROID_SDK_ROOT './emulator/emulator').FullName
Write-Host($avdManagerPath)
Write-Host($emulatorPath)

Invoke-Expression -Command '$avdManagerPath create avd -name android-31 --package "system-images;android-31;google_apis_playstore;x86_64"'
if (-Not $?) {
    Write-Host ("Avd creation failed.")
    exit $LASTEXITCODE
}

Invoke-Expression -Command '$emulatorPath -avd android-31 -no-window -gpu swiftshader_indirect -no-snapshot -noaudio -no-boot-anim'
if (-Not $?) {
    Write-Host ("Android emulator failed to start.")
    exit $LASTEXITCODE
}
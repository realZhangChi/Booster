$Env:ANDROID_SDK_ROOT/tools/bin/avdmanager create avd -name android-31 --package "system-images;android-31;google_apis_playstore;x86_64"
if (-Not $?) {
    Write-Host ("Avd creation failed.")
    exit $LASTEXITCODE
}

$Env:ANDROID_SDK_ROOT/emulator/emulator -avd android-31 -no-window -gpu swiftshader_indirect -no-snapshot -noaudio -no-boot-anim
if (-Not $?) {
    Write-Host ("Android emulator failed to start.")
    exit $LASTEXITCODE
}
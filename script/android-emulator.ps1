$sdkRootPath = (Get-Item -Path $Env:ANDROID_SDK_ROOT -Verbose).FullName

$toolsPath = (Join-Path $sdkRootPath "tools/bin")
$emulatorPath = (Join-Path $sdkRootPath "emulator")

Set-Location $toolsPath
./avdmanager create avd --force -n android_31 -k "system-images;android-31;google_apis_playstore;x86_64"
./avdmanager list avd

Set-Location $emulatorPath
# ./emulator -avd android_31 -no-window -gpu swiftshader_indirect -no-snapshot -noaudio -no-boot-anim
ls

exit
$sdkRootPath = (Get-Item -Path $Env:ANDROID_SDK_ROOT -Verbose).FullName

$toolsPath = (Join-Path $sdkRootPath "tools/bin")
$emulatorPath = (Join-Path $sdkRootPath "emulator")

Set-Location $toolsPath
(./sdkmanager "system-images;android-31;google_apis_playstore;x86_64") -and
(yes |./sdkmanager --licenses) -and
(./avdmanager create avd --force -n android_31 -k "system-images;android-31;google_apis_playstore;x86_64")


Set-Location $emulatorPath
# ./emulator -avd android_31 -no-window -gpu swiftshader_indirect -no-snapshot -noaudio -no-boot-anim
ls

exit
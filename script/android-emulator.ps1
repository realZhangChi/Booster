$sdkRootPath = (Get-Item -Path $Env:ANDROID_SDK_ROOT -Verbose).FullName

$toolsPath = (Join-Path $sdkRootPath "tools/bin")
$emulatorPath = (Join-Path $sdkRootPath "emulator")

Set-Location $toolsPath
./avdmanager list avd
./avdmanager list device
./avdmanager list target

Set-Location $emulatorPath
./emulator -list-avds
# ./emulator -avd android_31 -no-window -gpu swiftshader_indirect -no-snapshot -noaudio -no-boot-anim
# ls

exit
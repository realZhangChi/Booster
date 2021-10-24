$sdkRootPath = (Get-Item -Path $Env:ANDROID_SDK_ROOT -Verbose).FullName

$toolsPath = (Join-Path $sdkRootPath "tools/bin")
$emulatorPath = (Join-Path $sdkRootPath "emulator")

Set-Location $emulatorPath
./emulator -avd Android_Emulator_31 -no-window -gpu swiftshader_indirect -no-snapshot -noaudio -no-boot-anim
# ls

exit 0
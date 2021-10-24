$sdkRootPath = (Get-Item -Path $Env:ANDROID_SDK_ROOT -Verbose).FullName

# $toolsPath = (Join-Path $sdkRootPath "tools/bin")
$emulatorPath = (Join-Path $sdkRootPath "emulator")
$platformPath = (Join-Path $sdkRootPath "platform-tools")

Set-Location $emulatorPath
./emulator -avd Android_Emulator_31 -no-window -gpu swiftshader_indirect -no-snapshot -noaudio -no-boot-anim

Set-Location $platformPath
Write-Host ("adb devices:")
adb devices

$rootFolder = (Get-Item -Path "./" -Verbose).FullName
$sdkRootPath = (Get-Item -Path $Env:ANDROID_SDK_ROOT -Verbose).FullName

# $toolsPath = (Join-Path $sdkRootPath "tools/bin")
$emulatorPath = (Join-Path $sdkRootPath "emulator")
$platformPath = (Join-Path $sdkRootPath "platform-tools")

Set-Location $emulatorPath
Write-Host ($emulatorPath)
ls
./emulator  -no-boot-anim -accel on -avd Android_Emulator_31 -prop monodroid.avdname=Android_Emulator_31

Set-Location $platformPath
Write-Host ("adb devices:")
adb devices

Set-Location $rootFolder
Get-ChildItem ./test/**/*-Signed.apk -recurse | ForEach-Object -Process{
	if($_ -is [System.IO.FileInfo])
	{
		$package = $_.Name -replace "-Signed.apk",""
		xharness android test --output-directory=out --package-name=$package --app=$_ --instrumentation=$package.TestInstrumentation --verbosity=Debug
		if (-Not $?) {
			Write-Host ("Test failed for the apk: " + $_.Name)
			exit $LASTEXITCODE
		}
	}
}
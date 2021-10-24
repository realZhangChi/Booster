$sdkRootPath = (Get-Item -Path $Env:ANDROID_SDK_ROOT -Verbose).FullName
$toolsPath = (Join-Path $sdkRootPath "tools/bin")

Set-Location $toolsPath
./avdmanager --install "system-images;android-31;google_apis_playstore;x86_64"
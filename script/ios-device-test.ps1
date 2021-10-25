$testDevice = ios-simulator-64_latest
Write-Host ("installing simulator...")
xharness apple simulators install $testDevice --verbosity=Debug

Get-ChildItem ./test/**/*.DeviceTest/**/*.app | ForEach-Object -Process{
	if($_ -is [System.IO.System.IO.FileInfo])
	{
		xharness apple test --app= $_.FullName --targets=$testDevice $testDevice=out $testDevice=Debug
		if (-Not $?) {
			Write-Host ("Test failed for the app: " + $_.Name)
			exit $LASTEXITCODE
		}
	}
}
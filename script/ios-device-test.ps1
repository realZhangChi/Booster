$testDevice = "ios-simulator_13.4"
# Write-Host ("installing simulator...")
# xharness apple simulators install $testDevice --verbosity=Debug

Get-ChildItem ./test/**/*.app -recurse | ForEach-Object -Process{
        Write-Host ($_.FullName)
	if($_ -is [System.IO.DirectoryInfo ])
	{
		xharness apple test --app= $_.FullName --targets=$testDevice $testDevice=out $testDevice=Debug
		if (-Not $?) {
			Write-Host ("Test failed for the app: " + $_.Name)
			exit $LASTEXITCODE
		}
	}
}

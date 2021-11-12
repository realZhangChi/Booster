$testDevice = "ios-simulator-64"
# Write-Host ("installing simulator...")
# xharness apple simulators install $testDevice --verbosity=Debug

Get-ChildItem ./src/**/*.app -recurse | ForEach-Object -Process{
        Write-Host ($_.FullName)
	if($_ -is [System.IO.DirectoryInfo ])
	{
		xharness apple test --app=$_ --targets=$testDevice --output-directory=out --verbosity=Debug
		if (-Not $?) {
			Write-Host ("Test failed for the app: " + $_.Name)
			exit $LASTEXITCODE
		}
	}
}

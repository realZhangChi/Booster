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
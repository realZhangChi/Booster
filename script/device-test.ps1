Get-ChildItem ./test/**/*-Signed.apk -recurse | ForEach-Object -Process{
	if($_ -is [System.IO.FileInfo])
	{
		$package = $_.Name -replace "-Signed.apk",""
		xharness android test --output-directory=out --package-name=$package --app=$_ --instrumentation=$package.MauiTestInstrumentation --verbosity=Debug
	}
}
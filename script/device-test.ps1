Get-ChildItem ./test/**/*-Signed.apk -recurse | ForEach-Object -Process{
	if($_ -is [System.IO.FileInfo])
	{
		Write-Host($_.FullName);
	}
}
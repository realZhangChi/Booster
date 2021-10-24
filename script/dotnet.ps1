$ProgressPreference = 'SilentlyContinue'
Invoke-WebRequest -Uri "https://dot.net/v1/dotnet-install.ps1" -OutFile dotnet-install.ps1
& .\dotnet-install.ps1 -Version 6.0.100-rc.2.21505.57 -InstallDir "$env:ProgramFiles\dotnet\" -Verbose
& dotnet --list-sdks
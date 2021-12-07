using System;
using ObjCRuntime;

[assembly: LinkWith ("libWeChatSDK.a", LinkTarget.ArmV7 | LinkTarget.Simulator, ForceLoad = true,
    Frameworks = "CFNetwork CoreTelephony Security SystemConfiguration",
    LinkerFlags = "-ObjC -all_load -lc++ -lsqlite3.0 -lz")]

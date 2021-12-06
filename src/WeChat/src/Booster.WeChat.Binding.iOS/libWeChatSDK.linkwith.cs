using System;
using ObjCRuntime;

[assembly: LinkWith ("libWeChatSDK.a", LinkTarget.ArmV7 | LinkTarget.Simulator, ForceLoad = true)]

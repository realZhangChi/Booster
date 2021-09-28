global using Maui.Toolkit.WeChat.Services.Http;
global using Maui.Toolkit.WeChat.Services.Identity;
global using Maui.Toolkit.WeChat.Models.Identity;
global using Maui.Toolkit.WeChat.Utils;
global using Microsoft.Extensions.Options;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Microsoft.Maui;
global using Microsoft.Maui.Controls;
global using Microsoft.Maui.Essentials;
global using System;
global using System.Net.Http;
global using System.Threading.Tasks;
global using System.Text.Json;

#if __ANDROID__
global using Maui.Toolkit.WeChat.Platforms.Android;
global using Maui.Toolkit.WeChat.Platforms.Android.Identity;
global using Com.Tencent.MM.Opensdk.Openapi;
global using Com.Tencent.MM.Opensdk.Modelmsg;
global using Com.Tencent.MM.Opensdk.Constants;
global using Com.Tencent.MM.Opensdk.Modelbase;
global using Android.Content;
global using Android.OS;
#endif

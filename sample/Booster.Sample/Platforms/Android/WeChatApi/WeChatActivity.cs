using System;

using Android.App;
using Android.Content;
using Android.Content.PM;

using Booster.WeChat.Platforms.Android.WeChatApi;

using Com.Tencent.MM.Opensdk.Modelbase;
using Com.Tencent.MM.Opensdk.Openapi;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;

namespace Booster.Sample.Platforms.Android.WeChatApi
{
    [Activity(
        Name = "com.companyname.Booster.Sample.WeChatApi.WeChatActivity",
        Exported = true,
        TaskAffinity = "com.companyname.Booster.Sample",
        LaunchMode = LaunchMode.SingleTask)]
    public class WeChatActivity : MauiAppCompatActivity, IWXAPIEventHandler
    {
        private readonly IWXAPI _weChatApi;

        public WeChatActivity()
        {
            _weChatApi = MauiApplication.Current.Services.GetRequiredService<IWXAPI>();
        }

        protected override void OnNewIntent(Intent? intent)
        {
            base.OnNewIntent(intent);
            _weChatApi.HandleIntent(intent, this);
        }

        public void OnReq(BaseReq? p0)
        {
            throw new NotImplementedException();
        }

        public async void OnResp(BaseResp? response)
        {
            var processorManager = MauiApplication.Current.Services.GetRequiredService<IResponseProcessorManager>();
            await processorManager.HandleAsync(response);
        }
    }
}

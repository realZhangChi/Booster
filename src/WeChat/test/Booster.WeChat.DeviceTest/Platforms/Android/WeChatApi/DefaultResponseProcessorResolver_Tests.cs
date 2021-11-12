using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Booster.WeChat.Platforms.Android.WeChatApi;

using Com.Tencent.MM.Opensdk.Constants;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;

using Shouldly;

using Xunit;

namespace Booster.WeChat.DeviceTest.Platforms.Android.WeChatApi
{
    public class DefaultResponseProcessorResolver_Tests
    {
        [Fact]
        public async Task Should_be_Resolved_Correctly()
        {
            var resolver = MauiApplication.Current.Services.GetRequiredService<IResponseProcessorResolver>();

            var authProcessor = await resolver.ResolveAsync(IConstantsAPI.CommandSendauth);
            var defaultProcessor = await resolver.ResolveAsync(IConstantsAPI.CommandUnknown);

            authProcessor.GetType().IsAssignableFrom(typeof(AuthorizationResponseProcessor)).ShouldBeTrue();
            defaultProcessor.GetType().IsAssignableFrom(typeof(DefaultResponseProcessor)).ShouldBeTrue();
        }
    }
}

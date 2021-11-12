using Booster.WeChat.Platforms.Android.WeChatApi;
using Booster.WeChat.Services.Identity;

using Com.Tencent.MM.Opensdk.Modelbase;

using Microsoft.Maui.Controls;

using Shouldly;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace Booster.WeChat.DeviceTest.Platforms.Android.WeChatApi
{
    public abstract class ResponseProcessorTestBase
    {
        protected IResponseProcessor Processor { get; set; }

        [Fact]
        public async Task Should_Receive_Message_When_WeChatResponse_Not_ErrOk()
        {
            var errorCommon = BaseResp.IErrCode.ErrComm;
            var response = new DummyWeChatResponse
            {
                Err_Code = errorCommon
            };
            var errorCodeInMessage = 0;
            MessagingCenter.Subscribe<IResponseProcessor, AuthorizationMessageArgs>(
                this,
                AuthorizationMessages.Failed,
                (_, args) => errorCodeInMessage = args.Code);

            await Processor.ProcessResponseAsync(response);

            errorCodeInMessage.ShouldBe(errorCommon);

            // clean
            MessagingCenter.Unsubscribe<IResponseProcessor, AuthorizationMessageArgs>(
                this,
                AuthorizationMessages.Failed);
        }



        protected class DummyWeChatResponse : Com.Tencent.MM.Opensdk.Modelbase.BaseResp
        {
            public override int Type => throw new NotImplementedException();

            public DummyWeChatResponse()
            {
                Err_Code = BaseResp.IErrCode.ErrOk;
            }

            public override bool CheckArgs()
            {
                throw new NotImplementedException();
            }
        }
    }
}

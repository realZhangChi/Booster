using Booster.WeChat.Services.Identity;

using Com.Tencent.MM.Opensdk.Modelbase;

using Microsoft.Maui.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booster.WeChat.Platforms.Android.WeChatApi
{
    public abstract class ResponseProcessorBase
    {
        public bool EnsureSuccessResponse(BaseResp response)
        {
            if (response.Err_Code is not BaseResp.IErrCode.ErrOk)
            {
                MessagingCenter.Send(
                    (IResponseProcessor)this,
                    AuthorizationMessages.Failed,
                    AuthorizationMessageArgs.FailedInstance(
                        response.Err_Code,
                        response.ErrStr ?? string.Empty));
                return false;
            }

            return true;
        }
    }
}

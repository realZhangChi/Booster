using Com.Tencent.MM.Opensdk.Modelbase;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booster.WeChat.Platforms.Android.WeChatApi
{
    public abstract class ResponseProcessorBase
    {
        public bool EnsureSuccessResponse(BaseResp? response)
        {
            if (response is null)
            {
                return false;
            }

            if (response.Err_Code is not BaseResp.IErrCode.ErrOk)
            {
                return false;
            }

            return true;
        }
    }
}

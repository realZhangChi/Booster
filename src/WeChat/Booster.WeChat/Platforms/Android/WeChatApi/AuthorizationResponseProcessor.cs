using System;
using System.Threading.Tasks;

using Booster.WeChat.Extensions;
using Booster.WeChat.Services.Identity;

using Com.Tencent.MM.Opensdk.Constants;
using Com.Tencent.MM.Opensdk.Modelbase;
using Com.Tencent.MM.Opensdk.Modelmsg;

using Microsoft.Extensions.Options;

namespace Booster.WeChat.Platforms.Android.WeChatApi
{
    public class AuthorizationResponseProcessor : ResponseProcessorBase, IResponseProcessor
    {
        public int ResponseType => IConstantsAPI.CommandSendauth;

        private readonly IAuthorizationService _authorizationService;
        private readonly WeChatMobileOptions _options;


        public AuthorizationResponseProcessor(
            IAuthorizationService authorizationService,
            IOptions<WeChatMobileOptions> options)
        {
            _authorizationService = authorizationService;
            _options = options.Value;
        }

        public Task HandleAsync(BaseResp response)
        {
            EnsureSuccessResponse(response);

            if (response is not SendAuth.Resp authResponse)
            {
                throw new ArgumentException("response is not SendAuth.Resp!");
            }

            return _authorizationService.AuthorizeCallbackAsync(_options.AppId, _options.AppSecret, authResponse.Code ?? string.Empty);
        }
    }
}

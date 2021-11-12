using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booster.WeChat.Platforms.Android.WeChatApi
{
    public class DefaultResponseResponseProcessorResolver : IResponseProcessorResolver
    {
        private readonly IEnumerable<IResponseProcessor> _handlers;

        public DefaultResponseResponseProcessorResolver(
            IEnumerable<IResponseProcessor> handlers)
        {
            _handlers = handlers;
        }

        public Task<IResponseProcessor> ResolveAsync(int responseType)
        {
            var handler = _handlers.FirstOrDefault(h => h.ResponseType == responseType);
            if (handler == null)
            {
                handler = new DefaultResponseHandler();
            }

            return Task.FromResult(handler);
        }
    }
}

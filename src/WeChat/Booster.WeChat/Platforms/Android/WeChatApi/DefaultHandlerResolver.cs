using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booster.WeChat.Platforms.Android.WeChatApi
{
    public class DefaultHandlerResolver : IHandlerResolver
    {
        private readonly IEnumerable<IResponseHandler> _handlers;

        public DefaultHandlerResolver(
            IEnumerable<IResponseHandler> handlers)
        {
            _handlers = handlers;
        }

        public Task<IResponseHandler> ResolveAsync(int responseType)
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

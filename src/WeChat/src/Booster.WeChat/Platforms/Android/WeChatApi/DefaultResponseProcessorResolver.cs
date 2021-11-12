using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booster.WeChat.Platforms.Android.WeChatApi
{
    public class DefaultResponseProcessorResolver : IResponseProcessorResolver
    {
        private readonly IEnumerable<IResponseProcessor> _handlers;

        public DefaultResponseProcessorResolver(
            IEnumerable<IResponseProcessor> handlers)
        {
            _handlers = handlers;
        }

        public Task<IResponseProcessor> ResolveAsync(int responseType)
        {
            var handler = _handlers.FirstOrDefault(h => h.ResponseType == responseType) ?? new DefaultResponseProcessor();

            return Task.FromResult(handler);
        }
    }
}

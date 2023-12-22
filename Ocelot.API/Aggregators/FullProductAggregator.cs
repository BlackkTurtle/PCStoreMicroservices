using Ocelot.Middleware;
using System.Net;
using System.Text;
using Ocelot.Multiplexer;
using System.Net.Http.Headers;

namespace Ocelot.API.Aggregators
{
    public class FullProductAggregator:IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            var one = await responses[0].Items.DownstreamResponse().Content.ReadAsStringAsync();
            var two = await responses[1].Items.DownstreamResponse().Content.ReadAsStringAsync();

            var contentBuilder = new StringBuilder();
            contentBuilder.Append(one);
            contentBuilder.Append(two);

            var stringContent = new StringContent(contentBuilder.ToString())
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };

            return new DownstreamResponse(stringContent, HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "OK");
        }
    }
}

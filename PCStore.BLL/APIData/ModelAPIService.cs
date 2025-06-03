using PCStore.BLL.APIData.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.BLL.APIData
{
    public class ModelAPIService : IModelAPIService
    {
        private readonly string key = "pl9XDVY10w0WXtZmVRpCMVb7IORK7KJL";

        public async Task<double> GetModelPrediction(string comment)
        {
            try
            {
                string encodedComment = Uri.EscapeDataString(comment);
                string url = $"http://host.docker.internal:8000/getcommentprediction/{key}/{encodedComment}";
                using (var httpClient = new HttpClient())
                {
                    using (HttpResponseMessage response = await httpClient.GetAsync(url).ConfigureAwait(false))
                    {
                        response.EnsureSuccessStatusCode();

                        var result = await response.Content.ReadFromJsonAsync<double>().ConfigureAwait(false);

                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Request error: {ex.Message}");
            }
        }
    }
}

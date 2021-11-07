using LibreriaComponenti.Interfaces;
using LibreriaComponenti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DemoWASM.Services
{
    public class ReqResDataService : IReqResService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private CancellationTokenSource cancellationTokenSource;

        public ReqResDataService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public void CancelRequest()
        {
            cancellationTokenSource.Cancel();
        }

        public async Task<ReqResData> GetReqResData()
        {
            var httpClient = httpClientFactory.CreateClient("ReqRes");
            cancellationTokenSource = new CancellationTokenSource();

            using var response = await httpClient.GetAsync("users",
                HttpCompletionOption.ResponseHeadersRead, cancellationTokenSource.Token);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ReqResData>();

            } else
            {
                return null;
            }
        }

        public async Task<string> PostNewUser(NewUser newUser)
        {
            var httpClient = httpClientFactory.CreateClient("ReqRes");

            using var response = await httpClient.PostAsJsonAsync<NewUser>(
                "users", newUser);

            if (response.IsSuccessStatusCode)
            {
                return response.StatusCode.ToString();
            } else
            {
                return "KO";
            }

        }
    }
}

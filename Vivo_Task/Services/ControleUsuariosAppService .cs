using Vivo_Task.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Diagnostics;

using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.FundamentalModels;

namespace Vivo_Task.Services
{
    public interface IControleUsuariosAppService
    {
        Task<MainResponse> BloquearUsuarios(string TP_AFASTAMENTO, string OBS, int id);
        Task<MainResponse> DesbloquearUsuarios(int id);
        Task<MainResponse> GetUsuarios(ControleUsuariosFilterModel data);
        Task<MainResponse> GetUsuariosFilter();
        Task<MainResponse> UpdateUsuarios(ACESSOS_MOBILE data);
    }
    public class ControleUsuariosAppService : IControleUsuariosAppService
    {
        public async Task<MainResponse> GetUsuariosFilter()
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("powerautomatelink");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress);
                var response = await MakeRequestAsync(request, client);
                return new MainResponse
                {
                    Content = response,
                    IsSuccess = true,
                    ErrorMessage = null
                };
            }
            catch (Exception)
            {
                return new MainResponse
                {
                    Content = "",
                    IsSuccess = false,
                    ErrorMessage = "algum erro ocorreu"
                };
            }
        }
        public async Task<MainResponse> GetUsuarios(ControleUsuariosFilterModel data)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("powerautomatelink");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var body = JsonConvert.SerializeObject(data);
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Content = content;
                var response = await MakeRequestAsync(request, client);
                return new MainResponse
                {
                    Content = response,
                    IsSuccess = true,
                    ErrorMessage = null
                };
            }
            catch (Exception)
            {
                return new MainResponse
                {
                    Content = "",
                    IsSuccess = false,
                    ErrorMessage = "algum erro ocorreu"
                };
            }
        }
        public async Task<MainResponse> UpdateUsuarios(ACESSOS_MOBILE data)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("powerautomatelink");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, client.BaseAddress);
                var body = JsonConvert.SerializeObject(data);
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Content = content;
                var response = await MakeRequestAsync(request, client);
                return new MainResponse
                {
                    Content = response,
                    IsSuccess = true,
                    ErrorMessage = null
                };
            }
            catch (Exception)
            {
                return new MainResponse
                {
                    Content = "",
                    IsSuccess = false,
                    ErrorMessage = "algum erro ocorreu"
                };
            }
        }

        public async Task<MainResponse> BloquearUsuarios(string TP_AFASTAMENTO, string OBS, int id)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("powerautomatelink");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, client.BaseAddress);
                var body = JsonConvert.SerializeObject(new { TP_AFASTAMENTO = TP_AFASTAMENTO, OBS = OBS, id = id });
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Content = content;
                var response = await MakeRequestAsync(request, client);
                return new MainResponse
                {
                    Content = response,
                    IsSuccess = true,
                    ErrorMessage = null
                };
            }
            catch (Exception)
            {
                return new MainResponse
                {
                    Content = "",
                    IsSuccess = false,
                    ErrorMessage = "algum erro ocorreu"
                };
            }
        }
        public async Task<MainResponse> DesbloquearUsuarios(int id)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("powerautomatelink");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, client.BaseAddress);
                var body = JsonConvert.SerializeObject(new {id = id });
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Content = content;
                var response = await MakeRequestAsync(request, client);
                return new MainResponse
                {
                    Content = response,
                    IsSuccess = true,
                    ErrorMessage = null
                };
            }
            catch (Exception)
            {
                return new MainResponse
                {
                    Content = "",
                    IsSuccess = false,
                    ErrorMessage = "algum erro ocorreu"
                };
            }
        }
        private async Task<string> MakeRequestAsync(HttpRequestMessage getRequest, HttpClient client)
        {
            var response = await client.SendAsync(getRequest).WaitAsync(new TimeSpan(0, 5, 0)).ConfigureAwait(true);
            var responseString = string.Empty;
            try
            {
                response.EnsureSuccessStatusCode();
                responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine(ex);
            }

            return responseString;
        }
    }
}

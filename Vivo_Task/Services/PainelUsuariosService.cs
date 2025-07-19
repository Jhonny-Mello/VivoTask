using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Vivo_Task.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using Vivo_Task.Shared_Static_Class.FundamentalModels;

namespace Vivo_Task.Services
{
    public interface IPainelUsuariosService
    {
        Task<MainResponse> GetUsuariosPendentes(GenericPaginationModel<FilterUsuariosPendentesModel> data);
    }
    public class PainelUsuariosService : IPainelUsuariosService
    {
        private string BaseUrl
        {
            get
            {
                return "s";
            }
        }
        public async Task<MainResponse> GetUsuariosPendentes(GenericPaginationModel<FilterUsuariosPendentesModel> data)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri($"s/GetUsuariosPendentes");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var body = JsonConvert.SerializeObject(data);
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Content = content;
                return await MakeRequestAsync(request, client);
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
        private async Task<MainResponse> MakeRequestAsync(HttpRequestMessage getRequest, HttpClient client)
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
            if (!string.IsNullOrEmpty(responseString))
            {
                return new MainResponse
                {
                    Content = responseString,
                    IsSuccess = true
                };
            }
            else
            {
                return new MainResponse
                {
                    Content = response,
                    IsSuccess = false,
                    ErrorMessage = "algum erro ocorreu"
                };
            }
        }
    }
}
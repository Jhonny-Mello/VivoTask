using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.ErrorModels;
using Vivo_Task.Shared_Static_Class.Model_DTO;
using Vivo_Task.Shared_Static_Class.FundamentalModels;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using static Vivo_Task.Shared_Static_Class.Data.DEMANDA_RELACAO_CHAMADO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Vivo_Task.Shared_Static_Class.Model_DTO.FilterModels;
using Azure;
using Vivo_Task.Shared_Static_Class.Model_ForumRTCZ_Context;
using Blazorise;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.JSInterop;
using Vivo_Task.Models;
using Shared_Static_Class.Model;

namespace Vivo_Task.Services
{
    public interface IForumRTCZService
    {
        Task<MainResponse> SearchByFilters(GenericPaginationModel<PainelForumRTCZ> filter);
        Task<MainResponse> SearchByFilters(GenericPaginationModel<PainelForumRTCZ> filter, int matricula);
        Task<MainResponse> SearchByAnalista(GenericPaginationModel<PainelForumRTCZ> filter, int matricula);
        Task<MainResponse> GetTemas();
        Task<MainResponse> GetTemas(int matricula);
        Task<MainResponse> PostPublicacao(PublicacaoModel data);
        Task<MainResponse> PostRespostaPublicacao(RespostaPublicacaoModel data);
        Task<MainResponse> PostAvaliacaoToPublicacao(AvaliacaoPublicacaoModel avaliacao);

    }

    public class ForumRTCZService : IForumRTCZService
    {

        public async Task<MainResponse> GetTemas()
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(APIs.GetTemas);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress);
                return await MakeRequestAsync(request, client);
            }
            catch (Exception ex)
            {
                return new MainResponse
                {
                    Content = ex,
                    IsSuccess = false,
                    ErrorMessage = "algum erro ocorreu"
                };
            }
        }
        public async Task<MainResponse> GetTemas(int matricula)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(APIs.GetTemasByAnalista.Replace("{matricula}", matricula.ToString()));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress);
                return await MakeRequestAsync(request, client);
            }
            catch (Exception ex)
            {
                return new MainResponse
                {
                    Content = ex,
                    IsSuccess = false,
                    ErrorMessage = "algum erro ocorreu"
                };
            }
        }
        public async Task<MainResponse> SearchByAnalista(GenericPaginationModel<PainelForumRTCZ> filter, int matricula)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(APIs.GetPublicacoesAnalista.Replace("{matricula}", matricula.ToString()));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);

                var body = JsonConvert.SerializeObject(filter);
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Content = content;

                return await MakeRequestAsync(request, client);
            }
            catch (Exception ex)
            {
                return new MainResponse
                {
                    Content = ex,
                    IsSuccess = false,
                    ErrorMessage = "algum erro ocorreu"
                };
            }
        }
        public async Task<MainResponse> SearchByFilters(GenericPaginationModel<PainelForumRTCZ> filter, int matricula)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(APIs.GetPublicacoesUsuario.Replace("{matricula}", matricula.ToString()));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);

                var body = JsonConvert.SerializeObject(filter);
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Content = content;

                return await MakeRequestAsync(request, client);
            }
            catch (Exception ex)
            {
                return new MainResponse
                {
                    Content = ex,
                    IsSuccess = false,
                    ErrorMessage = "algum erro ocorreu"
                };
            }
        }
        public async Task<MainResponse> SearchByFilters(GenericPaginationModel<PainelForumRTCZ> filter)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(APIs.GetPublicacoes);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);

                var body = JsonConvert.SerializeObject(filter);
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Content = content;

                return await MakeRequestAsync(request, client);
            }
            catch (Exception ex)
            {
                return new MainResponse
                {
                    Content = ex,
                    IsSuccess = false,
                    ErrorMessage = "algum erro ocorreu"
                };
            }
        }
        public async Task<MainResponse> PostPublicacao(PublicacaoModel data)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(APIs.PostPublicacao);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);

                var body = JsonConvert.SerializeObject(data);
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Content = content;

                return await MakeRequestAsync(request, client);
            }
            catch (Exception ex)
            {
                return new MainResponse
                {
                    Content = ex,
                    IsSuccess = false,
                    ErrorMessage = "algum erro ocorreu"
                };
            }
        }
        public async Task<MainResponse> PostRespostaPublicacao(RespostaPublicacaoModel data)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(APIs.PostRespostaPublicacao);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);

                var body = JsonConvert.SerializeObject(data);
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Content = content;

                return await MakeRequestAsync(request, client);
            }
            catch (Exception ex)
            {
                return new MainResponse
                {
                    Content = ex,
                    IsSuccess = false,
                    ErrorMessage = "algum erro ocorreu"
                };
            }
        }
        public async Task<MainResponse> PostAvaliacaoToPublicacao(AvaliacaoPublicacaoModel avaliacao)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(APIs.PostAvaliacaoPublicacao);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);

                var body = JsonConvert.SerializeObject(avaliacao);
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
            client.Timeout = Timeout.InfiniteTimeSpan;
            var response = await client.SendAsync(getRequest).WaitAsync(new TimeSpan(0, 5, 0)).ConfigureAwait(true);
            var responseString = string.Empty;
            try
            {
                response.EnsureSuccessStatusCode();
                responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            catch (HttpRequestException ex)
            {
                responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (!string.IsNullOrEmpty(responseString))
                {
                    var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseString);
                    var Erros = string.Join('\n', errorResponse.Errors.SelectMany(x => x.Value).Select((x, y) => $"{y + 1}°. {x}"));
                    return new MainResponse
                    {
                        Content = errorResponse,
                        IsSuccess = false,
                        ErrorMessage = Erros
                    };
                }
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

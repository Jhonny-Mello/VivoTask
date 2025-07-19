using Vivo_Task.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Diagnostics;
using Vivo_Task.ModelDTO;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.FundamentalModels;


namespace Vivo_Task.Services
{

    public interface IFormularioService
    {
        Task<MainResponse> DeleteFormulario(JORNADA_BD_QUESTION_HISTORICO data);
        Task<MainResponse> GetAllEnableFormJornada(string CANAL, string CARGO, int MATRICULA);
        Task<MainResponse> GetQuestionsByID_PROVA(int id);
        Task<MainResponse> GetAllEnableFormRotina(string CANAL, string CARGO, int MATRICULA);
        Task<MainResponse> GetForm(List<int?> IDs_Question);
        Task<MainResponse> GetListProvas_ByMatricula(int matricula, string cargo);
        Task<MainResponse> GetQuestionFromExcel();
        Task<MainResponse> InsertNovoFormulario(Form Resposta);
        Task<MainResponse> InsertRESPOSTA(List<JORNADA_BD_AVALIACAO_RETORNO> data);
        Task<MainResponse> Insert_RESULTADO_PROVA(JORNADA_BD_ANSWER_AVALIACAO data);
    }
    public class FormularioService : IFormularioService
    {
        public async Task<MainResponse> GetQuestionsByID_PROVA(int id)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("linktopowerautomate");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var body = JsonConvert.SerializeObject(new { id = id });
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
        public async Task<MainResponse> GetForm(List<int?> IDs_Question)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("linktopowerautomate");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var body = JsonConvert.SerializeObject(new { QUESTIONS = IDs_Question });
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
        public async Task<MainResponse> GetAllEnableFormJornada(string CANAL, string CARGO, int MATRICULA)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("linktopowerautomate");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var body = JsonConvert.SerializeObject(new { CANAL = CANAL, CARGO = CARGO, MATRICULA = MATRICULA, FIXA = Setting.UserBasicDetail.Fixa });
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
        public async Task<MainResponse> InsertRESPOSTA(List<JORNADA_BD_AVALIACAO_RETORNO> data)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("linktopowerautomate");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var body = JsonConvert.SerializeObject(new { RESPOSTAS = data });
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
        public async Task<MainResponse> Insert_RESULTADO_PROVA(JORNADA_BD_ANSWER_AVALIACAO data)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("linktopowerautomate");
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
        public async Task<MainResponse> GetAllEnableFormRotina(string CANAL, string CARGO, int MATRICULA)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("linktopowerautomate");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var body = JsonConvert.SerializeObject(new { CANAL = CANAL, CARGO = CARGO, MATRICULA = MATRICULA });
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
        public async Task<MainResponse> InsertNovoFormulario(Form Resposta)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                if (Resposta.FIXA != "SIM")
                {
                    client.BaseAddress = new Uri("linktopowerautomate");
                }
                else
                {
                    client.BaseAddress = new Uri("linktopowerautomate");
                }
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var body = JsonConvert.SerializeObject(Resposta);
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

        public async Task<MainResponse> GetQuestionFromExcel()
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("linktopowerautomate");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var content = new StringContent("{}", Encoding.UTF8, "application/json");
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
        public async Task<MainResponse> DeleteFormulario(JORNADA_BD_QUESTION_HISTORICO data)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("linktopowerautomate");
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
        public async Task<MainResponse> GetListProvas_ByMatricula(int matricula, string cargo)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("linktopowerautomate");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var body = JsonConvert.SerializeObject(new {matricula = matricula , cargo = cargo});
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
        public async Task<string> MakeRequestAsync(HttpRequestMessage getRequest, HttpClient client)
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

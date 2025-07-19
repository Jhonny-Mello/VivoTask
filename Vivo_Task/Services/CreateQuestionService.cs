using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Vivo_Task.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.FundamentalModels;


namespace Vivo_Task.Services
{
    public interface ICreateQuestionService
    {
        Task<MainResponse> CreateQuestion(string TEMA, string SUB_TEMA, IEnumerable<string> TP_FORMS, string TP_QUESTAO, string PERGUNTA, IEnumerable<int> CARGO, bool? FIXA, List<JORNADA_BD_ANSWER_ALTERNATIVA> ALTERNATIVAS, int? matricula);
        Task<MainResponse> GetDataCriarQuestion();
    }
    public class CreateQuestionService : ICreateQuestionService
    {
        public async Task<MainResponse> GetDataCriarQuestion()
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri($"s/GetDataCriarQuestion");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress);
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
        public async Task<MainResponse> CreateQuestion(
            string TEMA,
            string SUB_TEMA,
            IEnumerable<string> TP_FORMS,
            string TP_QUESTAO,
            string PERGUNTA,
            IEnumerable<int> CARGO,
            bool? FIXA,
            List<JORNADA_BD_ANSWER_ALTERNATIVA> ALTERNATIVAS,
            int? matricula
            )
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri($"s/CreateQuestion");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var body = JsonConvert.SerializeObject(new
                {
                    TEMA,
                    SUB_TEMA,
                    TP_FORMS,
                    TP_QUESTAO,
                    PERGUNTA,
                    CARGO,
                    FIXA,
                    ALTERNATIVAS,
                    matricula
                });
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

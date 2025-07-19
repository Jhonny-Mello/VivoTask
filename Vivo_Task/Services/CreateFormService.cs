using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Vivo_Task.Models;
using Newtonsoft.Json;
using System.Diagnostics;

using System.Globalization;
using Vivo_Task.Shared_Static_Class.FundamentalModels;

namespace Vivo_Task.Services
{
    public interface ICreateFormService
    {
        Task<MainResponse> CriarFormulario(IEnumerable<TEMAS_QTD>? TEMAS_QUANTIDADE,
            string TIPO_PROVA,
            int CARGO,
            bool FIXA,
            string REGIONAL,
            int MATRICULA,
            DateTime DT_INIT,
            DateTime? DT_FINAL,
            int QTD_TOTAL_SOLICITADA,
            bool ELEGIVEL);
        Task<MainResponse> GetDataCriarFormulario();
        Task<MainResponse> GetTemasCriarFormulario(string TIPO_PROVA, string REGIONAL, int CARGO, bool FIXA);
        Task<MainResponse> Get_Qtd_SubTema(string TIPO_PROVA, int CARGO, bool FIXA, int SUB_TEMA);
        Task<MainResponse> Get_Qtd_Tema(string TIPO_PROVA, int CARGO, bool FIXA, int TEMA);
    }
    public class CreateFormService : ICreateFormService
    {
        public async Task<MainResponse> GetDataCriarFormulario()
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(APIs.GetDataCriarFormulario);
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

        public async Task<MainResponse> GetTemasCriarFormulario(
      string TIPO_PROVA,
      string REGIONAL,
      int CARGO,
      bool FIXA
      )
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(APIs.GetTemasCriarFormulario);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var body = JsonConvert.SerializeObject(new
                {
                    TIPO_PROVA = TIPO_PROVA,
                    CARGO = CARGO,
                    FIXA = FIXA,
                    REGIONAL = REGIONAL
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

        public async Task<MainResponse> Get_Qtd_Tema(
            string TIPO_PROVA,
            int CARGO,
            bool FIXA,
            int TEMA
            )
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(APIs.Get_Qtd_Tema);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var body = JsonConvert.SerializeObject(new
                {
                    TIPO_PROVA = TIPO_PROVA,
                    CARGO = CARGO,
                    FIXA = FIXA,
                    TEMA = TEMA
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
        public async Task<MainResponse> Get_Qtd_SubTema(
           string TIPO_PROVA,
           int CARGO,
           bool FIXA,
           int SUB_TEMA
           )
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(APIs.Get_Qtd_SubTema);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var body = JsonConvert.SerializeObject(new
                {
                    TIPO_PROVA = TIPO_PROVA,
                    CARGO = CARGO,
                    FIXA = FIXA,
                    SUB_TEMA = SUB_TEMA
                });
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

        public async Task<MainResponse> CriarFormulario(
            IEnumerable<TEMAS_QTD>? TEMAS_QUANTIDADE,
            string TIPO_PROVA,
            int CARGO,
            bool FIXA,
            string REGIONAL,
            int MATRICULA,
            DateTime DT_INIT,
            DateTime? DT_FINAL,
            int QTD_TOTAL_SOLICITADA,
            bool ELEGIVEL
            )
        {
            try
            {
                CultureInfo provider = new CultureInfo("en-IE");
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(APIs.CriarFormulario);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                string dt_final;
                if (DT_FINAL.HasValue)
                {
                    dt_final = DT_FINAL.Value.ToString("dd/MM/yyyy");
                }
                else
                {
                    dt_final = "";
                }
                var body = JsonConvert.SerializeObject(new
                {
                    TEMAS_QUANTIDADE = TEMAS_QUANTIDADE,
                    TIPO_PROVA = TIPO_PROVA,
                    CARGO = CARGO,
                    FIXA = FIXA,
                    REGIONAL = REGIONAL,
                    MATRICULA = MATRICULA,
                    DT_INIT = DT_INIT.ToString("dd/MM/yyyy"),
                    DT_FINAL = dt_final,
                    QTD_TOTAL_SOLICITADA = QTD_TOTAL_SOLICITADA,
                    ELEGIVEL = ELEGIVEL
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

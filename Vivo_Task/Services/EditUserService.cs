using Vivo_Task.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Vivo_Task.ModelDTO;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.IO.Compression;
using System.IO.Pipelines;
using System.IO;
using SkiaSharp;
using Vivo_Task.Shared_Static_Class.FundamentalModels;

namespace Vivo_Task.Services
{
    public interface IEditUserService
    {
        Task<MainResponse> UpdateAvatarImage(byte[] bytes, int matricula);
        Task<MainResponse> UpdateSenhaUser(string old, string newone, string confirmnewone, int matricula);
    }
    public class EditUserService : IEditUserService
    {
        public async Task<MainResponse> UpdateSenhaUser(string old, string newone, string confirmnewone, int matricula)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(APIs.UpdateSenhaUser);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var body = JsonConvert.SerializeObject(new { old = old, newone = newone, confirmnewone = confirmnewone, matricula = matricula });
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
            catch (Exception ex)
            {
                return new MainResponse
                {
                    Content = ex.Message,
                    IsSuccess = false,
                    ErrorMessage = "algum erro ocorreu"
                };
            }
        }
        public async Task<MainResponse> UpdateAvatarImage(byte[] bytes, int matricula)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(APIs.UpdateAvatarImage);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);

                var body = JsonConvert.SerializeObject(new { bytes = bytes, matricula = matricula });
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
            catch (Exception ex)
            {
                return new MainResponse
                {
                    Content = ex.Message,
                    IsSuccess = false,
                    ErrorMessage = "algum erro ocorreu"
                };
            }
        }

        private async Task<string> MakeRequestAsync(HttpRequestMessage getRequest, HttpClient client)
        {
            var response = await client.SendAsync(getRequest).WaitAsync(new TimeSpan(0, 5, 0)).ConfigureAwait(false);
            var responseString = string.Empty;
            try
            {
                response.EnsureSuccessStatusCode();
                responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            catch (HttpRequestException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            return responseString;
        }
    }
}
                    

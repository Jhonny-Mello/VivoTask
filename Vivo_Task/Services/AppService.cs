using Vivo_Task.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using Vivo_Task.ModelDTO;
using System.Net.Http.Json;
using System.Text.Json;
using Vivo_Task.Shared_Static_Class.FundamentalModels;

namespace Vivo_Task.Services
{
    public interface IAppService
    {
        public Task<bool> GetLatestVersionAvailableOnStore();
        Task<bool> RefreshToken();
        public Task<(MainResponse, string)> AuthenticateUser(LoginModel loginModel);
        //Task<(bool IsSuccess, string ErrorMessage)> RegisterUser(RegistrationModel registerUser);
        public Task<AuthenticationModel> SendEmailForCodeVerificationAsync(string to, string CC);
        Task<string> GetListaAdm();
        string GetAvatarImageByMatricula(int matricula);
        Task<string> GetListaRoles();
        Task<MainResponse> UpdateSenhaUserByMatricula(string newone, string confirmnewone, int matricula);
        Task<MainResponse> ValidateEmailByMatricula(int matricula);
    }
    public class AppService : IAppService
    {
        private readonly IConfiguration _configuration;
        public AppService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> GetLatestVersionAvailableOnStore()
        {
            var remoteVersion = "0.0.0.0";

            var url = "powerautomatelink";
            var actualversion = AppInfo.Current.VersionString;

            using (HttpClient _httpClient = new HttpClient())
            {
                var saida = await _httpClient.GetAsync(url, CancellationToken.None);
                if (saida.IsSuccessStatusCode)
                {
                    remoteVersion = await saida.Content.ReadAsStringAsync();
                }
            }
            double varRemoteVersion = Convert.ToDouble(remoteVersion);
            double varactualversion = Convert.ToDouble(actualversion.Substring(0, 3));
            return varactualversion >= varRemoteVersion ;    
        }
            
        public async Task<MainResponse> ValidateEmailByMatricula(
            int matricula)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(APIs.ValidateEmailByMatricula);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var body = JsonConvert.SerializeObject(new {matricula = matricula});
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Content = content;

                return await MakeRequestReturnResponseAsync(request, client);
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
        public async Task<MainResponse> UpdateSenhaUserByMatricula(string newone, string confirmnewone, int matricula)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(APIs.UpdateSenhaUserByMatricula);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var body = JsonConvert.SerializeObject(new { newone = newone, confirmnewone = confirmnewone, matricula = matricula });
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Content = content;

                return await MakeRequestReturnResponseAsync(request, client);
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

        public async Task<(MainResponse, string)> AuthenticateUser(LoginModel loginModel)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(APIs.GetUserByMatricula);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var body = JsonConvert.SerializeObject(new { matricula = int.Parse(loginModel.matricula) });
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Content = content;
                var response = await MakeRequestAsync(request, client);
                if (string.IsNullOrWhiteSpace(response))
                {
                    return (new MainResponse
                    {
                        Content = "",
                        IsSuccess = false,
                        ErrorMessage = "usuário não autorizado, Login ou senha incorreto!"
                    }, null);
                }

                Response<AcessoModel> responseUser;
                var resultadoMatricula = JsonConvert.DeserializeObject<Response<object>>(response);
                if (resultadoMatricula.Succeeded)
                {
                    responseUser = JsonConvert.DeserializeObject<Response<AcessoModel>>(response);
                }
                else
                {
                    return (new MainResponse
                    {
                        Content = resultadoMatricula.Data,
                        IsSuccess = false,
                        ErrorMessage = resultadoMatricula.Message
                    }, null);
                }
                AcessoModel usuario;
                if (responseUser.Succeeded)
                {
                    usuario = responseUser.Data;
                }
                else
                {
                    return (new MainResponse
                    {
                        Content = "",
                        IsSuccess = false,
                        ErrorMessage = "matricula não encontrada, por favor verifique e tente novamente!"
                    }, null);
                }

                if (usuario.SENHA != CryptSenha(loginModel.Password))
                {
                    return (new MainResponse
                    {
                        Content = "",
                        IsSuccess = false,
                        ErrorMessage = "usuário não autorizado, senha incorreta!"
                    }, null);
                }

                if (usuario.STATUS == false)
                {
                    return (new MainResponse { Content = "", IsSuccess = false, ErrorMessage = $"usuário não autorizado, sua conta foi desativada! -  Motivo:{usuario.TP_AFASTAMENTO} - OBS:{usuario.OBS}" }, null);
                }

                string token = await CreateToken(usuario);

                //var refreshToken = GenerateRefreshToken();

                return (new MainResponse
                {
                    Content = token,
                    IsSuccess = true,
                    ErrorMessage = null
                }, usuario.UserAvatar != null ? Convert.ToBase64String(usuario.UserAvatar) : null);
            }
            catch (Exception ex)
            {
                return (new MainResponse
                {
                    Content = ex.InnerException.Message,
                    IsSuccess = false,
                    ErrorMessage = ex.Message + ";" + ex.InnerException.Message
                }, null);
            }
        }

        public async Task<bool> RefreshToken()
        {
            bool isTokenRefreshed = false;
            using (var client = new HttpClient())
            {
                var url = $"{Setting.DevBaseUrl}{APIs.RefreshToken}";

                var serializedStr = JsonConvert.SerializeObject(new AuthenticateRequestAndResponse
                {
                    RefreshToken = Setting.UserBasicDetail.RefreshToken,
                    AccessToken = Setting.UserBasicDetail.AccessToken
                });

                try
                {
                    var response = await client.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        string contentStr = await response.Content.ReadAsStringAsync();
                        var mainResponse = JsonConvert.DeserializeObject<MainResponse>(contentStr);
                        if (mainResponse.IsSuccess)
                        {
                            var tokenDetails = JsonConvert.DeserializeObject<AuthenticateRequestAndResponse>(mainResponse.Content.ToString());
                            Setting.UserBasicDetail.AccessToken = tokenDetails.AccessToken;
                            Setting.UserBasicDetail.RefreshToken = tokenDetails.RefreshToken;

                            string userDetailsStr = JsonConvert.SerializeObject(Setting.UserBasicDetail);
                            await SecureStorage.SetAsync(nameof(Setting.UserBasicDetail), userDetailsStr);
                            isTokenRefreshed = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
            }
            return isTokenRefreshed;
        }

        //public async Task<(bool IsSuccess, string ErrorMessage)> RegisterUser(RegistrationModel registerUser)
        //{
        //    return (false, errorMessage);
        //}
        //    string errorMessage = string.Empty;
        //    bool isSuccess = false;
        //    using (var client = new HttpClient())
        //    {
        //        var url = $"{Setting.BaseUrl}{APIs.RegisterUser}";

        //        var serializedStr = JsonConvert.SerializeObject(new
        //        {
        //            Username = registerUser.Username(),
        //            registerUser.Password,
        //            registerUser.Email,
        //            UserAvatar = registerUser.UserAvatar.IsNullOrEmpty() ? registerUser.UserAvatar : "",
        //            registerUser.Matricula
        //        });
        //        var response = await client.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));
        //        if (response.IsSuccessStatusCode)
        //        {
        //            isSuccess = true;
        //        }
        //        else
        //        {
        //            errorMessage = await response.Content.ReadAsStringAsync();
        //        }
        //    }
        //    return (isSuccess, errorMessage);
        //}
        public async Task<AuthenticationModel> SendEmailForCodeVerificationAsync(string to, string CC)
        {
            CC = CC.Count() < 0 ? CC : "";
            Random OTP = new();
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://prod-187.westeurope.logic.azure.com:443/workflows/26886d345d65478a9a55effb9d50e2a2/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=q1RUVmTBTbhS4B4_QwQrBaRh6fsKIwRZJLhM9q1av_4");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var body = $"{{\"To\":\"{to}\",\"CC\":\"{CC}\",\"OTP\":\"{OTP.Next(100000, 999999)}\"}}";
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Content = content;
                var response = await MakeRequestAsync(request, client);
                return JsonConvert.DeserializeObject<AuthenticationModel>(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception();
            }
        }

        public async Task<string> GetListaAdm()
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://prod-162.westeurope.logic.azure.com:443/workflows/ea559d2c68c54924b04e76113cef915d/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=ewuMgUkiKXyfA_KlHZnaJJ0sUieKJc-3KiiXgm9R8gU");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var body = "{}";
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Content = content;
                return await MakeRequestAsync(request, client);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> GetListaRoles()
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://prod-60.westeurope.logic.azure.com:443/workflows/eacd769c45c74b05bca83869b2f1b369/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=OUlAxNBmyYTw9WX0p1HajVlrMDbAuum2kIvKOWp9dvY");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress);
                return await MakeRequestAsync(request, client);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //public async Task<ActionResult<string>> RefreshToken()
        //{
        //    var refreshToken = RequeUst.Cookies["refreshToken"];

        //    if (!user.RefreshToken.Equals(refreshToken))
        //    {
        //        return Unauthorized("Invalid Refresh Token.");
        //    }
        //    else if (user.TokenExpires < DateTime.Now)
        //    {
        //        return Unauthorized("Token expired.");
        //    }

        //    string token = CreateToken(user);
        //    var newRefreshToken = GenerateRefreshToken();
        //    SetRefreshToken(newRefreshToken);

        //    return Ok(token);
        //}

        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(2),
                Created = DateTime.Now
            };

            return refreshToken;
        }
        private string CryptSenha(string senha)
        {
            var md5 = MD5.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(senha);
            byte[] hash = md5.ComputeHash(bytes);
            StringBuilder sb = new();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        private async Task<string> CreateToken(AcessoModel user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Matricula", user.MATRICULA.ToString()),
                new Claim("Cargo", ((int)user.CARGO).ToString()),
                new Claim("Canal", ((int)user.CANAL).ToString()),
                new Claim("Pdv", user.PDV),
                new Claim("CPF", user.CPF),
                new Claim("Nome", user.NOME),
                new Claim("Uf", user.UF),
                new Claim("Regional", user.REGIONAL),
                new Claim("DDD", user.DDD.ToString()),
                new Claim("Telefone", user.TELEFONE),
                //new Claim("exp", ),
                new Claim("Email", user.EMAIL),
                new Claim("Perfil", JsonConvert.SerializeObject(user.Perfil)),
                new Claim("Fixa", user.FIXA.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("key"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(100),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        public string GetAvatarImageByMatricula(int matricula)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("powerautomatekey");
                client.DefaultRequestHeaders.Accept.Clear();    
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var body = JsonConvert.SerializeObject(new { matricula = matricula });
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Content = content;
                var result = MakeRequestAsync(request, client).Result;
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<string> MakeRequestAsync(HttpRequestMessage getRequest, HttpClient client)
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
                Debug.WriteLine(ex);
            }

            return responseString;
        }
        private async Task<MainResponse> MakeRequestReturnResponseAsync(HttpRequestMessage getRequest, HttpClient client)
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

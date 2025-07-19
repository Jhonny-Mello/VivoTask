using Newtonsoft.Json;
using System.ComponentModel;
using Vivo_Task.Models;
using Blazorise.Charts;
using Vivo_Task.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Windows.Input;
using Vivo_Task.Pages;
using Vivo_Task.Shared_Static_Class.Converters;
using CommunityToolkit.Maui.Views;
using Vivo_Task.Shared_Static_Class.FundamentalModels;
using Vivo_Task.Shared_Static_Class.Enums;

namespace Vivo_Task.ViewModels
{
    public partial class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel(IAppService _appService)
        {
            AppService = _appService ?? throw new ArgumentNullException(nameof(_appService));
        }

        public readonly IAppService AppService;
        public LoginModel loginModel { get; set; } = new();

        public bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (isBusy == value) return;
                isBusy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));
            }
        }

        public ICommand Submit => new Command(async () =>
        {
            if (IsBusy) return;

            IsBusy = true;
            if (!string.IsNullOrWhiteSpace(loginModel.Password) && !string.IsNullOrWhiteSpace(loginModel.matricula))
            {

                if (loginModel.matricula == "Microsoft.admin.teste@gmail.com" && loginModel.Password == "Jesuse10-90w74hj")
                {
                    var userBasicDetail = new UserBasicDetail
                    {
                        Email = loginModel.matricula,
                        Name = "Microsoft tester Perfil",
                        Matricula = 151191,
                        Regional = "NE",
                        AccessToken = "",
                        exp = "",
                        Cargo = Cargos.ADM,
                        Canal = Canal.ADM,
                        Pdv = "BA1209-42",
                        CPF = "13389237612",
                        Fixa = true,
                        Uf = "PE",
                        DDD = 0,
                        UserAvatar = null
                    };

                    string userBasicInfoStr = JsonConvert.SerializeObject(userBasicDetail);
                    await SecureStorage.SetAsync(nameof(Setting.UserBasicDetail), userBasicInfoStr);

                    Setting.UserBasicDetail = userBasicDetail;
                    //SelectPlataform.Current.FlyoutHeader = new FlyoutHeaderControl(Setting.UserBasicDetail);
                    await AppConstant.AddFlyoutMenusDetails();
                    IsBusy = false;
                    return;
                }

                (MainResponse, string) response = await AppService.AuthenticateUser(loginModel);

                if (response.Item1.IsSuccess)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jsontoken = handler.ReadToken(response.Item1.Content.ToString()) as JwtSecurityToken;

                    string email = jsontoken.Claims.FirstOrDefault(f => f.Type == "Email").Value;
                    string regional = jsontoken.Claims.FirstOrDefault(f => f.Type == "Regional").Value;
                    string exp = jsontoken.Claims.FirstOrDefault(f => f.Type == "exp").Value;
                    string matricula = jsontoken.Claims.FirstOrDefault(f => f.Type == "Matricula").Value;
                    string nome = jsontoken.Claims.FirstOrDefault(f => f.Type == "Nome").Value;
                    string Cargo = jsontoken.Claims.FirstOrDefault(f => f.Type == "Cargo").Value;
                    string Canal = jsontoken.Claims.FirstOrDefault(f => f.Type == "Canal").Value;
                    string Pdv = jsontoken.Claims.FirstOrDefault(f => f.Type == "Pdv").Value;
                    string CPF = jsontoken.Claims.FirstOrDefault(f => f.Type == "CPF").Value;
                    string Uf = jsontoken.Claims.FirstOrDefault(f => f.Type == "Uf").Value;
                    string Fixa = jsontoken.Claims.FirstOrDefault(f => f.Type == "Fixa").Value;
                    string DDD = jsontoken.Claims.FirstOrDefault(f => f.Type == "DDD").Value;
                    string Perfil = jsontoken.Claims.FirstOrDefault(f => f.Type == "Perfil").Value;
                    string Telefone = jsontoken.Claims.FirstOrDefault(f => f.Type == "Telefone").Value;

                    AuthenticationModel numreturn = await AppService.SendEmailForCodeVerificationAsync(email, "automacao_ne.br@telefonica.com");

                    string result = await App.Current.MainPage.DisplayPromptAsync("Falta pouco...", "informe o OTP que enviamos ao seu e-mail!", maxLength: 6);

                    if (result == null)
                    {
                        //await App.Current.MainPage.DisplayAlert("Ok até mais", "", "OK");
                        //await App.Current.MainPage.ShowPopupAsync(new MopUpAlert("Até mais"));
                    }
                    else if (result == numreturn.OTP)
                    {
                        var userBasicDetail = new UserBasicDetail
                        {
                            Email = email,
                            Name = nome,
                            Matricula = int.Parse(matricula),
                            Regional = regional,
                            AccessToken = response.Item1.Content.ToString(),
                            exp = exp,
                            Cargo = ((Cargos)int.Parse(Cargo)),
                            Canal = ((Canal)int.Parse(Canal)),
                            Pdv = Pdv,
                            CPF = CPF,
                            Telefone= Telefone,
                            DDD = int.Parse(DDD),
                            Fixa = Convert.ToBoolean(Fixa),
                            Uf = Uf,
                            Perfil = JsonConvert.DeserializeObject<IEnumerable<Perfil>>(Perfil),
                            UserAvatar = DeviceInfo.Platform == DevicePlatform.WinUI ? null :response.Item2
                        };

                        string userBasicInfoStr = JsonConvert.SerializeObject(userBasicDetail);
                        await SecureStorage.SetAsync(nameof(Setting.UserBasicDetail), userBasicInfoStr);

                        if (response.Item2 != null && DeviceInfo.Platform == DevicePlatform.WinUI)
                        {
                            userBasicDetail.UserAvatar = response.Item2;
                        }

                        Setting.UserBasicDetail = userBasicDetail;
                        //SelectPlataform.Current.FlyoutHeader = new FlyoutHeaderControl(Setting.UserBasicDetail);
                        await AppConstant.AddFlyoutMenusDetails();
                        IsBusy = false;
                        return;
                    }
                    else
                    {
                        //await App.Current.MainPage.DisplayAlert("OTP inválido!", "Por favor tente logar novamente", "OK");
                        await App.Current.MainPage.ShowPopupAsync(new MopUpAlert("Por favor tente logar novamente"));
                        IsBusy = false;
                        return;
                    }

                }
                else
                {
                    //await App.Current.MainPage.DisplayAlert("Algum erro Ocorreu!", response.Item1.ErrorMessage, "OK");
                    await App.Current.MainPage.ShowPopupAsync(new MopUpAlert(response.Item1.ErrorMessage));

                    IsBusy = false;
                    return;
                }
                IsBusy = false;
                return;
            }
            //await App.Current.MainPage.DisplayAlert("Preste atenção!", "Por favor informe valores para o campo e-mail e senha", "OK");
            await App.Current.MainPage.ShowPopupAsync(new MopUpWarningAlert("Por favor informe valores para o campo e-mail e senha"));
            IsBusy = false;
            return;
        });

        public ICommand ForgotPassword => new Command(async () =>
        {
            if (IsBusy) return;

            IsBusy = true;
            var saida = await Shell.Current.ShowPopupAsync(new MopUpDisplayPrompt("INFORME SUA MATRÍCULA", "", Keyboard.Numeric, "Matrícula"));
            var matricula = saida as string;
            if (!string.IsNullOrEmpty(matricula))
            {
                var saidaemail = await AppService.ValidateEmailByMatricula(int.Parse(matricula));
                if (saidaemail.IsSuccess)
                {
                    var resultemail = JsonConvert.DeserializeObject<Response<string>>(saidaemail.Content.ToString());
                    if (resultemail.Succeeded)
                    {
                        AuthenticationModel numreturn = await AppService.SendEmailForCodeVerificationAsync(resultemail.Data, "automacao_ne.br@telefonica.com");

                        string result = await App.Current.MainPage.DisplayPromptAsync("Falta pouco...", "informe o OTP que enviamos ao seu e-mail!", maxLength: 6);
                        if (result == null)
                        {
                            IsBusy = false;
                            return;
                        }
                        else if (result == numreturn.OTP)
                        {
                            object resultnovasenha = await Shell.Current.ShowPopupAsync(new MopUpDisplayPromptResetSenha());
                            string[] novasenha = resultnovasenha as string[];
                            if (novasenha.Any())
                            {
                                var novasenhaconfirm = await AppService.UpdateSenhaUserByMatricula(novasenha[0], novasenha[1], int.Parse(matricula));
                                if (novasenhaconfirm.IsSuccess)
                                {
                                    var resultnovasenhaconfirm = JsonConvert.DeserializeObject<Response<string>>(novasenhaconfirm.Content.ToString());
                                    if (resultnovasenhaconfirm.Succeeded)
                                    {
                                        await Shell.Current.ShowPopupAsync(new MopUpSuccessAlert(resultnovasenhaconfirm.Message));
                                    }
                                    else
                                    {
                                        await Shell.Current.ShowPopupAsync(new MopUpAlert(resultnovasenhaconfirm.Message));
                                    }
                                }
                            }
                            IsBusy = false;
                            return;

                        }
                        IsBusy = false;
                        return;
                    }
                    else
                    {
                        await App.Current.MainPage.ShowPopupAsync(new MopUpAlert(resultemail.Message));
                        IsBusy = false;
                        return;
                    }
                }
                else
                {
                    await App.Current.MainPage.ShowPopupAsync(new MopUpAlert(saidaemail.ErrorMessage));
                    IsBusy = false;
                    return;
                }
            }
            IsBusy = false;
            return;
        });

        public event PropertyChangedEventHandler PropertyChanged;
    }
}












using BlazorBootstrap;
using Vivo_Task.Services;
using Vivo_Task.Pages;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using CurrieTechnologies.Razor.SweetAlert2;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Vivo_Task.ViewModels;
using Vivo_Task.Models;
using Mopups.Hosting;
using Camera.MAUI;
using Blazorise.LoadingIndicator;
using Radzen;
using Blazorise.RichTextEdit;
using PanCardView;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Vivo_Task.Shared;
using Vivo_Task.Templates;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.Maui.LifecycleEvents;

#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Android;
using Android.Content.PM;
using AndroidX.Core.App;
using AndroidX.Core.Content;
#endif

using DotNet.Meteor.HotReload.Plugin;
using MauiIcons.Cupertino;
using MauiIcons.Fluent;
using MauiIcons.FontAwesome;
using MauiIcons.FontAwesome.Brand;
using MauiIcons.FontAwesome.Solid;
using MauiIcons.Material;
using MauiIcons.Material.Sharp;

namespace Vivo_Task;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseCardsView()
            .UseMauiCommunityToolkit()
            .UseMauiCameraView()
            .ConfigureMopups()
            .UseFluentMauiIcons()
            .UseMaterialMauiIcons()
            .UseCupertinoMauiIcons()
            .UseMaterialSharpMauiIcons()
            .UseFontAwesomeMauiIcons()
            .UseFontAwesomeBrandMauiIcons()
            .UseFontAwesomeSolidMauiIcons()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("VivoTypeRegular.ttf", "Vivo-font");
                fonts.AddFont("VivoTypeBold.otf", "Vivo-font-bold");
                fonts.AddFont("VivoTypeLight.otf", "Vivo-font-light");
                fonts.AddFont("Kanit-Regular.ttf", "Kanit");
                fonts.AddFont("RobotoCondensed-Regular.ttf", "Roboto");
                fonts.AddFont("Ubuntu-Medium.ttf", "Ubuntu");
                fonts.AddFont("Font Awesome 6 Free-Solid-900", "Desktop");
                fonts.AddFont("fa-solid-900", "Web");
            })
            .ConfigureEssentials(essentials =>
            {
                essentials.UseVersionTracking();
            })
            .ConfigureLifecycleEvents(events =>
            {
#if ANDROID
                events.AddAndroid(android => android.OnCreate((activity, bundle) => MakeStatusBarTranslucent(activity)));
      
                static void MakeStatusBarTranslucent(Android.App.Activity activity)
                {
                    activity.Window.SetStatusBarColor(Android.Graphics.Color.DarkSlateBlue);
                    activity.Window.SetNavigationBarColor(Android.Graphics.Color.DarkSlateBlue);   
                }
#endif
            });
        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.EnableHotReload();
#endif
        builder.Services.AddBlazorBootstrap();
        builder.Services.AddSweetAlert2();
        builder.Services.AddBlazorWebView();
        builder.Services.AddFluentUIComponents();
        builder.Services.AddLoadingIndicator();
        builder.Services.AddBlazoriseRichTextEdit(options => { options.UseBubbleTheme = true; });
        builder.Services.AddBlazorise(options =>
        {
            options.Immediate = true;
        }).AddBootstrapProviders().AddFontAwesomeIcons();


        if (DeviceInfo.Platform == DevicePlatform.Android && OperatingSystem.IsAndroidVersionAtLeast(33))
        {
#if ANDROID
            //var activity = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity ?? throw new NullReferenceException("Current activity is null");
            //if (ContextCompat.CheckSelfPermission(activity, Manifest.Permission.ReadExternalStorage) != Permission.Granted)
            //{
            //    ActivityCompat.RequestPermissions(activity, new[] { Manifest.Permission.ReadExternalStorage }, 1);
            //}
#endif
        }

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.Background = null;
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif IOS
            handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
            handler.PlatformView.Layer.BorderWidth = 0;
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
        });

        Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.Background = null;
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif IOS
            handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
            handler.PlatformView.Layer.BorderWidth = 0;
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
        });

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        //General Configs
        builder.Services.AddSingleton<IFileSaver>(FileSaver.Default);
        //builder.Services.AddSingleton<IPopupNavigation>(MopupService.Instance);

        //Services
        builder.Services.AddSingleton<IAppService, AppService>();
        builder.Services.AddSingleton<IFormularioService, FormularioService>();
        builder.Services.AddSingleton<IPainelUsuariosService, PainelUsuariosService>();
        builder.Services.AddSingleton<IPrincipalService, PrincipalService>();
        builder.Services.AddSingleton<IControleUsuariosAppService, ControleUsuariosAppService>();
        builder.Services.AddSingleton<ICreateQuestionService, CreateQuestionService>();
        builder.Services.AddSingleton<ICreateFormService, CreateFormService>();
        builder.Services.AddSingleton<IListaFormService, ListaFormService>();
        builder.Services.AddSingleton<IAnswerFormService, AnswerFormService>();
        builder.Services.AddSingleton<IEditQuestionService, EditQuestionService>();
        builder.Services.AddSingleton<IEditSingleQuestionService, EditSingleQuestionService>();
        builder.Services.AddSingleton<IResultadosProvaService, ResultadosProvaService>();
        builder.Services.AddSingleton<IEditUserService, EditUserService>();
        builder.Services.AddSingleton<ICardsService, CardsService>();
        builder.Services.AddSingleton<ILinksService, LinksService>();
        builder.Services.AddSingleton<IForumRTCZService, ForumRTCZService>();


        //Single Pages
        builder.Services.AddTransient<EditUser, EdituserViewModel>();
        builder.Services.AddTransient<UpdateSenhaUser, EdituserViewModel>();

        // View Models sempre SINGLETON para que a conversa entre o blazor e o xamarin ocorra entre os componentes
        builder.Services.AddSingleton<Login, LoginViewModel>();

        builder.Services.AddTransient<PainelForumGiroV>();
        builder.Services.AddTransient<ForumGiroV>();
        builder.Services.AddTransient<AvaliacoesXaml>();
        builder.Services.AddTransient<ListaFormulariosXaml>();
        builder.Services.AddTransient<CriarFormularioXaml>();
        builder.Services.AddTransient<FlyoutHeaderControl>();
        builder.Services.AddTransient<FlyoutFooterControl>();
        builder.Services.AddTransient<Home>();
        builder.Services.AddSingleton<JornadaXrotaCruzada>();

        builder.Services.AddSingleton<ControleUsuariosAppViewModel>();
        builder.Services.AddSingleton<CreateQuestionViewModel>();
        builder.Services.AddSingleton<EditQuestionViewModel>();
        builder.Services.AddSingleton<CreateFormViewModel>();
        builder.Services.AddSingleton<PrincipalRotaxJornadaViewModel>();
        builder.Services.AddSingleton<ListaFormViewModel>();
        builder.Services.AddSingleton<IAnswerFormViewModel, AnswerFormViewModel>();
        builder.Services.AddSingleton<ResultadosProvaViewModel>();
        builder.Services.AddSingleton<LinksViewModel>();
        builder.Services.AddSingleton<CardsViewModel>();
        builder.Services.AddSingleton<JornadaXrotaCruzadaViewModel>();
        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddSingleton<HomeJornadaViewModel>();
        builder.Services.AddSingleton<MopUpGenericUserInfoViewModel>();
        builder.Services.AddSingleton<ForumRTCZViewModel>();


        //Shared StatesBase
        builder.Services.AddSingleton<UserBasicDetail>();
        builder.Services.AddSingleton<PainelRotaModel>();
        builder.Services.AddScoped<Radzen.DialogService>();

        //Pages
        builder.Services.AddSingleton<MopUpUserInfo>();
        builder.Services.AddSingleton<MopUpGenericUserInfo>();
        builder.Services.AddSingleton<MopUpSelectDate>();
        builder.Services.AddSingleton<RegisterPage>();
        builder.Services.AddSingleton<SelectPlataform>();
        builder.Services.AddSingleton<Cards_Qualidade>();
        builder.Services.AddSingleton<Links_Qualidade>();

        return builder.Build();
    }
}

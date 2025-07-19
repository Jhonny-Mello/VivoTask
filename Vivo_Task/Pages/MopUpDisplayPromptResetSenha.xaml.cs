using SkiaSharp;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Vivo_Task.Models;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Views;
using Vivo_Task.ViewModels;
using System.ComponentModel;
using CommunityToolkit.Maui.Core;


namespace Vivo_Task.Pages;

public partial class MopUpDisplayPromptResetSenha : Popup
{
    public MopUpDisplayPromptResetSenha()
    {
        InitializeComponent();
    }

    private bool _isBusy = true;
    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            _isBusy = value;
            if (!value)
                Close(new string[]{
                NovaSenha.Text,
                ConfirmarSenha.Text
                });
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Close(new string[]{
                NovaSenha.Text,
                ConfirmarSenha.Text
                });
    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Close(new string[] { });
    }
}





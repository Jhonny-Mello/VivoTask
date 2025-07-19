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

public partial class MopUpBusyIndicator : Popup
{
    private bool _isBusy = true;
    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            _isBusy = value;
            if (!value)
                Close();
        }
    }

    public MopUpBusyIndicator()
    {
        InitializeComponent();
    }
}





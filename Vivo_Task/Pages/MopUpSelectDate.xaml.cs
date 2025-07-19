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
using Microsoft.Maui.Handlers;

namespace Vivo_Task.Pages;

public partial class MopUpSelectDate : Popup
{
    private bool _isBusy = false;
    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            _isBusy = value;
            if (!value)
                Close(datePicker.Date);
        }
    }

    public MopUpSelectDate()
    {
        InitializeComponent();
        this.Opened += FocusItem;
    }



    public void FocusItem(object sender, EventArgs e)
    {
#if ANDROID
        var handler = datePicker.Handler as IDatePickerHandler;
        handler.PlatformView.PerformClick();
#else
        datePicker.Focus();
#endif
    }

    public void ClosePopUpItem(object sender, PopupClosedEventArgs e)
    {
        IsBusy = false;
    }

    private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        IsBusy = false;
    }
}





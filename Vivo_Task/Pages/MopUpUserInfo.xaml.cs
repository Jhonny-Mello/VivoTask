using SkiaSharp;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Vivo_Task.Models;
using Newtonsoft.Json;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Radzen.Blazor.Rendering;
using System.ComponentModel;

namespace Vivo_Task.Pages;

public partial class MopUpUserInfo
{
    public UserBasicDetail User { get; set; } = new();

    public MopUpUserInfo(UserBasicDetail user)
    {
        User = user;
        BindingContext = this;
        User.PropertyChanged += UpdateGridVisibility;
        InitializeComponent();
        front.IsVisible = !User.IsRoted && !User.IsRotedRunning;
        back.IsVisible = User.IsRoted && !User.IsRotedRunning;
    }

    private void UpdateGridVisibility(object sender, PropertyChangedEventArgs e)
    {
        front.IsVisible = !User.IsRoted && !User.IsRotedRunning;    
        back.IsVisible = User.IsRoted && !User.IsRotedRunning;
    }

    private async void RotateToBack(object sender, TappedEventArgs e)
    {
        User.IsRotedRunning = true;
        await Task.WhenAll(new Task[]
        {
            Content.RotateYTo(180,300,Easing.Linear)
            ,Content.TranslateTo(360,0,300,Easing.Linear)
            //,Content.ScaleTo(0.9,200,Easing.Linear)
        });
        User.IsRoted = !User.IsRoted;
        await Task.WhenAll(new Task[]
        {
            //Content.RotateYTo(180,300,Easing.Linear)
            //,
            Content.TranslateTo(0,0,0,Easing.Linear)
            //,Content.ScaleTo(1,200,Easing.Linear)
        });
        Content.RotationY = 0;
        User.IsRotedRunning = false;

        //await Content.RotateYTo(180, 50, Easing.Linear);
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}




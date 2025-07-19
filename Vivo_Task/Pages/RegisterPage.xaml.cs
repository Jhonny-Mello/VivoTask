using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Windows.Input;
using Vivo_Task.Models;
using Vivo_Task.Services;
using Vivo_Task.ViewModels;

namespace Vivo_Task.Pages;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }
}
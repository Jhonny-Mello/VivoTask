using Newtonsoft.Json;
using Vivo_Task.Models;
using Vivo_Task.Pages;

namespace Vivo_Task.ViewModels;

public class LoadingPageViewModel
{
	public LoadingPageViewModel()
	{
		CheckUserLayout();
	}

    public async void CheckUserLayout()
    {
        string userDetailsStr = await SecureStorage.GetAsync(nameof(Setting.UserBasicDetail));
        if (!string.IsNullOrWhiteSpace(userDetailsStr))
        {
            var userBasicDetail = JsonConvert.DeserializeObject<UserBasicDetail>(userDetailsStr);
            Setting.UserBasicDetail = userBasicDetail;
            //SelectPlataform.Current.FlyoutHeader = new FlyoutHeaderControl(Setting.UserBasicDetail);
            await AppConstant.AddFlyoutMenusDetails();
            await Shell.Current.GoToAsync("//Home");
        }
        else
        {
            await Shell.Current.GoToAsync("//Login");
            //Navigation.PushAsync(new LoginPage());
        }
    }
}
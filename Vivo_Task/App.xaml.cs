using Vivo_Task.Pages;

namespace Vivo_Task;


public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        //ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        //if (mergedDictionaries != null)
        //{
        //    mergedDictionaries.Clear();
        //    mergedDictionaries.Add(new DarkThemeColors());
        //}
        MainPage = new SelectPlataform();
    }
}
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LyfterOrders.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public SettingsViewModel()
        {
            Title = "Settings";
            SaveSettings = new Command(async () => await Browser.OpenAsync("https://lyfter.nl"));
        }

        public ICommand SaveSettings { get; }
    }
}

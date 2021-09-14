using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using LyfterOrders.Services;
using LyfterOrders.Models;
using System.Threading.Tasks;

namespace LyfterOrders.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public string WebshopUrl;
        public string ClientKey;
        public string ClientSecret;
        public AsyncCommand SaveCommand { get; }

        public SettingsViewModel()
        {
            Title = "Settings";
            SaveCommand = new AsyncCommand<Setting>(Add);
        }

        public ICommand SaveSettings { get; }

        async Task Save()
        {

        }

        async Task Refresh()
        {
            var webshopUrlSetting = await SettingsService.GetSetting("webshop_url");
            WebshopUrl = webshopUrlSetting.Value;

            var clientKeySetting = await SettingsService.GetSetting("client_key");
            ClientKey = clientKeySetting.Value;

            var clientSecretSetting = await SettingsService.GetSetting("client_secret");
            ClientSecret = clientSecretSetting.Value;
        }
    }
}

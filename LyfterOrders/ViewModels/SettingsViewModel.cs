using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using LyfterOrders.Services;
using Xamarin.CommunityToolkit.ObjectModel;
using System.Runtime.CompilerServices;

namespace LyfterOrders.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public string webshopUrl = "";
        public string clientKey = "";
        public string clientSecret = "";
        public string amountOrders = "";
        public bool saved = false;

        public SettingsViewModel()
        {
            SaveCommand = new Command(async () => await Save());
            LoadCommand = new AsyncCommand(async () => await Load());
        }

        public string Title
        {
            get { return "Settings"; }
        }

        public string WebshopUrl
        {
            get { return webshopUrl; }
            set { webshopUrl = value; NotifyPropertyChanged(); }
        }

        public string ClientKey
        {
            get { return clientKey; }
            set { clientKey = value; NotifyPropertyChanged(); }
        }

        public string ClientSecret
        {
            get { return clientSecret; }
            set { clientSecret = value; NotifyPropertyChanged(); }
        }

        public string AmountOrders
        {
            get { return amountOrders; }
            set { amountOrders = value; NotifyPropertyChanged(); }
        }

        public async Task Load()
        {
            var webshopUrlSetting = await SettingsService.GetSetting("webshop_url");

          
            if (webshopUrlSetting != null && webshopUrlSetting.Value != "")
            {
                WebshopUrl = webshopUrlSetting.Value;
            }
           
            var clientKeySetting = await SettingsService.GetSetting("client_key");

            if (clientKeySetting != null && clientKeySetting.Value != "")
            {
                ClientKey = clientKeySetting.Value;
            }

            var clientSecretSetting = await SettingsService.GetSetting("client_secret");

            if (clientSecretSetting != null && clientSecretSetting.Value != "")
            {
                ClientSecret = clientSecretSetting.Value;
            }

            var amountOrders = await SettingsService.GetSetting("amount_orders");

            if (amountOrders != null && amountOrders.Value != "")
            {
                AmountOrders = amountOrders.Value;
            }
        }

        public async Task Save()
        {
            saved = false;

            if (WebshopUrl != "" && ClientKey != "" && ClientSecret != "" && AmountOrders != "")
            {
                await SettingsService.SaveSetting("webshop_url", WebshopUrl);
                await SettingsService.SaveSetting("client_key", ClientKey);
                await SettingsService.SaveSetting("client_secret", ClientSecret);
                await SettingsService.SaveSetting("amount_orders", AmountOrders);

                saved = true;
            }

            WooOrderDataStore.rest = null;
            WooOrderDataStore.wc = null;

            if (Application.Current != null)
            {
                await Application.Current.MainPage.DisplayAlert("Saved", "Settings were saved successfully", "Ok");
            }
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

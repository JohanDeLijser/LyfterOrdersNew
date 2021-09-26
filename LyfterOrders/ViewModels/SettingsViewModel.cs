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
        string webshopUrl = "";
      
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

        public async Task Load()
        {
            var webshopUrlSetting = await SettingsService.GetSetting("webshop_url");

            if (webshopUrlSetting.Value != "")
            {
                WebshopUrl = webshopUrlSetting.Value;
            }

            System.Console.WriteLine(WebshopUrl);
        }

        public async Task Save()
        {
            System.Console.WriteLine(WebshopUrl);

            await SettingsService.SaveSetting("webshop_url", WebshopUrl);
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

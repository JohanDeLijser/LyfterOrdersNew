using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LyfterOrders.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://lyfter.nl"));
        }

        public ICommand OpenWebCommand { get; }
    }
}

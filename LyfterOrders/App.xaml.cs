using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LyfterOrders.Services;
using LyfterOrders.Views;

namespace LyfterOrders
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<WooOrderDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

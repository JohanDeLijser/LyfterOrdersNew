using System.ComponentModel;
using Xamarin.Forms;
using LyfterOrders.ViewModels;

namespace LyfterOrders.Views
{
    public partial class OrderDetailPage : ContentPage
    {
        public OrderDetailPage()
        {
            InitializeComponent();
            BindingContext = new OrderDetailViewModel();
        }
    }
}

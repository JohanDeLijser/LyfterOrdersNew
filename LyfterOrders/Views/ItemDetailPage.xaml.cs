using System.ComponentModel;
using Xamarin.Forms;
using LyfterOrders.ViewModels;

namespace LyfterOrders.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using WooCommerceNET.WooCommerce.v3;
using LyfterOrders.Views;

namespace LyfterOrders.ViewModels
{
    public class OrdersViewModel : BaseViewModel
    {
        private Order _selectedOrder;

        public ObservableCollection<Order> Orders { get; }
        public Command LoadOrdersCommand { get; }
        public Command<Order> OrderTapped { get; }

        public OrdersViewModel()
        {
            Title = "Orders";
            Orders = new ObservableCollection<Order>();
            LoadOrdersCommand = new Command(async () => await ExecuteLoadOrdersCommand());

            OrderTapped = new Command<Order>(OnOrderSelected);
            
        }

        async Task ExecuteLoadOrdersCommand()
        {
            IsBusy = true;

            try
            {
                Orders.Clear();
                var orders = await DataStore.GetOrdersAsync(true);
               
                foreach (var order in orders)
                {
                    Orders.Add(order);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Application.Current.MainPage.DisplayAlert("Something went wrong", "We weren't able to fetch any orders, check your settings and try again", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedOrder = null;
        }

        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                SetProperty(ref _selectedOrder, value);
                OnOrderSelected(value);
            }
        }

      
        async void OnOrderSelected(Order order)
        {
            if (order == null)
                return;

            // This will push the OrderDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(OrderDetailPage)}?{nameof(OrderDetailViewModel.OrderId)}={order.id}");
        }
    }
}

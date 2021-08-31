using System;
using System.Diagnostics;
using System.Threading.Tasks;
using LyfterOrders.Models;
using Xamarin.Forms;

namespace LyfterOrders.ViewModels
{
    [QueryProperty(nameof(OrderId), nameof(OrderId))]
    public class OrderDetailViewModel : BaseViewModel
    {
        private string orderId;
        private string text;
        private string description;
        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string OrderId
        {
            get
            {
                return orderId;
            }
            set
            {
                orderId = value;
                LoadOrderId(value);
            }
        }

        public async void LoadOrderId(string orderId)
        {
            try
            {
                var order = await DataStore.GetOrderAsync(orderId);
                Id = order.Id;
                Text = order.Text;
                Description = order.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Order");
            }
        }
    }
}

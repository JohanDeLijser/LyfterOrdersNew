//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using LyfterOrders.Models;
//using WooCommerceNET.WooCommerce.v3;
//using WooCommerceNET.WooCommerce.v3.Extension;

//namespace LyfterOrders.Services
//{
//    public class OrderDataStore : IOrderDataStore<Order>
//    {
//        readonly List<Order> orders;

//        public OrderDataStore()
//        {
//            orders = new List<Order>()
//            {
//                new Order { Id = Guid.NewGuid().ToString(), Text = "First order", Description="This is an order description." },
//                new Order { Id = Guid.NewGuid().ToString(), Text = "Second order", Description="This is an order description." },
//            };
//        }

//        public async Task<Order> GetOrderAsync(string id)
//        {
//            return await Task.FromResult(orders.FirstOrDefault(s => s.Id == id));
//        }

//        public async Task<IEnumerable<Order>> GetOrdersAsync(bool forceRefresh = false)
//        {
//            return await Task.FromResult(orders);
//        }
//    }
//}

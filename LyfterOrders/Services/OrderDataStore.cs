using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LyfterOrders.Models;

namespace LyfterOrders.Services
{
    public class OrderDataStore : IOrderDataStore<Item>
    {
        readonly List<Item> items;

        public OrderDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First order", Description="This is an order description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second order", Description="This is an order description." },
            };
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}

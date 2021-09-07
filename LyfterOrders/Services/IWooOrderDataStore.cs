using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LyfterOrders.Services
{
    public interface IWooOrderDataStore<T>
    {
        Task<T> GetOrderAsync(string id);
        Task<List<T>> GetOrdersAsync(bool forceRefresh = false);
    }
}

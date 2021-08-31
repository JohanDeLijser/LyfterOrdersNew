using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LyfterOrders.Services
{
    public interface IOrderDataStore<T>
    {
        Task<T> GetOrderAsync(string id);
        Task<IEnumerable<T>> GetOrdersAsync(bool forceRefresh = false);
    }
}

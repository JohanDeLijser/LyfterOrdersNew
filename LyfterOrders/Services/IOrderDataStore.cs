using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LyfterOrders.Services
{
    public interface IOrderDataStore<T>
    {
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v3;
using WooCommerceNET.WooCommerce.v3.Extension;


namespace LyfterOrders.Services
{
    public class WooOrderDataStore: IWooOrderDataStore<Order>
    {
        readonly RestAPI rest;
        readonly WCObject wc;

        public WooOrderDataStore()
        {
            rest = new RestAPI("http://ordersshop.lyfter.nl/wp-json/wc/v3/", "ck_4ea895dae01f206ca9c078ddcfe225b03b6e7d2b", "cs_fab029028035c86a7e42d95dc44fec6ddbca984f");
            wc = new WCObject(rest);
        }

        public async Task<Order> GetOrderAsync(string id)
        {
            return await wc.Order.Get(id);
        }

        public async Task<List<Order>> GetOrdersAsync(bool forceRefresh = false)
        {
            return await wc.Order.GetAll();
        }
    }
}

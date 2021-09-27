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
        public static RestAPI rest;
        public static WCObject wc;

        public WooOrderDataStore()
        {
            rest = null;
            wc = null;
        }

        public async Task SetRest()
        {
            var url = await SettingsService.GetSetting("webshop_url");
            var clientKey = await SettingsService.GetSetting("client_key");
            var clientSecret = await SettingsService.GetSetting("client_secret");

            if (url != null && url.Value != "" && clientKey != null && clientKey.Value != "" && clientSecret != null && clientSecret.Value != "")
            {
                rest = new RestAPI(url.Value + "/wp-json/wc/v3/", clientKey.Value, clientSecret.Value);
                wc = new WCObject(rest);
            }
        }

        public async Task<Order> GetOrderAsync(string id)
        {
            if (rest == null)
            {
               await SetRest();
            }

            if (rest != null)
            {
                return await wc.Order.Get(id);
            }

            return null;
        }

        public async Task<List<Order>> GetOrdersAsync(bool forceRefresh = false)
        {
            if (rest == null)
            {
                await SetRest();
            }

            if (rest != null)
            {
                var amountOrders = await SettingsService.GetSetting("amount_orders");

                if (amountOrders != null && amountOrders.Value != "")
                {
                    return await wc.Order.GetAll(new Dictionary<string, string>() {{ "per_page", amountOrders.Value } });
                }

                return await wc.Order.GetAll();
            }

            return null;
        }
    }
}

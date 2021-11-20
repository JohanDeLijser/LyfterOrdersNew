
using System;
using System.Threading.Tasks;
using NUnit.Framework;
using LyfterOrders.ViewModels;
using LyfterOrders.Services;

namespace LyfterOrders.UnitTests
{
    [TestFixture]
    public class SettingsTest
    {
        private bool passed;

        public async Task AddSaveTest(string url, string key, string secret, string amount)
        {
            new WooOrderDataStore();

            // Arrange
            var vm = new SettingsViewModel
            {
                webshopUrl = url,
                clientKey = key,
                clientSecret = secret,
                amountOrders = amount
            };

            // Act
            await vm.Save();

            passed = vm.saved;
        }

        [Test]
        public async void SaveTestPass()
        {
            await AddSaveTest(
                "https://ordersshop.lyfter.nl",
                "ck_4ea895dae01f206ca9c078ddcfe225b03b6e7d2b",
                "cs_fab029028035c86a7e42d95dc44fec6ddbca984f",
                "10"
            );

            // Assert
            Assert.IsTrue(passed);
        }

        [Test]
        public async void SaveTestFail()
        {
            await AddSaveTest(
               "https://ordersshop.lyfter.nl",
               "ck_4ea895dae01f206ca9c078ddcfe225b03b6e7d2b",
               "cs_fab029028035c86a7e42d95dc44fec6ddbca984f",
               ""
           );

            // Assert
            Assert.IsTrue(passed);
        }
    }
}

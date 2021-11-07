
using System;
using NUnit.Framework;
using LyfterOrders.ViewModels;
using LyfterOrders.Services;

namespace LyfterOrders.UnitTests
{
    [TestFixture]
    public class SettingsTest
    {
        [Test]
        public void AddSaveTest()
        {
            new WooOrderDataStore();

            // Arrange
            var vm = new SettingsViewModel
            {
                webshopUrl = "https://ordersshop.lyfter.nl",
                clientKey = "ck_4ea895dae01f206ca9c078ddcfe225b03b6e7d2b",
                clientSecret = "cs_fab029028035c86a7e42d95dc44fec6ddbca984f",
                amountOrders = "10"
            };

            // Act
            vm.SaveCommand.Execute(null);

            // Assert
            Assert.IsTrue(vm.saved != false);
        }

        [Test]
        [Ignore("another time")]
        public void Ignore()
        {
            Assert.True(false);
        }
    }
}

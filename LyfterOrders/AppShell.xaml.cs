﻿using System;
using System.Collections.Generic;
using LyfterOrders.ViewModels;
using LyfterOrders.Views;
using Xamarin.Forms;

namespace LyfterOrders
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
﻿using PetShopV2.Views;
using Xamarin.Forms;

namespace PetShopV2
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(FoodDetailPage), typeof(FoodDetailPage));
            Routing.RegisterRoute(nameof(ToysDetailPage), typeof(ToysDetailPage));
        }
    }
}
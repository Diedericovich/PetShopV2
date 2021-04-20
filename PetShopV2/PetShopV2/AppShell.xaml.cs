using PetShopV2.ViewModels;
using PetShopV2.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PetShopV2
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(FoodDetailPage), typeof(FoodDetailPage));

        }

    }
}

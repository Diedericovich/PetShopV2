using PetShopV2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopV2.Services
{
    public class CartSingleton : ObservableObject
    {
        private static CartSingleton instance;

        private ShoppingCart shoppingCart;

        public ShoppingCart ShoppingCart
        {
            get { return shoppingCart; }
            set { shoppingCart = value; OnPropertyChanged(nameof(ShoppingCart)); }
        }

        private CartSingleton()
        {
            ShoppingCart = new ShoppingCart();
        }

        public static CartSingleton GetSingleton()
        {
            return instance ?? (instance = new CartSingleton());
        }

    }
}

using PetShopV2.Models;
using PetShopV2.Services;
using PetShopV2.Views;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace PetShopV2.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        private CartRepo _cartRepo;

        private ObservableCollection<CartItem> itemsInCart;
        public  ObservableCollection<CartItem> ItemsInCart
        {
            get { return itemsInCart; }
            set { itemsInCart = value;

                OnPropertyChanged(nameof(ItemsInCart));
            }
        }

        public Command LoadProductsCommand { get; set; }

        public Command<CartItem> AddProductCommand { get; set; }

        public Command<CartItem> DeductProductCommand { get; set; }

        public Command<CartItem> DeleteProductCommand { get; set; }

        public Command RefreshCommand { get; set; }

        public CartViewModel()
        {
            Title = "Cart";
            _cartRepo = new CartRepo();

            LoadProductsCommand = new Command(OnLoaded);
            DeleteProductCommand = new Command<CartItem>(OnDeleteProduct);
            AddProductCommand = new Command<CartItem>(OnAddProduct);
            DeductProductCommand = new Command<CartItem>(OnDeductProduct);
            RefreshCommand = new Command(OnLoaded);

            OnLoaded();

        }

        private async void OnLoaded( )
        {
            var result = await _cartRepo.GetItemsInCart();
            ItemsInCart = new ObservableCollection<CartItem>(result);

        }

        private async void OnAddProduct(CartItem cartItem)
        {
            cartItem.CartItemQuantity++;
            //niet ideaal: beter: in memory opslaan en als klaar naar database, nu elke keer op knop duwen = refreshen database
            await _cartRepo.UpdateProductAsync(cartItem);
            
            //mag dit niet gewoon weg?????????
            //OnLoaded();
        }
       
        private async void OnDeductProduct(CartItem cartItem)
        {
            if (cartItem.CartItemQuantity > 1)
            {
                cartItem.CartItemQuantity--;
                await _cartRepo.UpdateProductAsync(cartItem);
            }
        }

        private async void OnDeleteProduct(CartItem cartItem)
        {
            ItemsInCart.Remove(cartItem);
            await _cartRepo.DeleteProductAsync(cartItem.ID);
        }

    }
}
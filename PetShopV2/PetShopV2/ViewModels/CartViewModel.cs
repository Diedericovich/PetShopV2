﻿using PetShopV2.Models;
using PetShopV2.Services;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PetShopV2.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        private CartRepo _cartRepo;

        public Command LoadProductsCommand { get; set; }

        public Command<CartItem> AddProductCommand { get; set; }

        public Command<CartItem> DeductProductCommand { get; set; }

        public Command<CartItem> DeleteProductCommand { get; set; }

        public Command RefreshCommand { get; set; }

        private ObservableCollection<CartItem> itemsInCart;

        public ObservableCollection<CartItem> ItemsInCart
        {
            get { return itemsInCart; }
            set
            {
                itemsInCart = value;

                OnPropertyChanged(nameof(ItemsInCart));
            }
        }

        private double totalPrice;

        public double TotalPrice
        {
            get { return totalPrice; }
            set
            {
                totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

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

        private async void OnLoaded()
        {
            var result = await _cartRepo.GetItemsInCart();
            ItemsInCart = new ObservableCollection<CartItem>(result);
            CalcTotalPrice();
        }

        private void CalcTotalPrice()
        {
            TotalPrice = 0;
            foreach (CartItem cartItem in ItemsInCart)
            {
                TotalPrice += cartItem.CartItemTotalPrice;
            };
        }

        private async void OnAddProduct(CartItem cartItem)
        {
            cartItem.CartItemQuantity++;
            int aantal = cartItem.CartItemQuantity;
            cartItem.CartItemTotalPrice = aantal * cartItem.Product.Price;
            //niet ideaal: beter: in memory opslaan en als klaar naar database, nu elke keer op knop duwen = refreshen database
            await _cartRepo.UpdateProductAsync(cartItem);
            TotalPrice += cartItem.Product.Price;
        }

        private async void OnDeductProduct(CartItem cartItem)
        {
            if (cartItem.CartItemQuantity > 1)
            {
                cartItem.CartItemQuantity--;
                int aantal = cartItem.CartItemQuantity;
                cartItem.CartItemTotalPrice = aantal * cartItem.Product.Price;
                await _cartRepo.UpdateProductAsync(cartItem);
                TotalPrice -= cartItem.Product.Price;
            }
        }

        private async void OnDeleteProduct(CartItem cartItem)
        {
            ItemsInCart.Remove(cartItem);
            await _cartRepo.DeleteProductAsync(cartItem.ID);
            TotalPrice -= cartItem.CartItemTotalPrice;
        }
    }
}
﻿using PetShopV2.Models;
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
        private Product _selectedProduct;

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

        public Command<Product> ProductTapped { get; set; }

        public Command<CartItem> DeleteProductCommand { get; set; }

        public CartViewModel()
        {
            Title = "Cart";
            //LoadProductsCommand = new Command(async () => await ExecuteLoadProductsCommand());

            //todo: fix erboven
            LoadProductsCommand = new Command(OnLoaded);
            ProductTapped = new Command<Product>(OnProductSelected);
            DeleteProductCommand = new Command<CartItem>(OnDeleteProduct);
            AddProductCommand = new Command<CartItem>(OnAddProduct);
            DeductProductCommand = new Command<CartItem>(OnDeductProduct);
            _cartRepo = new CartRepo();

            OnLoaded();
        }

        private async void OnLoaded( )
        {
            var result = await _cartRepo.GetItemsInCart();
            ItemsInCart = new ObservableCollection<CartItem>(result);

        }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                SetProperty(ref _selectedProduct, value);
                OnProductSelected(value);
            }
        }

        private async void OnProductSelected(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            await Shell.Current.GoToAsync($"{nameof(CartDetailPage)}?{nameof(CartDetailViewModel.ProductId)}={product.ID}");
        }

        private void OnAddProduct(CartItem cartItem)
        {
            cartItem.CartItemQuantity++;
        }

        private void OnDeductProduct(CartItem cartItem)
        {
            if (cartItem.CartItemQuantity > 1)
            {
                cartItem.CartItemQuantity--;
            }
        }

        private void OnDeleteProduct(CartItem cartItem)
        {
            
        }

    }
}
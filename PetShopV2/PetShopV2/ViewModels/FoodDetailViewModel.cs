using PetShopV2.Models;
using PetShopV2.ViewModels;
using PetShopV2.Services;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace PetShopV2.ViewModels
{
    [QueryProperty(nameof(FoodId), nameof(FoodId))]
    public class FoodDetailViewModel : BaseViewModel
    {
        private Food selectedFood;
        private int foodId;

        private CartRepo cartRepo;

        //waarom ICommand??
        public Command<CartItem> AddProductCommand { get; set; }


        public FoodDetailViewModel()
        {
            AddProductCommand = new Command<CartItem>(OnAddProduct);
            cartRepo = new CartRepo();

        }


        public int FoodId
        {
            get { return foodId; }
            set
            {
                foodId = value;
                LoadProduct(value);
            }
        }

        public Food SelectedFood
        {
            get { return selectedFood; }
            set
            {
                selectedFood = value;
                OnPropertyChanged(nameof(SelectedFood));
            }
        }

        public async void LoadProduct(int productId)
        {
            try
            {
                SelectedFood = await DataStore.GetProductAsync(productId) as Food;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private async void OnAddProduct(CartItem cartItem)
        {
            cartItem = await cartRepo.GetProductAsync(selectedFood.ID);
            if (cartItem == null)
            {
                await cartRepo.AddProductAsync(cartItem);
            }
            else
            {
                cartItem.CartItemQuantity++;
                await cartRepo.UpdateProductAsync(cartItem);
            }
        }
    }
}
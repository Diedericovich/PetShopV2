using PetShopV2.Models;
using PetShopV2.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace PetShopV2.ViewModels
{
    [QueryProperty(nameof(FoodId), nameof(FoodId))]
    public class FoodDetailViewModel : BaseViewModel
    {
        private Food selectedFood;
        private int foodId;
        public Command AddProductCommand => new Command(OnAddProduct);

        public ObservableCollection<Product> CartItems;

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


        private void OnAddProduct()
        {
            //  await Shell.Current.GoToAsync(nameof(NewFoodPage));

            var Cart2 = CartSingleton.GetSingleton();
            var Cart = Cart2.ShoppingCart.ItemsInCart;





            CartItem cartItem = new CartItem()
            {
                Product = selectedFood,
                ProductId = selectedFood.ID,
            };

            Cart.Add(cartItem);

        }

    }
}
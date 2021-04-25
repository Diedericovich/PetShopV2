using PetShopV2.Models;
using PetShopV2.ViewModels;
using PetShopV2.Services;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace PetShopV2.ViewModels
{
    [QueryProperty(nameof(FoodId), nameof(FoodId))]
    public class FoodDetailViewModel : BaseViewModel
    {
        private Food selectedFood;
        private int foodId;

        private CartRepo cartRepo;

        //todo: use single style (extracten naar ctor)
        public ICommand AddProductCommand;

        public FoodDetailViewModel()
        {
            AddProductCommand = new Command(OnAddProduct);
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

        private async void OnAddProduct()
        {
            // TO DO ???
            CartItem cartitem;
            CartItem item = await cartRepo.GetProductAsync(selectedFood.ID);
            if (item == null)
            {
                cartitem = new CartItem()
                {
                    CartItemQuantity = 1,
                    ProductId = selectedFood.ID,
                };
                await cartRepo.AddProductAsync(cartitem);
            }
            else
            {
                item.CartItemQuantity++;
                await cartRepo.UpdateProductAsync(item);
            }

        }
    }
}
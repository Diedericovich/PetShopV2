using PetShopV2.Models;
using PetShopV2.Services;
using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace PetShopV2.ViewModels
{
    [QueryProperty(nameof(FoodId), nameof(FoodId))]
    public class FoodDetailViewModel : BaseViewModel
    {
        private Food selectedFood;
        private int foodId;

        private CartRepo _cartRepo;

        public Command AddProductCommand { get; set; }

        public FoodDetailViewModel()
        {
            Title = "Food Details";
            _cartRepo = new CartRepo();
            AddProductCommand = new Command(OnAddProduct);
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
            CartItem cartitem;
            var CartList = await _cartRepo.GetItemsInCart();

            var item = CartList.FirstOrDefault(x => x.ProductId == selectedFood.ID);

            if (item == null)
            {
                cartitem = new CartItem()
                {
                    CartItemQuantity = 1,
                    ProductId = selectedFood.ID,
                    CartItemTotalPrice = selectedFood.Price
                };
                await _cartRepo.AddProductAsync(cartitem);
            }
            else
            {
                item.CartItemQuantity++;

                int aantal = item.CartItemQuantity;
                double prijs = item.Product.Price;

                item.CartItemTotalPrice = aantal * prijs;

                await _cartRepo.UpdateProductAsync(item);
            }
        }
    }
}
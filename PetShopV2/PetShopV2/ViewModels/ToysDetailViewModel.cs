using PetShopV2.Models;
using PetShopV2.Services;
using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace PetShopV2.ViewModels
{
    [QueryProperty(nameof(ToysId), nameof(ToysId))]
    public class ToysDetailViewModel : BaseViewModel
    {
        private Toys selectedToys;
        private int toysId;

        private CartRepo _cartRepo;
        public Command AddProductCommand { get; set; }

        public ToysDetailViewModel()
        {
            Title = "Toy Details";
            _cartRepo = new CartRepo();
            AddProductCommand = new Command(OnAddProduct);
        }

        public int ToysId
        {
            get { return toysId; }
            set
            {
                toysId = value;
                LoadProduct(value);
            }
        }

        public Toys SelectedToys
        {
            get { return selectedToys; }
            set
            {
                selectedToys = value;
                OnPropertyChanged(nameof(SelectedToys));
            }
        }

        public async void LoadProduct(int productId)
        {
            try
            {
                SelectedToys = await DataStore.GetProductAsync(productId) as Toys;
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
            var item = CartList.FirstOrDefault(x => x.ProductId == selectedToys.ID);
            if (item == null)
            {
                cartitem = new CartItem()
                {
                    CartItemQuantity = 1,
                    ProductId = selectedToys.ID,
                    CartItemTotalPrice = selectedToys.Price
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
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

        private CartRepo cartRepo;
        public Command AddProductCommand;

        public ToysDetailViewModel()
        {
            AddProductCommand = new Command(OnAddProduct);
            cartRepo = new CartRepo();
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
            CartItem item = await cartRepo.GetProductAsync(selectedToys.ID);
            if (item == null)
            {
                cartitem = new CartItem()
                {
                    CartItemQuantity = 1,
                    ProductId = selectedToys.ID,
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
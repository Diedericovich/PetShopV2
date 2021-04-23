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
        public Command AddProductCommand => new Command(OnAddProduct);

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

        private void OnAddProduct()
        {
            CartItem cartItem = new CartItem()
            {
                Product = selectedToys,
                ID = selectedToys.ID,
            };

            var lijstje = CartSingleton.ShoppingCart.ItemsInCart;

            bool ziterin = false;

            foreach (var item in lijstje)
            {
                if (item.Product == selectedToys)
                {
                    ziterin = true;
                }
            }

            if (!ziterin)
            {
                CartSingleton.ShoppingCart.ItemsInCart.Add(cartItem);
            }

            lijstje.FirstOrDefault(x => x.Product == selectedToys).CartItemQuantity += 1;
        }
    }
    
}
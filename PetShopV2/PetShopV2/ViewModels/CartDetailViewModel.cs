using PetShopV2.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace PetShopV2.ViewModels
{
    [QueryProperty(nameof(ProductId), nameof(ProductId))]
    public class CartDetailViewModel : BaseViewModel
    {
        private Product selectedProduct;
        private int productId;

        public int ProductId
        {
            get { return productId; }
            set
            {
                productId = value;
                LoadProduct(value);
            }
        }

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        public async void LoadProduct(int productId)
        {
            try
            {
                SelectedProduct = await DataStore.GetProductAsync(productId) as Product;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

    }
}

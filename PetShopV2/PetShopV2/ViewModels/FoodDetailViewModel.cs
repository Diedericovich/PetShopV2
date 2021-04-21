using PetShopV2.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace PetShopV2.ViewModels
{
    [QueryProperty(nameof(ProductID), nameof(ProductID))]
    public class FoodDetailViewModel : BaseViewModel
    {
        public Food SelectedProduct { get; }
        public int ProductID { get; set; }
        public async void LoadProductID(int productID)
        {
            try
            {
                //todo: 
                //SelectedProduct = await DataStore.GetProductAsync(productID);
                

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
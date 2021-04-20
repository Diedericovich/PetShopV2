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
        public ObservableCollection<Product> SelectedProduct { get; }

        private int productID;
        private string name;
        private string description;
        public int ID { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public int ProductID
        {
            get
            {
                return productID;
            }
            set
            {
                productID = value;
                LoadProductID(value);
            }
        }

        public async void LoadProductID(int productID)
        {
            try
            {
                var product = await DataStore.GetProductAsync(productID);
                ID = product.ID;
                Name = product.Name;
                Description = product.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
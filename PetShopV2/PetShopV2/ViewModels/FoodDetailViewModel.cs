using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace PetShopV2.ViewModels
{
    [QueryProperty(nameof(ProductID), nameof(ProductID))]
    public class FoodDetailViewModel : BaseViewModel
    {
        private int productID;
        private string name;
        private string description;
        private double price;
        private bool inStock;
        private string itemBrand;

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

        public double Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        public bool InStock
        {
            get => inStock;
            set => SetProperty(ref inStock, value);
        }

        public string ItemBrand
        {
            get => itemBrand;
            set => SetProperty(ref itemBrand, value);
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
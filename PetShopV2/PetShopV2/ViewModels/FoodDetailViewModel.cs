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
        //private double price;
        //private bool inStock;
        //private string itemBrand;

        //private double foodWeight;
        //private bool isGrainFree;

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

        //public double Price
        //{
        //    get => price;
        //    set => SetProperty(ref price, value);
        //}

        //public bool InStock
        //{
        //    get => inStock;
        //    set => SetProperty(ref inStock, value);
        //}

        //public string ProductBrand
        //{
        //    get => itemBrand;
        //    set => SetProperty(ref itemBrand, value);
        //}

        //public double FoodWeight
        //{
        //    get => foodWeight;
        //    set => SetProperty(ref foodWeight, value);
        //}

        //public double IsGrainFree
        //{
        //    get => isGrainFree;
        //    set => SetProperty(ref isGrainFree, value);
        //}

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

                //Price = product.Price;
                //InStock = product.InStock;
                //ProductBrand = product.ProductBrand;
                //FoodWeight = food.FoodWeight;
                //IsGrainFree = food.IsGrainFree;

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
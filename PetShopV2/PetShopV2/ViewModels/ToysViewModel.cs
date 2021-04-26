using PetShopV2.Models;
using PetShopV2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace PetShopV2.ViewModels
{
    public class ToysViewModel : BaseViewModel
    {
        private Toys _selectedProduct;

        private ObservableCollection<Toys> toysItems;

        public ObservableCollection<Toys> ToysItems
        {
            get { return toysItems; }
            set
            {
                toysItems = value;
                OnPropertyChanged(nameof(ToysItems));
            }
        }

        public Command LoadProductsCommand { get; }
        public Command AddProductCommand { get; }
        public Command<Toys> ProductTapped { get; }

        public ToysViewModel()
        {
            Title = "Toys";
            ToysItems = new ObservableCollection<Toys>();
            ExecuteLoadProductsCommand();
            LoadProductsCommand = new Command(ExecuteLoadProductsCommand);
            ProductTapped = new Command<Toys>(OnProductSelected);
        }

        private async void ExecuteLoadProductsCommand()
        {
            IsBusy = true;

            try
            {
                ToysItems.Clear();
                IEnumerable<Product> products = await DataStore.GetAllProductsAsync(true);

                List<Toys> newToysList = new List<Toys>();

                foreach (var product in products)
                {
                    //Products.Add(product);
                    if (product is Toys toys)
                    {
                        newToysList.Add(toys);
                    }
                }
                ToysItems = new ObservableCollection<Toys>(newToysList);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Toys SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                SetProperty(ref _selectedProduct, value);
                OnProductSelected(value);
            }
        }

        private async void OnProductSelected(Toys toys)
        {
            if (toys == null)
            {
                throw new ArgumentNullException(nameof(toys));
            }

            await Shell.Current.GoToAsync($"{nameof(ToysDetailPage)}?{nameof(ToysDetailViewModel.ToysId)}={toys.ID}");
        }
    }
}
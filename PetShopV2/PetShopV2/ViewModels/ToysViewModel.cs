using PetShopV2.Models;
using PetShopV2.Services;
using PetShopV2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PetShopV2.ViewModels
{
    public class ToysViewModel : BaseViewModel
    {
        private IProductExampleDB<Product> productExampleDB;

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
        public Command<Toys> ProductTapped { get; }

        public ToysViewModel()
        {
            Title = "Toys";
            ToysItems = new ObservableCollection<Toys>();
            productExampleDB = new GenericRepo<Product>();
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
                IEnumerable<Product> products = await productExampleDB.GetAllProductsAsync(true);
                ToysItems = new ObservableCollection<Toys>();
                
                foreach (var item in products)
                {
                    if (item is Toys)
                    {
                        ToysItems.Add((Toys)item);
                    }
                }
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

        //public void OnAppearing()
        //{
        //    IsBusy = true;
        //    SelectedProduct = null;
        //}

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

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ToysDetailPage)}?{nameof(ToysDetailViewModel.ToysId)}={toys.ID}");
        }
    }
}
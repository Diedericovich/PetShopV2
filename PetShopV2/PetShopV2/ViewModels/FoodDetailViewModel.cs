using PetShopV2.Models;
using PetShopV2.ViewModels;
using PetShopV2.Services;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace PetShopV2.ViewModels
{
    [QueryProperty(nameof(FoodId), nameof(FoodId))]
    public class FoodDetailViewModel : BaseViewModel
    {
        private IProductExampleDB<Product> productExampleDB;

        private Food selectedFood;
        private int foodId;

        private CartRepo _cartRepo;

        private ObservableCollection<CartItem> itemsInCart;
        public ObservableCollection<CartItem> ItemsInCart
        {
            get { return itemsInCart; }
            set
            {
                itemsInCart = value;

                OnPropertyChanged(nameof(ItemsInCart));
            }
        }


        //waarom ICommand??
        public Command AddProductCommand { get; set; }


        public FoodDetailViewModel()
        {
            _cartRepo = new CartRepo();

            AddProductCommand = new Command(OnAddProduct);

        }


        public int FoodId
        {
            get { return foodId; }
            set
            {
                foodId = value;
                LoadProduct(value);
            }
        }

        public Food SelectedFood
        {
            get { return selectedFood; }
            set
            {
                selectedFood = value;
                OnPropertyChanged(nameof(SelectedFood));
            }
        }

        public async void LoadProduct(int productId)
        {
            try
            {
                SelectedFood = await productExampleDB.GetProductAsync(productId) as Food;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private async void OnAddProduct()
        {
            CartItem cartitem;
            CartItem item = await _cartRepo.GetProductAsync(selectedFood.ID);
            if (item == null)
            {
                cartitem = new CartItem()
                {
                    CartItemQuantity = 1,
                    ProductId = selectedFood.ID,
                };
                await _cartRepo.AddProductAsync(cartitem);
            }
            else
            {
                item.CartItemQuantity++;
                await _cartRepo.UpdateProductAsync(item);
            }
        }

        //private async void OnAddProduct()
        //{
        //    var result = await _cartRepo.GetItemsInCart();
        //    ItemsInCart = new ObservableCollection<CartItem>(result);

        //    CartItem cartItem = new CartItem();
        //    cartItem = await _cartRepo.GetProductAsync(selectedFood.ID);

        //    //cartItem.ProductId = selectedFood.ID;

        //    if (!ItemsInCart.Contains(cartItem))
        //    {

        //    await _cartRepo.AddProductAsync(cartItem);
        //    }

        //    ItemsInCart.Add(cartItem);
        //}
    }
}
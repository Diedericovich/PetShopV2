using PetShopV2.Models;
using PetShopV2.ViewModels;
using PetShopV2.Services;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopV2.ViewModels
{
    [QueryProperty(nameof(FoodId), nameof(FoodId))]
    public class FoodDetailViewModel : BaseViewModel
    {
        private IProductExampleDB<Product> productExampleDB;

        private Food selectedFood;
        private int foodId;

        private CartRepo cartRepo;

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


        //todo: use single style (extracten naar ctor)
        public ICommand AddProductCommand;

        public FoodDetailViewModel()
        {
            productExampleDB = new GenericRepo<Product>();
            AddProductCommand = new Command<Food>(OnAddProduct);
            cartRepo = new CartRepo();
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

        private void OnAddProduct(Food food)
        {
            var cartItem = ItemsInCart.FirstOrDefault(x => x.Product.ID == FoodId);

            if (cartItem == null)
            {
                CartItem newCartItem = new CartItem
                {
                    CartItemQuantity = 1,
                    Product = food,
                };
                ItemsInCart.Add(newCartItem);
            }
            else
            {
                cartItem.CartItemQuantity++;
            }


        }
    }
}
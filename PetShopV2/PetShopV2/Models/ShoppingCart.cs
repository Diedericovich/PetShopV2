using System.Collections.ObjectModel;

namespace PetShopV2.Models
{
    public class ShoppingCart : Model
    {
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

        private double totalPrice;

        public double TotalPrice
        {
            get { return totalPrice; }
            set
            {
                totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public ShoppingCart()
        {
            ItemsInCart = new ObservableCollection<CartItem>();
        }
    }
}
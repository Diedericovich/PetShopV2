namespace PetShopV2.Models
{
    public class CartItem : Model
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        private int cartItemQuantity;

        public int CartItemQuantity
        {
            get { return cartItemQuantity; }
            set { cartItemQuantity = value;

                OnPropertyChanged(nameof(CartItemQuantity));
            }
        }


        //public int ShoppingCartId { get; set; }

        //public ShoppingCart ShoppingCart { get; set; }
    }
}
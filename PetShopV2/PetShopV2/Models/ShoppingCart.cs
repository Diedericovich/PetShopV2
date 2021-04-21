using System.Collections.Generic;

namespace PetShopV2.Models
{
    public class ShoppingCart : Model
    {
        public List<CartItem> ItemsInCart { get; set; }

        public ShoppingCart()
        {
            ItemsInCart = new List<CartItem>();
        }
    }
}
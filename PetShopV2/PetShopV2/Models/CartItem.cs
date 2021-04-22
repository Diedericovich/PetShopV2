namespace PetShopV2.Models
{
    public class CartItem : Model
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        //public int ShoppingCartId { get; set; }

        //public ShoppingCart ShoppingCart { get; set; }
    }
}
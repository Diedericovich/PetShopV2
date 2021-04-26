namespace PetShopV2.Models
{
    public enum AnimalType { Unknown = 0, Cat = 1, Dog = 2 }

    public class Product : Model
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public bool InStock { get; set; }

        public AnimalType Animal { get; set; }
        public string ProductBrand { get; set; }
    }
}
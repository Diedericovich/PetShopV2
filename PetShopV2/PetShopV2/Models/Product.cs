using System;

namespace PetShopV2.Models
{
    public enum AnimalType { Unknown = 0, Cat = 1, Dog = 2 }

    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public bool InStock { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime LastEdited { get; set; }
        public AnimalType Animal { get; set; }
        public string ItemBrand { get; set; }

        public Product()
        {
            DateOfCreation = DateTime.Today;
            LastEdited = DateTime.Now;
        }
    }
}
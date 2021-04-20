namespace PetShopV2.Models
{
    public class Food : Product
    {
        public double FoodWeight { get; set; }
        public bool IsGrainFree { get; set; }
    }
}
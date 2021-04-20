namespace PetShopV2.Models
{
    internal class Toys : Product
    {
        public bool ContainsLatex { get; set; }
        public bool IsTough { get; set; }
        public bool IsInteractive { get; set; }
        public bool MakesSound { get; set; }
    }
}
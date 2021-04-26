using PetShopV2.Services;
using System;

namespace PetShopV2.Models
{
    public abstract class Model : ObservableObject
    {
        public int ID { get; set; }

        public DateTime DateOfCreation { get; set; }
        public DateTime LastEdited { get; set; }

        public Model()
        {
            DateOfCreation = DateTime.Today;
            LastEdited = DateTime.Now;
        }
    }
}
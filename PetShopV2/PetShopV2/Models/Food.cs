using PetShopV2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopV2.Models
{
    public class Food : Product
    {
        public double FoodWeight { get; set; }
        public bool IsGrainFree { get; set; }
    }
}
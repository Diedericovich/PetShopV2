using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopV2.Models
{
    public abstract class Model
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

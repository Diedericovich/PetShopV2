using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopV2.Models
{
    class Toys : Product
    {
        public bool ContainsLatex { get; set; }
        public bool IsTough { get; set; }
        public bool IsInteractive { get; set; }
        public bool MakesSound { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using PetShopV2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShopV2.Services
{
    public class CartRepo : GenericRepo<CartItem>
    {
        public async Task<ICollection<CartItem>> GetItemsInCart()
        {
            using (var dbContext = new PetShopContext())
            {
                return await dbContext.CartItems
                    .Include(x => x.Product)
                    .ToListAsync();
            }
        }
    }
}
using AuctionApp.Core.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.BLL.Service.Contract
{
    public interface ICartService
    {
        Task AddItemToCart(int itemId);
        Task RemoveCartItem(int id);
        Task RemoveCart();
        List<CartItemDTO> GetCartItems();
        decimal GetTotalPrice();
    }
}
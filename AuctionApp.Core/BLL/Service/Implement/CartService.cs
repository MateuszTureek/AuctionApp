using AuctionApp.Core.BLL.DTO;
using AuctionApp.Core.BLL.Service.Contract;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.BLL.Service.Implement
{
    public class CartService : ICartService
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly ISession _s;
        readonly string _key = "";
        readonly IItemService _itemService;
        readonly IMapper _mapper;

        public CartService(
            IHttpContextAccessor httpContextAccessor,
            IItemService itemService,
            IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _s = _httpContextAccessor.HttpContext.Session;
            _itemService = itemService;
            _mapper = mapper;
        }

        public async Task AddItemToCart(int itemId)
        {
            SingleItemDTO item = _itemService.GetItem(itemId);
            if (item == null) throw new NullReferenceException();

            var cartItem = _mapper.Map<SingleItemDTO, CartItemDTO>(item);

            if (!_s.IsAvailable)
                await _s.LoadAsync().ConfigureAwait(false);

            var cartItems = GetCartItems();

            cartItems.Add(cartItem);
            _s.SetString(_key, JsonConvert.SerializeObject(cartItems));
            await _s.CommitAsync().ConfigureAwait(false);
        }

        public List<CartItemDTO> GetCartItems()
        {
            List<CartItemDTO> cartItems;

            if (_s.Keys.Contains(_key))
            {
                cartItems = JsonConvert.DeserializeObject<List<CartItemDTO>>(_s.GetString(_key));
                if (cartItems == null) cartItems = new List<CartItemDTO>();
            }
            else cartItems = new List<CartItemDTO>();

            return cartItems;
        }

        public decimal GetTotalPrice()
        {
            var cartItems = GetCartItems();
            int i = 0,
                length = cartItems.Count;
            decimal sum = 0;

            for (i = 0; i < length; i += 1)
            {
                sum += cartItems[i].Price;
            }
            return sum;
        }

        public async Task RemoveCart()
        {
            await _s.LoadAsync().ConfigureAwait(false);
            _s.Remove(_key);
            await _s.CommitAsync().ConfigureAwait(false);
        }

        public async Task RemoveCartItem(int id)
        {
            List<CartItemDTO> cartItems = JsonConvert.DeserializeObject<List<CartItemDTO>>(_s.GetString(_key));
            if (cartItems == null) throw new NullReferenceException();

            var cartItem = cartItems.FirstOrDefault(f => f.Id == id);

            if (cartItem == null) throw new NullReferenceException();
            cartItems.Remove(cartItem);

            await _s.LoadAsync().ConfigureAwait(false);
            _s.SetString(_key, JsonConvert.SerializeObject(cartItems));
            await _s.CommitAsync().ConfigureAwait(false);
        }
    }
}

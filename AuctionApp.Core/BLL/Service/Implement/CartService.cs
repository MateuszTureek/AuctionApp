using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionApp.Core.BLL.DTO.Cart;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AuctionApp.Core.BLL.Service.Implement {
    public class CartService : ICartService {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly ISession _s;
        readonly string _key = "";
        readonly IMapper _mapper;
        readonly IItemRepo _itemRepo;

        public CartService (
            IHttpContextAccessor httpContextAccessor,
            IItemRepo itemRepo,
            IMapper mapper) {
            _httpContextAccessor = httpContextAccessor;
            _s = _httpContextAccessor.HttpContext.Session;
            _itemRepo = itemRepo;
            _mapper = mapper;
        }

        public async Task AddItemToCart (int itemId) {
            Item item = _itemRepo.GetById (itemId);

            if (item == null) throw new NullReferenceException ();

            CartItemDTO cartItem = _mapper.Map<Item, CartItemDTO> (item);

            if (!_s.IsAvailable)
                await _s.LoadAsync ().ConfigureAwait (false);

            var cartItems = GetCartItems ();

            if (!Exist (cartItem, cartItems)) {
                cartItems.Add (cartItem);
                _s.SetString (_key, JsonConvert.SerializeObject (cartItems));
                await _s.CommitAsync ().ConfigureAwait (false);
            }
        }

        public bool Exist (CartItemDTO itemToAdded, List<CartItemDTO> cardItems) {
            int i, length = cardItems.Count;

            for (i = 0; i < length; i += 1)
                if (cardItems[i].ItemId == itemToAdded.ItemId) return true;
            return false;
        }

        public List<CartItemDTO> GetCartItems () {
            List<CartItemDTO> cartItems;

            if (_s.Keys.Contains (_key)) {
                cartItems = JsonConvert.DeserializeObject<List<CartItemDTO>> (_s.GetString (_key));
                if (cartItems == null) cartItems = new List<CartItemDTO> ();
            } else cartItems = new List<CartItemDTO> ();

            return cartItems;
        }

        public decimal GetTotalPrice () {
            var cartItems = GetCartItems ();

            var sum = cartItems.Sum (s => s.Price + s.DeliveryCost);
            return sum;
        }

        public async Task RemoveCart () {
            await _s.LoadAsync ().ConfigureAwait (false);
            _s.Remove (_key);
            await _s.CommitAsync ().ConfigureAwait (false);
        }

        public async Task RemoveCartItem (int id) {
            List<CartItemDTO> cartItems = JsonConvert.DeserializeObject<List<CartItemDTO>> (_s.GetString (_key));
            if (cartItems == null) throw new NullReferenceException ();

            var cartItem = cartItems.FirstOrDefault (f => f.Id == id);

            if (cartItem == null) throw new NullReferenceException ();
            cartItems.Remove (cartItem);

            await _s.LoadAsync ().ConfigureAwait (false);
            _s.SetString (_key, JsonConvert.SerializeObject (cartItems));
            await _s.CommitAsync ().ConfigureAwait (false);
        }
    }
}
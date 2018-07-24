using System.Threading.Tasks;
using AuctionApp.Core.BLL.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Controllers
{
    public class CartController : Controller
    {
        readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            var cartItems = _cartService.GetCartItems();
            ViewBag.TotalCost = string.Format(new System.Globalization.CultureInfo("pl"), "{0:C}", _cartService.GetTotalPrice());

            return View(cartItems);
        }

        public async Task<IActionResult> AddCartItem(int? itemId)
        {
            if (itemId == null) return NotFound();

            await _cartService.AddItemToCart((int)itemId).ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null) return NotFound();

            await _cartService.RemoveCartItem((int)id).ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Clear()
        {
            await _cartService.RemoveCart().ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Summary()
        {
            var model = _cartService.GetCartItems();
            return View(model);
        }
    }
}
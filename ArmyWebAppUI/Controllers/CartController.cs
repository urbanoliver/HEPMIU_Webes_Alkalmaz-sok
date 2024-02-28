using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArmyWebAppUI.Controllers
{

    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepo;

        public CartController(ICartRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }

        public async Task<IActionResult> AddItem(int weaponId, int qt = 1, int redirect = 0)
        {

            var cartCount = await _cartRepo.AddItem(weaponId, qt);
            if (redirect == 0)
            {
                return Ok(cartCount);
            }
            return RedirectToAction("GetUserCart");
        }

        public async Task<IActionResult> RemoveItem(int weaponId)
        {
            var cartCount = await _cartRepo.RemoveItem(weaponId);

            return RedirectToAction("GetUserCart");
        }

        public async Task<IActionResult> GetUserCart()
        {
            var cart = await _cartRepo.GetUserCart();

            return View(cart);
        }

        public async Task<IActionResult> GetTotalItemInCart()
        {
            int cartItem = await _cartRepo.GetCartItemCount();
            return Ok(cartItem);
        }

        public async Task<IActionResult> Checkout()
        {
            bool isCheckedOut = await _cartRepo.DoCheck();

            if (!isCheckedOut)
            {
                throw new Exception("Valami törtent a szerver oldalon");
            
            }
            


            return RedirectToAction("Index", "Home");
        }
    }
}

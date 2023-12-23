using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.Entity.Concrete;
using TeaShopApi.WebUI.Models;

namespace TeaShopApi.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Default");
            }
            else
            {
                ModelState.AddModelError("", "Giriş başarısız oldu.Lütfen tekrar deneyiniz.");


            }
            return View();
        }


        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

          return  RedirectToAction("Index","Default");
        }
    }
}

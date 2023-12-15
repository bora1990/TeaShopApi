using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.Entity.Concrete;
using TeaShopApi.WebUI.Models;


namespace TeaShopApi.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager; // ( Kayıt  Profil Güncelleme,Kullanıcı Herhangi bir bilgisine ulaşma vs)
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            var appUser = new AppUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.UserName
            };

            var result = await _userManager.CreateAsync(appUser, model.Password);  //Hatchlenmiş gelsin diye burda

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}

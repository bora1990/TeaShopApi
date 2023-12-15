using Microsoft.AspNetCore.Mvc;

namespace TeaShopApi.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialHeader() 
        {

            return PartialView();
        }

        public PartialViewResult PartialFooter()
        {

            return PartialView();
        }

        public PartialViewResult PartialScript()
        {

            return PartialView();
        }

    }
}

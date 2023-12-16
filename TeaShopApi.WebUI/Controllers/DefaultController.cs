using Microsoft.AspNetCore.Mvc;
using TeaShopApi.Business.Abstract;
using TeaShopApi.Entity.Concrete;
using TeaShopApi.WebUI.Dtos.MessageDtos;

namespace TeaShopApi.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly HttpClient _client;

        public DefaultController(HttpClient client)
        {
            _client = client;
        }

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
        [HttpPost]
        public async Task<IActionResult> AddContact(Message message)
        {
             message.MessageSendDate = DateTime.Now;
            await _client.PostAsJsonAsync("https://localhost:7026/api/Subscribe/", message);


            return RedirectToAction("Index");
        }



    }
}

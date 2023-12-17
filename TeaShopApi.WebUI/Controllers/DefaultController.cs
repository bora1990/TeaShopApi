using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TeaShopApi.Business.Abstract;
using TeaShopApi.Entity.Concrete;
using TeaShopApi.WebUI.Dtos.MessageDtos;
using TeaShopApi.WebUI.Dtos.SubscribeDtos;

namespace TeaShopApi.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; //API tarafında isteği oluşturacak.Client(İstemci)

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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

            var client = _httpClientFactory.CreateClient();

            await client.PostAsJsonAsync("https://localhost:7026/api/Message/", message);


            return RedirectToAction("Index");
        }


        [HttpGet]
        public PartialViewResult _SubscribePartial()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> _SubscribePartial(CreateSubscribeDto createSubscribeDto)
        {

            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(createSubscribeDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7181/api/Subscribe", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();

        }



    }
}

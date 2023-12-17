using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using TeaShopApi.WebUI.Dtos.DrinkDtos;
using TeaShopApi.WebUI.Dtos.MessageDtos;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]  //Admin Areasında olduğunu bildiriyoruz.
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v = "Mesaj Yönetimi";
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7026/api/Messages");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = System.Text.Json.JsonSerializer.Deserialize<List<ResultMessageDto>>(jsonData);

                return View(values);
            }

            return View();
        }
        [HttpGet]
        public ActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
           createMessageDto.messageSendDate = DateTime.Now;


            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(createMessageDto);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");


            var responseMessage =await  client.PostAsync("https://localhost:7026/api/Messages", content);

            if(responseMessage.IsSuccessStatusCode)
            {
                RedirectToAction("Index");

            }

            return View(responseMessage);
        }

        public async Task<IActionResult> DeleteMessage(int id)
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7026/api/Messages?id="+id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();        
        }

        public async Task<IActionResult> UpdateMessage(int id)
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7026/api/Messages/"+id);

            if (responseMessage.IsSuccessStatusCode)
            {

            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var value = System.Text.Json.JsonSerializer.Deserialize<UpdateMessageDto>(jsonData);

            return View(value);

            }

            return View();
        }
        [HttpPost]

        public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateMessageDto);

            var content=new StringContent(jsonData,Encoding.UTF8,"application/json");

            var response = await client.PutAsync("https://localhost:7026/api/Messages", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

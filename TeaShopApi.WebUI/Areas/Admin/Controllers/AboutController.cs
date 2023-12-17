using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using TeaShopApi.WebUI.Dtos.AboutDtos;
using TeaShopApi.WebUI.Dtos.TestimonialDtos;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]  //Admin Areasında olduğunu bildiriyoruz.
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AboutController : Controller
    {
       
        private readonly IHttpClientFactory _httpClientFactory; //API tarafında isteği oluşturacak.Client(İstemci)

            public AboutController(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }

            [HttpGet]
            public async Task<IActionResult> Index()
            {
                ViewBag.v = "Hakkımızda Yönetimi";

                var client = _httpClientFactory.CreateClient();

                var responseMessage = await client.GetAsync("https://localhost:7026/api/Abouts");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync(); //ilgili veri json geldi notepad olarak oku Paste Special
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);

                return View(values);
                }
                return View();
            }

            [HttpGet]
            public IActionResult CreateAbout()
            {
                return View();
            }

            [HttpPost]

            public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = System.Text.Json.JsonSerializer.Serialize(createAboutDto);


                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://localhost:7026/api/Abouts", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                return View();


            }

            public async Task<IActionResult> DeleteAbout(int id)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.DeleteAsync("https://localhost:7026/api/Abouts?id=" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();

            }

            [HttpGet]
            public async Task<IActionResult> UpdateAbout(int id)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7026/api/Abouts/" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
                    return View(values);
                }
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(updateAboutDto);

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await client.PutAsync("https://localhost:7026/api/Abouts", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
        }
    }


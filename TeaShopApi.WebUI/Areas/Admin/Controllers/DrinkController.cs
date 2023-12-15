using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using TeaShopApi.WebUI.Dtos.DrinkDtos;




namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]  //Admin Areasında olduğunu bildiriyoruz.
    [Route("[area]/[controller]/[action]/{id?}")]

    public class DrinkController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; //API tarafında isteği oluşturacak.Client(İstemci)

        public DrinkController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory; 
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7026/api/Drinks/");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //ilgili veri json geldi notepad olarak oku Paste Special
                var values = JsonSerializer.Deserialize<List<ResultDrinkDto>>(jsonData); 

                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateDrink()
        {
            return View(); 
        }

        [HttpPost]

        public async Task<IActionResult> CreateDrink(CreateDrinkDto createDrinkDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonSerializer.Serialize(createDrinkDto);
                       
        
            var content  = new StringContent(jsonData, Encoding.UTF8, "application/json");
        
            var response =await client.PostAsync("https://localhost:7026/api/Drinks", content);
            if (response.IsSuccessStatusCode)
            {  
                return RedirectToAction("Index");  
            }

            return View();


        }

        public async Task<IActionResult> DeleteDrink(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7026/api/Drinks?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UpdateDrink(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7026/api/Drinks/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateDrinkDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDrink(UpdateDrinkDto updateDrinkDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(updateDrinkDto);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7026/api/Drinks", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

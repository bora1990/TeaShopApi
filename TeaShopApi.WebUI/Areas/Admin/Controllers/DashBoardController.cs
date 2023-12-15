﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaShopApi.WebUI.Dtos.DrinkDtos;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]  //Admin Areasında olduğunu bildiriyoruz.
    [Route("[area]/[controller]/[action]/{id?}")]
    public class DashBoardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; //API tarafında isteği oluşturacak.Client(İstemci)

        public DashBoardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory; //HttpClient, .NET platformundaki bir sınıftır ve HTTP üzerinden iletişim kurmak için kullanılır. HttpClient sınıfı, HTTP protokolü üzerinden sunuculara istekler göndermek ve bu sunuculardan gelen yanıtları almak için tasarlanmıştır.
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v = "Özet Bilgiler";
            var client = _httpClientFactory.CreateClient();

            var responseMessage1 = await client.GetAsync("https://localhost:7026/api/Statistics/GetDrinkAveragePrice");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync(); //ilgili veri json geldi notepad olarak oku
            ViewBag.v1 = jsonData1;

            var responseMessage2 = await client.GetAsync("https://localhost:7026/api/Statistics/GetDrinkCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync(); //ilgili veri json geldi notepad olarak oku
            ViewBag.v2 = jsonData2;

            var responseMessage3 = await client.GetAsync("https://localhost:7026/api/Statistics/GetLastDrinkName");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync(); //ilgili veri json geldi notepad olarak oku
            ViewBag.v3 = jsonData3;

            var responseMessage4 = await client.GetAsync("https://localhost:7026/api/Statistics/GetMaxPriceDrink");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync(); //ilgili veri json geldi notepad olarak oku
            ViewBag.v4 = jsonData4;


            return View();
        }
    }
}

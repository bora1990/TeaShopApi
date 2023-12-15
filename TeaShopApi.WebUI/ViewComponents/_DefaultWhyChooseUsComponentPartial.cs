using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaShopApi.WebUI.Dtos.DrinkDtos;

namespace TeaShopApi.WebUI.ViewComponents
{
    public class _DefaultWhyChooseUsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhyChooseUsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int sayfa = 1)
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage1 = await client.GetAsync("https://localhost:7026/api/Statistics/GetDrinkCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync(); //ilgili veri json geldi notepad olarak oku
            ViewBag.v1 = jsonData1;

           
            var responseMessage2 = await client.GetAsync("https://localhost:7026/api/Statistics/GetMinPriceDrink");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync(); //ilgili veri json geldi notepad olarak oku
            ViewBag.v2 = jsonData2;

            var responseMessage3 = await client.GetAsync("https://localhost:7026/api/Statistics/CountTestimonials");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync(); //ilgili veri json geldi notepad olarak oku
            ViewBag.v3 = jsonData3;


            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.PowerBI.Api.Models;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using TeaShopApi.WebUI.Dtos.AboutDtos;
using TeaShopApi.WebUI.Dtos.DrinkDtos;

namespace TeaShopApi.WebUI.ViewComponents
{
    public class _DefaultAboutComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultAboutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int sayfa = 1)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7026/api/Abouts/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);

                return View(values);

            }
            return View();
        }

    }

}


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

using TeaShopApi.WebUI.Dtos.DrinkDtos;
using X.PagedList;


namespace TeaShopApi.WebUI.ViewComponents
{
    public class _DefaultDrinkLinkComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultDrinkLinkComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int sayfa = 1)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7026/api/Drinks/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync(); 
                var values=JsonConvert.DeserializeObject<List<ResultDrinkDto>>(jsonData);

                return View(values);
               
            }
            return View();
        }

    
    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using TeaShopApi.WebUI.Dtos.TestimonialDtos;
using TeaShopApi.WebUI.Dtos.DrinkDtos;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
        [Area("Admin")]  
        [Route("[area]/[controller]/[action]/{id?}")]
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; //API tarafında isteği oluşturacak.Client(İstemci)

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7026/api/Testimonials");

            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData =await responseMessage.Content.ReadAsStringAsync();
                var values= JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);  

                return View(values);
                      
            }

            return View();
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var client=_httpClientFactory.CreateClient();

            var jsonData= System.Text.Json.JsonSerializer.Serialize(createTestimonialDto);  //serilize ettikten sonra contenti string yapmak lazım

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var jsonResponse = await client.PostAsync("https://localhost:7026/api/Testimonials", content);

            if(jsonResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage=  await client.DeleteAsync("https://localhost:7026/api/Testimonials?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {

              return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage=await client.GetAsync("https://localhost:7026/api/Testimonials/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateTestimonialDto>(jsonData);
                return View(value);
            }

            return View();
        }
        [HttpPost]

        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var client= _httpClientFactory.CreateClient();  

            var jsonData=JsonConvert.SerializeObject(updateTestimonialDto);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7026/api/Testimonials", content);
            if (responseMessage.IsSuccessStatusCode)
            {
               return RedirectToAction("Index");
            }
            return View();       
        }

    }
}

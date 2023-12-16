using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.Business.Abstract;
using TeaShopApi.Entity.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutsController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }



        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetAllList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(DtoLayer.AboutDtos.CreateAboutDto createAboutDto)
        {
            About About = new About()
            {
                ImageUrl = createAboutDto.ImageUrl,
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
               
            };

            _aboutService.TInsert(About);
            return Ok("Eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]  //2 tane get olduğundan , 1 inde parametre alacağı için bu şekilde

        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]

        public IActionResult UpdateAbout(DtoLayer.AboutDtos.UpdateAboutDto updateAboutDto)
        {
            About About = new About()
            {
                AboutID = updateAboutDto.AboutID,
                Title = updateAboutDto.Title,
                Description = updateAboutDto.Description,
                ImageUrl = updateAboutDto.ImageUrl
            };
            _aboutService.TUpdate(About);
            return Ok("Güncelleme Yapıldı");
        }
    }
}

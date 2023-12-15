using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.Business.Abstract;
using TeaShopApi.Dto.DrinkDtos;
using TeaShopApi.Entity.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase   //APILER BAŞINDA ATTRİBUTE YOKSA TEST EDİLEMEZ.ATTRIBUTE MUTLAKA OLMALI
    {
        private readonly IDrinkService _drinkService;

        public DrinksController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        [HttpGet]
        public IActionResult DrinkList()
        {
            var values = _drinkService.TGetAllList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateDrink(CreateDrinkDto createDrinkDto)
        {
            Drink drink = new Drink()
            {
                DrinkImageUrl = createDrinkDto.drinkImageUrl,
                DrinkName = createDrinkDto.drinkName,
                DrinkPrice = createDrinkDto.drinkPrice
            };

            _drinkService.TInsert(drink);
            return Ok("İçeceğiniz başarıyla eklenmiştir.");
        }

        [HttpDelete]
        public IActionResult DeleteDrink(int id)
        {
            var value = _drinkService.TGetById(id);
            _drinkService.TDelete(value);
            return Ok("Silindi");
        }
       
        [HttpGet("{id}")]  //2 tane get olduğundan , 1 inde parametre alacağı için bu şekilde

        public IActionResult GetDrink(int id)
        {
            var value = _drinkService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]

        public IActionResult UpdateDrink(UpdateDrinkDto updateDrinkDto)
        {
            Drink drink = new Drink()
            {
                DrinkID = updateDrinkDto.drinkID,
                DrinkName = updateDrinkDto.drinkName,
                DrinkImageUrl = updateDrinkDto.drinkImageUrl,
                DrinkPrice = updateDrinkDto.drinkPrice
            };
          _drinkService.TUpdate(drink);
            return Ok("Güncelleme Yapıldı");
        }
    }
}

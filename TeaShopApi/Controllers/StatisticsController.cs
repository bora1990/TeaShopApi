using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.Business.Abstract;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }
        [HttpGet("GetDrinkAveragePrice")]

        public IActionResult GetDrinkAveragePrice()
        {
            return Ok(_statisticService.TDrinkAveragePrice());
        }

        [HttpGet("GetDrinkCount")]

        public IActionResult GetDrinkCount()
        {
            return Ok(_statisticService.TDrinkCount());
        }

        [HttpGet("GetLastDrinkName")]

        public IActionResult GetLastDrinkName()
        {
            return Ok(_statisticService.TLastDrinkName());
        }

        [HttpGet("GetMaxPriceDrink")]

        public IActionResult GetMaxPriceDrink()
        {
            return Ok(_statisticService.TMaxPriceDrink());
        }

    }
}

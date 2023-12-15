using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopApi.Dto.DrinkDtos
{
    public class UpdateDrinkDto
    {
            public int drinkID { get; set; }
            public string drinkName { get; set; }
            public decimal drinkPrice { get; set; }
            public string drinkImageUrl { get; set; }
    }
}

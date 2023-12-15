using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopApi.DataAccess.Abstract
{
    public interface IStaticticsDal
    {
        int DrinkCount();

        decimal DrinkAveragePrice();

        string LastDrinkName();

        string MaxPriceDrink();
    }
}

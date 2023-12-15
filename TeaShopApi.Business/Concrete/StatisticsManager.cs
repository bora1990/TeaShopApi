using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApi.Business.Abstract;
using TeaShopApi.DataAccess.Abstract;

namespace TeaShopApi.Business.Concrete
{
    public class StatisticsManager : IStatisticService
    {
        private readonly IStaticticsDal _statisticDal;

        public StatisticsManager(IStaticticsDal statisticDal)
        {
            _statisticDal = statisticDal;
        }

        public decimal TDrinkAveragePrice()
        {
           return _statisticDal.DrinkAveragePrice();
        }

        public int TDrinkCount()
        {
            return _statisticDal.DrinkCount();
        }

        public string TLastDrinkName()
        {
            return _statisticDal.LastDrinkName();
        }

        public string TMaxPriceDrink()
        {
            return _statisticDal.MaxPriceDrink();
        }

        public decimal TMinPriceDrink()
        {
            return _statisticDal.MinPriceDrink();
        }

        public decimal TTestimonialCount()
        {
            return _statisticDal.TestimonialCount();
        }
    }
}

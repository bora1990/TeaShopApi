using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApi.DataAccess.Abstract;
using TeaShopApi.DataAccess.Context;

namespace TeaShopApi.DataAccess.EntityFramework
{
    public class EfStatisticsDal : IStaticticsDal
    {
        private readonly TeaContext _context;

        public EfStatisticsDal(TeaContext context)
        {
            _context = context;
        }

        public decimal DrinkAveragePrice()
        {
           decimal value=_context.Drinks.Average(x=>x.DrinkPrice);
            return value;
        }

        public int DrinkCount()
        {
            return _context.Drinks.Count();
        }

        public string LastDrinkName()
        {
            string value=_context.Drinks.OrderByDescending(x=>x.DrinkID).Select(y=>y.DrinkName).Take(1).FirstOrDefault();

            return value;
        }

        public string MaxPriceDrink()
        {
            decimal price = _context.Drinks.Max(x => x.DrinkPrice);
            string value=_context.Drinks.Where(x=>x.DrinkPrice==price).Select(x=>x.DrinkName).FirstOrDefault();

            return value;
        }
        public decimal MinPriceDrink()
        {
            decimal price= _context.Drinks.Min(x=>x.DrinkPrice);
        
            return price;
        }

        public decimal TestimonialCount()
        {
            return _context.Testimonials.Count();
        }
    }
}

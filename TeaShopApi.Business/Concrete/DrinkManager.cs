using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApi.Business.Abstract;
using TeaShopApi.DataAccess.Abstract;
using TeaShopApi.Entity.Concrete;

namespace TeaShopApi.Business.Concrete
{
    public class DrinkManager : IDrinkService
    {
        private readonly IDrinkDal _drinkDal;

        public DrinkManager(IDrinkDal drinkDal)
        {
            _drinkDal = drinkDal;
        }

        public void TDelete(Drink entity)
        {
            _drinkDal.Delete(entity);
        }


        public List<Drink> TGetAllList()
        {
            return _drinkDal.GetAllList();
        }

        public Drink TGetById(int id)
        {
            return _drinkDal.GetById(id);
        }

        public void TInsert(Drink entity)
        {
            _drinkDal.Insert(entity);
        }

        public void TUpdate(Drink entity)
        {
            _drinkDal.Update(entity);
        }
    }
}

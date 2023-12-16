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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TDelete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public List<About> TGetAllList()
        {
            return _aboutDal.GetAllList();  
        }

        public About TGetById(int id)
        {
            return _aboutDal.GetById(id);
        }

        public void TInsert(About entity)
        {
            _aboutDal.Insert(entity);
        }

        public void TUpdate(About entity)
        {
            _aboutDal.Update(entity);
        }
    }
}

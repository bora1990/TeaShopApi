using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApi.DataAccess.Abstract;
using TeaShopApi.DataAccess.Concrete;
using TeaShopApi.DataAccess.Context;
using TeaShopApi.Entity.Concrete;

namespace TeaShopApi.DataAccess.EntityFramework
{
    public class EfSubscribeDal : GenericRepository<Subscribe>, ISubscribeDal
    {
        public EfSubscribeDal(TeaContext context) : base(context)
        {
        }
    }
}

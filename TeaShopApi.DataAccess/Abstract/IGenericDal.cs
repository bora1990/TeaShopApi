using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopApi.DataAccess.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        List<T> GetAllList();

        T GetById(int id);

    }
}

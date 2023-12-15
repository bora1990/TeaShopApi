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
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messagedal;

        public MessageManager(IMessageDal messagedal)
        {
            _messagedal = messagedal;
        }

        public void TDelete(Message entity)
        {
            _messagedal.Delete(entity);
        }

        public List<Message> TGetAllList()
        {
            return _messagedal.GetAllList();
        }

        public Message TGetById(int id)
        {
            return _messagedal.GetById(id);
        }

        public void TInsert(Message entity)
        {
            _messagedal.Insert(entity);
        }

        public void TUpdate(Message entity)
        {
            _messagedal.Update(entity);
        }
    }
}

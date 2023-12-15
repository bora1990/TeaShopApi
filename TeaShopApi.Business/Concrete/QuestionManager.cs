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
    public class QuestionManager : IQuestionService
    {
        private readonly IQuestionDal _questionDal;

        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        public void TDelete(Question entity)
        {
            _questionDal.Delete(entity);
        }

        public List<Question> TGetAllList()
        {
           return _questionDal.GetAllList();
        }

        public Question TGetById(int id)
        {
            return _questionDal.GetById(id);
        }

        public void TInsert(Question entity)
        {
            _questionDal.Insert(entity);
        }

        public void TUpdate(Question entity)
        {
            _questionDal.Update(entity);
        }
    }
}

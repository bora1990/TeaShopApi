using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.Business.Abstract;
using TeaShopApi.Dto.QuestionDtos;
using TeaShopApi.Entity.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;

   
        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        [HttpGet]  //listeleme işlemlerinde kullanılır.
        public IActionResult QuestionList()
        {
            var values = _questionService.TGetAllList();

            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateQuestion(CreateQuestionDtos createQuestionDto)
        {
            Question question = new Question()
            {
                AnswerDetail = createQuestionDto.AnswerDetail,
                QuestionDetail = createQuestionDto.QuestionDetail
            };
            _questionService.TInsert(question);
            return Ok("Soru başarılı bir şekilde eklendi");
        }



        [HttpGet("id")]
        public IActionResult GetQuestion(int id)
        { 
            var values=_questionService.TGetById(id);
            return Ok(values);
          
        }
        [HttpDelete]
        public IActionResult DeleteQuestion(int id)
        {
            var values = _questionService.TGetById(id);
            _questionService.TDelete(values);
            return Ok("Soru başarıyla silindi");

        }

        [HttpPut]
        public IActionResult UpdateQuestion(UpdateQuestionDto updateQuestionDto)
        {
            Question question = new Question()
            {
                AnswerDetail = updateQuestionDto.AnswerDetail,
                QuestionDetail = updateQuestionDto.QuestionDetail,
                QuestionID = updateQuestionDto.QuestionID
            };
            _questionService.TUpdate(question);
            return Ok("Güncelleme yapıldı");

        }



    }
}

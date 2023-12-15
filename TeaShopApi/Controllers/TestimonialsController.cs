using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.Business.Abstract;
using TeaShopApi.DtoLayer.TestimonialSDtos;
using TeaShopApi.Entity.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialsController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
           var values=  _testimonialService.TGetAllList();


            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto) 
        {
            Testimonial value = new Testimonial()
            {
                TestimonialComment=createTestimonialDto.TestimonialComment,
                TestimonialName=createTestimonialDto.TestimonialName,
                TestimonialImageUrl=createTestimonialDto.TestimonialImageUrl


            };

            _testimonialService.TInsert(value);
            return Ok("Referans başarılı bir şekilde eklenmiştir.");    
        }

        [HttpGet("{id}")]

        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);

            return Ok(value);
        }

        [HttpDelete]

        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("İlgili referans silinmiştir");
        }

        [HttpPut]

        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonial)
        {
            Testimonial value = new Testimonial()
            {
                TestimonialComment = updateTestimonial.TestimonialComment,
                TestimonialID = updateTestimonial.TestimonialID,
                TestimonialName = updateTestimonial.TestimonialName,
                TestimonialImageUrl = updateTestimonial.TestimonialImageUrl
            };
            _testimonialService.TUpdate(value);


            return Ok("İlgili referans güncellenmiştir");
        }


    }
}

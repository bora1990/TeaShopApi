using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.Business.Abstract;
using TeaShopApi.DtoLayer.MessageDtos;
using TeaShopApi.Entity.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult GetListMessages()
        {
            var values = _messageService.TGetAllList();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public IActionResult GetMessage(int id) 
        {
            var value=_messageService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            Message message = new Message()
            {
                MessageSenderName = createMessageDto.messageSenderName,
                MessageDetail = createMessageDto.messageDetail,
                MessageEmail = createMessageDto.messageEmail,
                MessageSendDate = createMessageDto.messageSendDate,
                MessageSubject = createMessageDto.messageSubject,


            };

            _messageService.TInsert(message);

            return Ok("Mesajımnız Eklenmiştir");
        }

        [HttpDelete]

        public IActionResult DeleteMessage(int id)
        {
            var message = _messageService.TGetById(id);
            _messageService.TDelete(message);
            return Ok("Mesajımız silinmiştir");
        }

        [HttpPut]

        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            Message message = new Message()
            {
                MessageID = updateMessageDto.MessageID,
                MessageDetail = updateMessageDto.MessageDetail,
                MessageEmail = updateMessageDto.MessageEmail,
                MessageSendDate = updateMessageDto.MessageSendDate,
                MessageSubject = updateMessageDto.MessageSubject,
                MessageSenderName = updateMessageDto.MessageSenderName
            };
            _messageService.TUpdate(message);


            return Ok("Mesajımız Güncellenmiştir.");
        }
    }
}

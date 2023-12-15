namespace TeaShopApi.WebUI.Dtos.MessageDtos
{
    public class CreateMessageDto
    {
            public string messageSenderName { get; set; }
            public string messageSubject { get; set; }
            public string messageEmail { get; set; }
            public string messageDetail { get; set; }
            public DateTime messageSendDate { get; set; }
        
    }
}

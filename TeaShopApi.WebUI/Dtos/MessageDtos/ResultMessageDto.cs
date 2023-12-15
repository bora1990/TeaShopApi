namespace TeaShopApi.WebUI.Dtos.MessageDtos
{
    public class ResultMessageDto
    {
  
            public int messageID { get; set; }
            public string messageSenderName { get; set; }
            public string messageSubject { get; set; }
            public string messageEmail { get; set; }
            public string messageDetail { get; set; }
            public DateTime messageSendDate { get; set; }
        

    }
}

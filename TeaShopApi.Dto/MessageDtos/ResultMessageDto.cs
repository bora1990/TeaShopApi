using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopApi.DtoLayer.MessageDtos
{
    public class ResultMessageDto
    {
        public int MessageID { get; set; }
        public string messageSenderName { get; set; }
        public string messageSubject { get; set; }
        public string messageEmail { get; set; }
        public string messageDetail { get; set; }
        public DateTime messageSendDate { get; set; }
    }
}

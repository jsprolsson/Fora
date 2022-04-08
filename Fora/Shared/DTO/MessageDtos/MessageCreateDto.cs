using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fora.Shared.DTO.MessageDtos
{
    public class MessageCreateDto
    {
        //What is the message
        public string Message { get; set; } = String.Empty;
        //In what thread
        public int ThreadId { get; set; }
        //And what user posted the message
        public int? UserId { get; set; }
    }
}

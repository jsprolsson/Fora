using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fora.Shared.DTO.MessageDtos
{
    public class MessageCreateDto
    {
        //What is the message
        [Required]
        [StringLength(300, ErrorMessage ="Message can't exceed 300 characters.", MinimumLength = 1)]
        public string Message { get; set; } = String.Empty;
        //In what thread
        public int ThreadId { get; set; }
        //And what user posted the message
        public int? UserId { get; set; }
    }
}

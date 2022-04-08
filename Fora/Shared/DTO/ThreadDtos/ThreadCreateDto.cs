using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fora.Shared.DTO.ThreadDtos
{
    public class ThreadCreateDto
    {
        public string Name { get; set; } = String.Empty;
        public int InterestId { get; set; }
        public int? UserId { get; set; }
    }
}

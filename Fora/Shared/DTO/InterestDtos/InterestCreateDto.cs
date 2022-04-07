using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fora.Shared.DTO.InterestDtos
{
    public class InterestCreateDto
    {
        public string Name { get; set; } = String.Empty;
        public int? UserId { get; set; }
    }
}

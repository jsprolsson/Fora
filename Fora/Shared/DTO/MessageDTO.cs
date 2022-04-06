using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fora.Shared.DTO
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string Message { get; set; } = String.Empty;
        public DateTime DateTimeCreated { get; set; }
        public DateTime? DateTimeModified { get; set; } = null;
        public bool Deleted { get; set; }
        public int? UserId { get; set; }
        public int ThreadId { get; set; }

    }
}

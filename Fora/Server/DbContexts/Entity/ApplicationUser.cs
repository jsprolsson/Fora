using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fora.Shared.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public bool Banned { get; set; }
        public bool Deleted { get; set; }
        public DateTime DateTimeCreated { get; set; } = DateTime.Now;
        public DateTime DateTimeModified { get; set; }
    }
}

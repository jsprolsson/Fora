using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fora.Shared
{
    public class MessageModel
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; } = String.Empty;
        public DateTime DateTimeCreated { get; set; } = DateTime.Now;
        public DateTime DateTimeModified { get; set; }
        public bool Deleted { get; set; }


        // Relations
        [ForeignKey(nameof(Thread))]
        public int ThreadId { get; set; }
        [JsonIgnore]
        public ThreadModel Thread { get; set; }

        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
        public UserModel? User { get; set; }
    }
}

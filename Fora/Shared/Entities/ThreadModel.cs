using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fora.Shared
{
    public class ThreadModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public List<MessageModel> Messages { get; set; }
        public DateTime DateTimeCreated { get; set; } = DateTime.Now;
        public DateTime DateTimeModified { get; set; }

        // Relations
        [ForeignKey(nameof(Interest))]
        public int InterestId { get; set; }
        [JsonIgnore]
        public InterestModel Interest { get; set; }
        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
        public UserModel? User { get; set; }

    }
}

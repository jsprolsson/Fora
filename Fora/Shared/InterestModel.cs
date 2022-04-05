using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fora.Shared
{
    public class InterestModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public List<ThreadModel> Threads { get; set; }

        // Relations
        public List<UserInterestModel> UserInterests { get; set; }

        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
        public UserModel? User { get; set; }
    }
}

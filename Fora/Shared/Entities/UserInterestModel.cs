using System.Text.Json.Serialization;

namespace Fora.Shared
{
    public class UserInterestModel
    {
        public int UserId { get; set; }
        [JsonIgnore]
        public UserModel User { get; set; }
        public int InterestId { get; set; }
        public InterestModel Interest { get; set; }
    }
}

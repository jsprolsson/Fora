﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fora.Shared
{
    public class InterestModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public List<ThreadModel> Threads { get; set; }
        public DateTime DateTimeCreated { get; set; } = DateTime.Now;
        public DateTime DateTimeModified { get; set; }

        // Relations
        [JsonIgnore]
        public List<UserInterestModel> UserInterests { get; set; }

        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
        public UserModel? User { get; set; }
    }
}

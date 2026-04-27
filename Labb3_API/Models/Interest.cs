using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Labb3_API.Models
{
    public class Interest
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<InterestPerson> InterestPersons { get; set; } = [];
    }
}

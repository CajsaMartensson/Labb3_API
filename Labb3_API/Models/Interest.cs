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

        //nav prop
        [JsonIgnore]
        public ICollection<Link> Links { get; set; } = null!;

        [JsonIgnore]
        public ICollection<Person> Persons { get; set; } = null!;
    }
}

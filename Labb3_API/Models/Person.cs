using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Labb3_API.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        //nav prop


        //public ICollection<Interest> Interests { get; set; } = null!;
        [JsonIgnore]
        public ICollection<InterestPerson> InterestPersons { get; set; } = [];
    }
}

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Labb3_API.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public int InterestPersonId { get; set; }

        //Nav prop
        [JsonIgnore]
        public InterestPerson InterestPerson { get; set; } = null!;
    }
}

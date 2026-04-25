using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Labb3_API.Models
{
    public class Link
    {
        public int Id { get; set; }
        //personliga länkar men dem är sorterade efter intresse.
        //intresse filmer -- koppla till en person.
        //länkarna är unika för varje person, men kopplade till ett intresse (personer kan ha samma interest

        //[Required]
        public string Url { get; set; } = string.Empty;
        public int PersonId { get; set; }
        public int InterestId { get; set; }

        //Nav prop
        [JsonIgnore]
        public Person Person { get; set; } = null!;
        [JsonIgnore]
        public Interest Interest { get; set; } = null!;
    }
}

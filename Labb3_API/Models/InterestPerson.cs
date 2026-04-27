namespace Labb3_API.Models
{
    public class InterestPerson
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int InterestId { get; set; }

        public Person Person { get; set; }
        public Interest Interest { get; set; }

        public ICollection<Link> Links { get; set; } = [];
    }
}

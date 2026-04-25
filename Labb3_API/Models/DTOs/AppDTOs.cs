namespace Labb3_API.Models.DTOs
{
    public record GetPersonResponse(int Id, string Name, string Phone);
    //public record GetInterestResponse(int Id, string Title);

    
    public record AddInterestToPersonRequst (int PersonId, int InterestId);

    public record UpdateLink(string Url);
}
